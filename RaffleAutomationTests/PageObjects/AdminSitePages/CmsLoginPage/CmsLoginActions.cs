using NUnit.Allure.Steps;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsLogin
    {
        [AllureStep("Enter login and password")]
        public CmsLogin EnterLoginAndPassword(string email, string password)
        {
            WaitUntil.ElementIsVisible(_inputEmail);
            inputEmail.SendKeys(email);
            WaitUntil.ElementIsVisible(_inputPassword);
            inputPassword.SendKeys(password);

            return this;
        }

        [AllureStep("Click SignIn button")]
        public CmsLogin ClickSignInBtn()
        {
            WaitUntil.ElementIsVisible(_signInBtn);
            signInBtn.Click();

            return this;
        }



    }
}
