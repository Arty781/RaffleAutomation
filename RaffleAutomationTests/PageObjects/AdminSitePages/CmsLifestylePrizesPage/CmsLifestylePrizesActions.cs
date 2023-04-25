namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsLifestylePrizes
    {
        public CmsLifestylePrizes OpenLifestylePizesPage()
        {
            Browser._Driver.Navigate().GoToUrl(AdminEndpoints.LIFESTYLE_PRIZES);
            return this;
        }

        public CmsLifestylePrizes SetRowsPerPageAs100()
        {
            WaitUntil.CustomElementIsVisible(rowPerPage);
            rowPerPage.Click();
            listOfRowValues.Last().Click();
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        public CmsLifestylePrizes ClickNextBtn()
        {
            if (buttonNextPage.Enabled == true)
            {
                buttonNextPage.Click();
                WaitUntil.WaitSomeInterval(500);
                new Actions(Browser._Driver)
                 .SendKeys(Keys.Home)
                 .Build()
                 .Perform();
                WaitUntil.WaitSomeInterval(2000);
            }

            return this;
        }

        public CmsLifestylePrizes ActivatePrizesOnPage()
        {
            WaitUntil.WaitSomeInterval(150);
            WaitUntil.CustomElementIsVisible(switcher.First());
            foreach (var switc in switcher)
            {
                switc.Click();
                WaitUntil.WaitSomeInterval(150);
            }
            WaitUntil.WaitSomeInterval(2000);
            return this;
        }
    }
}