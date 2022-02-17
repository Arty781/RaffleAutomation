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
            WaitUntil.ElementIsVisible(_prizeManagementBtn);
            prizeManagementBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open DreamHome page")]
        public CmsCommon OpenDreamHomePage()
        {
            WaitUntil.ElementIsVisible(_dreamhomeBtn);
            dreamhomeBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open LifestylePrizes page")]
        public CmsCommon OpenLifestylePrizesPage()
        {
            WaitUntil.ElementIsVisible(_lifestylePrizesBtn);
            lifestylePrizesBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open Competitions page")]
        public CmsCommon OpenCompetitionsPage()
        {
            WaitUntil.ElementIsVisible(_competitionsBtn);
            competitionsBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open UserManagement page")]
        public CmsCommon OpenUserManagementPage()
        {
            WaitUntil.ElementIsVisible(_userManagementBtn);
            userManagementBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open StaffManagement page")]
        public CmsCommon OpenStaffManagementPage()
        {
            WaitUntil.ElementIsVisible(_staffManagementBtn);
            staffManagementBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open Settings list")]
        public CmsCommon OpenSettingsList()
        {
            WaitUntil.ElementIsVisible(_settingsBtn);
            settingsBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open General page")]
        public CmsCommon OpenGeneralPage()
        {
            WaitUntil.ElementIsVisible(_generalBtn);
            generalBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open Winners page")]
        public CmsCommon OpenWinnersPage()
        {
            WaitUntil.ElementIsVisible(_winnersBtn);
            winnersBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open Referrals page")]
        public CmsCommon OpenReferralsPage()
        {
            WaitUntil.ElementIsVisible(_referralsBtn);
            referralsBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open Reports page")]
        public CmsCommon OpenReportsPage()
        {
            WaitUntil.ElementIsVisible(_reportsBtn);
            reportsBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }







        #endregion

        [AllureStep("Click \"Save\" button")]
        public CmsCommon ClickSaveBtn()
        {
            WaitUntil.WaitSomeInterval(1);
            int elemPos = saveBtn.Location.Y;
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            saveBtn.Click();

            return this;
        }

        [AllureStep("Click \"Cancel\" button")]
        public CmsCommon ClickCancelBtn()
        {
            WaitUntil.ElementIsVisible(_cancelBtn);
            int elemPos = cancelBtn.Location.Y;
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            cancelBtn.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Open \"Description\" tab")]
        public CmsCommon OpenDescriptionTab()
        {
            WaitUntil.ElementIsVisible(_descriptionTab);
            int elemPos = descriptionTab.Location.Y;
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            descriptionTab.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }



    }
}
