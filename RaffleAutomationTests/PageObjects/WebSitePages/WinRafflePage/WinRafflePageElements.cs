namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class WinRafflePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='ticket-list']//button")]
        public IList<IWebElement> btnTicketBundles;

        [FindsBy(How = How.XPath, Using = "//div[@class='price']/p[2]")]
        public IList<IWebElement> textTicketBundlePrice;
    }
}
