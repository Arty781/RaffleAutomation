using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.WEB.CommonPage
{
    public partial class Common
    {
        public const string confirmCookieBtn = "//button[@class='cookie-close-button']";
        public const string toaster = "//div[contains(text(), 'Error')]/parent::div/div[2]";
    }
}
