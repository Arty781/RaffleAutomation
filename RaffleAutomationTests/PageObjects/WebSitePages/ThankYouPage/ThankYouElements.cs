namespace RaffleAutomationTests.PageObjects
{
    public partial class ThankYou
    {
        [FindsBy(How = How.XPath, Using = "//h1[@class='orderCompleted']")]
        public IWebElement titleThankYouPage;

        [FindsBy(How = How.XPath, Using = "//button[text()='Activate My Account']")]
        public IWebElement btnActivateMyAccount;
    }
}
