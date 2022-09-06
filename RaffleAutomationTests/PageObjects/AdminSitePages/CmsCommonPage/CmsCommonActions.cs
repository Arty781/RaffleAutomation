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
            Button.Click(pagePrizeManagement);

            return this;
        }

        [AllureStep("Open DreamHome page")]
        public CmsCommon OpenDreamHomePage()
        {
            Button.Click(pageDreamHome);

            return this;
        }

        [AllureStep("Open LifestylePrizes page")]
        public CmsCommon OpenLifestylePrizesPage()
        {
            Button.Click(pagePrizes);

            return this;
        }

        [AllureStep("Open Competitions page")]
        public CmsCommon OpenCompetitionsPage()
        {
            Button.Click(pageCompetitions);

            return this;
        }

        [AllureStep("Open UserManagement page")]
        public CmsCommon OpenUserManagementPage()
        {
            Button.Click(pageUsers);

            return this;
        }

        [AllureStep("Open StaffManagement page")]
        public CmsCommon OpenStaffManagementPage()
        {
            Button.Click(pageStaff);

            return this;
        }

        [AllureStep("Open Settings list")]
        public CmsCommon OpenSettingsList()
        {
            Button.Click(pageSettings);

            return this;
        }

        [AllureStep("Open General page")]
        public CmsCommon OpenGeneralPage()
        {
            Button.Click(pageSettingsGeneral);

            return this;
        }

        [AllureStep("Open Winners page")]
        public CmsCommon OpenWinnersPage()
        {
            Button.Click(pageSettingsWinners);

            return this;
        }

        [AllureStep("Open Referrals page")]
        public CmsCommon OpenReferralsPage()
        {
            Button.Click(pageSettingsReferrals);

            return this;
        }

        [AllureStep("Open Reports page")]
        public CmsCommon OpenReportsPage()
        {
            Button.Click(pageSettingsReports);

            return this;
        }



        #endregion

        [AllureStep("Click \"Save\" button")]
        public CmsCommon ClickSaveBtn()
        {
            WaitUntil.WaitSomeInterval(1);
            int elemPos = btnSave.Location.Y;
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            Button.Click(btnSave);

            return this;
        }

        [AllureStep("Click \"Cancel\" button")]
        public CmsCommon ClickCancelBtn()
        {
            WaitUntil.CustomElevemtIsVisible(btnCancel);
            int elemPos = btnCancel.Location.Y;
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            btnCancel.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        



    }
}
