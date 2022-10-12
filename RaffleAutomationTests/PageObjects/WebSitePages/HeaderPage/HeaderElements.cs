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
        public IWebElement logo => Browser._Driver.FindElement(_logo);
        public readonly static By _logo = By.XPath("//*[@class='headerLogo']");

        public IWebElement liveCompetitionsList => Browser._Driver.FindElement(_liveCompetitionsList);
        public readonly static By _liveCompetitionsList = By.XPath("//*[@class='toggle-live-btn toggle-live-btn-desk false']");

        public IWebElement dreamHomeLink => Browser._Driver.FindElement(_dreamHomeLink);
        public readonly static By _dreamHomeLink = By.XPath("//a/span[contains(text(), 'Dream Home')]");

        public IWebElement weeklyLink => Browser._Driver.FindElement(_weeklyLink);
        public readonly static By _weeklyLink = By.XPath("//a/span[contains(text(), 'Weekly Prizes')]");

        public IWebElement fixedOddsLink => Browser._Driver.FindElement(_fixedOddsLink);
        public readonly static By _fixedOddsLink = By.XPath("//a/span[contains(text(), 'Fixed Odds')]");

        public IWebElement winnersLink => Browser._Driver.FindElement(_winnersLink);
        public readonly static By _winnersLink = By.XPath("//*[@class='headerNav']/a[1]");

        public IWebElement faqsLink => Browser._Driver.FindElement(_faqsLink);
        public readonly static By _faqsLink = By.XPath("//*[@class='headerNav']/a[2]");

        public IWebElement aboutLink => Browser._Driver.FindElement(_aboutLink);
        public readonly static By _aboutLink = By.XPath("//*[@class='headerNav']/a[3]");

        public IWebElement signInBtn => Browser._Driver.FindElement(_signInBtn);
        public readonly static By _signInBtn = By.XPath("//*[@class='headerAuth']/div/button[1]");

        public IWebElement signUpBtn => Browser._Driver.FindElement(_signUpBtn);
        public readonly static By _signUpBtn = By.XPath("//*[@class='headerAuth']/div/a");

        public IWebElement freeEntryBtn => Browser._Driver.FindElement(_freeEntryBtn);
        public readonly static By _freeEntryBtn = By.XPath("//*[@class='headerAuth']/div/button[1]");

        public static IWebElement btnCart => Browser._Driver.FindElement(_btnCart);
        public readonly static By _btnCart = By.XPath("//button[@class='headerBtnCart']");

        [FindsBy(How=How.XPath, Using = "//div[@class='header-drop-name']/span[1]")]
        public IWebElement UserFirstNameBtn;

        public IWebElement UserLastNameBtn => Browser._Driver.FindElement(_UserLastNameBtn);
        public readonly static By _UserLastNameBtn = By.XPath("//div[@class='header-drop-name']/span[2]");

    }
}
