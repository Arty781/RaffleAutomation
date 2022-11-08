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
    public partial class CmsLogin
    {
        [FindsBy(How=How.Name,Using ="email")]
        public IWebElement inputEmail;

        [FindsBy(How=How.Name,Using ="password")]
        public IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement btnSignIn;
    }
}
