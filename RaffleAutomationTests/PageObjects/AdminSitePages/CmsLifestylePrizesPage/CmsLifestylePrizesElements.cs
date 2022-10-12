using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsLifestylePrizes
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='#/prizes']")]
        public IWebElement titleSideBarLifestyle;

        [FindsBy(How = How.XPath, Using = "//td[@id='status-table-head-actions']//input")]
        public IList<IWebElement> switcher;

        [FindsBy(How = How.XPath, Using = "//div/div/input")]
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
    }
}