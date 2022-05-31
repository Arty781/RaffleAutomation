using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class SignUp
    {
        public IWebElement InputEmail => Browser._Driver.FindElement(_InputEmail);
        public readonly static By _InputEmail = By.XPath("//input[@name='email']");

        public IWebElement InputPassword => Browser._Driver.FindElement(_InputPassword);
        public readonly static By _InputPassword = By.XPath("//input[@name='password']");

        public IWebElement InputFirstName => Browser._Driver.FindElement(_InputFirstName);
        public readonly static By _InputFirstName = By.XPath("//input[@name='name']");

        public IWebElement InputSurname => Browser._Driver.FindElement(_InputSurname);
        public readonly static By _InputSurname = By.XPath("//input[@name='surname']");

        public IWebElement SignUpBtn => Browser._Driver.FindElement(_SignUpBtn);
        public readonly static By _SignUpBtn = By.XPath("//*[@class='rafflebtn primary full-width']");

        public IWebElement confirmAgeBtn => Browser._Driver.FindElement(_confirmAgeBtn);
        public readonly static By _confirmAgeBtn = By.XPath("//div[@class='agreeBlock']/label[1]//input[@type='checkbox']");

        public IWebElement confirmOptBtn => Browser._Driver.FindElement(_confirmOptBtn);
        public readonly static By _confirmOptBtn = By.XPath("//div[@class='agreeBlock']/label[2]//input[@type='checkbox']");

        public IWebElement rememberBtn => Browser._Driver.FindElement(_rememberBtn);
        public readonly static By _rememberBtn = By.XPath("//div[@class='agreeRemebmer']//input[@type='checkbox']");

        public IWebElement countryList => Browser._Driver.FindElement(_countryList);
        public readonly static By _countryList = By.XPath("//ul//li[contains(text(),'Ukraine')]");

        public IWebElement countryInput => Browser._Driver.FindElement(_countryInput);
        public readonly static By _countryInput = By.XPath("//div[@aria-haspopup='listbox']");

        public IWebElement phoneInput => Browser._Driver.FindElement(_phoneInput);
        public readonly static By _phoneInput = By.XPath("//input[@class='phone-input']");
    }
}
