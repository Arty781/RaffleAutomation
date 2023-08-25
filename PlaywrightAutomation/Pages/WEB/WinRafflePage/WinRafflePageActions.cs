using PlaywrightAutomation.Pages.WEB.BasketPage;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.WinRafflePage
{
    public partial class WinRafflePage
    {
        public static async Task OpenWinRaffle()
        {
            await GoToPage(Endpoints.Web.WIN_RAFFLE, btnTicketBundles);
            await WaitUntil.Timeout(1000);
            await Element.Action("End");
            await WaitUntil.ElementIsVisible(btnTicketBundles);
        }

        public static async Task SelectTicketBundle()
        {
            int num = RandomHelper.RandomIntNumber(3);
            string bundleprice = (await Browser.Driver.QuerySelectorAllAsync(textTicketBundlePrice))[num].TextContentAsync().Result ?? throw new Exception("Price is null");
            await Browser.Driver.QuerySelectorAllAsync(btnTicketBundles).Result[num].ClickAsync();
            await WaitUntil.ElementIsVisible(Basket.btncheckOutNow);
        }
    }
}
