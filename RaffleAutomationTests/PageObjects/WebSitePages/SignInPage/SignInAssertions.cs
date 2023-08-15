using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;

namespace RaffleAutomationTests.PageObjects
{
    public partial class SignIn
    {
        [AllureStep("Verify Is Sign In")]
        public SignIn VerifyIsSignIn(out string name)
        {
            WaitUntil.CustomElementIsVisible(Pages.Profile.inputFirstName);
            Assert.IsTrue(Pages.Profile.inputFirstName.Displayed);
            WaitUntil.WaitSomeInterval();
            name = Pages.Profile.inputFirstName.GetAttribute("value");
            return this;
        }

        [AllureStep("Verify Is Sign In")]
        public string GetFirstName()
        {
            WaitUntil.CustomElementIsVisible(Pages.Profile.titleProfile);
            Assert.IsTrue(Pages.Profile.inputFirstName.Displayed);
            WaitUntil.WaitSomeInterval();
            string name = Pages.Profile.inputFirstName.GetAttribute("value");
            return name;
        }

        [AllureStep("Verify Displaying Email Error Message")]
        public SignIn VerifyDisplayingEmailErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textEmailErrorMessage);
            Assert.IsTrue(textEmailErrorMessage.Displayed, "Email error message is not displayed");
            return this;
        }

        [AllureStep("Verify Displaying Password Error Message")]
        public SignIn VerifyDisplayingPasswordErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textPasswordErrorMessage);
            Assert.IsTrue(textPasswordErrorMessage.Displayed, "Password error message is not displayed");
            return this;
        }
        [AllureStep("Verify Validation On SignIn")]
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
                        EnterLoginAndPass(response.User.Email.Replace(".com", ""), Credentials.PASSWORD);
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 3:
                        EnterLoginAndPass(response.User.Email, "");
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 4:
                        EnterLoginAndPass(response.User.Email, "qwertyzaq");
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 5:
                        EnterLoginAndPass(response.User.Email, "123456789");
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 6:
                        EnterLoginAndPass(response.User.Email, "Qaz1");
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                }
            }
        }

    }
}
