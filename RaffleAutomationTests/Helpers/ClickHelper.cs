using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
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
            }
            catch (Exception) { }

        }

        public static void ClickJS(IWebElement element)
        {
            WaitUntil.CustomElementIsVisible(element, 10);
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
            WebDriverWait wait = new(Browser._Driver, TimeSpan.FromSeconds(30))
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
            public IWebElement btnEdit { get; set;}
            public IWebElement btnDelete { get; set;}
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


    }
}
