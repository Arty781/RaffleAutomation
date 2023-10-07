
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.CommonPage
{
    public partial class Common
    {
        public static async Task CloseCookiesPopUp()
        {
            await Button.Click(confirmCookieBtn);
        }

        public static async Task<IPage> CloseTabAndWait30Seconds()
        {
            var newPage = await Browser.Driver.Context.NewPageAsync();
            await Browser.Driver.CloseAsync();
            await newPage.BringToFrontAsync();
            await Task.Delay(3000);
            return Browser.page = newPage;
        }
    }
}
