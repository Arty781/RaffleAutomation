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
    public partial class SignIn : BaseWeb
    {
        [AllureStep]
        public SignIn EnterLoginAndPass(string login, string password)
        {
            
            WaitUntil.ElementIsClickable(InputLogin, 3);

            InputLogin.SendKeys(login);
            InputPassword.SendKeys(password);
            SignInBtn.Click();

            return this;
        }

        public SignIn GoogleAuth(string login, string password)
        {

            WaitUntil.ElementIsClickable(SignInGoogleBtn, 3);

            SignInGoogleBtn.Click();
            SwitchWindow();
            WaitUntil.ElementIsClickable(GoogleEmailInput, 3);
            GoogleEmailInput.SendKeys(login);
            new Actions(Browser._Driver)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();
            /*GoogleNextBtn.SendKeys(Keys.Enter);*/
            WaitUntil.ElementIsVisibleAndClickable(_GooglePasswordInput, 3);
            GooglePasswordInput.SendKeys(password);
            new Actions(Browser._Driver)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();
            /*GoogleNextBtn.SendKeys(Keys.Enter);*/


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
