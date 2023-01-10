using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Common
    {
        [FindsBy(How = How.XPath, Using = "//button[@class='enter-now__button']")]
        public IWebElement enterBtn;

        [FindsBy(How = How.XPath, Using = "//button[@class='cookie-close-button']")]
        public IWebElement confirmCookieBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[5]")]
        public IWebElement addOneTicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[6]")]
        public IWebElement addTenTicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[7]")]
        public IWebElement add25TicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[3]")]
        public IWebElement removeOneTicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[2]")]
        public IWebElement removeTenTicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[1]")]
        public IWebElement remove25TicketBtn;

        [FindsBy(How = How.XPath, Using = "//span[@class='add-basket']/ancestor::div[@class='popular-tickets-container']/button")]
        public IWebElement btnAddToBasket;

        #region Toaster

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Error')]/parent::div/div[2]")]
        public IWebElement toaster;

        #endregion






    }
}
