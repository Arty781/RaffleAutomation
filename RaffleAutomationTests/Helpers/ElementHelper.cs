using RaffleAutomationTests.PageObjects;
using static RaffleAutomationTests.APIHelpers.Web.Subscriptions.SubsriptionsResponse;

namespace RaffleAutomationTests.Helpers
{
    public class Elements
    {
        public static void Click(IWebElement element)
        {
            WaitUntil.WaitSomeInterval(350);
            WaitUntil.CustomElementIsVisible(element);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser._Driver;
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
                IJavaScriptExecutor jsi = (IJavaScriptExecutor)Browser._Driver;
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
        public static string GgetHtmlBody(string email)
        {
            var activateLink = PutsBox.GetHtmlFromEmail(email);

            return activateLink;
        }

        //[AllureStep("Go to activation link")]
        public static void GgetHtmlBody(string email, string id, out string initialBody)
        {
            initialBody = PutsBox.GetHtmlFromEmail(email, id);
        }

        //[AllureStep("Go to activation link")]
        public static void GgetAllEmailData(string email, out List<PutsboxEmail>? emailData)
        {
            PutsBox.GetAllEmails(email, out string emailsList);
            emailData = JsonConvert.DeserializeObject<List<PutsboxEmail>?>(emailsList);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailData, email);
            PutsBox.GetAllEmails(email, out emailsList);
            emailData = JsonConvert.DeserializeObject<List<PutsboxEmail>?>(emailsList);
        }

        [AllureStep("Clear email history")]
        public static void ClearEmailHistory(string email)
        {
            PutsBox.ClearEmailHistory(email);

        }
    }
}
