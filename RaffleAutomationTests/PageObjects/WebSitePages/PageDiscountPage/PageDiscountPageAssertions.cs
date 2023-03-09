namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class PageDiscountPage
    {
        public PageDiscountPage VerifyPriceOfAddedOrder(string bundlePrice)
        {
            WaitUntil.CustomElementIsVisible(Pages.Basket.checkOutNowBtn);
            Assert.IsTrue(bundlePrice == Pages.Basket.textPrice.FirstOrDefault().Text, $"{Pages.Basket.textPrice.FirstOrDefault().Text}");
            return this;
        }
    }
}
