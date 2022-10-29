using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PutsboxWrapper;
using RaffleAutomationTests.APIHelpers.Admin;
using RaffleAutomationTests.APIHelpers.Web;
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
        public void PurchaseWeeklyPrizes()
        {
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Header
                .OpenWeeklyPrizesPage(WebEndpoints.LIFESTYLE);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Weekly
                .CloseWeeklyPopUp()
                .SelectCategory(Categories.CATEGORY)
                .SelectSubCategory(SubCategoriesD.SUBCATEGORY)
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
                .OpenDreamhomePage(WebEndpoints.DREAMHOME);
           
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
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();

            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var dreamHomeId = CountdownRequestWeb.GetDreamHomeCountdown(token);
            var competitionId = CountdownRequestWeb.GetWeeklyPrizesCompetitionId(token);
            var weeklyID = competitionId[2].Id;
            var listOfWeeklyPrizes = CountdownRequestWeb.GetWeeklyPrizes(token, weeklyID);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, dreamHomeId);
            for (int i = 0; i < 5; i++)
            {
                WeeklyPrizesRequestWeb.AddWeeklyPrizes(token, listOfWeeklyPrizes);
            }
            
            Pages.Basket
                .ClickCartBtn();
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
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
            Pages.Common
                .CloseCookiesPopUp();
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
                .OpenAboutPage(WebEndpoints.ABOUT)
                .VerifyFindOutBlock()
                .VerifyStepsBlock()
                .VerifyCharitableBlock()
                .VerifySiteCreditBlock();

            var responseLogin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            SignInAssertionsAdmin
                .VerifyIsAdminSignInSuccesfull(responseLogin);

        }
    }
}