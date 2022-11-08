using AngleSharp.Dom;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
       public Dreamhome OpenDreamHomePage()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.DREAMHOME);

            return this;
        }

        [AllureStep("Open ticket selector")]
        public Dreamhome OpenDreamHomeTicketSelector()
        {
            Button.Click(btnDreamHome);

            return this;
        }


        [AllureStep("Select first bundle")]
        public Dreamhome SelectFirstBundleBtn()
        {
            Button.Click(btnFirstBundle);

            return this;
        }

        [AllureStep("Select second bundle")]
        public Dreamhome SelectSecondBundleBtn()
        {
            Button.Click(btnSecondBundle);

            return this;
        }

        [AllureStep("Select third bundle")]
        public Dreamhome SelectThirdBundleBtn()
        {
            Button.Click(btnThirdBundle);

            return this;
        }

        [AllureStep("Select forth bundle")]
        public Dreamhome SelectForthBundleBtn()
        {
            Button.Click(btnFourthBundle);

            return this;
        }
        #endregion

    }
}
