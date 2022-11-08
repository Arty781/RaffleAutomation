using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Header
    {
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
            Button.Click(signInBtn);

            return this;
        }

        public Header OpenSignUpPage()
        {
            WaitUntil.CustomElementIsClickable(signUpBtn);
            signUpBtn.Click();

            return this;
        }

        public Header OpenFreeEntryPage(string url)
        {
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
    }
}
