using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PutsboxWrapper;
using RaffleAutomationTests.APIHelpers.SignInPageAdmin;
using RaffleAutomationTests.APIHelpers.WebApi;
using RaffleAutomationTests.Helpers;
using RaffleAutomationTests.PageObjects;
using System;
using WebsiteTests.BASE;

namespace RaffleHouseAutomation.WebSiteTests
{
    [TestFixture]
    [AllureNUnit]
    public class WebsiteTests : TestBaseWeb
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
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.login, Credentials.password);
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
        public void PurchaseWeeklyPrizes()
        {
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.login, Credentials.password);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Header
                .OpenWeeklyPrizesPage(Endpoints.Lifestyle);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Weekly
                .CloseWeeklyPopUp()
                .SelectCategory(Categories.category)
                .SelectSubCategory(SubCategories.subCategory)
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

            Pages.Header
                .OpenDreamhomePage(Endpoints.Dreamhome);
           
            Pages.Dreamhome
                .OpenDreamHomeProductPage()
                .OpenDreamHomeTicketSelector()
                .SelectThirdBundleBtn();
            Pages.Common
                .ClickAddToBasketBtn();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails();
            Pages.Basket
                .ClickPayNowBtn();
            
        }

        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchasePrizes()
        {
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.login, Credentials.password);
            Pages.SignIn
                .VerifyIsSignIn();

            var token = SignInRequestWeb.MakeSignIn(Credentials.login, Credentials.password);
            var dreamHomeId = CountdownRequestWeb.GetCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, dreamHomeId);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, dreamHomeId);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, dreamHomeId);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, dreamHomeId);

            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchase();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
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
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .EnterUserData();
            string email = SignUp.GetEmail();
            Pages.SignUp
                .ClickSignUpBtn()
                .VerifyEmail(email)
                .VerifyVisibilityOfToaster(email);

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

        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("AboutPage")]
        public void VerifiedAboutPage()
        {
            
            Pages.About
                .OpenAboutPage(Endpoints.About)
                .VerifyFindOutBlock()
                .VerifyStepsBlock()
                .VerifyCharitableBlock()
                .VerifySiteCreditBlock();

            var responseLogin = SignInRequestAdmin.MakeAdminSignIn(Credentials.loginAdmin, Credentials.passwordAdmin);
            SignInAssertionsAdmin
                .VerifyIsAdminSignInSuccesfull(responseLogin);

        }
    }
}