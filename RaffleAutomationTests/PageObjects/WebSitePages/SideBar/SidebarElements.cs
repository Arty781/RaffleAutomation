namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public class SidebarElements
    {
        [FindsBy(How = How.XPath, Using = "//button[text()='Sign In']")]
        public IWebElement btnSignIn;

        [FindsBy(How = How.XPath, Using = "//button[text()='Sign Up']")]
        public IWebElement btnSignUp;

        [FindsBy(How = How.XPath, Using = "//button[@class='freeEntryBtn']")]
        public IWebElement btnFreeEntry;

        [FindsBy(How = How.XPath, Using = "//button[@class='headerBtnCart']")]
        public IWebElement btnBasket;

        [FindsBy(How = How.XPath, Using = "//span[text()='Home']/parent::button")]
        public IWebElement btnHomeList;

        [FindsBy(How = How.XPath, Using = "//button[text()='Dream Home']")]
        public IWebElement btnDreamHomeLink;

        [FindsBy(How = How.XPath, Using = "//button[text()='Winners']")]
        public IWebElement btnWinners;

        [FindsBy(How = How.XPath, Using = "//button[text()='Contact']")]
        public IWebElement btnContact;

        [FindsBy(How = How.XPath, Using = "//button[text()='T&Cs']")]
        public IWebElement btnTermsConditions;

        [FindsBy(How = How.XPath, Using = "Privacy Policy")]
        public IWebElement btnPrivacyPolicy;

        [FindsBy(How = How.XPath, Using = "//button[text()='Logout']")]
        public IWebElement btnLogout;

        [FindsBy(How = How.XPath, Using = "//button[@class='btnSidebarDropdown ']")]
        public IWebElement btnProfileDropdownList;

        #region Profile dropdown list

        [FindsBy(How = How.XPath, Using = "//button[text()='Back to Menu']")]
        public IWebElement btnBackToMenu;

        [FindsBy(How = How.XPath, Using = "//button[text()='My Tickets & Competitions']")]
        public IWebElement btnMyTicketsAndCompetitions;

        [FindsBy(How = How.XPath, Using = "//button[text()='My Details']")]
        public IWebElement btnMyDetails;

        #endregion

    }
}
