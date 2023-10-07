using Fizzler;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Microsoft.Playwright;
using Newtonsoft.Json;
using PlaywrightAutomation;
using PlaywrightAutomation.Pages.CMS.UserManagementPage;
using PlaywrightAutomation.Pages.WEB.ActivateUserPage;
using RaffleAutomationTests.APIHelpers.Web.Subscriptions;
using RequestModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlaywrightAutomation
{
    public class Credentials
    {
        public const string ADMIN_LOGIN = "bennospencer@gmail.com";
        public const string ADMIN_PASSWORD = "1289Raffle@!CMS";

        public const string USER_LOGIN = "qatester91311@gmail.com";
        public const string USER_PASSWORD = "Qaz11111";
        public const string NEW_PASWORD = "Qaz11111!";
    }

    public class Endpoints
    {
        public const string loginPage = "https://admin-staging.rafflehouse.com/#/login";
        public const string dreamhomePage = "https://admin-staging.rafflehouse.com/#/dreamHome";

        public class Admin
        {
            public const string ADMIN_HOST = "https://admin-staging.rafflehouse.com";
            public const string DREAMHOME_PRIZES = "https://admin-staging.rafflehouse.com/#/dreamHome";
            public const string LIFESTYLE_PRIZES = "https://admin-staging.rafflehouse.com/#/prizes";
            public const string FIXEDODDS_PRIZES = "https://admin-staging.rafflehouse.com/#/fixedOdds";
            public const string USER_MANAGEMENT = "https://admin-staging.rafflehouse.com/#/users";
            public const string STAFF_MANAGEMENT = "https://admin-staging.rafflehouse.com/#/staffUsers";
            public const string SETTINGS_GENERAL = "https://admin-staging.rafflehouse.com/#/general";
            public const string SETTING_WINNERS = "https://admin-staging.rafflehouse.com/#/winners";
            public const string SETTINGS_REFERRALS = "https://admin-staging.rafflehouse.com/#/referrals";
            public const string COMPETITIONS = "https://admin-staging.rafflehouse.com/#/competitions";
        }

        public class Web
        {
            public const string WEBSITE_HOST = "https://staging.rafflehouse.com";
            public const string SIGN_IN = "https://staging.rafflehouse.com/sign-in";
            public const string SIGN_UP = "https://staging.rafflehouse.com/sign-up";
            public const string DREAMHOME = "https://staging.rafflehouse.com/dreamhome";
            public const string LIFESTYLE = "https://staging.rafflehouse.com/lifestyleprizes";
            public const string FIXEDODDS = "https://staging.rafflehouse.com/fixedodds";
            public const string WINNERS = "https://staging.rafflehouse.com/winners";
            public const string ABOUT = "https://staging.rafflehouse.com/about-us";
            public const string PROFILE = "https://staging.rafflehouse.com/profile";
            public const string FREE_ENTRY = "https://staging.rafflehouse.com/post";
            public const string BASKET = "https://staging.rafflehouse.com/basket";
            public const string PAGE_DISCOUNT = "https://pagediscount-staging.rafflehouse.com/";
            public const string WIN_RAFFLE = "https://win-staging.rafflehouse.com/";
        }
    }
    
    public class Helpers
    {
        public static async Task GoToPage(string url, string waitSelector)
        {
            await Browser.Driver.GotoAsync(url);
            await Browser.Driver.WaitForSelectorAsync(waitSelector);
        } 

        public class TextBox
        {
            public static async Task<string> GetText(string selector)
            {
                await WaitUntil.ElementIsVisible(selector);
                return Browser.Driver.QuerySelectorAsync(selector).Result.TextContentAsync().Result ?? throw new Exception("Element is null");
            }

            public static async Task<string> GetTextForList(string selector, int index)
            {
                await WaitUntil.ElementIsVisible(selector);
                return (await Browser.Driver.QuerySelectorAllAsync(selector))[index].TextContentAsync().Result ?? throw new Exception("Element is null");
            }

            public static async Task<string> GetAttribute(string selector, string attribute)
            {
                await WaitUntil.ElementIsVisible(selector);
                return Browser.Driver.QuerySelectorAsync(selector).Result.GetAttributeAsync(attribute).Result ?? throw new Exception("Element is null");
            }
        }

        public class InputBox
        {
            public static async Task TypeText(string selector, string text)
            {
                await WaitUntil.ElementIsVisible(selector);
                await Browser.Driver.FocusAsync(selector);
                await Browser.Driver.Keyboard.PressAsync("Control+A");
                await Browser.Driver.Keyboard.PressAsync("Backspace");
                await Browser.Driver.QuerySelectorAsync(selector).Result.FillAsync(text);
            }

            public static async Task AddImages(string selector, string text)
            {
                await WaitUntil.ElementIsVisible(selector);
                await Browser.Driver.QuerySelectorAsync(selector).Result.TypeAsync(text);
            }

            public static async Task SelectCbbx(string selector, string data)
            {
                await WaitUntil.ElementIsVisible(selector);
                await Browser.Driver.QuerySelectorAsync(selector).Result.TypeAsync(data + Browser.Driver.Keyboard.PressAsync("Enter"));
            }
        }

        public class Button
        {
            public static async Task Click(string selector)
            {
                await WaitUntil.ElementIsVisible(selector);
                await Browser.Driver.QuerySelectorAsync(selector).Result.ScrollIntoViewIfNeededAsync();
                await Browser.Driver.QuerySelectorAsync(selector).Result.ClickAsync();
            }

            public static async Task DoubleClick(string selector)
            {
                await WaitUntil.ElementIsVisible(selector);
                await Browser.Driver.QuerySelectorAsync(selector).Result.DblClickAsync();
            }

            public static async Task ClickOnNthElement(string selector, int nthNum)
            {
                await WaitUntil.ElementIsVisible(selector);
                await Browser.Driver.QuerySelectorAllAsync(selector).Result[nthNum].ClickAsync();
            }

            static async Task<string> GetSelectorFromElement(IElementHandle element)
            {
                return await element.EvaluateAsync<string>(@"(element) => {
                function getPathTo(element) {
                if (element === document.body) return 'body';
                const nodeName = element.nodeName.toLowerCase();
                if (element.id) return `#${element.id}`;
                const parent = element.parentNode;
                if (!parent) return nodeName;
                const sameTagSiblings = Array.from(parent.children).filter(e => e.nodeName.toLowerCase() === nodeName);
                if (sameTagSiblings.length === 1) return getPathTo(parent) + ' > ' + nodeName;
                const index = Array.from(sameTagSiblings).indexOf(element) + 1;
                return getPathTo(parent) + ' > ' + `${nodeName}:nth-child(${index})`;
                    }
                    return getPathTo(element);
                }");
            }
        }

        public class Element
        {
            public static async Task Action(string key)
            {
                await Browser.Driver.WaitForTimeoutAsync(700);
                await Browser.Driver.Keyboard.PressAsync(key);
                await Browser.Driver.WaitForTimeoutAsync(300);
            }
        }

        public class WaitUntil
        {
            public static async Task Timeout(float timeout = 3000)
            {
                await Browser.Driver.WaitForTimeoutAsync(timeout);
            }

            public static async Task ElementIsVisible(string selector, float milliseconds = 30000)
            {
                Thread.Sleep(250);
                var waitForSelectorOptions = new PageWaitForSelectorOptions { Timeout = milliseconds, State = WaitForSelectorState.Attached };
                await Browser.Driver.WaitForSelectorAsync(selector, waitForSelectorOptions);
            }

            public static async Task FrameIsVisible(string selector, float milliseconds = 30000)
            {
                Thread.Sleep(250);
                var frame = Browser.Driver.QuerySelectorAsync(selector).Result.ContentFrameAsync().Result;
                var waitForSelectorOptions = new FrameWaitForSelectorOptions { Timeout = milliseconds, State = WaitForSelectorState.Attached };
                await frame.WaitForSelectorAsync(selector, waitForSelectorOptions);
            }

            public static async Task ElementListIsVisible(string selector, float milliseconds = 30000)
            {
                Thread.Sleep(250);
                var jsCode = string.Concat(
                "async () => {" +
                "const elements = document.querySelectorAll('" + selector + "');" +
                "const allVisible = Array.from(elements).every(element => element.offsetWidth > 0 && element.offsetHeight > 0);" +
                "return allVisible;" +
                "}");
                var waitForSelectorOptions = new PageWaitForFunctionOptions { Timeout = milliseconds, PollingInterval = 50 };
                await Browser.Driver.WaitForFunctionAsync(jsCode, waitForSelectorOptions);
            }

            public static async Task ElementIsInvisible(string selector, float milliseconds = 10000)
            {
                Thread.Sleep(250);
                var waitForSelectorOptions = new PageWaitForSelectorOptions { Timeout = milliseconds, State = WaitForSelectorState.Detached };
                await Browser.Driver.WaitForSelectorAsync(selector, waitForSelectorOptions);
            }

            public static async Task FrameIsInvisible(string selector, float milliseconds = 10000)
            {
                Thread.Sleep(250);
                var frame = Browser.Driver.QuerySelectorAsync(selector).Result.ContentFrameAsync().Result;
                var waitForSelectorOptions = new FrameWaitForSelectorOptions { Timeout = milliseconds, State = WaitForSelectorState.Detached };
                await frame.WaitForSelectorAsync(selector, waitForSelectorOptions);
            }

            public static async Task CustomCheckoutIsDisplayed(float milliseconds = 10000)
            {
                Thread.Sleep(250);
                var waitForSelectorOptions = new PageWaitForURLOptions { Timeout = milliseconds };
                await Browser.Driver.WaitForURLAsync(url => url.Contains("pending?cko-session-id") || url.Contains("pending?paypal"), waitForSelectorOptions);
            }
        }

        public class DropdownList
        {
            public static async Task SelectDropdownItemByText(string selector, string text)
            {
                await WaitUntil.ElementIsVisible(selector);
                var element = (await Browser.Driver.QuerySelectorAllAsync(selector)).Where(x => x.TextContentAsync().Result == text)
                                  .Select(x => x).First().ClickAsync();
            }

        }
    }
    
    public partial class RandomHelper
    {
        public static string RandomNumber()
        {
            Random r = new Random();
            int genRand = r.Next(3, 20);
            string randomNum = string.Empty;

            randomNum = genRand switch
            {
                _ => genRand.ToString(),// Handle other numbers
            };
            if (genRand == 6)
            {
                RandomNumber();
            }
            return randomNum;
        }

        public static int RandomIntNumber(int maxNum)
        {
            Random r = new();
            int genRand = r.Next(1, maxNum);

            return genRand;
        }

        public static int RandomCharityNumber(int maxNum)
        {
            Random r = new Random();
            int genRand = r.Next(3, maxNum);

            return genRand;
        }

        //public static int RandomWPId(WeeklyPrizesResponseModelWeb content)
        //{
        //    Random r = new Random();
        //    int genRand = r.Next(0, content.Prizes.Count());

        //    return genRand;
        //}

        public static int RandomFPId(List<string> content)
        {
            Random r = new();
            int genRand = r.Next(0, content.Count());

            return genRand;
        }


        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomPhone()
        {
            Random random = new Random();
            const string firstChar = "123456789";  // Allowed characters for the first digit
            const string chars = "0123456789";     // Allowed characters for the rest of the digits

            // Generate the first digit
            string firstDigit = firstChar[random.Next(firstChar.Length)].ToString();

            // Generate the rest of the digits
            string restOfDigits = new(Enumerable.Repeat(chars, 9)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return firstDigit + restOfDigits;
        }

        public static string RandomPhone(int charNum)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, charNum)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }




    }

    public class SpecificSearch
    {
        public static async Task<IElementHandle> FindSpecificDreamhome(string titleDreamhome)
        {

            await Helpers.WaitUntil.ElementIsVisible($"//tbody/tr/td[text()='{titleDreamhome}']");
            return await Browser.Driver.QuerySelectorAsync($"//tbody/tr/td[text()='{titleDreamhome}']") ?? throw new Exception("Dreamhome is not find");

        }

        public static async Task<UserRowModel> FindSpecificUser(string email)
        {
            await Helpers.WaitUntil.ElementIsVisible($"//td[text()='{email}']");

            UserRowModel user = new()
            {
                Name = await Browser.Driver.QuerySelectorAsync($"//td[text()='{email}']/parent::tr/td[1]").Result.TextContentAsync(),
                Surname = await Browser.Driver.QuerySelectorAsync($"//td[text()='{email}']/parent::tr/td[2]").Result.TextContentAsync(),
                Email = await Browser.Driver.QuerySelectorAsync($"//td[text()='{email}']").Result.TextContentAsync(),
                Phone = await Browser.Driver.QuerySelectorAsync($"//td[text()='{email}']/parent::tr/td[4]").Result.TextContentAsync(),
                toggleStatus = $"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Show']",
                btnShow = $"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Show']",
                btnEdit = $"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Edit']",
                btnDelete = $"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/div"
            };

            return user;
        }



        public static async Task<List<CompetitionRowModel>> FindSpecificCompetitionRows(string competition)
        {
            await Helpers.WaitUntil.ElementIsInvisible(UserManagement.textNoOrders);
            await Helpers.WaitUntil.ElementIsVisible($"//td[text()='{competition}']");

            var competitionRowElements = await Browser.Driver.QuerySelectorAllAsync($"//td[text()='{competition}']/parent::tbody");
            var listOfCompetitions = new List<RequestModels.CompetitionRowModel>();

            foreach (var item in competitionRowElements)
            {
                var competitionRow = new RequestModels.CompetitionRowModel
                {
                    Competition = await GetTextContent(item, ".//td[1]"),
                    Product = await GetTextContent(item, ".//td[2]"),
                    NumberOfTickets = await GetTextContent(item, ".//td[3]"),
                    DrawDate = await GetTextContent(item, ".//td[4]"),
                    btnShowtickets = new Locator(".//td[5]/div/*[1]").Selector,
                    btnEditTickets = new Locator(".//td[5]/div/*[2]").Selector,
                    btnDeleteTickets = new Locator(".//td[5]/div/*[3]/*").Selector
                };

                listOfCompetitions.Add(competitionRow);
            }

            return listOfCompetitions;
        }

        private static async Task<string?> GetTextContent(IElementHandle element, string selector)
        {
            var queryResult = await element.QuerySelectorAsync(selector);
            return queryResult != null ? await queryResult.TextContentAsync() : null;
        }

    }

}

