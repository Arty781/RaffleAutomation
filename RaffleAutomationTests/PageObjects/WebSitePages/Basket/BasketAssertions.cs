using NUnit.Framework;
using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using RimuTec.Faker;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Basket
    {
       
        public Basket VerifyErrorMessageIsDisplayed()
        {
            

            WaitUntil.CustomElementIsVisible(Pages.Common.toaster);
            Console.WriteLine(Pages.Common.toaster.Text);
            WaitUntil.CustomElementIsVisible(checkOutNowBtn);

            return this;
        }
    }
}
