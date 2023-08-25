using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.WinnersPage
{
    public partial class Winners
    {
        public static async Task VerifyDisplayedFilteredWinnersByYear(RaffleAutomationTests.APIHelpers.Web.WinnersWeb.WinnerResponse listOfWinners)
        {
            await WaitUntil.ElementIsVisible(cardWinner);
            for (int i = 0; i < (listOfWinners.AllCount / 6); i++)
            {
                await Element.Action("End");
            }
            for (int i = 0; i < listOfWinners.Winners.Count; i++)
            {
                var a = listOfWinners.Winners[i].DrawDate.DateTime;
                if (a.Hour >= 21)
                {
                    a = a.AddDays(+1);
                }
                Assert.That(a.ToString("dd' 'MMMM', 'yyyy").TrimStart('0') == await TextBox.GetTextForList(textWinnerDate, i), Is.True, a.ToString("dd' 'MMMM', 'yyyy") + "\r\n" + await TextBox.GetTextForList(textWinnerDate, i));
            }
        }

        public static async Task VerifyDisplayedCTAButtons(int winnerCount)
        {
            await WaitUntil.ElementIsVisible(cardWinner);
            for (int i = 0; i < (winnerCount / 6); i++)
            {
                await Element.Action("End");
            }
            for (int i = 0; i < winnerCount; i += 4)
            {
                Assert.That(await TextBox.GetTextForList(textWinnerCardDescription, i) == "Be our next winner. Take a look at what's live now!", Is.True, "Not CTA card");
            }
        }
    }
}
