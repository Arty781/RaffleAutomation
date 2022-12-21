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
    public partial class SignIn
    {
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement inputLogin;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn primary full-width']")]
        public IWebElement btnSignIn;

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        public IWebElement checkboxPolicy;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Forgot password?')]")]
        public IWebElement inputForgotPassword;


        


    }
}
