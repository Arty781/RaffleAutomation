using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.WinnersPage
{
    public partial class Winners
    {
        public const string cardWinner = "//div[@class='winner-card']";
        public const string textWinnerTitle = "//div[@class='winner-card-name']";
        public const string textWinnerDate = "//span[@class='winner-card-date']";
        public const string textWinnerDescription = "//div[@class='winner-card-desc text-container']";
        public const string textWinnerCardDescription = "//div[@class='winner-card']//p";
        public const string filterYearSelector = "//ul[@class='winners-date']/li";

    }
}
