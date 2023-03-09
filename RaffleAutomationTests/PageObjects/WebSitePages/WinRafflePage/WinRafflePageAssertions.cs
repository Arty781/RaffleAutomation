namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class WinRafflePage
    {
        public WinRafflePage VerifyPriceOfAddedOrder(string bundlePrice)
        {
            WaitUntil.CustomElementIsVisible(Pages.Basket.checkOutNowBtn);
            Assert.IsTrue(bundlePrice == Pages.Basket.textPrice.FirstOrDefault().Text,$"{Pages.Basket.textPrice.FirstOrDefault().Text}");
            Assert.IsTrue(Pages.Basket.textPrice.LastOrDefault().Text == "£0", $"{Pages.Basket.textPrice.LastOrDefault().Text}");
            return this;
        }
    }
}
