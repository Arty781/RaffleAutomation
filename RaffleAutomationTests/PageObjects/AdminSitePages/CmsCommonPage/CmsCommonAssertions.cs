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
            WaitUntil.CustomElementIsVisible(tbPrizeManagement);
            Assert.IsTrue(tbPrizeManagement.Displayed);
            return this;
        }

        [AllureStep("Verify that dreamhome {0} created successfully")]
        public CmsCommon VerifyIsDreamhomeCreatedSuccessfully(string dreamhomeTitle)
        {
            WaitUntil.VisibilityOfAllElementsLocatedBy(By.XPath("//td"));
            goToLastPageBtn.Click();
            WaitUntil.WaitSomeInterval(5);
            IReadOnlyCollection<IWebElement> dreamhomeList = Browser._Driver.FindElements(By.XPath("//td"));
            
            foreach (var dreamhome in dreamhomeList)
            {
                if(dreamhome.Text == dreamhomeTitle)
                {
                    Console.WriteLine("Dreamhome title is " + "\"" +dreamhome.Text + "\"");
                    break;
                }
                
            }
            return this;
        }
    }
}
