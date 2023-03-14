namespace RaffleAutomationTests.PageObjects
{
    public partial class ThankYou
    {
        public void VerifyThankYouPageIsDisplayed()
        {
            Pages.Basket.VerifyUrl();
            WaitUntil.CustomElementIsVisible(titleThankYouPage, 60);
            Assert.IsTrue(titleThankYouPage.Enabled, "Thank You page is not displayed");
        }

        
    }
}