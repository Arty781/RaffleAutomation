using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.WEB.SignUpPage
{
    public partial class SignUp
    {
        public const string inputEmail = "//input[@name='email']";
        public const string inputPassword = "//input[@name='password']";
        public const string inputFirstName = "//input[@name='name']";
        public const string inputSurname = "//input[@name='surname']";
        public const string btnSignUp = "//button[@class='rafflebtn primary full-width']";
        public const string btnCloseSignUpPopup = "//button[@class='close-sign-up']";
        public const string btnConfirmOpt = "//div[@class='agreeBlock']/label[1]//input[@type='checkbox']";
        public const string btnRememberMe = "//div[@class='agreeRemebmer']//input[@type='checkbox']";
        public const string listCountry = "//ul[@role='listbox']/li[contains(text(),'Ukraine')]";
        public const string listCountryAll = "//ul[@role='listbox']/li";
        public const string inputCountry = "//div[@aria-haspopup='listbox']";
        public const string inputPhone = "//input[@class='phone-input']";
        public const string toasterSuccessMessage = "//div[contains(text(),'Email verified successfully')]";
        public const string textFirstNameErrorMessage = "//label[contains(text(), 'First name')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textLastNameErrorMessage = "//label[contains(text(), 'Last name')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textEmailErrorMessage = "//label[contains(text(), 'Email')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textPhoneErrorMessage = "//label[contains(text(), 'Phone')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textPasswordErrorMessage = "//label[contains(text(), 'Password')]/parent::div/p[@id='outlined-basic-helper-text']";
    }
}
