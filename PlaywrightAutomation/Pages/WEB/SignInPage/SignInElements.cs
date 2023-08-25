using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.WEB.SignInPage
{
    public partial class SignIn
    {
        public const string inputLogin = "//input[@name='email']";
        public const string inputPassword = "//input[@name='password']";
        public const string btnSignIn = "//button[@class='rafflebtn primary full-width']";
        public const string checkboxPolicy = "//input[@type='checkbox']";
        public const string btnForgotPassword = "//span[contains(text(), 'Forgot password?')]";
        public const string textEmailErrorMessage = "//label[contains(text(), 'Email')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textPasswordErrorMessage = "//label[contains(text(), 'Password')]/parent::div/p[@id='outlined-basic-helper-text']";
    }
}
