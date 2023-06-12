using HtmlAgilityPack;
using RaffleAutomationTests.PageObjects.WebSitePages;
using RimuTec.Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using static RaffleAutomationTests.Helpers.WebMOdels.Profile;

namespace RaffleAutomationTests.Helpers
{
    public class ParseHelper
    {
        private static string IgnoreLinkInHtml(string html)
        {
            // Find the link in the HTML code
            string pattern = $"<a.href=\"" + "(.+?)\"";
            string result = Regex.Replace(html, pattern, "<a href=" + "\"" + "link with token" + "\"", RegexOptions.IgnoreCase);
            pattern = "src=\"(.+?)\"";
            result = Regex.Replace(result, pattern, "src=" + "\"" + "link with token" + "\"", RegexOptions.IgnoreCase);
            //pattern = "<td>(.+?)</td>";
            //result = Regex.Replace(result, pattern, "<td>" + "</td>", RegexOptions.IgnoreCase);
            //pattern = "<strong>Hi(.+?),";
            //result = Regex.Replace(result, pattern, "<strong>Hi \"Name\",", RegexOptions.IgnoreCase);

            return result;
        }

        private static void CompareEmailWithTemplate(string html, string template)
        {
            
            string expectedText = template;
            string actualText = html;

            Assert.Multiple(() =>
            {
                Assert.That(actualText, Is.EqualTo(expectedText), "Texts don't match");
                Assert.That(expectedText.Length, Is.EqualTo(actualText.Length), "Number of elements doesn't match");

                var mismatchedIndices = expectedText.Select((text, index) => new { text, index })
                    .Where(item => !actualText[item.index].Equals(item.text))
                    .Select(item => item.index)
                    .ToList();

                if (mismatchedIndices.Count > 0)
                {
                    string errorMessage = $"Expected text does not match the actual text at index(es): {string.Join(", ", mismatchedIndices)}";
                    Assert.Fail(errorMessage);
                }
            });
        }

        public static void ParseHtmlAndCompare(string html, string template)
        {
            // Load HTML code into an HtmlDocument object
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            // Convert the modified HTML back to a string
            string parsedHtml = htmlDoc.DocumentNode.OuterHtml;

            //replase links
            parsedHtml = IgnoreLinkInHtml(parsedHtml);

            // Compare the parsed HTML with the template
            CompareEmailWithTemplate(parsedHtml, template);
            
        }



    }

    public class EmailVerificator
    {
        public static void VerifyInitialEmailAuth(string email, string name, string charity)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
            var quantity = (int)(sub.NumOfTickets + sub.Extra);
            var value = (double)sub.TotalCost / 100;
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.InitialAuth(name, quantity, value, charity));

        }

        public static void VerifyInitialEmailUnauth(string email, string name, string charity, int activeRaffles)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
            var quantity = (int)(sub.NumOfTickets + sub.Extra);
            var value = (double)sub.TotalCost / 100;
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.InitialUnauth(name, quantity * activeRaffles, value, charity));

        }

        public static void VerifyMonthlyEmailAuth(string email, string name, string charity, int activeRaffles)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
            var quantity = (int)(sub.NumOfTickets + sub.Extra);
            var value = (double)sub.TotalCost / 100;
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.MonthlyAuth(name, quantity * activeRaffles, value, charity));

        }

        public static void VerifyCancelationEmail(string email, string name)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription cancellation receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.Cancel(name));

        }

        public static void VerifyPauseEmail(string email, string name)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Paused subscription").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.Pause(name));

        }

        public static void VerifyUnpauseEmail(string email, string name, string charity, int activeRaffles)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            var sub = subscriptionList.Where(x => x.Status == "ACTIVE" && x.PausedAt == null).Select(x => x).First();
            var quantity = (int)(sub.NumOfTickets + sub.Extra);
            var value = (double)sub.TotalCost / 100;
            var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(user);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.Unpause(name, quantity * activeRaffles, value, charity));
        }

        public static void VerifyReminderEmail(string email,string name)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription pause reminder").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.SevenDaysBeforeUnpause(name));

        }

        public static void VerifyPurchaseFailedEmail(string email, string name)
        {
            WaitUntil.WaitSomeInterval();
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Failed subscription payment").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.PurchaseFailed(name));

        }

    }

    public class OrderHistoryVerificator
    {
        private static List<OrderHistory> SplitIntoRows(List<IWebElement> inputList, int elementsPerRow, int maxRows, out int totalPriceSum)
        {
            List<OrderHistory> historyList = new List<OrderHistory>();
            int sum= 0;
            int numRows = inputList.Count / elementsPerRow;
            if (numRows < maxRows)
            {
                throw new Exception("Not enough rows available.");
            }
            numRows = Math.Min(maxRows, numRows); // Calculate the actual number of rows to include
            for (int i = 0; i < numRows * elementsPerRow; i += elementsPerRow)
            {
                IWebElement prizeElement = inputList[i];
                IWebElement purchaseDateElement = inputList[i + 1];
                IWebElement numTicketsElement = inputList[i + 2];
                IWebElement priceElement = inputList[i + 3];

                OrderHistory item = new OrderHistory()
                {
                    PRIZE = prizeElement.Text,
                    PURCHASE_DATE = purchaseDateElement.Text,
                    NUM_TICKETS = int.Parse(numTicketsElement.Text),
                    PRICE = int.Parse(priceElement.Text.Substring(1))
                };
                sum += item.PRICE; // Accumulate the price
                historyList.Add(item);
            }

            totalPriceSum= sum;

            return historyList;
        }

        public static List<OrderHistory> GetOrderHistory(List<IWebElement> inputList, int maxRows, out int totalPriceSum)
        {
            List<OrderHistory> result = SplitIntoRows(inputList, 4, maxRows, out int sum);
            totalPriceSum= sum;

            return result;
        }


    }

}
