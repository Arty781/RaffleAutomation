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
    public partial class CmsCommon
    {
        #region Opening sidebar menu's tabs

        [AllureStep("Open PrizeManagement list")]
        public CmsCommon OpenPrizeManagementList()
        {
            WaitUntil.CustomElementIsVisible(pagePrizeManagement);
            pagePrizeManagement.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open DreamHome page")]
        public CmsCommon OpenDreamHomePage()
        {
            WaitUntil.CustomElementIsVisible(pageDreamHome);
            pageDreamHome.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open LifestylePrizes page")]
        public CmsCommon OpenLifestylePrizesPage()
        {
            WaitUntil.CustomElementIsVisible(pagePrizes);
            pagePrizes.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open Competitions page")]
        public CmsCommon OpenCompetitionsPage()
        {
            WaitUntil.CustomElementIsVisible(pageCompetitions);
            pageCompetitions.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open UserManagement page")]
        public CmsCommon OpenUserManagementPage()
        {
            WaitUntil.CustomElementIsVisible(pageUsers);
            pageUsers.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open StaffManagement page")]
        public CmsCommon OpenStaffManagementPage()
        {
            WaitUntil.CustomElementIsVisible(pageStaff);
            pageStaff.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open Settings list")]
        public CmsCommon OpenSettingsList()
        {
            WaitUntil.CustomElementIsVisible(pageSettings);
            pageSettings.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open General page")]
        public CmsCommon OpenGeneralPage()
        {
            WaitUntil.CustomElementIsVisible(pageSettingsGeneral);
            pageSettingsGeneral.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open Winners page")]
        public CmsCommon OpenWinnersPage()
        {
            WaitUntil.CustomElementIsVisible(pageSettingsWinners);
            pageSettingsWinners.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open Referrals page")]
        public CmsCommon OpenReferralsPage()
        {
            WaitUntil.CustomElementIsVisible(pageSettingsReferrals);
            pageSettingsReferrals.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Open Reports page")]
        public CmsCommon OpenReportsPage()
        {
            WaitUntil.CustomElementIsVisible(pageSettingsReports);
            pageSettingsReports.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        #endregion

        [AllureStep("Click \"Save\" button")]
        public CmsCommon ClickSaveBtn()
        {
            WaitUntil.WaitSomeInterval(1);
            int elemPos = btnSave.Location.Y;
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            btnSave.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        [AllureStep("Click \"Cancel\" button")]
        public CmsCommon ClickCancelBtn()
        {
            WaitUntil.CustomElementIsVisible(btnCancel);
            int elemPos = btnCancel.Location.Y;
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            btnCancel.Click();
            WaitUntil.WaitSomeInterval(250);

            return this;
        }

        //[AllureStep("Open \"Description\" tab")]
        //public CmsCommon OpenDescriptionTab()
        //{
        //    WaitUntil.ElementIsVisible(_descriptionTab);
        //    int elemPos = descriptionTab.Location.Y;
        //    ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
        //    descriptionTab.Click();
        //    WaitUntil.WaitSomeInterval(1);

        //    return this;
        //}



    }
}
