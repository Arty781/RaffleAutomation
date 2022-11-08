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
    public partial class SignUp
    {
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement inputEmail;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement inputPassword;

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement inputFirstName;

        [FindsBy(How = How.Name, Using = "surname")]
        public IWebElement inputSurname;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn primary full-width']")]
        public IWebElement btnSignUp;

        //public IWebElement confirmAgeBtn => Browser._Driver.FindElement(_confirmAgeBtn);
        //public readonly static By _confirmAgeBtn = By.XPath("//div[@class='agreeBlock']/label[1]//input[@type='checkbox']");

        [FindsBy(How = How.XPath, Using = "//div[@class='agreeBlock']/label[1]//input[@type='checkbox']")]
        public IWebElement btnConfirmOpt;

        [FindsBy(How = How.XPath, Using = "//div[@class='agreeRemebmer']//input[@type='checkbox']")]
        public IWebElement btnRememberMe;

        [FindsBy(How = How.XPath, Using = "//ul//li[contains(text(),'Ukraine')]")]
        public IWebElement listCountry;

        [FindsBy(How = How.XPath, Using = "//div[@aria-haspopup='listbox']")]
        public IWebElement inputCountry;

        [FindsBy(How = How.XPath, Using = "//input[@class='phone-input']")]
        public IWebElement inputPhone;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Email verified successfully')]")]
        public IWebElement toasterSuccessMessage;
    }
}