namespace RequestModels
{
    public interface ILocator
    {
        string Selector { get; }
    }

    // Implement the ILocator interface
    public class Locator : ILocator
    {
        public string Selector { get; }

        public Locator(string selector)
        {
            Selector = selector;
        }
    }
    public class UserRowModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? toggleStatus { get; set; }
        public string? btnShow { get; set; }
        public string? btnEdit { get; set; }
        public string? btnDelete { get; set; }
    }

    public class CompetitionRowModel
    {
        public string? Competition { get; set; }
        public string? Product { get; set; }
        public string? NumberOfTickets { get; set; }
        public string? DrawDate { get; set; }
        public string? btnShowtickets { get; set; }
        public string? btnEditTickets { get; set; }
        public string? btnDeleteTickets { get; set; }
    }

    public class PutsboxEmail
    {
        public string id { get; set; }
        public string headers { get; set; }
        public string from_email { get; set; }
        public string from_name { get; set; }
        public List<string> to { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
        public string html { get; set; }
        public object attachments { get; set; }
        public string created_at { get; set; }

    }

    public class Profile
    {
        public class OrderHistory
        {
            public string PRIZE { get; set; }
            public string PURCHASE_DATE { get; set; }
            public int NUM_TICKETS { get; set; }
            public int PRICE { get; set; }
        }
    }

    public class Basket
    {
        public class Order
        {
            public string PRIZE { get; set; }
            public int NUM_TICKETS { get; set; }
            public double PRICE { get; set; }
        }
    }
}

