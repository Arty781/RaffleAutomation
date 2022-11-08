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
    public partial class SignIn
    {
        public SignIn VerifyIsSignIn()
        {
            WaitUntil.CustomElementIsVisible(Pages.Profile.titleProfile);
            
            Assert.IsTrue(Pages.Profile.FirstNameInput.Displayed);
            

            return this;
        }
    }
}
