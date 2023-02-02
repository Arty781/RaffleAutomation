using NUnit.Framework;
using OpenQA.Selenium;
using RaffleAutomationTests.APIHelpers.Web.WinnersWeb;
using RaffleAutomationTests.Helpers;
using System.Linq;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Winners
    {
        public Winners VerifyDisplayedFilteredWinnersByYear(WinnerResponse listOfWinners)
        {
            WaitUntil.CustomElementIsVisible(cardWinner.FirstOrDefault());
            for (int i = 0; i < (listOfWinners.AllCount/ 6); i++)
            {
                Element.Action(Keys.End);
            }
            for(int i = 0; i< listOfWinners.Winners.Count; i++)
            {
                var a = listOfWinners.Winners[i].DrawDate.DateTime;
                if (a.Hour >= 21)
                {
                    a = a.AddDays(+1);
                }
                Assert.IsTrue(a.ToString("dd' 'MMMM', 'yyyy").TrimStart('0') == textWinnerDate[i].Text, a.ToString("dd' 'MMMM', 'yyyy") + "\r\n"+ textWinnerDate[i].Text);
            }

            return this;
        }

        public Winners VerifyDisplayedCTAButtons(int winnerCount)
        {
            WaitUntil.CustomElementIsVisible(cardWinner.LastOrDefault());
            for (int i = 0; i < (winnerCount/6); i++)
            {
                Element.Action(Keys.End);
            }
            for (int i = 0; i < winnerCount; i += 4)
            {
                Assert.IsTrue(textWinnerCardDescription[i].Text == "Be our next winner. Take a look at what's live now!", "Not CTA card");
            }

            return this;
        }
    }
}
