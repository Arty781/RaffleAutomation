using System;
using System.Collections.Generic;
using System.Linq;

namespace RaffleHouseAutomation.AdminSiteTests
{
    [TestFixture]
    [AllureNUnit]
    public class DemoTest : TestBaseAdmin
    {
        [Test]
        public void Demo()
        {
            var email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"), "@putsbox.com");
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsUserManagement
                .OpenUserManagement()
                .ClickAddNewBtn()
                .EnterUserData(email);
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsUserManagement
                .SearchIsUserDisplayed(email);
            var password = Pages.CmsUserManagement.GetPassword(email);

            Browser.Navigate(WebEndpoints.WEBSITE_HOST);
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, password);
            Pages.SignIn
                .VerifyIsSignIn();
        }
    }



    [TestFixture]
    [AllureNUnit]
    public class AdminDreamHomeTests : TestBaseAdmin
    {

        [Test]
        public void CreateNewDreamhomeWithFreeTicketsInGeneralSettings()
        {
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .OpenDreamhomePage()
                .ClickAddDreamhomeBtn()
                .EnterTitle();
            string dreamhomeTitle = Pages.CmsDreamhome.GetDreamhomeTitle();
            Pages.CmsDreamhome
                .EnterAddress()
                .EnterStartDate()
                .EnterFinishDate()
                .EnterMetaTags()
                .UploadImages();
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsDreamhome
                .UploadDreamhomeCardImage()
                .UploadFloorPlanCardImage()
                .UploadLocationImage()
                .EnterAboutText(DreamHomeTexts.ABOUT)
                .EnterProductCTAText(DreamHomeTexts.PRODUCT_CTA_BTN)
                .EnterHeadingText(DreamHomeTexts.HEADING);
            Pages.CmsCommon
                .OpenDiscountTab();
            Pages.CmsDreamhome
                .EnterPrice()
                .EnterNumOfTickets()
                .SetDiscountThreshold()
                .AddTicketsBundles();
            Pages.CmsCommon
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);
        }

        [Test]
        public void CreateNewDreamhomeWithFreeTicketsWithin()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.DeactivateDreamHome(tokenAdmin, dreamResponse);

            #endregion

            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .OpenDreamhomePage()
                .ClickAddDreamhomeBtn()
                .EnterTitle();
            string dreamhomeTitle = Pages.CmsDreamhome.GetDreamhomeTitle();
            Pages.CmsDreamhome
                .EnterAddress()
                .AcivateDreamHome()
                .EnterStartDate()
                .EnterFinishDate()
                .EnterMetaTags()
                .UploadImages();
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsDreamhome
                .UploadDreamhomeCardImage()
                .UploadFloorPlanCardImage()
                .UploadLocationImage()
                .EnterAboutText(DreamHomeTexts.ABOUT)
                .EnterProductCTAText(DreamHomeTexts.PRODUCT_CTA_BTN)
                .EnterHeadingText(DreamHomeTexts.HEADING);
            Pages.CmsCommon
                .OpenDiscountTab();
            Pages.CmsDreamhome
                .EnterPrice()
                .EnterNumOfTickets()
                .SetDiscountThreshold()
                .SetFreeTickets()
                .AddTicketsBundles();
            Pages.CmsCommon
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);
        }

        [Test]
        public void EditNewDreamhome()
        {
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .OpenDreamhomePage()
                .ClickAddDreamhomeBtn()
                .EnterTitle();
            string dreamhomeTitle = Pages.CmsDreamhome.GetDreamhomeTitle();
            Pages.CmsDreamhome
                .EnterAddress()
                .EnterStartDate()
                .EnterFinishDate()
                .EnterMetaTags()
                .UploadImages();
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsDreamhome
                .UploadDreamhomeCardImage()
                .UploadFloorPlanCardImage()
                .UploadLocationImage()
                .EnterAboutText(DreamHomeTexts.ABOUT)
                .EnterProductCTAText(DreamHomeTexts.PRODUCT_CTA_BTN)
                .EnterHeadingText(DreamHomeTexts.HEADING);
            Pages.CmsCommon
                .OpenDiscountTab();
            Pages.CmsDreamhome
                .EnterPrice()
                .EnterNumOfTickets()
                .SetDiscountThreshold()
                .AddTicketsBundles();
            Pages.CmsCommon
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);
            Pages.CmsDreamhome
                .EditDreamHome(dreamhomeTitle)
                .UploadImages();
            Pages.CmsCommon
                .ClickSaveBtn()
                .ClickSaveBtn()
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);
        }

    }

    [TestFixture]
    [AllureNUnit]
    public class AdminLifestyleTests : TestBaseAdmin
    {
        [Test]
        public void ActivateLF()
        {
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsLifestylePrizes
                .OpenLifestylePizesPage()
                .SetRowsPerPageAs100()
                .ActivatePrizesOnPage()
                .ClickNextBtn()
                .ActivatePrizesOnPage()
                .ClickNextBtn()
                .ActivatePrizesOnPage();

        }
    }


    [TestFixture]
    [AllureNUnit]
    public class AdminUserManagementTests : TestBaseAdmin
    {

    }
}