

namespace RaffleAutomationTests.PageObjects
{
    public partial class SignIn
    {
        [AllureStep]
        public SignIn EnterLoginAndPass(string login, string password)
        {

            WaitUntil.CustomElementIsVisible(inputLogin, 3);

            InputBox.Element(inputLogin, 10, login);
            InputBox.Element(inputPassword, 10, password);
            Button.Click(btnSignIn);

            return this;
        }

        public SignIn SwitchWindow()
        {
            WaitUntil.WaitSomeInterval(5);
            Browser.Driver.SwitchTo().Window(Browser.Driver.WindowHandles.ToList().Last());
            return this;
        }

        public SignIn ClickForgotPassword()
        {
            Button.Click(btnForgotPassword);
            return this;
        }

    }
}
