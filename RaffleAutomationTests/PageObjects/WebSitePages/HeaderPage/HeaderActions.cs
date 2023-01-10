using RaffleAutomationTests.Helpers;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Header
    {
#if DEBUG || CHROME || FIREFOX

        #region Opening links in header
        public Header OpenHomePage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        public Header OpenDreamhomePage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        //public Header OpenWeeklyPrizesPage()
        //{
        //    Browser._Driver.Navigate().GoToUrl(WebEndpoints.LIFESTYLE);

        //    return this;
        //}
        //public Header OpenFixedOddsPrizesPage(string url)
        //{
        //    Browser._Driver.Navigate().GoToUrl(url);

        //    return this;
        //}

        public Header OpenWinnersPage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        //public Header OpenFAQsPage(string url)
        //{
        //    Browser._Driver.Navigate().GoToUrl(url);

        //    return this;
        //}

        //public Header OpenAboutPage(string url)
        //{
        //    Browser._Driver.Navigate().GoToUrl(url);

        //    return this;
        //}

        public Header OpenSignInPage()
        {
            //Button.Click(signInBtn);
            Browser._Driver.Navigate().GoToUrl("https://staging.rafflehouse.com/sign-in");

            return this;
        }

        public Header OpenSignUpPage()
        {

            Browser._Driver.Navigate().GoToUrl("https://staging.rafflehouse.com/sign-up");

            return this;
        }

        public Header OpenFreeEntryPage()
        {
            Browser._Driver.Navigate().GoToUrl("https://staging.rafflehouse.com/post");

            return this;
        }

        public Header OpenSidebar()
        {
            Button.Click(btnBurgerMenu);
            return this;
        }

        public Header OpenCartPage()
        {
            Browser._Driver.Navigate().GoToUrl("https://staging.rafflehouse.com/basket");

            return this;
        }

        public Header DoLogout()
        {
            Button.Click(btnBurgerMenu);
            WaitUntil.WaitSomeInterval(1000);
            Button.Click(btnLogOut);
            return this;
        }

        #endregion

#endif

#if DEBUG_MOBILE

        #region Opening links in header
        public Header OpenHomePage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        public Header OpenDreamhomePage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        public Header OpenWeeklyPrizesPage()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.LIFESTYLE);

            return this;
        }
        public Header OpenFixedOddsPrizesPage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        public Header OpenWinnersPage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        public Header OpenFAQsPage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        public Header OpenAboutPage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        public Header OpenSignInPage()
        {
            WaitUntil.CustomElementIsClickable(btnHeaderBurgerMenu);
            Button.Click(btnHeaderBurgerMenu);
            Button.Click(signInBtn);

            return this;
        }

        public Header OpenSignUpPage()
        {

            WaitUntil.CustomElementIsClickable(btnHeaderBurgerMenu);
            Button.Click(btnHeaderBurgerMenu);
            Button.Click(signUpBtn);
            Button.Click(Pages.SignUp.btnCloseSignUpPopup);


            return this;
        }

        public Header OpenFreeEntryPage(string url)
        {
            WaitUntil.CustomElementIsClickable(btnHeaderBurgerMenu);
            Button.Click(btnHeaderBurgerMenu);
            Browser._Driver.Navigate().GoToUrl(url);

            return this;
        }

        public Header OpenCartPage()
        {
            WaitUntil.CustomElementIsClickable(btnCart);
            btnCart.Click();

            return this;
        }

        #endregion

#endif
    }
}
