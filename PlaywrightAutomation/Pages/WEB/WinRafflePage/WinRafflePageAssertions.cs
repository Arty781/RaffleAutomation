using PlaywrightAutomation.Pages.WEB.BasketPage;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.WinRafflePage
{
    public partial class WinRafflePage
    {
        public static async Task VerifyPriceOfAddedOrder(string bundlePrice)
        {
            await WaitUntil.ElementIsVisible(Basket.checkOutNowBtn);
            Assert.Multiple(async () =>
            {
                Assert.That(bundlePrice == (await Browser.Driver.QuerySelectorAllAsync(Basket.textPrice)).FirstOrDefault().TextContentAsync().Result, Is.True,
                            $"{(await Browser.Driver.QuerySelectorAllAsync(Basket.textPrice)).FirstOrDefault().TextContentAsync().Result}");
                Assert.That((await Browser.Driver.QuerySelectorAllAsync(Basket.textPrice)).LastOrDefault().TextContentAsync().Result == "£0", Is.True,
                    $"{(await Browser.Driver.QuerySelectorAllAsync(Basket.textPrice)).LastOrDefault().TextContentAsync().Result}");
            });
        }
    }
}
