using RestSharp;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using RaffleAutomationTests.PageObjects;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading;
using static RaffleAutomationTests.APIHelpers.Web.Subscriptions.SubsriptionsResponse;
using System.Net.Http;

namespace RaffleAutomationTests.Helpers
{
    public class Button
    {
        public static void Click(IWebElement element)
        {
            WaitUntil.CustomElementIsVisible(element);
            element.Click();
            
        }

        public static void ClickJS(IWebElement element)
        {
            WaitUntil.WaitSomeInterval();
            IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser.Driver;
            ex.ExecuteScript("arguments[0].click();", element);
        }

        public static void ClickCountryJS(IWebElement element)
        {
            var elem = Browser.Driver.FindElement(By.XPath($"//ul[@role='listbox']/li[contains(text(),'{Country.COUNTRY_CODES[RandomHelper.RandomFPId(Country.COUNTRY_CODES)]}')]"));
            WaitUntil.CustomElementIsVisible(element, 10);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser.Driver;
            ex.ExecuteScript("arguments[0].click();", elem);
        }


    }
    public class InputBox
    {
        public static IWebElement Element(IWebElement element, int seconds, string data)
        {
           
            WaitUntil.CustomElementIsVisible(element, seconds);
            element.SendKeys(Keyss.Control() + "A" + Keys.Delete);
            WaitUntil.WaitSomeInterval(150);
            element.SendKeys(data);
            WaitUntil.WaitSomeInterval(350);

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
            WebDriverWait wait = new(Browser.Driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            try
            {
                wait.Until(e =>
                {
                    try { return Browser.Driver.FindElement(By.XPath($"//tbody/tr/td[text()='{titleDreamhome}']")).Enabled; }
                    catch (NoSuchElementException) { return false; }
                    catch (StaleElementReferenceException) { return false; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }

            var _element = Browser.Driver.FindElement(By.XPath($"//tbody/tr/td[text()='{titleDreamhome}']"));


            return _element;
        }

        public static UserRowModel FindSpecificUser(string email)
        {
            WebDriverWait wait = new(Browser.Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            try
            {
                wait.Until(e =>
                {
                    try { return Browser.Driver.FindElement(By.XPath($"//td[text()='{email}']")).Enabled; }
                    catch (NoSuchElementException) { return false; }
                    catch (StaleElementReferenceException) { return false; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }

            UserRowModel user = new()
            {
                Name = Browser.Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr/td[1]")).Text,
                Surname = Browser.Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr/td[2]")).Text,
                Email = Browser.Driver.FindElement(By.XPath($"//td[text()='{email}']")).Text,
                Phone = Browser.Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr/td[4]")).Text,
                toggleStatus = Browser.Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Show']")),
                btnShow = Browser.Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Show']")),
                btnEdit = Browser.Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Edit']")),
                btnDelete = Browser.Driver.FindElement(By.XPath($"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/div"))
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
            WebDriverWait wait = new(Browser.Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            try
            {
                wait.Until(e =>
                {
                    try { return Browser.Driver.FindElement(By.XPath($"//td[text()='{competition}']")).Enabled; }
                    catch (NoSuchElementException) { return false; }
                    catch (StaleElementReferenceException) { return false; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }

            foreach (var item in Browser.Driver.FindElements(By.XPath($"//td[text()='{competition}']/parent::tbody")))
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
            WaitUntil.WaitSomeInterval(700);
            Actions actions = new(Browser.Driver);
            actions.SendKeys(key);
            actions.Perform();
            WaitUntil.WaitSomeInterval(700);
        }

        public static void Action(string key, IWebElement element)
        {
            Actions actions = new(Browser.Driver);
            element.SendKeys(key);
            actions.Perform();
            WaitUntil.WaitSomeInterval(700);
        }
    }

    public class PutsBox
    {
        private static string ClearHistory(string email)
        {
            string arg = email.Substring(0, email.IndexOf('@'));
            return $"https://putsbox.com/{arg}/clear";
        }
        private static string GetHtmlUrl(string email)
        {
            string arg = email.Substring(0, email.IndexOf('@'));
            return $"https://preview.putsbox.com/p/{arg}/last.html";
        }
        private static string GetHtmlUrl(string email, string id)
        {
            string arg = email.Substring(0, email.IndexOf('@'));
            return $"https://preview.putsbox.com/p/{arg}/{id}.html";
        }
        private static string GetHtmlUrlToInspect(string email)
        {
            string arg = email.Substring(0, email.IndexOf('@'));
            return $"https://putsbox.com/{arg}/inspect";
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
            return client.ExecuteGetAsync(request).Result.Content ?? throw new Exception("Content is null.");
        }

        private static string GetHtmlContent(string email)
        {
            RestClient client = new RestClient(GetHtmlUrl(email));
            RestRequest request = new RestRequest("");
            return client.ExecuteGetAsync(request).Result.Content ?? throw new Exception("Content is null.");
        }

        private static string GetHtmlContent(string email, string id)
        {
            RestClient client = new RestClient(GetHtmlUrl(email, id));
            RestRequest request = new RestRequest("");
            return client.ExecuteGetAsync(request).Result.Content ?? throw new Exception("Content is null.");
        }

        private static string GetEmailContent(string email)
        {
            RestClient client = new RestClient(GetHtmlUrlToInspect(email));
            RestRequest request = new RestRequest("");
            return client.ExecuteGetAsync(request).Result.Content ?? throw new Exception("Content is null.");
        }

        private static void ClearRequest(string email)
        {
            Browser.Driver.Navigate().GoToUrl(GetHtmlUrlToInspect(email));
            WaitUntil.CustomElementIsVisible(Pages.Putsbox.inputEmail);
            Button.Click(Pages.Putsbox.btnClearHistory);
            Elements.Alerts.AcceptAlert();
            WaitUntil.CustomElementIsVisible(Pages.Putsbox.textNumberOfEmails);
            Assert.AreEqual(0, int.Parse(Pages.Putsbox.textNumberOfEmails.Text));
        }

        public static string GetLinkFromEmailWithValue(string domain, string value)
        {
            Thread.Sleep(2000);
            string jsonContent = GetJsonContent(domain);
            if (jsonContent.Contains("Not Found"))
            {
                Thread.Sleep(2000);
                jsonContent = GetJsonContent(domain);
            }

            string text = Decode(jsonContent);
            GetBodyData(text);
            return ParseAllLinks(text).Link.First((PutsboxWrapper.Link x) => x.Name == value).Url ?? throw new Exception("URL is null.");
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

        public static string GetHtmlFromEmail(string domain, string id)
        {
            Thread.Sleep(2000);
            string htmlContent = GetHtmlContent(domain, id);
            if (htmlContent.Contains("Not Found"))
            {
                Thread.Sleep(2000);
                htmlContent = GetHtmlContent(domain, id);
            }

            string text = Decode(htmlContent);
            return text;
        }

        public static void GetAllEmails(string domain, out List<PutsboxEmail>? emailList)
        {
            Thread.Sleep(2000);
            var htmlContent = GetEmailContent(domain);
            emailList = JsonConvert.DeserializeObject<List<PutsboxEmail>?>(htmlContent);
            if (htmlContent.Contains("Not Found"))
            {
                Thread.Sleep(2000);
                htmlContent = GetEmailContent(domain);
            }
        }

        public static void ClearEmailHistory(string domain)
        {
            Thread.Sleep(2000);
            ClearRequest(domain);
            
        }


    }

    public class Xitroo
    {
        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'qatester')]")]
        public IWebElement nameTab;

        [FindsBy(How = How.XPath, Using = "//tbody//td[1]")]
        public IWebElement nameEmailSubject;


    }

    public class Elements
    {
        public static void Click(IWebElement element)
        {
            WaitUntil.CustomElementIsVisible(element);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser.Driver;
            ex.ExecuteScript("arguments[0].click();", element);

        }

        public static void EnterText(IWebElement element, string text)
        {
            WaitUntil.CustomElementIsVisible(element);
            element.SendKeys(Keys.Control + "A" + Keys.Delete);
            element.SendKeys(text);
        }

        public static string GetAttribute(IWebElement element, string attribute)
        {
            WaitUntil.CustomElementIsVisible(element);
            return element.GetAttribute(attribute);
        }

        public static void ScrollTo(int xPosition, int yPosition)
        {
            try
            {
                IJavaScriptExecutor jsi = (IJavaScriptExecutor)Browser.Driver;
                jsi.ExecuteScript("window.scrollTo({0}, {1})", xPosition, yPosition);
            }
            catch (Exception) { }
        }

        [AllureStep("Go to activation link")]
        public static void GoToActivationLink(string email)
        {
            var activateLink = PutsBox.GetLinkFromEmailWithValue(email, "Activate account");
            Browser.Navigate(activateLink);
        }

        [AllureStep("Go to activation link")]
        public static void GgetHtmlBody(string email, out string emailInitial)
        {
            emailInitial = PutsBox.GetHtmlFromEmail(email);
        }

        //[AllureStep("Go to activation link")]
        public static void GgetHtmlBody(string email, string id, out string emailInitial)
        {
            emailInitial = PutsBox.GetHtmlFromEmail(email, id);
        }

        //[AllureStep("Go to activation link")]
        public static void GgetAllEmailData(string email, out List<PutsboxEmail>? emailList)
        {
            PutsBox.GetAllEmails(email, out emailList);
            SubscriptionsRequest.CheckEmailsCountFor35Minutes(emailList, email);
            PutsBox.GetAllEmails(email, out emailList);
        }

        [AllureStep("Clear email history")]
        public static void ClearEmailHistory(string email)
        {
            PutsBox.ClearEmailHistory(email);

        }

        public class Alerts
        {
            public static void AcceptAlert()
            {
                Thread.Sleep(1000);
                IAlert alert = Browser.Driver.SwitchTo().Alert();
                alert.Accept();
                Browser.Driver.SwitchTo().DefaultContent();
            }

            public static void DismissAlert()
            {
                Thread.Sleep(1000);
                IAlert alert = Browser.Driver.SwitchTo().Alert();
                alert.Dismiss();
                Browser.Driver.SwitchTo().DefaultContent();
            }
        }
    }
}
