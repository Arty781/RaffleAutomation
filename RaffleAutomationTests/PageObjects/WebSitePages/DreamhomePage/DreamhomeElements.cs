using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Dreamhome
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='sticky-buy-dh']/button")]
        public IWebElement btnDreamHome;

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(), 'Win Your Dream Home in a Raffle')]")]
        public IWebElement counterTwoDreamhomes;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Win Your Dream Home')]")]
        public IWebElement counterDreamhome;

        [FindsBy(How = How.XPath, Using = "//div[@class='card']/div[@class='card__side card__side--front']//button")]
        public IList<IWebElement> cardDreamhome;

        [FindsBy(How = How.XPath, Using = "//ul[@class='popular-tickets']/li[1]")]
        public IWebElement btnFirstBundle;

        [FindsBy(How = How.XPath, Using = "//ul[@class='popular-tickets']/li[2]")]
        public IWebElement btnSecondBundle;

        [FindsBy(How = How.XPath, Using = "//ul[@class='popular-tickets']/li[3]")]
        public IWebElement btnThirdBundle;

        [FindsBy(How = How.XPath, Using = "//ul[@class='popular-tickets']/li[4]")]
        public IWebElement btnFourthBundle;

        [FindsBy(How = How.XPath, Using = "//section[@class='contacts-submit']//div[@class='winner-club-title']")]
        public IWebElement contactSection;

        [FindsBy(How = How.XPath, Using = "//div[@class='winner-club-title']")]
        public IWebElement winnersSectionTitle;
    }
}
