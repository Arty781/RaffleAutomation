using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class AboutUs
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='sample-timer']/h1")]
        public IWebElement titleAboutPage;

        [FindsBy(How = How.XPath, Using = "//div[@class='findOutWrapper-home']/div[@class='findBlock-home']//h3")]
        public IList<IWebElement> titleFindOut;

        [FindsBy(How = How.XPath, Using = "//div[@class='findOutWrapper-home']/div[@class='findBlock-home']//p")]
        public IList<IWebElement> descriptionFindOut;

        [FindsBy(How=How.XPath,Using = "//div[@id='about-categories']/a")]
        public IList<IWebElement> blockCategories;

        #region How section

        [FindsBy(How=How.XPath,Using = "//div[@class='howMain']/h2")]
        public IWebElement titleHowSection;

        [FindsBy(How = How.XPath, Using = "//div[@class='howMain']//p")]
        public IWebElement descriptionHowSection;

        [FindsBy(How = How.XPath, Using = "//div[@class='howMain']//button")]
        public IWebElement btnHowSection;

        [FindsBy(How = How.XPath, Using = "//div[@class='step']//h3")]
        public IList<IWebElement> titleHowStep;

        [FindsBy(How = How.XPath, Using = "//div[@class='step']//p")]
        public IList<IWebElement> descriptionHowStep;

        #endregion

        #region Charitable Giving section

        [FindsBy(How = How.XPath, Using = "//h2[text()='Charitable giving']/parent::div//p")]
        public IList<IWebElement> descriptionCharitableCard;

        #endregion

        #region Site credit section

        [FindsBy(How = How.XPath, Using = "//h2[text()='Site Credit']/parent::div//h5")]
        public IWebElement titleSiteCredit;

        [FindsBy(How = How.XPath, Using = "//h2[text()='Site Credit']/parent::div//p")]
        public IList<IWebElement> descriptionSiteCredit;

        [FindsBy(How = How.XPath, Using = "//h2[text()='Site Credit']/parent::div//button")]
        public IWebElement btnSiteCredit;

        #endregion
    }
}
