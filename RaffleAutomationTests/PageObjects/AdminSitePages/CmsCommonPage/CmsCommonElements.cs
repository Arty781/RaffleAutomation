namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsCommon
    {
        #region SideBarMenu

        [FindsBy(How = How.XPath, Using = "//li[@role='menuitem']//span[contains(text(),'Prize Management')]")]
        public IWebElement pagePrizeManagement;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/dreamHome']")]
        public IWebElement pageDreamHome;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/dreamHome/create/3']")]
        public IWebElement tabDiscount;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/prizes']")]
        public IWebElement pagePrizes;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/fixedOdds']")]
        public IWebElement pageFixedOdds;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/competitions']")]
        public IWebElement pageCompetitions;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/users']")]
        public IWebElement pageUsers;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/staffUsers']")]
        public IWebElement pageStaff;

        [FindsBy(How = How.XPath, Using = "//li[@role='menuitem']//span[contains(text(),'Settings')]")]
        public IWebElement pageSettings;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/general']")]
        public IWebElement pageSettingsGeneral;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/winners']")]
        public IWebElement pageSettingsWinners;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/referrals']")]
        public IWebElement pageSettingsReferrals;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/reports']")]
        public IWebElement pageSettingsReports;


        #endregion

        #region Save, Remove and Cancel btns

        [FindsBy(How = How.XPath, Using = "//span[text()='Save']/parent::button")]
        public IWebElement btnSave;

        [FindsBy(How = How.XPath, Using = "//span[text()='Save Changes']/parent::button")]
        public IWebElement btnSaveChanges;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Cancel')]/parent::button")]
        public IWebElement btnCancel;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Remove')]/parent::button")]
        public IWebElement btnRemove;

        #endregion

        #region Pagination

        [FindsBy(How = How.XPath, Using = "//div[@title='First Page']")]
        public IWebElement btnFirstPage;

        [FindsBy(How = How.XPath, Using = "//div[@title='Previous Page']")]
        public IWebElement btnPreviousPage;

        [FindsBy(How = How.XPath, Using = "//div[@title='Next Page']")]
        public IWebElement btnNextPage;

        [FindsBy(How = How.XPath, Using = "//div[@title='Last Page']")]
        public IWebElement btnLastPage;


        #endregion

        #region Alerts

        [FindsBy(How = How.XPath, Using = "//div[@role='alert']/div")]
        public IWebElement textAlertMessage;

        #endregion



    }
}
