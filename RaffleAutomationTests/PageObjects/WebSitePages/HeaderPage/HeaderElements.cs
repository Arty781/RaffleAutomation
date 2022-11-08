using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Header
    {
        [FindsBy(How=How.XPath,Using = "//a[@class='headerLogo']")]
        public IWebElement logo;

        [FindsBy(How=How.XPath,Using = "//button[contains(@class,'toggle-live-btn toggle-live-btn-desk')]")]
        public IWebElement liveCompetitionsList;

        [FindsBy(How=How.XPath,Using = "//a[@href='/dreamhome']")]
        public IWebElement linkDreamHome;

        [FindsBy(How = How.XPath, Using = "//a[@href='/lifestyleprizes']")]
        public IWebElement linkWeekly;

        [FindsBy(How = How.XPath, Using = "//a[@href='/fixedodds']")]
        public IWebElement linkFixedOdds;

        [FindsBy(How = How.XPath, Using = "//nav[@class='headerNav']/a[@href='/winners']")]
        public IWebElement winnersLink;

        [FindsBy(How = How.XPath, Using = "//nav[@class='headerNav']/a[@href='https://help.rafflehouse.com']")]
        public IWebElement linkFAQs;

        [FindsBy(How = How.XPath, Using = "//nav[@class='headerNav']/a[@href='/about-us']")]
        public IWebElement linkAboutUs;

        [FindsBy(How=How.XPath,Using = "//button[@class='btnSignInHeader']")]
        public IWebElement signInBtn;

        [FindsBy(How=How.XPath,Using = "//a[@href='/sign-up']")]
        public IWebElement signUpBtn;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn entry-button']")]
        public IWebElement freeEntryBtn;

        [FindsBy(How=How.XPath,Using = "//button[@class='headerBtnCart']")]
        public static IWebElement btnCart;

        [FindsBy(How=How.XPath, Using = "//button[@class='dropdownAccount ']")]
        public IWebElement btnDropDownAccount;


    }
}
