using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects._3rdPartyPage.Klaviyo
{
    public partial class Klaviyo
    {
        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement inputEmail;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//div[@class='recaptcha-checkbox-checkmark']")]
        public IWebElement recapcha;

        [FindsBy(How = How.Id, Using = "submit-button")]
        public IWebElement btnSubmit;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'qatester-2023')]/ancestor::td")]
        public IList<IWebElement> rowUser;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Delete Profile')]")]
        public IWebElement btnDeleteProfile;

        [FindsBy(How = How.XPath, Using = "//input[@value='Delete Person']")]
        public IWebElement btnDletePerson;

        [FindsBy(How = How.XPath, Using = "//div/span[contains(text(),'Home')]")]
        public IWebElement titleHome;
    }
}
