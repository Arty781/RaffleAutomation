using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Home
    {
        #region Home > Win block

        [FindsBy(How = How.XPath, Using = "//div[@class='win-block']/h1")]
        public IWebElement textWInBlockH1;

        [FindsBy(How = How.XPath, Using = "//div[@class='win-block']/div[@class='win-home-title']")]
        public IWebElement textWInBlockTitle;

        [FindsBy(How = How.XPath, Using = "//div[@class='win-block']/div[@class='win-home-subtitle']")]
        public IWebElement textWInBlockSubtitle;

        [FindsBy(How = How.XPath, Using = "//div[@class='win-block']/div[@class='our-next-winner']/button")]
        public IWebElement btnFindOutMoreWinBlock;

        #endregion

        #region Dream statistic

        [FindsBy(How = How.XPath, Using = "//div[@class='dreaming-big-title']")]
        public IWebElement textDreamingTitle;

        [FindsBy(How = How.XPath, Using = "//div[@class='dream-big-statistic']")]
        public IList<IWebElement> textStatisticsValues;

        #endregion

        #region Most Popular section

        [FindsBy(How = How.XPath, Using = "//div[text()='Most Popular Competitions']/ancestor::div[@class='container']")]
        public IWebElement sectionMostPopular;

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement name;

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement name;

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement name;

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement name;

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement name;

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement name;

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement name;

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement name;

        //[FindsBy(How = How.XPath, Using = "")]
        //public IWebElement name;
        #endregion
    }
}
