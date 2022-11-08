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
            InputBox.Element(inputEmail, 10, email);
            InputBox.Element(inputPassword, 10, password);

            return this;
        }

        [AllureStep("Click SignIn button")]
        public CmsLogin ClickSignInBtn()
        {
            Button.Click(btnSignIn);
            return this;
        }



    }
}
