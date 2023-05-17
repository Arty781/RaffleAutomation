using HtmlAgilityPack;
using RaffleAutomationTests.PageObjects.WebSitePages;
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
            pattern = "<td>(.+?)</td>";
            result = Regex.Replace(result, pattern, "<td>" + "</td>", RegexOptions.IgnoreCase);
            pattern = "<strong>Hi(.+?),";
            result = Regex.Replace(result, pattern, "<strong>Hi \"Name\",", RegexOptions.IgnoreCase);

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
        public static void VerifyInitialEmailAuth(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.INITIAL_AUTH);

        }

        public static void VerifyInitialEmailUnauth(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.INITIAL_UNAUTH);

        }

        public static void VerifyMonthlyEmailAuth(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.MONTHLY_AUTH);

        }

        public static void VerifyCancelationEmail(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription cancellation receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.CANCEL);

        }

        public static void VerifyPauseEmail(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Paused subscription").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.PAUSE);

        }

        public static void VerifyUnpauseEmail(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.UNPAUSE);

        }

        public static void VerifyReminderEmail(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription pause reminder").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.SEVEN_DAYS_BEFORE_UNPAUSE);

        }

        public static void VerifyPurchaseFailedEmail(string email)
        {
            WaitUntil.WaitSomeInterval();
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Failed subscription payment").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.PURCHASE_FAILED);

        }

    }

    public class OrderHistoryVerificator
    {
        private static List<OrderHistory> SplitIntoRows(List<IWebElement> inputList, int elementsPerRow, int maxRows, out int totalPriceSum)
        {
            List<OrderHistory> historyList = new List<OrderHistory>();
            int sum= 0;
            int numRows = Math.Min(maxRows, inputList.Count / elementsPerRow); // Calculate the actual number of rows to include
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
