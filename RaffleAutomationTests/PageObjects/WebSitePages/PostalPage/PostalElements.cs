using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Postal
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='entreeInfo']//h1")]
        public IWebElement textTitlePostPage;

        [FindsBy(How=How.XPath,Using = "//div[@class='entreeInfo']//p")]
        public IList<IWebElement> textParagraphsPostPage;

        [FindsBy(How = How.XPath, Using = "//div[@class='entreeInfo']//a")]
        public IList<IWebElement> textLinksPostPage;
    }
}
