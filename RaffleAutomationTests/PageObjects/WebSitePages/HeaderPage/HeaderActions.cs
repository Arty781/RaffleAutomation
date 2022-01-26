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
        public Header OpenHomePage()
        {
            WaitUntil.ElementIsVisibleAndClickable(_logo);
            logo.Click();

            return this;
        }

        public Header OpenDreamhomePage()
        {
            WaitUntil.WaitSomeInterval(1);
            liveCompetitionsList.Click();
            WaitUntil.ElementIsVisibleAndClickable(_dreamHomeLink);
            dreamHomeLink.Click();

            return this;
        }

        public Header OpenWeeklyPrizesPage()
        {
            WaitUntil.ElementIsClickable(liveCompetitionsList);
            liveCompetitionsList.Click();
            WaitUntil.ElementIsVisibleAndClickable(_weeklyLink);
            weeklyLink.Click();

            return this;
        }
        public Header OpenFixedOddsPrizesPage()
        {
            WaitUntil.ElementIsClickable(liveCompetitionsList);
            liveCompetitionsList.Click();
            WaitUntil.ElementIsVisibleAndClickable(_fixedOddsLink);
            fixedOddsLink.Click();

            return this;
        }

        public Header OpenWinnersPage()
        {
            WaitUntil.ElementIsClickable(winnersLink);
            winnersLink.Click();

            return this;
        }

        public Header OpenFAQsPage()
        {
            WaitUntil.ElementIsClickable(faqsLink);
            faqsLink.Click();

            return this;
        }

        public Header OpenAboutPage()
        {
            WaitUntil.ElementIsClickable(aboutLink);
            aboutLink.Click();

            return this;
        }

        public Header OpenSignInPage()
        {
            WaitUntil.ElementIsClickable(signInBtn);
            signInBtn.Click();

            return this;
        }

        public Header OpenSignUpPage()
        {
            WaitUntil.ElementIsClickable(signUpBtn);
            signUpBtn.Click();

            return this;
        }

        public Header OpenFreeEntryPage()
        {
            WaitUntil.ElementIsClickable(freeEntryBtn);
            freeEntryBtn.Click();

            return this;
        }

        public Header OpenCartPage()
        {
            WaitUntil.ElementIsClickable(cartBtn);
            cartBtn.Click();

            return this;
        }
        #endregion
    }
}
