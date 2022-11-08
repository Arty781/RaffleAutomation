using NUnit.Framework;
using OpenQA.Selenium;
using PutsboxWrapper;
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
        public static string GetEmail()
        {
            string getEmail = Browser._Driver.FindElement(By.XPath("//input[@name='email']")).GetAttribute("value");
            string email = getEmail.ToLower();

            return email;
        }


        public SignUp VerifyEmail(string email)
        {
            WaitUntil.CustomElementIsVisible(Pages.Profile.titleProfile);
            string emailFld = inputEmail.GetAttribute("value").ToLower();

            Assert.AreEqual(email, emailFld);

            return this;
        }

        public SignUp VerifyVisibilityOfToaster(string email)
        {
            string s = Putsbox.GetLinkFromEmailWithValue(email, "Verify");
            Browser._Driver.Navigate().GoToUrl(s);
            WaitUntil.CustomElementIsVisible(toasterSuccessMessage);
            

            return this;
        }
    }
}
