using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class ThankYou
    {
        public void VerifyThankYouPageIsDisplayed()
        {
            WaitUntil.CustomElementIsVisible(titleThankYouPage);
            Assert.IsTrue(AssertHelper.ElementIsVisible(titleThankYouPage));

        }
    }
}