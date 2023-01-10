using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using RaffleAutomationTests.APIHelpers.Admin;
using RaffleAutomationTests.APIHelpers.Admin.DreamHomePage;
using RaffleAutomationTests.APIHelpers.Admin.UsersPage;
using RaffleAutomationTests.APIHelpers.Web;
using RaffleAutomationTests.APIHelpers.Web.Basket;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;
using RaffleAutomationTests.Helpers;
using RaffleAutomationTests.PageObjects;
using WebsiteTests.BASE;

namespace RaffleHouseAutomation.WebSiteTests
{
    [TestFixture]
    [AllureNUnit]
    public class Demo : TestBaseWeb
    {
        [Test]
        public void Demotest()
        {
            var response = SignUpRequest.RegisterNewUser();
            Pages.Common
                .CloseCookiesPopUp();
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Browser.Navigate("https://staging.rafflehouse.com/#contact-us");
            Browser.Navigate("https://staging.rafflehouse.com/post");
            Browser.Navigate("https://staging.rafflehouse.com/winners");
        }
    }

    [TestFixture]
    [AllureNUnit]
    public class Authorization : TestBaseWeb
    {


        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Login")]
        public void LoginByEmail()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();

        }

        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void RegisterNewUser()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .EnterUserData();
            string email = SignUp.GetEmail();
            Pages.SignUp
                .ClickSignUpBtn()
                .VerifyEmail(email);

        }

        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void EditUserData()
        {
            var response = SignUpRequest.RegisterNewUser();
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn();
            Pages.Profile
                .EditPersonalData()
                .VerifyDisplayingToaster();
            Pages.Profile
                .EditPassword()
                .VerifyDisplayingToaster();
            Pages.Profile
                .EditAccountData()
                .VerifyDisplayingToaster();
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

        }

    }
    [TestFixture]
    [AllureNUnit]
    public class Payment : TestBaseWeb
    {
        //[Test]
        //[Category("Payment")]
        //[AllureTag("Regression")]
        //[AllureOwner("Artem Sukharevskyi")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[Author("Artem", "qatester91311@gmail.com")]
        //[AllureSuite("Client")]
        //[AllureSubSuite("Payment")]
        //public void PurchaseWeeklyPrizes()
        //{
        //    Pages.Common
        //        .CloseCookiesPopUp();
        //    Pages.Header
        //        .OpenSignInPage();
        //    Pages.SignIn
        //        .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
        //    Pages.SignIn
        //        .VerifyIsSignIn();
        //    Pages.Weekly
        //        .OpenWeeklyPrizesPage()
        //        .CloseWeeklyPopUp()
        //        .SelectCategory(Categories.TECH)
        //        .SelectSubCategory(SubCategoriesD.PHONES_TABLETS)
        //        .SelectPrize("iPhone 12 Pro Max");
        //    Pages.Common
        //        .ClickEnterBtn()
        //        .ClickAddTenTickets()
        //        .ClickAddToBasketBtn();
        //    Pages.Basket
        //        .ClickAddMoreBtn();
        //    Pages.Common
        //        .ClickAdd25Tickets()
        //        .ClickAddToBasketBtn();
        //    Pages.Basket
        //        .ClickCheckoutNowBtn()
        //        .EnterCardDetails();
        //    Pages.Basket
        //        .ClickPayNowBtn()
        //        .ConfirmPurchaseStage();
        //    Pages.ThankYou
        //        .VerifyThankYouPageIsDisplayed();

        //}

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchaseDreamHome()
        {
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Home
               .OpenHomePage();
            Element.Action(Keys.End);
            Pages.Home
               .OpenDreamTicketSelector()
               .SelectThirdBundleBtn();
            Pages.Common
                .ClickAddToBasketBtn();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder);
        }

        //[Test]
        //[Category("Payment")]
        //[AllureTag("Regression")]
        //[AllureOwner("Artem Sukharevskyi")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[Author("Artem", "qatester91311@gmail.com")]
        //[AllureSuite("Client")]
        //[AllureSubSuite("Payment")]
        //public void PurchaseTwoActiveDreamHome()
        //{
        //    var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
        //    var basketOrders = BasketRequest.GetBasketOrders(token);
        //    BasketRequest.DeleteOrders(token, basketOrders);
        //    Pages.Common
        //        .CloseCookiesPopUp();
        //    Pages.Header
        //       .OpenSignInPage();
        //    Pages.SignIn
        //        .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
        //    Pages.SignIn
        //        .VerifyIsSignIn();
        //    Pages.Dreamhome
        //       .OpenHomePage()
        //       .SelectFirstDreamhome()
        //       .OpenDreamHomeTicketSelector()
        //       .SelectThirdBundleBtn();
        //    Pages.Common
        //        .ClickAddToBasketBtn();
        //    Pages.Dreamhome
        //       .OpenHomePage()
        //       .SelectLastDreamhome()
        //       .OpenDreamHomeTicketSelector()
        //       .SelectThirdBundleBtn();
        //    Pages.Common
        //        .ClickAddToBasketBtn();
        //    Pages.Basket
        //        .ClickCartBtn();
        //    double totalOrder = Pages.Basket.GetOrderTotal();
        //    Pages.Basket
        //        .ClickCheckoutNowBtn()
        //        .EnterCardDetails()
        //        .ClickPayNowBtn()
        //        .ConfirmPurchaseStage();
        //    Pages.ThankYou
        //        .VerifyThankYouPageIsDisplayed();
        //    Pages.Profile
        //        .OpenOrderHistoryPage()
        //        .OpenDreamHomeHistoryList()
        //        .VerifyAddingTickets(totalOrder);
        //}

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void SignUpAddTicketsMakePurchase()
        {
            Pages.Common
                .CloseCookiesPopUp();
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList);
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.Basket
                .ClickCartBtn();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            for (int i = 0; i < 5; i++)
            {
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList);
                WaitUntil.WaitSomeInterval(250);
            }
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder);
            Pages.Basket
                .ClickCartBtn();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void SignUpAddReferralsAndTicketsMakePurchase()
        {
            WaitUntil.WaitSomeInterval(5000);
            Pages.Common
                .CloseCookiesPopUp();
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList);
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.Basket
                .ClickCartBtn();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder);
            Pages.Header
                .DoLogout();
            for (int i = 0; i < 10; i++)
            {
                var responseReferral = SignUpRequest.RegisterNewReferral(response.User.ReferralKey);
                var tokenReferral = SignInRequestWeb.MakeSignIn(responseReferral.User.Email, Credentials.PASSWORD);
                var prizesListReferral = CountdownRequestWeb.GetDreamHomeCountdown(tokenReferral);
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(tokenReferral, prizesListReferral);
                WaitUntil.WaitSomeInterval(250);
                Pages.Header
                    .OpenSignInPage();
                Pages.SignIn
                    .EnterLoginAndPass(responseReferral.User.Email, Credentials.PASSWORD);
                Pages.Basket
                    .ClickCartBtn();
                double totalOrderReferral = Pages.Basket.GetOrderTotal();
                Pages.Basket
                    .ClickCheckoutNowBtn()
                    .EnterCardDetails()
                    .ClickPayNowBtn()
                    .ConfirmPurchaseStage();
                Pages.ThankYou
                    .VerifyThankYouPageIsDisplayed();
                Pages.Profile
                    .OpenMyTicketsCompetitions()
                    .OpenDreamHomeHistoryList()
                    .VerifyAddingTickets(totalOrderReferral);
                Pages.Header
                    .DoLogout();
            }
        }

    }

    [TestFixture]
    [AllureNUnit]
    public class CheckingTextsOnPages : TestBaseWeb
    {
        //[Test]
        //[AllureTag("Regression")]
        //[AllureOwner("Artem Sukharevskyi")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[Author("Artem", "qatester91311@gmail.com")]
        //[AllureSuite("Client")]
        //[AllureSubSuite("AboutPage")]
        //public void VerifiedAboutPage()
        //{
        //    Pages.Common
        //        .CloseCookiesPopUp();
        //    Pages.About
        //        .OpenAboutPage(WebEndpoints.ABOUT)
        //        .VerifyFindOutBlock()
        //        .VerifyStepsBlock()
        //        .VerifyCharitableBlock()
        //        .VerifySiteCreditBlock();

        //    var responseLogin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
        //    SignInAssertionsAdmin
        //        .VerifyIsAdminSignInSuccesfull(responseLogin);

        //}

        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifiedHomePage()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Home
                .OpenHomePage(WebEndpoints.WEBSITE_HOST)
                .SwitchingSliderImages()
                .OpenFloorPlan()
                .OpenMap()
                .VerifySecondaryBannerTitle()
                .VerifyInfoBlockTitles()
                .VerifyInfoBlockParagraphs();
            Element.Action(Keys.End);
            Pages.Home
                .VerifyHowItWorksTitle()
                .VerifyHowItWorksParagraph()
                .VerifyHowItWorksStepsTitles()
                .VerifyHowItWorksStepsParagraphs();

        }
    }

    [TestFixture]
    [AllureNUnit]
    public class ErrorPaymentTests : TestBaseWeb
    {
        #region Test displaying of error messages

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void InsufientFundsError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList, 151);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void RestrictedCardError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList, 62);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void BadTrackDataError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList, 154);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void SecurityVioLationError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList, 163);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void InvalidTransactionError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList, 12);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        #endregion
    }
}