

namespace RaffleAutomationTests.PageObjects
{
    public partial class Home
    {
        [AllureStep("Open Home page")]
        public Home OpenHomePage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);
            WaitUntil.CustomElementIsVisible(tbsSlider[0]);

            return this;
        }

        [AllureStep("Switching Slider Images")]
        public Home SwitchingSliderImages()
        {
            for (int i = 0; i < 3; i++)
            {
                Button.Click(btnNextTopSlider);
            }
            for (int i = 0; i < 5; i++)
            {
                Button.Click(btnPrevTopSlider);
            }
            return this;
        }

        [AllureStep("Open Floor Plan")]
        public Home OpenFloorPlan()
        {
            Button.Click(tbsSlider[1]);
            Assert.IsTrue(imgFloorPlan.Enabled);
            return this;
        }

        [AllureStep("Open Map")]
        public Home OpenMap()
        {
            Button.Click(tbsSlider[2]);
            Assert.IsTrue(imgMap.Enabled);
            return this;
        }


        [AllureStep("Open Dreamhome product page")]
        public Home OpenHomePage()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.WEBSITE_HOST);
            WaitUntil.WaitSomeInterval(1000);

            return this;
        }

        [AllureStep("Open dreamhome Ticket Selector")]
        public Home OpenDreamTicketSelector()
        {
            Button.ClickJS(btnDreamTicketSelector);

            return this;
        }

        [AllureStep("Select first bundle")]
        public Home SelectFirstBundleBtn()
        {
            WaitUntil.WaitSomeInterval(500);
            Button.Click(btnBundles.FirstOrDefault());
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("Select second bundle")]
        public Home SelectSecondBundleBtn()
        {
            WaitUntil.WaitSomeInterval(500);
            Button.Click(btnBundles[1]);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("Select third bundle")]
        public Home SelectThirdBundleBtn()
        {
            WaitUntil.WaitSomeInterval(500);
            Button.Click(btnBundles[2]);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("Select forth bundle")]
        public Home SelectForthBundleBtn()
        {
            WaitUntil.WaitSomeInterval(700);
            Button.Click(btnBundles[3]);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("AddTickets")]
        public Home AddTicketsToBasket(int maxIterations)
        {

            for (int i = 0; i <= maxIterations; i++)
            {
                switch (i)
                {
                    case 0:
                        OpenHomePage();
                        Element.Action(Keys.End);
                        OpenDreamTicketSelector();
                        SelectFirstBundleBtn();
                        break;
                    case 1:
                        OpenHomePage();
                        Element.Action(Keys.End);
                        OpenDreamTicketSelector();
                        SelectSecondBundleBtn();
                        break;
                    case 2:
                        OpenHomePage();
                        Element.Action(Keys.End);
                        OpenDreamTicketSelector();
                        SelectForthBundleBtn();
                        break;
                    case 3:
                        OpenHomePage();
                        Element.Action(Keys.End);
                        OpenDreamTicketSelector();
                        SelectThirdBundleBtn();
                        break;
                    default:
                        OpenHomePage();
                        Element.Action(Keys.End);
                        OpenDreamTicketSelector();
                        SelectFirstBundleBtn();
                        break;
                }
            }

            return this;
        }
    }
}
