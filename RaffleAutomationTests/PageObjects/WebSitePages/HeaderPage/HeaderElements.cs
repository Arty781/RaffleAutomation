namespace RaffleAutomationTests.PageObjects
{
    public partial class Header
    {

#if DEBUG || RELEASE || CHROME || FIREFOX

        [FindsBy(How = How.XPath, Using = "//a[@class='headerLogo']")]
        public IWebElement logo;

        [FindsBy(How = How.XPath, Using = "//button[@class='headerBurgerMenu']")]
        public IWebElement btnBurgerMenu;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'toggle-live-btn toggle-live-btn-desk')]")]
        public IWebElement liveCompetitionsList;

        [FindsBy(How = How.XPath, Using = "//a[@href='/dreamhome']")]
        public IWebElement linkDreamHome;

        [FindsBy(How = How.XPath, Using = "//nav[@class='headerNav']/a[@href='/winners']")]
        public IWebElement winnersLink;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn entry-button']")]
        public IWebElement freeEntryBtn;

        [FindsBy(How = How.XPath, Using = "//button[@class='headerBtnCart']")]
        public IWebElement btnCart;

        [FindsBy(How = How.XPath, Using = "//button[@class='dropdownAccount ']")]
        public IWebElement btnDropDownAccount;

        [FindsBy(How = How.XPath, Using = "//button[text()='Logout']")]
        public IWebElement btnLogOut;
#endif

#if DEBUG_MOBILE

        [FindsBy(How = How.XPath, Using = "//a[@class='headerLogo']")]
        public IWebElement logo;

        [FindsBy(How=How.XPath,Using = "//button[@class='headerBurgerMenu']")]
        public IWebElement btnHeaderBurgerMenu;

        [FindsBy(How = How.XPath, Using = "//div[@class='headerSidebarMenu']/button[contains(@class,'toggle-live-btn')]")]
        public IWebElement liveCompetitionsList;

        [FindsBy(How = How.XPath, Using = "//button[text()='Dream Home']")]
        public IWebElement linkDreamHome;

        [FindsBy(How = How.XPath, Using = "//button[text()='Winners']")]
        public IWebElement winnersLink;

        [FindsBy(How = How.XPath, Using = "//nav[@class='headerNav']/a[@href='https://help.rafflehouse.com']")]
        public IWebElement linkFAQs;

        [FindsBy(How = How.XPath, Using = "//nav[@class='headerNav']/a[@href='/about-us']")]
        public IWebElement linkAboutUs;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn secondary']")]
        public IWebElement signInBtn;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn primary']")]
        public IWebElement signUpBtn;

        [FindsBy(How = How.XPath, Using = "//button[text()='free entry']")]
        public IWebElement freeEntryBtn;

        [FindsBy(How = How.XPath, Using = "//button[@class='btnSidebarDropdown ']/div[@class='header-drop-name']")]
        public IWebElement btnDropDownAccount;

        [FindsBy(How = How.XPath, Using = "//button[text()='Logout']")]
        public IWebElement btnLogOut;

        [FindsBy(How = How.XPath, Using = "//button[@class='headerBtnCart']")]
        public IWebElement btnCart;

        [FindsBy(How=How.XPath,Using = "//div/img[@class='header-user-icon']")]
        public IWebElement btnProfile;



#endif
    }
}
