namespace RaffleAutomationTests.PageObjects
{
    public partial class Putsbox
    {
        [FindsBy(How = How.Id, Using = "putsbox-token-input")]
        public IWebElement inputEmail;

        [FindsBy(How = How.XPath, Using = "//a[text()='Clear History']")]
        public IWebElement btnClearHistory;

        [FindsBy(How=How.XPath, Using = "//h4[contains(text(),'Emails')]/parent::div//h3[text()='0']")]
        public IWebElement textNumberOfEmails;

    }
}
