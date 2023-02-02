using NUnit.Allure.Steps;
using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using System.Diagnostics;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Home
    {
        public Home OpenHomePage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);
            WaitUntil.CustomElementIsVisible(tbsSlider[0]);

            return this;
        }

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

        public Home OpenFloorPlan()
        {
            Button.Click(tbsSlider[1]);
            Assert.IsTrue(imgFloorPlan.Enabled);
            return this;
        }

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

            return this;
        }

        public Home OpenDreamTicketSelector()
        {
            Button.ClickJS(btnDreamTicketSelector);

            return this;
        }

        [AllureStep("Select first bundle")]
        public Home SelectFirstBundleBtn()
        {
            WaitUntil.WaitSomeInterval(500);
            Button.Click(btnFirstBundle);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("Select second bundle")]
        public Home SelectSecondBundleBtn()
        {
            WaitUntil.WaitSomeInterval(500);
            Button.Click(btnSecondBundle);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("Select third bundle")]
        public Home SelectThirdBundleBtn()
        {
            WaitUntil.WaitSomeInterval(500);
            Button.Click(btnThirdBundle);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }

        [AllureStep("Select forth bundle")]
        public Home SelectForthBundleBtn()
        {
            WaitUntil.WaitSomeInterval(500);
            Button.Click(btnFourthBundle);
            WaitUntil.WaitSomeInterval(2000);

            return this;
        }
    }
}
