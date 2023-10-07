using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.WEB.ThankYouPage
{
    public partial class ThankYou
    {
        public const string titleThankYouPage = "//h1[@class='orderCompleted']";
        public const string btnActivateMyAccount = "//button[text()='Activate My Account']";
        public const string btnViewTickets = "button.outlineBtnTickets";
    }
}
