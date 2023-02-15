namespace RaffleAutomationTests.PageObjects
{
    public partial class Header
    {
#if DEBUG || RELEASE || CHROME || FIREFOX

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

        public Header OpenWinnersPage()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.WINNERS);

            return this;
        }

        public Header OpenSignInPage()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.SIGN_IN);

            return this;
        }

        public Header OpenSignUpPage()
        {

            Browser._Driver.Navigate().GoToUrl(WebEndpoints.SIGN_UP);

            return this;
        }

        public Header OpenSidebar()
        {
            Button.Click(btnBurgerMenu);
            return this;
        }

        public Header OpenCartPage()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.BASKET);

            return this;
        }

        public Header OpenPostPage()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.FREE_ENTRY);

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
