using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsLifestylePrizes
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='#/prizes']")]
        public IWebElement titleSideBarLifestyle;

        [FindsBy(How = How.XPath, Using = "//td[@id='status-table-head-actions']//label")]
        public IList<IWebElement> switcher;

        [FindsBy(How = How.XPath, Using = "//div[@role='button']")]
        public IWebElement rowPerPage;

        [FindsBy(How = How.XPath, Using = "//li[@data-value]")]
        public IList<IWebElement> listOfRowValues;

        [FindsBy(How = How.XPath, Using = "//button[@title='First Page']")]
        public IWebElement buttonFistPage;

        [FindsBy(How = How.XPath, Using = "//button[@title='Previous page']")]
        public IWebElement buttonPreviousPage;

        [FindsBy(How = How.XPath, Using = "//button[@title='Next page']")]
        public IWebElement buttonNextPage;

        [FindsBy(How = How.XPath, Using = "//button[@title='Last Page']")]
        public IWebElement buttonLastPage;

        [FindsBy(How = How.XPath, Using = "//span[text()='Category']")]
        public IWebElement filterCategory;

        [FindsBy(How = How.XPath, Using = "//span[@class='category-title']")]
        public IList<IWebElement> filterCategoryItems;
    }
}