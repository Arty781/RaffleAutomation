using NUnit.Allure.Steps;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class SignUp
    {
        [AllureStep("Enter user data")]
        public SignUp EnterUserData()
        {
            WaitUntil.CustomElementIsVisible(inputFirstName);
            inputFirstName.SendKeys("Jane");
            inputSurname.SendKeys("Doe");
            inputEmail.SendKeys("qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
            inputCountry.Click();
            ClickHelper.Clicker(listCountry);
            inputPhone.SendKeys("961234563");
            inputPassword.SendKeys("Qaz11111");
            btnConfirmOpt.Click();
            btnRememberMe.Click();

            return this;
        }

        [AllureStep("Click \"Sign Up\" button")]
        public SignUp ClickSignUpBtn()
        {
            WaitUntil.CustomElementIsVisible(btnSignUp);
            btnSignUp.Click();

            return this;
        }
    }
}
