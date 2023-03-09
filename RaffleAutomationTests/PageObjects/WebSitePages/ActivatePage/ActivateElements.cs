namespace RaffleAutomationTests.PageObjects.WebSitePages.ActivatePage
{
    public partial class Activate
    {
        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement inputFirstName;

        [FindsBy(How=How.Name, Using = "surname")]
        public IWebElement inputLastName;

        [FindsBy(How=How.Name, Using ="email")]
        public IWebElement inputEmail;

        [FindsBy(How=How.XPath, Using ="//input[@type='tel']")]
        public IWebElement inputPhone;

        [FindsBy(How=How.Name, Using ="password")]
        public IWebElement inputPassword;

        [FindsBy(How=How.XPath, Using = "//button[text()='Activate account']")]
        public IWebElement btnActivateAccount;

        [FindsBy(How=How.XPath, Using ="//h1[text()='Account Activated']")]
        public IWebElement titleActivatedAccount;
    }
}
