using PlaywrightAutomation.Pages.WEB.BasketPage;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.PageDiscountPage
{
    public partial class PageDiscount
    {
        public static async Task VerifyPriceOfAddedOrder(string bundlePrice)
        {
            await WaitUntil.ElementIsVisible(Basket.checkOutNowBtn);
            Assert.That(bundlePrice == (await TextBox.GetText(Basket.textPrice)), Is.True, $"{await TextBox.GetText(Basket.textPrice)}");
        }
    }
}
