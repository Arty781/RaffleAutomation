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

        public IWebElement PersonalEditBtn => Browser._Driver.FindElement(_PersonalEditBtn);
        public readonly static By _PersonalEditBtn = By.XPath("//div[@class='my-details-item personal-details']/*/button[@data-edit]");

        public IWebElement FirstNameInput => Browser._Driver.FindElement(_FirstNameInput);
        public readonly static By _FirstNameInput = By.XPath("//div[@class='my-details-item personal-details']/*/div[1]/div/*[@id]");

        public IWebElement LastNameInput => Browser._Driver.FindElement(_LastNameInput);
        public readonly static By _LastNameInput = By.XPath("//div[@class='my-details-item personal-details']/*/div[2]/div/*[@id]");

        public IWebElement PasswordEditBtn => Browser._Driver.FindElement(_PasswordEditBtn);
        public readonly static By _PasswordEditBtn = By.XPath("//div[@class='my-details-item personal-passwords']/*/button[@data-edit]");

        public IWebElement CurrentPasswordInput => Browser._Driver.FindElement(_CurrentPasswordInput);
        public readonly static By _CurrentPasswordInput = By.XPath("//div[1]/label/div/div/*[@id='outlined-basic']");

        public IWebElement NewPasswordInput => Browser._Driver.FindElement(_NewPasswordInput);
        public readonly static By _NewPasswordInput = By.XPath("//div[2]/label/div/div/*[@id='outlined-basic']");

        public IWebElement ConfirmPasswordInput => Browser._Driver.FindElement(_ConfirmPasswordInput);
        public readonly static By _ConfirmPasswordInput = By.XPath("//div[3]/label/div/div/*[@id='outlined-basic']");

        public IWebElement AccountEditBtn => Browser._Driver.FindElement(_AccountEditBtn);
        public readonly static By _AccountEditBtn = By.XPath("//div[@class='my-details-item account-details']/*/button[@data-edit]");

        public IWebElement EmailInput => Browser._Driver.FindElement(_EmailInput);
        public readonly static By _EmailInput = By.XPath("//div[@class='my-details-item account-details']/*/div[1]/div/*[@id]");

        public IWebElement PhoneInput => Browser._Driver.FindElement(_PhoneInput);
        public readonly static By _PhoneInput = By.XPath("//div[@class='my-details-item account-details']/*/div[2]/div/*[@id]");

        public IWebElement EmailCommunication => Browser._Driver.FindElement(_EmailCommunication);
        public readonly static By _EmailCommunication = By.XPath("//*[@value='emailCommunication']");

        public IWebElement CorporateNotification => Browser._Driver.FindElement(_CorporateNotification);
        public readonly static By _CorporateNotification = By.XPath("//*[@value='corporateNotification']");

        #endregion
    }
}
