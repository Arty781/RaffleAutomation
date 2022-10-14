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
        IWebElement inputEmail => Browser._Driver.FindElement(_inputEmail);
        public readonly By _inputEmail = By.XPath("//*/input[@name=\"email\"]");

        IWebElement inputPassword => Browser._Driver.FindElement(_inputPassword);
        public readonly By _inputPassword = By.XPath("//*/input[@name=\"password\"]");

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement btnSignIn;
    }
}
