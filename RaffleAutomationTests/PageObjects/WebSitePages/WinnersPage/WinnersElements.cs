namespace RaffleAutomationTests.PageObjects
{
    public partial class Winners
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='winner-card']")]
        public IList<IWebElement> cardWinner;

        [FindsBy(How = How.XPath, Using = "//div[@class='winner-card-name']")]
        public IList<IWebElement> textWinnerTitle;

        [FindsBy(How = How.XPath, Using = "//span[@class='winner-card-date']")]
        public IList<IWebElement> textWinnerDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='winner-card-desc text-container']")]
        public IList<IWebElement> textWinnerDescription;

        [FindsBy(How = How.XPath, Using = "//div[@class='winner-card']//p")]
        public IList<IWebElement> textWinnerCardDescription;

        [FindsBy(How = How.XPath, Using = "//ul[@class='winners-date']/li")]
        public IList<IWebElement> filterYearSelector;

    }
}
