﻿namespace RaffleAutomationTests.PageObjects
{
    public partial class Winners
    {
        [AllureStep("Scroll To End Of List")]
        public Winners ScrollToEndOfList(int winnerCount)
        {
            WaitUntil.WaitSomeInterval(2000);
            for (int i = 0; i < (winnerCount / 6); i++)
            {
                Element.Action(Keys.End);
            }
            return this;
        }

        [AllureStep("Filter Winners By Year")]
        public Winners FilterWinnersByYear(int yearNum)
        {
            WaitUntil.CustomElementIsVisible(filterYearSelector.LastOrDefault());
            foreach (var year in filterYearSelector)
            {
                if (yearNum.ToString() == year.Text)
                {
                    year.Click();
                }
            }
            return this;
        }
    }
}
