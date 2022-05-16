using NUnit.Framework;
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
        public static string GetEmail()
        {
            string getEmail = Browser._Driver.FindElement(By.XPath("//input[@name='email']")).GetAttribute("value");
            string email = getEmail.ToLower();

            return email;
        }

        public SignUp VerifyEmail(string email)
        {
            WaitUntil.VisibilityOfAllElementsLocatedBy(By.XPath("//h1[contains(text(),'My Details')]"));
            string emailFld = InputEmail.GetAttribute("value");

            Assert.AreEqual(email, emailFld);

            return this;
        }
    }
}
