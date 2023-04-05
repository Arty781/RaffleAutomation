﻿using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;

namespace RaffleAutomationTests.PageObjects
{
    public partial class SignIn
    {
        public SignIn VerifyIsSignIn()
        {
            WaitUntil.CustomElementIsVisible(Pages.Profile.titleProfile);
            Assert.IsTrue(Pages.Profile.inputFirstName.Displayed);
            return this;
        }

        public SignIn VerifyDisplayingEmailErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textEmailErrorMessage);
            Assert.IsTrue(textEmailErrorMessage.Displayed, "Email error message is not displayed");
            return this;
        }

        public SignIn VerifyDisplayingPasswordErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textPasswordErrorMessage);
            Assert.IsTrue(textPasswordErrorMessage.Displayed, "Password error message is not displayed");
            return this;
        }

        public void VerifyValidationOnSignIn(SignUpResponse response)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        EnterLoginAndPass("", Credentials.PASSWORD);
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 1:
                        EnterLoginAndPass(response.User.Email.Replace("@p", "@ p"), Credentials.PASSWORD);
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 2:
                        EnterLoginAndPass(response.User.Email, "");
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 3:
                        EnterLoginAndPass(response.User.Email, "qwertyzaq");
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 4:
                        EnterLoginAndPass(response.User.Email, "123456789");
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 5:
                        EnterLoginAndPass(response.User.Email, "Qaz1");
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                }
            }
        }

    }
}
