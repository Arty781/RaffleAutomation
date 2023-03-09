namespace RaffleAutomationTests.PageObjects
{
    public partial class ThankYou
    {
        [AllureStep("Go to activation link")]
        public ThankYou GoToActivationLink(string email)
        {
            var activateLink = PutsBox.GetLinkFromEmailWithValue(email, "Activate account");
            Browser.Navigate(activateLink);

            return this;
        }

        [AllureStep("Click activate my account btn")]
        public ThankYou ClickActivateMyAccount()
        {
            Button.Click(btnActivateMyAccount);

            return this;
        }
    }
}
