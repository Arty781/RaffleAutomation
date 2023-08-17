namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class Subscription
    {
        public Subscription OpenSubscriptionPage()
        {
            Browser.Driver.Navigate().GoToUrl("https://staging.rafflehouse.com/subscription");
            WaitUntil.CustomElementIsVisible(btnSubscribeNowTop);
            return this;
        }

        public Subscription AddTenSubscriptionToBasket(out double? price, out int? quantity)
        {
            Button.Click(btnSubscribeNowTop);
            WaitUntil.WaitSomeInterval();
            WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector.First());
            price = double.Parse(textPrice.FirstOrDefault().Text.Substring(1, 2));
            quantity = int.Parse(btnSubscribeNowSelector.FirstOrDefault().GetAttribute("value"));
            Button.Click(btnSubscribeNowSelector.FirstOrDefault());
            WaitUntil.CustomElementIsVisible(Pages.Basket.framePaymentNumber);
            return this;
        }

        public Subscription AddTwentyFiveSubscriptionToBasket(out double? price, out int? quantity)
        {
            Button.Click(btnSubscribeNowTop);
            WaitUntil.CustomElevemtIsInvisible(Pages.Common.loader);
            WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector.Last());
            price = double.Parse(textPrice.LastOrDefault().Text.Substring(1, 2));
            quantity = int.Parse(btnSubscribeNowSelector.LastOrDefault().GetAttribute("value"));
            Button.Click(btnSubscribeNowSelector.LastOrDefault());
            WaitUntil.CustomElementIsVisible(Pages.Basket.framePaymentNumber);
            return this;
        }

        
    }
}
