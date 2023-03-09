namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class PageDiscountPage
    {
        public PageDiscountPage OpenPageDiscount()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.PAGE_DISCOUNT);
            WaitUntil.WaitSomeInterval(1000);
            Element.Action(Keys.End);
            WaitUntil.CustomElementIsVisible(btnTicketBundles.FirstOrDefault(), 10);
            return this;
        }

        public PageDiscountPage SelectTicketBundle(int bundleNumber)
        {
            Button.ClickJS(btnTicketBundles[bundleNumber]);
            WaitUntil.CustomElementIsVisible(Pages.Basket.btncheckOutNow);

            return this;
        }
    }
}
