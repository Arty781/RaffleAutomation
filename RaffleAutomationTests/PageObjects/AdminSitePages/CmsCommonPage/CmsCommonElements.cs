using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsCommon
    {
        #region SideBarMenu
        IWebElement prizeManagementBtn => Browser._Driver.FindElement(_prizeManagementBtn);
        public readonly By _prizeManagementBtn = By.XPath("//*/div[@class=\"menu-wrap\"]/li[1]");

        IWebElement dreamhomeBtn => Browser._Driver.FindElement(_dreamhomeBtn);
        public readonly By _dreamhomeBtn = By.XPath("//*/a[@href=\"#/dreamHome\"]");

        IWebElement lifestylePrizesBtn => Browser._Driver.FindElement(_lifestylePrizesBtn);
        public readonly By _lifestylePrizesBtn = By.XPath("//*/a[@href=\"#/prizes\"]");

        IWebElement fixedOddsBtn => Browser._Driver.FindElement(_fixedOddsBtn);
        public readonly By _fixedOddsBtn = By.XPath("//*/a[@href=\"#/fixedOdds\"]");

        IWebElement competitionsBtn => Browser._Driver.FindElement(_competitionsBtn);
        public readonly By _competitionsBtn = By.XPath("//*/a[@href=\"#/competitions\"]");

        IWebElement userManagementBtn => Browser._Driver.FindElement(_userManagementBtn);
        public readonly By _userManagementBtn = By.XPath("//*/a[@href=\"#/users\"]");

        IWebElement staffManagementBtn => Browser._Driver.FindElement(_staffManagementBtn);
        public readonly By _staffManagementBtn = By.XPath("//*/a[@href=\"#/staffUsers\"]");

        IWebElement settingsBtn => Browser._Driver.FindElement(_settingsBtn);
        public readonly By _settingsBtn = By.XPath("//*/div[@class=\"menu-wrap\"]/li[2]");

        IWebElement generalBtn => Browser._Driver.FindElement(_generalBtn);
        public readonly By _generalBtn = By.XPath("//*/a[@href=\"#/general\"]");

        IWebElement winnersBtn => Browser._Driver.FindElement(_winnersBtn);
        public readonly By _winnersBtn = By.XPath("//*/a[@href=\"#/winners\"]");

        IWebElement referralsBtn => Browser._Driver.FindElement(_referralsBtn);
        public readonly By _referralsBtn = By.XPath("//*/a[@href=\"#/referrals\"]");

        IWebElement reportsBtn => Browser._Driver.FindElement(_reportsBtn);
        public readonly By _reportsBtn = By.XPath("//*/a[@href=\"#/reports\"]");

        #endregion

    }
}
