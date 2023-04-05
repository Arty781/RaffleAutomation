namespace RaffleAutomationTests.PageObjects.WebSitePages.ResetPasswordPage
{
    public partial class ResetPassword
    {
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement inputEmail;

        [FindsBy(How = How.XPath, Using = "//button/p[text()='Request']")]
        public IWebElement btnRequest;

        [FindsBy(How = How.XPath, Using = "//div[@class='reset-send-success forgot-send-success']/p")]
        public IWebElement titleResetSuccess;

        [FindsBy(How = How.XPath, Using = "//div[@class='reset-send-success forgot-send-success']/b")]
        public IWebElement titleResetSuccessEmail;

        [FindsBy(How = How.XPath, Using = "//button[text()='OK']")]
        public IWebElement btnOk;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement inputPassword;

        [FindsBy(How = How.Name, Using = "confirmPassword")]
        public IWebElement inputConfirmPassword;

        [FindsBy(How = How.XPath, Using = "//button[text()='Set new password']")]
        public IWebElement btnSetNewPassword;
    }
}
