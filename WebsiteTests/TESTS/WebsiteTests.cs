using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using RaffleAutomationTests.PageObjects;
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
        public void LoginByGoogle()
        {
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .GoogleAuth(Credentials.login, Credentials.password);
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
                .OpenWeeklyPrizesPage(Endpoints.lifestyle);
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
                .OpenDreamhomePage(Endpoints.dreamhome);
           
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
        public void RegisterNewUser()
        {
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
    }
}