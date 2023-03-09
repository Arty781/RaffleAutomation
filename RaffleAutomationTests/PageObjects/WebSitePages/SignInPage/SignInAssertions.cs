namespace RaffleAutomationTests.PageObjects
{
    public partial class SignIn
    {
        public SignIn VerifyIsSignIn()
        {
            WaitUntil.CustomElementIsVisible(Pages.Profile.titleProfile);
            Assert.IsTrue(Pages.Profile.FirstNameInput.Displayed);
            return this;
        }

    }
}
