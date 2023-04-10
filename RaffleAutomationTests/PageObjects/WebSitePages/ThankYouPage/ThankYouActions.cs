namespace RaffleAutomationTests.PageObjects
{
    public partial class ThankYou
    {
        [AllureStep("Click activate my account btn")]
        public ThankYou ClickActivateMyAccount()
        {
            Button.Click(btnActivateMyAccount);

            return this;
        }
    }

}
