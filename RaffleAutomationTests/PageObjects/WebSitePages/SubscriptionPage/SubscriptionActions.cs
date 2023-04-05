namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class Subscription
    {
        public Subscription OpenSubscriptionPage()
        {
            Browser._Driver.Navigate().GoToUrl("https://staging.rafflehouse.com/subscription");
            WaitUntil.CustomElementIsVisible(btnSubscribeNowTop);
            return this;
        }

        public Subscription AddTenSubscriptionToBasket()
        {
            Button.Click(btnSubscribeNowTop);
            WaitUntil.WaitSomeInterval();
            WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector.First());
            Button.Click(btnSubscribeNowSelector.FirstOrDefault());
            WaitUntil.CustomElementIsVisible(Pages.Basket.framePaymentNumber);
            return this;
        }

        public Subscription AddTwentyFiveSubscriptionToBasket()
        {
            Button.Click(btnSubscribeNowTop);
            WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector.LastOrDefault());
            Button.Click(btnSubscribeNowSelector.LastOrDefault());
            WaitUntil.CustomElementIsVisible(Pages.Basket.framePaymentNumber);
            return this;
        }

        
    }
}
