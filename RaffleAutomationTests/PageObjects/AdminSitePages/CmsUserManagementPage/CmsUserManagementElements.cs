using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsUserManagement
    {
        #region Add new User
        public IWebElement addUserBtn => Browser._Driver.FindElement(_addUserBtn);
        public readonly By _addUserBtn = By.XPath("//*/a[@aria-label=\"Add new\"]");

        public IWebElement firstNameInput => Browser._Driver.FindElement(_firstNameInput);
        public readonly By _firstNameInput = By.XPath("//*[@id=\"user-general-input\"][@name=\"name\"]");

        public IWebElement lastNameInput => Browser._Driver.FindElement(_lastNameInput);
        public readonly By _lastNameInput = By.XPath("//*[@id=\"user-general-input\"][@name=\"surname\"]");

        public IWebElement emailInput => Browser._Driver.FindElement(_emailInput);
        public readonly By _emailInput = By.XPath("//*[@id=\"user-general-input\"][@name=\"email\"]");

        public IWebElement phoneInput => Browser._Driver.FindElement(_phoneInput);
        public readonly By _phoneInput = By.XPath("//*[@id=\"user-general-input\"][@name=\"phone\"]");

        public IWebElement searchInput => Browser._Driver.FindElement(_searchInput);
        public readonly By _searchInput = By.XPath("//*[@//*[@id=\"search-input\"]");

        public IWebElement countryList => Browser._Driver.FindElement(_countryList);
        public readonly By _countryList = By.XPath("//*/ul[@role=\"listbox\"]");
        #endregion

        #region Tabs selector

        public IWebElement generalTab => Browser._Driver.FindElement(_generalTab);
        public readonly By _generalTab = By.XPath("//*/a[@role=\"tab\"][1]");

        public IWebElement securityTab => Browser._Driver.FindElement(_securityTab);
        public readonly By _securityTab = By.XPath("//*/a[@role=\"tab\"][2]");

        public IWebElement ticketsTab => Browser._Driver.FindElement(_ticketsTab);
        public readonly By _ticketsTab = By.XPath("//*/a[@role=\"tab\"][3]");

        public IWebElement creditlTab => Browser._Driver.FindElement(_creditTab);
        public readonly By _creditTab = By.XPath("//*/a[@role=\"tab\"][4]");

        public IWebElement referralTab => Browser._Driver.FindElement(_referralTab);
        public readonly By _referralTab = By.XPath("//*/a[@role=\"tab\"][5]");

        public IWebElement couponTab => Browser._Driver.FindElement(_couponTab);
        public readonly By _couponTab = By.XPath("//*/a[@role=\"tab\"][6]");


        #endregion

        #region Edit User

        public IWebElement newPassInput => Browser._Driver.FindElement(_newPassInput);
        public readonly By _newPassInput = By.XPath("//*[2]/div/div[1]/div[1]/div/div/div[1]/div");

        public IWebElement confirmPassInput => Browser._Driver.FindElement(_confirmPassInput);
        public readonly By _confirmPassInput = By.XPath("//*[2]/div/div[1]/div[2]/div/div/div[1]/div");

        public IWebElement saveBtn => Browser._Driver.FindElement(_saveBtn);
        public readonly By _saveBtn = By.XPath("//*[2]/div/div[2]/button");

        public IWebElement addTicketBtn => Browser._Driver.FindElement(_addTicketBtn);
        public readonly By _addTicketBtn = By.XPath("//*[3]/div/div/div[1]/button");

        public IWebElement competitionCbbx => Browser._Driver.FindElement(_competitionCbbx);
        public readonly By _competitionCbbx = By.XPath("//*/div[3]/div/div/div/div[2]/div/div");

        public IWebElement dreamhomeInList => Browser._Driver.FindElement(_dreamhomeInList);
        public readonly By _dreamhomeInList = By.XPath("//*/ul/li[1]");

        public IWebElement lifestyleInList => Browser._Driver.FindElement(_lifestyleInList);
        public readonly By _lifestyleInList = By.XPath("//*/ul/li[2]");

        public IWebElement fixedInList => Browser._Driver.FindElement(_fixedInList);
        public readonly By _fixedInList = By.XPath("//*/ul/li[3]");

        public IWebElement categoryCbbx => Browser._Driver.FindElement(_categoryCbbx);
        public readonly By _categoryCbbx = By.XPath("//*/div/div/div/div[3]/div/div");

        public IWebElement subCategoryCbbx => Browser._Driver.FindElement(_subCategoryCbbx);
        public readonly By _subCategoryCbbx = By.XPath("//*/div/div/div/div[4]/div/div");

        public IWebElement LifestyleProductCbbx => Browser._Driver.FindElement(_LifestyleProductCbbx);
        public readonly By _LifestyleProductCbbx = By.XPath("//*/div/div/div/div[5]/div/div");




        #endregion
    }
}