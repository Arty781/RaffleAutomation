namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class Subscription
    {
        [FindsBy(How = How.XPath, Using = "//h1")]
        public IWebElement titleH1;

        [FindsBy(How = How.XPath, Using = "//h2")]
        public IList<IWebElement> titleH2List;

        [FindsBy(How = How.XPath, Using = "//h3")]
        public IList<IWebElement> titleH3List;

        [FindsBy(How = How.XPath, Using = "//p")]
        public IList<IWebElement> paragraphList;

        [FindsBy(How = How.XPath, Using = "//button[text()='SUBSCRIBE NOW']")]
        public IWebElement btnSubscribeNowTop;

        [FindsBy(How = How.XPath, Using = "//div[@class='cta-btn-row']/button[text()='SUBSCRIBE NOW']")]
        public IWebElement btnSubscribeNowBottom;

        [FindsBy(How = How.XPath, Using = "//div[@class='buttons']/button")]
        public IList<IWebElement> btnSubscribeNowSelector;

        [FindsBy(How = How.XPath, Using = "//div[@class='info']/p[@class='price']")]
        public IList<IWebElement> textPrice;
    }
}
