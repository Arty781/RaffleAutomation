namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class WinRafflePage
    {
        public WinRafflePage OpenWinRaffle()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.WIN_RAFFLE);
            WaitUntil.WaitSomeInterval(1000);
            Element.Action(Keys.End);
            WaitUntil.CustomElementIsVisible(btnTicketBundles.FirstOrDefault(), 10);
            return this;
        }

        public WinRafflePage SelectTicketBundle(int bundleWinNumber)
        {
            Button.ClickJS(btnTicketBundles[bundleWinNumber]);
            WaitUntil.CustomElementIsVisible(Pages.Basket.btncheckOutNow);

            return this;
        }
    }
}
