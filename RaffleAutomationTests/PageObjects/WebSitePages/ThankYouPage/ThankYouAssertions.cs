using NUnit.Framework;
using RaffleAutomationTests.Helpers;

namespace RaffleAutomationTests.PageObjects
{
    public partial class ThankYou
    {
        public void VerifyThankYouPageIsDisplayed()
        {
            WaitUntil.CustomElementIsVisible(titleThankYouPage, 60);
            Assert.IsTrue(titleThankYouPage.Enabled);

        }
    }
}