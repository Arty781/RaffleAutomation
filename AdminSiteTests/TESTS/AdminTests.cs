using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using RaffleAutomationTests.PageObjects;
using AdminSiteTests.BASE;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace RaffleHouseAutomation.AdminSiteTests
{
    [TestFixture]
    [AllureNUnit]
    public class AdminSiteTests : TestBaseAdmin
    {

        [Test]
        public void CreateNewDreamhome()
        {
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.loginAdmin, Credentials.passwordAdmin)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .ClickAddDreamhomeBtn()
                .UploadImages()
                .EnterTitle();
            string dreamhomeTitle = Pages.CmsDreamhome.GetDreamhomeTitle();
            Pages.CmsDreamhome
                .EnterAddress()
                .EnterStartDate()
                .EnterFinishDate()
                .EnterMetaTags();
            Pages.CmsCommon
                .ClickSaveBtn();
            /*Pages.CmsCommon
                .OpenDescriptionTab();*/
            Pages.CmsDreamhome
                .UploadDreamhomeCardImage()
                .UploadBedroomCardImage()
                .UploadBathroomCardImage()
                .UploadOutspaceCardImage()
                .UploadFloorPlanCardImage()
                .EnterBedroomText(DreamHomeTexts.Bedrooms)
                .EnterBathroomText(DreamHomeTexts.Bathrooms)
                .EnterOutSpaceText(DreamHomeTexts.Outspace)
                .ClickAddOverviewRowsBtn()
                .EnterOverviewTitle()
                .EnterOverviewValue()
                .EnterAboutText(DreamHomeTexts.About)
                .EnterProductCTAText(DreamHomeTexts.ProductPageCTA)
                .EnterHeadingText(DreamHomeTexts.Heading);
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsDreamhome
                .EnterPrice()
                .EnterNumOfTickets();
            Pages.CmsCommon
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);
            







        }

        [Test]
        public void EditEndDateInFixedOdds()
        {

        }
    }
}