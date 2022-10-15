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

        public IWebElement EditPersonalBtn => Browser._Driver.FindElement(_PersonalEditBtn);
        public readonly static By _PersonalEditBtn = By.XPath("//button[@data-edit='personal']");

        public IWebElement FirstNameInput => Browser._Driver.FindElement(_FirstNameInput);
        public readonly static By _FirstNameInput = By.XPath("//div[@class='my-details-item personal-details']/*/div[1]/div/*[@id]");

        public IWebElement LastNameInput => Browser._Driver.FindElement(_LastNameInput);
        public readonly static By _LastNameInput = By.XPath("//div[@class='my-details-item personal-details']/*/div[2]/div/*[@id]");

        public IWebElement EditPasswordBtn => Browser._Driver.FindElement(_PasswordEditBtn);
        public readonly static By _PasswordEditBtn = By.XPath("//button[@data-edit='password']");

        public IWebElement CurrentPasswordInput => Browser._Driver.FindElement(_CurrentPasswordInput);
        public readonly static By _CurrentPasswordInput = By.XPath("//input[@name='oldPassword']");

        public IWebElement NewPasswordInput => Browser._Driver.FindElement(_NewPasswordInput);
        public readonly static By _NewPasswordInput = By.XPath("//input[@name='newPassword']");

        public IWebElement ConfirmPasswordInput => Browser._Driver.FindElement(_ConfirmPasswordInput);
        public readonly static By _ConfirmPasswordInput = By.XPath("//input[@name='confirmPassword']");

        [FindsBy(How = How.XPath, Using = "//button[@data-edit='account']")]
        public IWebElement btnEditAccount;

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        public IWebElement inputEmail;

        [FindsBy(How = How.XPath, Using = "//input[@name='phone']")]
        public IWebElement inputPhone;

        [FindsBy(How = How.XPath, Using = "//input[@name='country']")]
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
    }
}
