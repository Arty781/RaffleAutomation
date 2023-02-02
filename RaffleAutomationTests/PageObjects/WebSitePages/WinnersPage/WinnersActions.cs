using NUnit.Framework;
using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using System.Linq;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Winners
    {
        public Winners ScrollToEndOfList(int winnerCount)
        {
            //WaitUntil.CustomElementIsVisible(textWinnerTitle.FirstOrDefault());
            WaitUntil.WaitSomeInterval(2000);
            for(int i =0; i< (winnerCount/6); i++)
            {
                Element.Action(Keys.End);
            }
            return this;
        }

        public Winners FilterWinnersByYear(int yearNum)
        {
            WaitUntil.CustomElementIsVisible(filterYearSelector.LastOrDefault());
            foreach(var year in filterYearSelector)
            {
                if(yearNum.ToString() == year.Text)
                {
                    year.Click();
                }
            }
            return this;
        }
    }
}
