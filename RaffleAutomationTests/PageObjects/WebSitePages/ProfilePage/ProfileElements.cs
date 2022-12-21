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
    public partial class Profile
    {
        #region My Details 

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'My Details')]")]
        public IWebElement titleProfile;

        [FindsBy(How=How.XPath,Using = "//button[@data-edit='personal']")]
        public IWebElement EditPersonalBtn;

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement FirstNameInput;

        [FindsBy(How = How.Name, Using = "surname")]
        public IWebElement LastNameInput;

        [FindsBy(How = How.XPath, Using = "//button[@data-edit='password']")]
        public IWebElement EditPasswordBtn;

        [FindsBy(How = How.Name, Using = "oldPassword")]
        public IWebElement CurrentPasswordInput;

        [FindsBy(How = How.Name, Using = "newPassword")]
        public IWebElement NewPasswordInput;

        [FindsBy(How = How.Name, Using = "confirmPassword")]
        public IWebElement ConfirmPasswordInput;

        [FindsBy(How = How.XPath, Using = "//button[@data-edit='account']")]
        public IWebElement btnEditAccount;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement inputEmail;

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement inputPhone;

        [FindsBy(How = How.Name, Using = "country")]
        public IWebElement inputCountry;

        [FindsBy(How = How.XPath, Using = "//input[@value='emailCommunication']")]
        public IWebElement inputEmailCommunication;

        [FindsBy(How = How.XPath, Using = "//input[@value='corporateNotification']")]
        public IWebElement inputCorporateNotification;

        [FindsBy(How=How.XPath,Using = "//button[contains(@class,'savingNewPassword visible')]")]
        public IWebElement btnSave;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Profile info update success')]")]
        public IWebElement SuccessUpdateDialog;

        #endregion

        #region Order History

        [FindsBy(How=How.XPath,Using = "//span[text()='Order History']/parent::button")]
        public IWebElement tabOrderHistory;

        [FindsBy(How = How.XPath, Using = "//span[text()='Dream Home']/parent::div")]
        public IWebElement listDreamHomeHistory;

        [FindsBy(How = How.XPath, Using = "//span[text()='Lifestyle Competitions']/parent::div")]
        public IWebElement listWeeklyHistory;

        [FindsBy(How = How.XPath, Using = "//span[text()='Fixed Odds']/parent::div")]
        public IWebElement listFixedOddsHistory;

        [FindsBy(How = How.XPath, Using = "//table[@class='historyAreaTable']/tbody/tr/td[1]")]
        public IWebElement prizeName;

        [FindsBy(How = How.XPath, Using = "//table[@class='historyAreaTable']/tbody/tr/td[3]")]
        public IWebElement prizeTickets;

        [FindsBy(How = How.XPath, Using = "//table[@class='historyAreaTable']/tbody/tr/td[4]")]
        public IList<IWebElement> prizePrice;

        #endregion
    }
}
