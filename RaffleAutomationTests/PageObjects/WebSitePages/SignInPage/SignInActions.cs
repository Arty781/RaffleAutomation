using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaffleAutomationTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Allure.Steps;
using System.Diagnostics;

namespace RaffleAutomationTests.PageObjects
{
    public partial class SignIn
    {
        [AllureStep]
        public SignIn EnterLoginAndPass(string login, string password)
        {
            
            WaitUntil.CustomElementIsClickable(InputLogin, 3);

            InputLogin.SendKeys(login);
            InputPassword.SendKeys(password);
            SignInBtn.Click();

            return this;
        }

        public SignIn SwitchWindow()
        {
            WaitUntil.WaitSomeInterval(5);
            Browser._Driver.SwitchTo().Window(Browser._Driver.WindowHandles.ToList().Last());
            return this;
        }
    }
}
