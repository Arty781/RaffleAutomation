namespace RaffleAutomationTests.PageObjects.WebSitePages.TermsAndConditionsPage
{
    public partial class TermsAndConditions
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='staff-content']/div[3]")]
        public IWebElement textTerms;

        [FindsBy(How = How.XPath, Using = "//div[@class='staff-content']/div[2]")]
        public IWebElement textPrivacy;

        [FindsBy(How=How.XPath,Using ="//h1")]
        public IWebElement titleTermsAndConditions;
    }
}
