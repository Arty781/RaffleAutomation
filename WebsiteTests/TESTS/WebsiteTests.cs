using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using RaffleAutomationTests.PageObjects;
using WebsiteTests.BASE;

namespace RaffleHouseAutomation.WebSiteTests
{
    public class WebsiteTests : TestBaseWeb
    {

       [Test]
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
        public void PurchaseWeeklyPrizes()
        {
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.login, Credentials.password);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Header
                .OpenWeeklyPrizesPage();
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
           /* Pages.Basket
                .ClickAddMoreBtn();
            Pages.Common
                .ClickAdd25Tickets()
                .ClickAddToBasketBtn();*/

            Pages.Header
                .OpenDreamhomePage();
            Pages.Common
                .ScrollToElement();
            Pages.Dreamhome
                .OpenDreamHomeProductPage()
                .OpenDreamHomeTicketSelector()
                .SelectThirdBundleBtn();
            Pages.Common
                .ClickAddToBasketBtn();
            /*Pages.Basket
                .ClickAddMoreBtn();
            Pages.Dreamhome
                .SelectFirstBundleBtn();
            Pages.Common
                .ClickAddToBasketBtn();*/
            Pages.Common
                .ScrollToElement();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails();
            Pages.Common
                .ScrollToElement();
            Pages.Basket
                .ClickPayNowBtn();
            
        }
    }
}