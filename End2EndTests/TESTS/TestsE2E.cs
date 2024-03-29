﻿using Allure.Commons;
using NUnit.Allure.Attributes;
using RaffleAutomationTests.APIHelpers.Admin.UsersPage;

namespace End2EndTests.TESTS
{
    [TestFixture]
    [AllureNUnit]
    public class E2ETests : TestBaseE2E
    {
        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("E2E")]
        public void CreateDreamHomeFreeTicketsWithinAndMakePurchase()
        {
            #region Preconditions
            string title = string.Empty;
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out _);
            DreamHomeRequest.DeactivateDreamHome(tokenAdmin, dreamResponse);

            #endregion

            #region Create Dreamhome

            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .OpenDreamhomePage()
                .ClickAddDreamhomeBtn()
                .EnterTitle(out title);
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

            #endregion

            #region Make payment on Web
            
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            Browser.Navigate(WebEndpoints.WEBSITE_HOST);
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out _);
            Pages.Home
                .AddTicketsToBasket(2);
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();

            #endregion
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("E2E")]
        public void CreateDreamHomeAndMakePurchase()
        {
            #region Preconditions
            string title = string.Empty;
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out _);
            DreamHomeRequest.DeactivateDreamHome(tokenAdmin, dreamResponse);

            #endregion

            #region Create Dreamhome

            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .OpenDreamhomePage()
                .ClickAddDreamhomeBtn()
                .EnterTitle(out title);
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
                .AddTicketsBundles();
            Pages.CmsCommon
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);

            #endregion

            #region Make payment on Web

            
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            Browser.Navigate(WebEndpoints.WEBSITE_HOST);
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out _);
            Pages.Home
                .AddTicketsToBasket(2);
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();

            #endregion

            #region PostConditions

            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }
    }
}
