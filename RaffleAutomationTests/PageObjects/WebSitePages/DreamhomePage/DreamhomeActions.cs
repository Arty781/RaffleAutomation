namespace RaffleAutomationTests.PageObjects
{
    public partial class Dreamhome
    {
        #region Ticket Selector
        [AllureStep("Open Dreamhome product page")]
        public Dreamhome OpenHomePage()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.WEBSITE_HOST);

            return this;
        }

        [AllureStep("Select Dreamhome card")]
        public Dreamhome SelectFirstDreamhome()
        {
            WaitUntil.CustomElementIsVisible(counterTwoDreamhomes);
            Button.ClickJS(cardDreamhome.First());
            return this;
        }

        [AllureStep("Select Dreamhome card")]
        public Dreamhome SelectLastDreamhome()
        {
            WaitUntil.CustomElementIsVisible(counterTwoDreamhomes);
            Button.ClickJS(cardDreamhome.LastOrDefault());
            return this;
        }

        [AllureStep("Open ticket selector")]
        public Dreamhome OpenDreamHomeTicketSelector()
        {
            Button.Click(btnDreamHome);

            return this;
        }


        [AllureStep("Select first bundle")]
        public Dreamhome SelectFirstBundleBtn()
        {
            Button.Click(btnFirstBundle);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("Select second bundle")]
        public Dreamhome SelectSecondBundleBtn()
        {
            Button.Click(btnSecondBundle);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("Select third bundle")]
        public Dreamhome SelectThirdBundleBtn()
        {
            Button.Click(btnThirdBundle);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("Select forth bundle")]
        public Dreamhome SelectForthBundleBtn()
        {
            Button.Click(btnFourthBundle);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }
        #endregion

    }
}
