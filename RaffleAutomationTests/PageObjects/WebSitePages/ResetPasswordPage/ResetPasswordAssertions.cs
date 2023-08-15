namespace RaffleAutomationTests.PageObjects.WebSitePages.ResetPasswordPage
{
    public partial class ResetPassword
    {
        public ResetPassword VerifySuccessfullMessageAppeared(string email)
        {
            WaitUntil.CustomElementIsVisible(titleResetSuccess);
            Assert.IsTrue(titleResetSuccessEmail.Text == email, $"Expected {email}, but was {titleResetSuccessEmail.Text}");

            return this;
        }
    }
}
