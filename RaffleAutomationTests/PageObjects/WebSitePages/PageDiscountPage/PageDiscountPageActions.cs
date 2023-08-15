namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class PageDiscountPage
    {
        public PageDiscountPage OpenPageDiscount()
        {
            Browser.Driver.Navigate().GoToUrl(WebEndpoints.PAGE_DISCOUNT);
            WaitUntil.WaitSomeInterval(1000);
            Element.Action(Keys.End);
            WaitUntil.CustomElementIsVisible(btnTicketBundles.FirstOrDefault(), 10);
            return this;
        }

        public PageDiscountPage SelectTicketBundle(out string bundleprice)
        {
            int num = RandomHelper.RandomIntNumber(3);
            bundleprice = Pages.WinRafflePage.textTicketBundlePrice[num].Text;
            Button.ClickJS(btnTicketBundles[num]);
            WaitUntil.CustomElementIsVisible(Pages.Basket.btncheckOutNow);

            return this;
        }
    }
}
