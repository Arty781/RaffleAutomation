using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
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

        public IWebElement EditAccountBtn => Browser._Driver.FindElement(_AccountEditBtn);
        public readonly static By _AccountEditBtn = By.XPath("//button[@data-edit='account']");

        public IWebElement EmailInput => Browser._Driver.FindElement(_EmailInput);
        public readonly static By _EmailInput = By.XPath("//input[@name='email']");

        public IWebElement PhoneInput => Browser._Driver.FindElement(_PhoneInput);
        public readonly static By _PhoneInput = By.XPath("//input[@name='phone']");

        public IWebElement EmailCommunication => Browser._Driver.FindElement(_EmailCommunication);
        public readonly static By _EmailCommunication = By.XPath("//*[@value='emailCommunication']");

        public IWebElement CorporateNotification => Browser._Driver.FindElement(_CorporateNotification);
        public readonly static By _CorporateNotification = By.XPath("//*[@value='corporateNotification']");

        public IWebElement SaveBtn => Browser._Driver.FindElement(_SaveBtn);
        public readonly static By _SaveBtn = By.XPath("//button[contains(@class,'savingNewPassword visible')]");

        public IWebElement SuccessUpdateDialog => Browser._Driver.FindElement(_SuccessUpdateDialog);
        public readonly static By _SuccessUpdateDialog = By.XPath("//div[contains(text(), 'Profile info update success')]");

        #endregion
    }
}
