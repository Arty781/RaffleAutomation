namespace RaffleAutomationTests.PageObjects
{
    public partial class Footer
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='footerWrap ']//h3")]
        public IWebElement textTitleFooter;

        [FindsBy(How = How.XPath, Using = "//div[@class='footerWrap ']/div/span")]
        public IWebElement textParagraphFooter;

        [FindsBy(How = How.XPath, Using = "//div[@class='footerContactLinks']//a")]
        public IList<IWebElement> textLinkContactsFooter;

        [FindsBy(How = How.XPath, Using = "//ul[@class='sponsors']//a")]
        public IList<IWebElement> textLinkSponsorFooter;
    }
}
