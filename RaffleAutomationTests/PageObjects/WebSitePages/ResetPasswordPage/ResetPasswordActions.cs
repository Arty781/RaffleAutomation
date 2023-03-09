namespace RaffleAutomationTests.PageObjects.WebSitePages.ResetPasswordPage
{
    public partial class ResetPassword
    {
        [AllureStep("Request Forgot Password")]
        public ResetPassword RequestForgotPassword(string email)
        {
            InputBox.Element(inputEmail, 10, email);
            Button.Click(btnRequest);
            return this;
        }

        [AllureStep("Click Ok Btn")]
        public ResetPassword ClickOkBtn()
        {
            Button.Click(btnOk);
            return this;
        }

        [AllureStep("Go to activation link")]
        public ResetPassword GoToResetPassLink(string email)
        {
            var resetPassLink = PutsBox.GetLinkFromEmailWithValue(email, "Reset Password");
            Browser.Navigate(resetPassLink);

            return this;
        }

        [AllureStep("Get Reset Password")]
        public ResetPassword GetResetPassword()
        {
            InputBox.Element(inputPassword, 10, Credentials.NEW_PASWORD);
            InputBox.Element(inputConfirmPassword, 10, Credentials.NEW_PASWORD);
            Button.Click(btnSetNewPassword);

            return this;
        }
    }
}
