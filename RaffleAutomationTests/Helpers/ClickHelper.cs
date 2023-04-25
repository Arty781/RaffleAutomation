using RestSharp;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using RaffleAutomationTests.PageObjects;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading;

namespace RaffleAutomationTests.Helpers
{
    public class Button
    {
        public static void Click(IWebElement element)
        {
            WaitUntil.WaitSomeInterval(300);
            WebDriverWait wait = new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50)
            };
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element != null && element.Enabled)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception) { return false; }

                });
                element.Click();
                WaitUntil.WaitSomeInterval(350);
            }
            catch (Exception) { }

        }

        public static void ClickJS(IWebElement element)
        {
            WaitUntil.WaitSomeInterval();
            IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser._Driver;
            ex.ExecuteScript("arguments[0].click();", element);
        }

        public static void ClickCountryJS(IWebElement element)
        {
            var elem = Browser._Driver.FindElement(By.XPath($"//ul[@role='listbox']/li[contains(text(),'{Country.COUNTRY_CODES[RandomHelper.RandomFPId(Country.COUNTRY_CODES)]}')]"));
            WaitUntil.CustomElementIsVisible(element, 10);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser._Driver;
            ex.ExecuteScript("arguments[0].click();", elem);
        }


    }
    public class InputBox
    {
        public static IWebElement Element(IWebElement element, int seconds, string data)
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(element, seconds);
            element.SendKeys(Keyss.Control() + "A" + Keys.Delete);
            WaitUntil.WaitSomeInterval(250);
            element.SendKeys(data);

            return element;
        }

        public static IWebElement ElementImage(IWebElement element, int seconds, string data)
        {
            WaitUntil.CustomElementIsVisible(element, seconds);
            WaitUntil.WaitSomeInterval(250);
            element.SendKeys(data);

            return element;
        }

        public static IWebElement CbbxElement(IWebElement element, int seconds, string data)
        {

            WaitUntil.CustomElementIsVisible(element, seconds);
            element.SendKeys(data + Keys.Enter);

            return element;
        }


    }

    public class TextBox
    {
        public static string GetText(IWebElement element)
        {
            WaitUntil.CustomElementIsVisible(element);
            return element.Text;
        }

        public static string GetAttribute(IWebElement element, string attribute)
        {
            WaitUntil.CustomElementIsVisible(element);
            return element.GetAttribute(attribute);

        }
    }

    public class Element
    {
        public static IWebElement FindSpecificDreamhome(string titleDreamhome)
        {
            WebDriverWait wait = new(Browser._Driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            try
            {
                wait.Until(e =>
                {
                    try { return Browser._Driver.FindElement(By.XPath($"//tbody/tr/td[text()='{titleDreamhome}']")).Enabled; }
                    catch (NoSuchElementException) { return false; }
                    catch (StaleElementReferenceException) { return false; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }

            var _element = Browser._Driver.FindElement(By.XPath($"//tbody/tr/td[text()='{titleDreamhome}']"));


            return _element;
        }

        public static UserRowModel FindSpecificUser(string email)
        {
            WebDriverWait wait = new(Browser._Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            try
            {
                wait.Until(e =>
                {
                    try { return Browser._Driver.FindElement(By.XPath($"//td[text()='{email}']")).Enabled; }
                    catch (NoSuchElementException) { return false; }
                    catch (StaleElementReferenceException) { return false; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }

            UserRowModel user = new()
            {
                Name = Browser._Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr/td[1]")).Text,
                Surname = Browser._Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr/td[2]")).Text,
                Email = Browser._Driver.FindElement(By.XPath($"//td[text()='{email}']")).Text,
                Phone = Browser._Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr/td[4]")).Text,
                toggleStatus = Browser._Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Show']")),
                btnShow = Browser._Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Show']")),
                btnEdit = Browser._Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Edit']")),
                btnDelete = Browser._Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/div"))
            };

            return user;
        }

        public class UserRowModel
        {
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public IWebElement toggleStatus { get; set; }
            public IWebElement btnShow { get; set; }
            public IWebElement btnEdit { get; set; }
            public IWebElement btnDelete { get; set; }
        }

        public static List<CompetitionRowModel> FindSpecificCompetitionRows(string competition)
        {
            List<CompetitionRowModel> listOfCompetitions = new();
            WaitUntil.CustomElevemtIsInvisible(Pages.CmsUserManagement.textNoOrders);
            WebDriverWait wait = new(Browser._Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            try
            {
                wait.Until(e =>
                {
                    try { return Browser._Driver.FindElement(By.XPath($"//td[text()='{competition}']")).Enabled; }
                    catch (NoSuchElementException) { return false; }
                    catch (StaleElementReferenceException) { return false; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }

            foreach (var item in Browser._Driver.FindElements(By.XPath($"//td[text()='{competition}']/parent::tbody")))
            {
                CompetitionRowModel competitionRow = new();
                competitionRow.Competition = item.FindElement(By.XPath($".//td[1]")).Text;
                competitionRow.Product = item.FindElement(By.XPath($".//td[2]")).Text;
                competitionRow.NumberOfTickets = item.FindElement(By.XPath($".//td[3]")).Text;
                competitionRow.DrawDate = item.FindElement(By.XPath($".//td[4]")).Text;
                competitionRow.btnShowtickets = item.FindElement(By.XPath($".//td[5]/div/*[1]"));
                competitionRow.btnEditTickets = item.FindElement(By.XPath($".//td[5]/div/*[2]"));
                competitionRow.btnDeleteTickets = item.FindElement(By.XPath($".//td[5]/div/*[3]/*"));
                listOfCompetitions.Add(competitionRow);
            }

            return listOfCompetitions;
        }

        public class CompetitionRowModel
        {
            public string Competition { get; set; }
            public string Product { get; set; }
            public string NumberOfTickets { get; set; }
            public string DrawDate { get; set; }
            public IWebElement btnShowtickets { get; set; }
            public IWebElement btnEditTickets { get; set; }
            public IWebElement btnDeleteTickets { get; set; }
        }

        public static void Action(string key)
        {
            Actions actions = new(Browser._Driver);
            actions.SendKeys(key);
            actions.Perform();
            WaitUntil.WaitSomeInterval(700);
        }
    }

    public class PutsBox
    {
        private static string ClearHistory(string email)
        {
            string arg = email.Substring(0, email.IndexOf('@'));
            return $"https://preview.putsbox.com/p/{arg}/last.html";
        }
        private static string GetHtmlUrl(string email)
        {
            string arg = email.Substring(0, email.IndexOf('@'));
            return $"https://preview.putsbox.com/p/{arg}/last.html";
        }
        private static string GetJsonUrl(string email)
        {
            string arg = email.Substring(0, email.IndexOf('@'));
            return $"https://preview.putsbox.com/p/{arg}/last.json";
        }

        private static string GetBodyData(string value)
        {
            int startIndex = value.IndexOf("body");
            return value.Substring(startIndex);
        }

        private static string Decode(string rawData)
        {
            return Regex.Unescape(rawData);
        }

        private static PutsboxWrapper.Email ParseAllLinks(string rawData)
        {
            PutsboxWrapper.Email email = new PutsboxWrapper.Email();
            Collection<PutsboxWrapper.Link> collection = new Collection<PutsboxWrapper.Link>();
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(rawData);
            foreach (HtmlNode item in htmlDocument.DocumentNode.QuerySelectorAll("a"))
            {
                collection.Add(new PutsboxWrapper.Link
                {
                    Name = item.InnerText,
                    Url = item.GetAttributeValue("href", null)
                });
            }

            email.Link = collection;
            return email;
        }

        private static string ParseAllText(string rawData)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(rawData);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (HtmlNode item in htmlDocument.DocumentNode.QuerySelectorAll("p"))
            {
                sb.AppendLine(item.InnerText);
            }

            return sb.ToString();
        }

        private static string GetJsonContent(string email)
        {
            RestClient client = new RestClient(GetJsonUrl(email));
            RestRequest request = new RestRequest("");
            return client.ExecuteGetAsync(request).Result.Content;
        }

        private static string GetHtmlContent(string email)
        {
            RestClient client = new RestClient(GetHtmlUrl(email));
            RestRequest request = new RestRequest("");
            return client.ExecuteGetAsync(request).Result.Content;
        }

        private static void ClearRequest(string email)
        {
            RestClient client = new RestClient(ClearHistory(email));
            RestRequest request = new RestRequest("");
        }

        public static string GetLinkFromEmailWithValue(string domain, string value)
        {
            string value2 = value;
            Thread.Sleep(2000);
            string jsonContent = GetJsonContent(domain);
            if (jsonContent.Contains("Not Found"))
            {
                Thread.Sleep(2000);
                jsonContent = GetJsonContent(domain);
            }

            string text = Decode(jsonContent);
            GetBodyData(text);
            return ParseAllLinks(text).Link.First((PutsboxWrapper.Link x) => x.Name == value2).Url;
        }

        public static string GetTextFromEmailWithValue(string domain, string value)
        {
            string value2 = value;
            Thread.Sleep(2000);
            string jsonContent = GetJsonContent(domain);
            if (jsonContent.Contains("Not Found"))
            {
                Thread.Sleep(2000);
                jsonContent = GetJsonContent(domain);
            }

            string text = Decode(jsonContent);
            GetBodyData(text);
            string[] texts = ParseAllText(text)
                .Split(Environment.NewLine)
                .Where(x => x.Contains(value2))
                .ToArray();
            return ParseAllText(text).Split(Environment.NewLine).Where(x => x.Contains(value2)).FirstOrDefault().Replace($"{value2}", "");
        }

        public static string GetHtmlFromEmail(string domain)
        {
            Thread.Sleep(2000);
            string htmlContent = GetHtmlContent(domain);
            if (htmlContent.Contains("Not Found"))
            {
                Thread.Sleep(2000);
                htmlContent = GetHtmlContent(domain);
            }

            string text = Decode(htmlContent);
            return text;
        }

        public static void ClearEmailHistory(string domain)
        {
            Thread.Sleep(2000);
            ClearRequest(domain);
        }


    }
}
