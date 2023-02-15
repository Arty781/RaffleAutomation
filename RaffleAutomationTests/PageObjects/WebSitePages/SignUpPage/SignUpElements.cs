namespace RaffleAutomationTests.PageObjects
{
    public partial class SignUp
    {
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement inputEmail;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement inputPassword;

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement inputFirstName;

        [FindsBy(How = How.Name, Using = "surname")]
        public IWebElement inputSurname;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn primary full-width']")]
        public IWebElement btnSignUp;

        [FindsBy(How = How.XPath, Using = "//button[@class='close-sign-up']")]
        public IWebElement btnCloseSignUpPopup;

        [FindsBy(How = How.XPath, Using = "//div[@class='agreeBlock']/label[1]//input[@type='checkbox']")]
        public IWebElement btnConfirmOpt;

        [FindsBy(How = How.XPath, Using = "//div[@class='agreeRemebmer']//input[@type='checkbox']")]
        public IWebElement btnRememberMe;

        [FindsBy(How = How.XPath, Using = "//ul[@role='listbox']/li[contains(text(),'Ukraine')]")]
        public IWebElement listCountry;

        [FindsBy(How = How.XPath, Using = "//ul[@role='listbox']/li")]
        public IList<IWebElement> listCountryAll;

        [FindsBy(How = How.XPath, Using = "//div[@aria-haspopup='listbox']")]
        public IWebElement inputCountry;

        [FindsBy(How = How.XPath, Using = "//input[@class='phone-input']")]
        public IWebElement inputPhone;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Email verified successfully')]")]
        public IWebElement toasterSuccessMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'First name')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textFirstNameErrorMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Last name')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textLastNameErrorMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Email')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textEmailErrorMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Phone')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textPhoneErrorMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Password')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textPasswordErrorMessage;

    }
}
