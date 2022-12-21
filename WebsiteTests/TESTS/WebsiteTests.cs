using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RaffleAutomationTests.APIHelpers.Admin;
using RaffleAutomationTests.APIHelpers.Web;
using RaffleAutomationTests.APIHelpers.Web.Weekly;
using RaffleAutomationTests.APIHelpers.Web.Basket;
using RaffleAutomationTests.Helpers;
using RaffleAutomationTests.PageObjects;
using WebsiteTests.BASE;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using OpenQA.Selenium;
using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;

namespace RaffleHouseAutomation.WebSiteTests
{
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
            Pages.Profile
                .EditPersonalData()
                .VerifyDisplayingToaster();
            Pages.Profile
                .EditPassword()
                .VerifyDisplayingToaster();
            Pages.Profile
                .EditAccountData()
                .VerifyDisplayingToaster();

        }

    }
    [TestFixture]
    [AllureNUnit]
    public class Payment : TestBaseWeb
    {
        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchaseWeeklyPrizes()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Weekly
                .OpenWeeklyPrizesPage()
                .CloseWeeklyPopUp()
                .SelectCategory(Categories.TECH)
                .SelectSubCategory(SubCategoriesD.PHONES_TABLETS)
                .SelectPrize("iPhone 12 Pro Max");
            Pages.Common
                .ClickEnterBtn()
                .ClickAddTenTickets()
                .ClickAddToBasketBtn();
            Pages.Basket
                .ClickAddMoreBtn();
            Pages.Common
                .ClickAdd25Tickets()
                .ClickAddToBasketBtn();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails();
            Pages.Basket
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();

        }

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
            Pages.Dreamhome
               .OpenHomePage()
               .OpenDreamHomeTicketSelector()
               .SelectThirdBundleBtn();
            Pages.Common
                .ClickAddToBasketBtn();
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
                .OpenOrderHistoryPage()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder);
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchaseTwoActiveDreamHome()
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
            Pages.Dreamhome
               .OpenHomePage()
               .SelectFirstDreamhome()
               .OpenDreamHomeTicketSelector()
               .SelectThirdBundleBtn();
            Pages.Common
                .ClickAddToBasketBtn();
            Pages.Dreamhome
               .OpenHomePage()
               .SelectLastDreamhome()
               .OpenDreamHomeTicketSelector()
               .SelectThirdBundleBtn();
            Pages.Common
                .ClickAddToBasketBtn();
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
                .OpenOrderHistoryPage()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder);
        }

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
            for(int i=0; i < 5; i++)
            {
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList);
                WaitUntil.WaitSomeInterval(250);
            }
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.Basket
                .ClickCartBtn()
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
    public class ErrorTests : TestBaseWeb
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
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var weeklyComp = CountdownRequestWeb.GetWeeklyPrizesCompetitionId(token);
            var weeklyPrizes = CountdownRequestWeb.GetWeeklyPrizes(token, weeklyComp[2].Id);
            WeeklyPrizesRequestWeb.AddWeeklyPrizes(token, weeklyPrizes, "151");

            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();
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
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var weeklyComp = CountdownRequestWeb.GetWeeklyPrizesCompetitionId(token);
            var weeklyPrizes = CountdownRequestWeb.GetWeeklyPrizes(token, weeklyComp[2].Id);
            WeeklyPrizesRequestWeb.AddWeeklyPrizes(token, weeklyPrizes, "62");

            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();
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
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var weeklyComp = CountdownRequestWeb.GetWeeklyPrizesCompetitionId(token);
            var weeklyPrizes = CountdownRequestWeb.GetWeeklyPrizes(token, weeklyComp[2].Id);
            WeeklyPrizesRequestWeb.AddWeeklyPrizes(token, weeklyPrizes, "154");

            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();
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
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var weeklyComp = CountdownRequestWeb.GetWeeklyPrizesCompetitionId(token);
            var weeklyPrizes = CountdownRequestWeb.GetWeeklyPrizes(token, weeklyComp[2].Id);
            WeeklyPrizesRequestWeb.AddWeeklyPrizes(token, weeklyPrizes, "163");

            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();
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
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var weeklyComp = CountdownRequestWeb.GetWeeklyPrizesCompetitionId(token);
            var weeklyPrizes = CountdownRequestWeb.GetWeeklyPrizes(token, weeklyComp[2].Id);
            WeeklyPrizesRequestWeb.AddWeeklyPrizes(token, weeklyPrizes, "12");

            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();
        }

        #endregion
    }
}