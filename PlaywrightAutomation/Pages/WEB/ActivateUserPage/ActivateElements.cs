using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.WEB.ActivateUserPage
{
    public partial class Activate
    {
        public const string inputFirstName = "//input[@name='name']";
        public const string inputLastName = "//input[@name='surname']";
        public const string inputEmail = "//input[@name='email']";
        public const string inputPhone = "//input[@type='tel']";
        public const string inputPassword = "//input[@name='password']";
        public const string btnActivateAccount = "//button[text()='Activate account']";
        public const string titleActivatedAccount = "//h1[text()='Account Activated']";
    }
}
