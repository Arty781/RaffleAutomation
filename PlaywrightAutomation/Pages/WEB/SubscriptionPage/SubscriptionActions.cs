using PlaywrightAutomation.Pages.WEB.BasketPage;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.SubscriptionPage
{
    public partial class Subscription
    {
        public static async Task OpenSubscriptionPage()
        {
            await GoToPage("https://staging.rafflehouse.com/subscription", btnSubscribeNowTop);
            await WaitUntil.ElementIsVisible(btnSubscribeNowTop);
        }

        public static async Task<(double, int)> AddTenSubscriptionToBasket()
        {
            await Button.Click(btnSubscribeNowTop);
            await WaitUntil.Timeout();
            await WaitUntil.ElementIsVisible(btnSubscribeNowSelector);
            double price = double.Parse((await Browser.Driver.QuerySelectorAllAsync(textPrice)).FirstOrDefault().TextContentAsync().Result.Substring(1, 2));
            int quantity = int.Parse((await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).FirstOrDefault().GetAttributeAsync("value").Result);
            await (await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).FirstOrDefault().ClickAsync();
            await WaitUntil.ElementIsVisible(Basket.framePaymentNumber);
            return (price, quantity);
        }

        public static async Task<(double, int)> AddTwentyFiveSubscriptionToBasket()
        {
            await Button.Click(btnSubscribeNowTop);
            await WaitUntil.Timeout();
            await WaitUntil.ElementIsVisible(btnSubscribeNowSelector);
            double price = double.Parse((await Browser.Driver.QuerySelectorAllAsync(textPrice)).LastOrDefault().TextContentAsync().Result.Substring(1, 2));
            int quantity = int.Parse((await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).LastOrDefault().GetAttributeAsync("value").Result);
            await (await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).LastOrDefault().ClickAsync();
            await WaitUntil.ElementIsVisible(Basket.framePaymentNumber);
            return (price, quantity);
        }

        
    }
}
