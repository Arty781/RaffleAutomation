using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Profile
    {
        #region My Details 

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'My Details')]")]
        public IWebElement titleProfile;

        [FindsBy(How = How.XPath, Using = "//button[@data-edit='personal']")]
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

        [FindsBy(How = How.XPath, Using = "//div[@aria-haspopup='listbox']")]
        public IWebElement cbbxCountry;

        [FindsBy(How = How.XPath, Using = "//input[@value='emailCommunication']")]
        public IWebElement inputEmailCommunication;

        [FindsBy(How = How.XPath, Using = "//input[@value='corporateNotification']")]
        public IWebElement inputCorporateNotification;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'savingNewPassword visible')]")]
        public IWebElement btnSave;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Profile info update success')]")]
        public IWebElement SuccessUpdateDialog;

        [FindsBy(How=How.Id,Using = "outlined-basic-helper-text")]
        public IWebElement textErrorMessage;

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
    }
}