namespace SMTP_API
{
    public class PutsBox
    {
        public static List<RequestModels.PutsboxEmail>? emailsList = null;
        
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

        private static string GetJsonUrl(string email, string id)
        {
            string arg = email.Substring(0, email.IndexOf('@'));
            return $"https://preview.putsbox.com/p/{arg}/{id}.json";
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

        private static string GetJsonContent(string email, string id)
        {
            RestClient client = new RestClient(GetJsonUrl(email, id));
            RestRequest request = new RestRequest("");
            return client.ExecuteGetAsync(request).Result.Content ?? throw new Exception("Content is null.");
        }

        private static string GetEmailContent(string email)
        {
            RestClient client = new RestClient(GetHtmlUrlToInspect(email));
            RestRequest request = new RestRequest("");
            return client.ExecuteGetAsync(request).Result.Content ?? throw new Exception("Content is null.");
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
            return ParseAllText(text).Split(Environment.NewLine).Where(x => x.Contains(value2)).FirstOrDefault().Replace($"{value2}", "") ?? throw new Exception($"Email is null");
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
            emailList = JsonConvert.DeserializeObject<List<RequestModels.PutsboxEmail>?>(htmlContent);
            if (htmlContent.Contains("Not Found"))
            {
                Thread.Sleep(2000);
                htmlContent = GetEmailContent(domain);
            }
        }

        public static string CheckEmailBySubject(string email, string subject, string value)
        {
            GgetAllEmailData(email, out emailsList);
            var id = emailsList.Where(x => x.subject == subject).Select(q => q.id).FirstOrDefault();
            var content = Decode(GetJsonContent(email, id));
            GetBodyData(content);
            string[] texts = ParseAllText(content)
                .Split(Environment.NewLine)
                .Where(x => x.Contains(value))
                .ToArray();
            return ParseAllText(content).Split(Environment.NewLine).Where(x => x.Contains(value)).FirstOrDefault().Replace($"{value}", "") ?? throw new Exception($"Email is null");
            

        }

        static void GgetAllEmailData(string email, out List<PutsboxEmail>? emailList)
        {
            GetAllEmails(email, out emailList);
            CheckEmailsCountFor35Minutes(emailList, email);
            GetAllEmails(email, out emailList);
        }

        static void CheckEmailsCountFor35Minutes(List<PutsboxEmail>? userEmails, string email)
        {
            DateTime startTime = DateTime.Now;
            int checkInterval = 30000; // in milliseconds
            bool statusChanged = false;
            int minutes = 35;

            while (DateTime.Now - startTime < TimeSpan.FromMinutes(minutes)) // loop for 15 minutes
            {
                switch (userEmails.Any(x => x != null && !x.subject.Contains("How many stars would you give")))
                {
                    case false:
                        Thread.Sleep(checkInterval); // wait for 30 seconds before checking again
                        GetAllEmails(email, out userEmails);
                        break;

                    case true:
                        statusChanged = true;
                        goto LoopExit; // exit the loop since the status has changed

                }


            }
        LoopExit:
            // Continue with the rest of the code outside the switch statement            
            if (!statusChanged)
            {
                throw new Exception($"Subscription status did not change within {minutes} minutes.");
            }
        }

        static void GgetHtmlBody(string email, string id, out string emailInitial)
        {
            emailInitial = GetHtmlFromEmail(email, id);
        }

        public static async Task GoToActivationLink(string email)
        {
            var activateLink = GetLinkFromEmailWithValue(email, "Activate account");
            await Helpers.GoToPage(activateLink, Activate.inputFirstName);
        }
    }
}
