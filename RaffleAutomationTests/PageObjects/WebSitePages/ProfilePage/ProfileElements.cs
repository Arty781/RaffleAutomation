namespace RaffleAutomationTests.PageObjects
{
    public partial class Profile
    {
        #region My Details 

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'My Details')]")]
        public IWebElement titleProfile;

        [FindsBy(How = How.XPath, Using = "//button[@data-edit='personal']")]
        public IWebElement btnEditPersonal;

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement inputFirstName;

        [FindsBy(How = How.Name, Using = "surname")]
        public IWebElement inputLastName;

        [FindsBy(How = How.XPath, Using = "//button[@data-edit='password']")]
        public IWebElement btnEditPassword;

        [FindsBy(How = How.Name, Using = "oldPassword")]
        public IWebElement inputCurrentPassword;

        [FindsBy(How = How.Name, Using = "newPassword")]
        public IWebElement inputNewPassword;

        [FindsBy(How = How.Name, Using = "confirmPassword")]
        public IWebElement inputConfirmPassword;

        [FindsBy(How = How.XPath, Using = "//button[@data-edit='account']")]
        public IWebElement btnEditAccount;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement inputEmail;

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement inputPhone;

        [FindsBy(How = How.XPath, Using = "//input[@value='emailCommunication']")]
        public IWebElement inputEmailCommunication;

        [FindsBy(How = How.XPath, Using = "//input[@value='corporateNotification']")]
        public IWebElement inputCorporateNotification;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'savingNewPassword visible')]")]
        public IWebElement btnSave;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Profile info update success')]")]
        public IWebElement SuccessUpdateDialog;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Password update success')]")]
        public IWebElement SuccessUpdatePasswordDialog;

        [FindsBy(How = How.Id, Using = "outlined-basic-helper-text")]
        public IWebElement textErrorMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'First name')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textFirstNameErrorMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Last name')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textLastNameErrorMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Email')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textEmailErrorMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Phone')]/parent::div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textPhoneErrorMessage;

        [FindsBy(How = How.XPath, Using = "//input[@name='oldPassword']/ancestor::label/div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textOldPasswordErrorMessage;

        [FindsBy(How = How.XPath, Using = "//input[@name='newPassword']/ancestor::label/div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textNewPasswordErrorMessage;

        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']/ancestor::label/div/p[@id='outlined-basic-helper-text']")]
        public IWebElement textConfirmPasswordErrorMessage;

        #endregion

        #region Order History

        [FindsBy(How = How.XPath, Using = "//span[text()='My Tickets & Competitions']/parent::button")]
        public IWebElement tabMyTicketsCompetitions;

        [FindsBy(How = How.XPath, Using = "//span[text()='Dream Home']/ancestor::div[@class='history-accordion-inner']/div")]
        public IWebElement listDreamHomeHistory;

        [FindsBy(How = How.XPath, Using = "//span[text()='Lifestyle Competitions']/ancestor::div[@class='history-accordion-inner']/div")]
        public IWebElement listWeeklyHistory;

        [FindsBy(How = How.XPath, Using = "//span[text()='Fixed Odds']/ancestor::div[@class='history-accordion-inner']/div")]
        public IWebElement listFixedOddsHistory;

        [FindsBy(How = How.XPath, Using = "//table[@class='historyAreaTable']/tbody/tr/td[1]")]
        public IWebElement prizeName;

        [FindsBy(How = How.XPath, Using = "//table[@class='historyAreaTable']/tbody/tr/td[3]")]
        public IWebElement prizeTickets;

        [FindsBy(How = How.XPath, Using = "//table[@class='historyAreaTable']/tbody/tr/td[4]")]
        public IList<IWebElement> prizePrice;

        #endregion

        #region Subscriptions

        [FindsBy(How = How.XPath, Using = "//h1[text()='My Subscription']")]
        public IWebElement titleSubscriptionProfile;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'profile-subscription-card ')]//p[text()='Details']")]
        public IList<IWebElement> btnDetails;

        [FindsBy(How=How.XPath,Using = "//div[contains(@class,'profile-subscription-card ')]/div[contains(@class, 'header')]")]
        public IList<IWebElement> titleSubscriptionStatus;

        [FindsBy(How = How.XPath, Using = "//div[@class='select-charity-wrapper']/div")]
        public IList<IWebElement> cbbxCharitySelector;

        [FindsBy(How = How.XPath, Using = "//div[@role='presentation']/div/ul/li")]
        public IList<IWebElement> listCharities;

        [FindsBy(How = How.XPath, Using = "//div[@class='select-charity-wrapper']/div//input")]
        public IList<IWebElement> inputCharity;

        [FindsBy(How = How.Name, Using = "paused")]
        public IList<IWebElement> inputPause;

        [FindsBy(How = How.XPath, Using = "//button[text()='Cancel Subscription']")]
        public IList<IWebElement> btnCancelSubscription;

        [FindsBy(How = How.XPath, Using = "//button[text()='Reactivate Subscription']")]
        public IList<IWebElement> btnReactivateSubscription;

        [FindsBy(How = How.XPath, Using = "//button[text()='Pause']")]
        public IWebElement btnPausePopUp;

        [FindsBy(How = How.XPath, Using = "//button[text()='Unpause']")]
        public IWebElement btnUnpausePopUp;

        [FindsBy(How = How.XPath, Using = "//button[text()='Cancel']")]
        public IWebElement btnCancelPopUp;

        [FindsBy(How = How.XPath, Using = "//button[text()='Reactivate']")]
        public IWebElement btnReactivatePopUp;

        [FindsBy(How = How.XPath, Using = "//button[text()='Back']")]
        public IWebElement btnBackPopUp;


        #endregion
    }
}
