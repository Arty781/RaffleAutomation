namespace RaffleAutomationTests.PageObjects.WebSitePages.ActivatePage
{
    public partial class Activate
    {
        public void VerifyIsDisplayedEmail(string email)
        {
            WaitUntil.CustomElementIsVisible(inputEmail);
            Assert.IsTrue(TextBox.GetAttribute(inputEmail, "value") == email, $"Emails are not matched, must be {email} but was {TextBox.GetAttribute(inputEmail, "value")}");
        }

        public void VerifySuccessfullActivation()
        {
            WaitUntil.CustomElementIsVisible(titleActivatedAccount, 60);
            Assert.IsTrue(titleActivatedAccount.Enabled, "Thank You page is not displayed");
        }
    }
}
