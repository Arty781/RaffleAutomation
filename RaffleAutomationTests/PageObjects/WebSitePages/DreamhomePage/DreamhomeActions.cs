using NUnit.Allure.Steps;
using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Dreamhome
    {
        #region Ticket Selector
        [AllureStep("Open Dreamhome product page")]
       public Dreamhome OpenDreamHomeProductPage()
        {
            WaitUntil.ElementIsVisible(_raffleBtn);
            Browser._Driver.SwitchTo().Equals(raffleBtn);
            raffleBtn.Click();

            return this;
        }

        [AllureStep("Open ticket selector")]
        public Dreamhome OpenDreamHomeTicketSelector()
        {
            WaitUntil.ElementIsVisible(_enterNowDreamhomeBtn);
            enterNowDreamhomeBtn.Click();

            return this;
        }


        [AllureStep("Select first bundle")]
        public Dreamhome SelectFirstBundleBtn()
        {
            WaitUntil.ElementIsVisible(_firstBundleBtn);
            firstBundleBtn.Click();

            return this;
        }

        [AllureStep("Select second bundle")]
        public Dreamhome SelectSecondBundleBtn()
        {
            WaitUntil.ElementIsVisible(_secondBundleBtn);
            secondBundleBtn.Click();

            return this;
        }

        [AllureStep("Select third bundle")]
        public Dreamhome SelectThirdBundleBtn()
        {
            WaitUntil.ElementIsVisible(_thirdBundleBtn);
            thirdBundleBtn.Click();

            return this;
        }

        [AllureStep("Select forth bundle")]
        public Dreamhome SelectForthBundleBtn()
        {
            WaitUntil.ElementIsVisible(_forthBundleBtn);
            forthBundleBtn.Click();

            return this;
        }
        #endregion

    }
}
