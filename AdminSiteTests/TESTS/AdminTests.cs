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
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
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
                .UploadBedroomCardImage()
                .UploadBathroomCardImage()
                .UploadOutspaceCardImage()
                .UploadFloorPlanCardImage()
                .EnterOutSpaceText(DreamHomeTexts.OUTSPACE)
                .ClickAddOverviewRowsBtn()
                .EnterBedroomText(DreamHomeTexts.BEDROOMS)
                .EnterBathroomText(DreamHomeTexts.BATHROOMS)
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
        public void EditNewDreamhome()
        {
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
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
                .UploadBedroomCardImage()
                .UploadBathroomCardImage()
                .UploadOutspaceCardImage()
                .UploadFloorPlanCardImage()
                .EnterOutSpaceText(DreamHomeTexts.OUTSPACE)
                .ClickAddOverviewRowsBtn()
                .EnterBedroomText(DreamHomeTexts.BEDROOMS)
                .EnterBathroomText(DreamHomeTexts.BATHROOMS)
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

        [Test]
        public void Demo()
        {
            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamHome = DreamHomeRequest.CreateNewDreamHome(token);
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .EditDreamHome(dreamHome.Title)
                .UploadImages();
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsDreamhome
                .UploadDreamhomeCardImage()
                .UploadBedroomCardImage()
                .UploadBathroomCardImage()
                .UploadOutspaceCardImage()
                .UploadFloorPlanCardImage();
            Pages.CmsCommon
                .ClickSaveBtn();
            WaitUntil.WaitSomeInterval(10000);
            Pages.CmsCommon
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamHome.Title);
        }
    }
}