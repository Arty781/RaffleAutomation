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
            WaitUntil.CustomElevemtIsVisible(Pages.Header.UserFirstNameBtn);
            
            Assert.IsTrue(Pages.Header.UserFirstNameBtn.Displayed);
            Console.WriteLine(Pages.Header.UserFirstNameBtn.Displayed);
            

            return this;
        }
    }
}
