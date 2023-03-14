namespace RaffleAutomationTests.PageObjects
{
    public partial class SignIn
    {
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement inputLogin;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn primary full-width']")]
        public IWebElement btnSignIn;

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        public IWebElement checkboxPolicy;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Forgot password?')]")]
        public IWebElement btnForgotPassword;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Email')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textEmailErrorMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Password')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textPasswordErrorMessage;

    }
}
