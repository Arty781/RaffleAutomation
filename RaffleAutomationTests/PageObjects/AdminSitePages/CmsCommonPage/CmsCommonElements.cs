using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsCommon
    {
        #region SideBarMenu

        [FindsBy(How = How.XPath, Using = "//li[@role='menuitem']//span[contains(text(),'Prize Management')]")]
        public IWebElement tbPrizeManagement;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/dreamHome']")]
        public IWebElement tbDreamHome;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/prizes']")]
        public IWebElement tbLifeStylePrizes;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='#/fixedOdds']")]
        public IWebElement tbFixedOdds;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/competitions']")]
        public IWebElement tbCompetitions;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/users']")]
        public IWebElement tbUserManagement;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/staffUsers']")]
        public IWebElement tbStaffManagement;

        [FindsBy(How = How.XPath, Using = "//li[@role='menuitem']//span[contains(text(),'Settings')]")]
        public IWebElement tbSettings;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/general']")]
        public IWebElement tbGeneral;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/winners']")]
        public IWebElement tbWinners;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/referrals']")]
        public IWebElement tbReferrals;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/reports']")]
        public IWebElement tbReports;

        #endregion

        #region Save and Cancel btns

        [FindsBy(How = How.XPath, Using = "//button/span[contains(text(),'Save')]")]
        public IWebElement btnSave;

        [FindsBy(How = How.XPath, Using = "//button/span[contains(text(),'Cancel')]")]
        public IWebElement btnCancel;

        #endregion

        #region Pagination

        [FindsBy(How = How.XPath, Using = "//div[@title='Last Page']")]
        public IWebElement btnGoToLastPage;

        #endregion

        public IWebElement generalTab => Browser._Driver.FindElement(_generalTab);
        public readonly By _generalTab = By.XPath("//a[@href='#/dreamHome/create']");

        public IWebElement descriptionTab => Browser._Driver.FindElement(_descriptionTab);
        public readonly By _descriptionTab = By.XPath("//a[@href='#/dreamHome/create/1']");

        public IWebElement discountTicketsTab => Browser._Driver.FindElement(_discountTicketsTab);
        public readonly By _discountTicketsTab = By.XPath("//a[@href='#/dreamHome/create/3']");


    }
}
