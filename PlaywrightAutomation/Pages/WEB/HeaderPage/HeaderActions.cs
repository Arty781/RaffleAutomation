
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.HeaderPage
{
    public partial class Header
    {
        public static async Task OpenHomePage()
        {
            await GoToPage( Endpoints.Web.WEBSITE_HOST, HomePage.Home.titleMain);
        }

        public static async Task OpenDreamhomePage(string url)
        {
            await GoToPage( Endpoints.Web.DREAMHOME, HomePage.Home.btnDreamTicketSelector);
        }

        public static async Task OpenWinnersPage()
        {
            await GoToPage( Endpoints.Web.WINNERS, "//h1");
        }

        public static async Task OpenSignInPage()
        {
            await GoToPage( Endpoints.Web.SIGN_IN, SignInPage.SignIn.btnSignIn);
        }

        public static async Task OpenSignUpPage()
        {
            await GoToPage( Endpoints.Web.SIGN_UP, SignUpPage.SignUp.btnSignUp);
        }

        public static async Task OpenSidebar()
        {
            await Button.Click( btnBurgerMenu);
           
        }

        public static async Task OpenCartPage()
        {
            await GoToPage( Endpoints.Web.BASKET, BasketPage.Basket.btncheckOutNow);
        }

        public static async Task OpenPostPage()
        {
            await GoToPage( Endpoints.Web.FREE_ENTRY, "//h1");
        }

        public static async Task DoLogout()
        {
            await Button.Click( btnBurgerMenu);
            await Button.Click( btnLogOut);
           
        }
    }
}
