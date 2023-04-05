namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsUserManagement
    {
        [FindsBy(How = How.XPath, Using = "//div[text()='User Management']")]
        public IWebElement textTitleUserManagement;




        #region Add new User

        [FindsBy(How = How.XPath, Using = "//a[@aria-label='Add new ']")]
        public IWebElement btnAddUser;

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement inputFirstName;

        [FindsBy(How = How.Name, Using = "surname")]
        public IWebElement inputLastName;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement inputEmail;

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement inputPhone;

        [FindsBy(How = How.Id, Using = "search-input")]
        public IWebElement inputSearch;

        [FindsBy(How = How.XPath, Using = "//ul[@role='listbox']/li")]
        public IList<IWebElement> listCountry;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Save']")]
        public IWebElement btnSave;

        #endregion

        #region Tabs selector

        [FindsBy(How = How.XPath, Using = "//span[text()='General']/parent::a")]
        public IWebElement tabGeneral;

        [FindsBy(How = How.XPath, Using = "//span[text()='Security & Notifications']/parent::a")]
        public IWebElement tabSecurity;

        [FindsBy(How = How.XPath, Using = "//span[text()='Tickets']/parent::a")]
        public IWebElement tabTickets;

        [FindsBy(How = How.XPath, Using = "//span[text()='Credit']/parent::a")]
        public IWebElement tabCredit;

        [FindsBy(How = How.XPath, Using = "//span[text()='Referral']/parent::a")]
        public IWebElement tabReferral;

        [FindsBy(How = How.XPath, Using = "//span[text()='Coupon']/parent::a")]
        public IWebElement tabCoupon;

        [FindsBy(How = How.XPath, Using = "//span[text()='Payments']/parent::a")]
        public IWebElement tabPayments;


        #endregion

        #region Edit User

        [FindsBy(How = How.XPath, Using = "//p[text()='New password']/parent::div//input[@id='user-general-input']")]
        public IWebElement inputNewPassword;

        [FindsBy(How = How.XPath, Using = "//p[text()='Confirm new password']/parent::div//input[@id='user-general-input']")]
        public IWebElement inputConfirmPassword;

        [FindsBy(How = How.XPath, Using = "//span[text()='Save Changes']/parent::button")]
        public IWebElement btnSaveChanges;

        [FindsBy(How = How.XPath, Using = "//span[text()='Add Ticket']/parent::button")]
        public IWebElement btnAddTicket;

        [FindsBy(How = How.XPath, Using = "//span[text()='Add Tickets']/parent::button")]
        public IWebElement btnAddTicketsInPopUp;

        [FindsBy(How = How.Name, Using = "competition")]
        public IWebElement cbbxCompetition;

        [FindsBy(How = How.XPath, Using = "//div/ul/li")]
        public IList<IWebElement> listCompetitions;

        [FindsBy(How = How.Name, Using = "product")]
        public IWebElement cbbxProduct;

        [FindsBy(How = How.XPath, Using = "//p[text()='Tickets']/parent::div//input")]
        public IWebElement inputNumberOfTickets;

        [FindsBy(How = How.XPath, Using = "//span[text()='Add Credits']/parent::button")]
        public IWebElement btnAddCredits;

        [FindsBy(How = How.XPath, Using = "//p[text()='Credits']/parent::div//input")]
        public IWebElement inputNumberOfCredits;

        [FindsBy(How = How.XPath, Using = "//p[text()='Description']/parent::div//div[@class='DraftEditor-root']//span")]
        public IWebElement inputCreditDescription;

        [FindsBy(How = How.XPath, Using = "//div[@role='dialog']//span[text()='Save']/parent::button")]
        public IWebElement btnSaveInPopup;

        [FindsBy(How = How.XPath, Using = "//div[@role='dialog']//span[text()='Cancel']/parent::button")]
        public IWebElement btnCancelInPopup;

        [FindsBy(How = How.XPath, Using = "//div/span[3]//h6[text()='No ']")]
        public IWebElement textNoOrders;

        [FindsBy(How = How.XPath, Using = "//div[text()='View Tickets']/ancestor::div[@class='MuiDialogContent-root']//table//td[6]")]
        public IList<IWebElement> btnDeletePopUp;


        #endregion
    }
}