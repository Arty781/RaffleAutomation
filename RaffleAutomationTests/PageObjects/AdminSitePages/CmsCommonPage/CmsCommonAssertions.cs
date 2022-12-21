using NUnit.Allure.Steps;
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
    public partial class CmsCommon
    {
        [AllureStep("Verify is login successfully")]
        public CmsCommon VerifyIsLoginSuccessfull()
        {
            WaitUntil.CustomElementIsVisible(pagePrizeManagement);
            Assert.IsTrue(pagePrizeManagement.Displayed);
            return this;
        }

        [AllureStep("Verify that dreamhome {0} created successfully")]
        public CmsCommon VerifyIsDreamhomeCreatedSuccessfully(string dreamhomeTitle)
        {
            //Button.Click(btnLastPage);
            WaitUntil.CustomElementIsVisible(Element.FindSpecificDreamhome(dreamhomeTitle), 20);
            Assert.IsTrue(dreamhomeTitle == Element.FindSpecificDreamhome(dreamhomeTitle).Text);
            return this;
        }
    }
}
