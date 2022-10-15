using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class ThankYou
    {
        [FindsBy(How = How.XPath, Using = "//h1[@class='orderCompleted']")]
        public IWebElement titleThankYouPage;
    }
}
