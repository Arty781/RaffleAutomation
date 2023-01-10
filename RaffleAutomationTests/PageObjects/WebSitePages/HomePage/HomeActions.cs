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

        public Home VerifySecondaryBannerTitle()
        {
            Debug.WriteLine(textTitleBannerSecondary.Text);
            Assert.IsTrue(textTitleBannerSecondary.Text.ToLower() == HomeTexts.SECONDARY_BANNER_TITLE.ToLower());

            return this;
        }

        public Home VerifyInfoBlockTitles()
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.WriteLine(textTitle[i].Text.ToLower());
                Assert.IsTrue(textTitle[i].Text.ToLower() == HomeTexts.TITLES_INFO_BLOCKS[i].ToLower());
            }

            return this;
        }

        public Home VerifyInfoBlockParagraphs()
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.WriteLine(textParagraph[i].Text.ToLower());
                Assert.IsTrue(textParagraph[i].Text.ToLower() == HomeTexts.PARAGRAPHS_INFO_BLOCKS[i].ToLower());
            }

            return this;
        }

        public Home VerifyHowItWorksTitle()
        {
            Debug.WriteLine(textHowItWorksTitle.Text.ToLower());
            Assert.IsTrue(textHowItWorksTitle.Text.ToLower() == HomeTexts.HOW_IT_WORKS_TITLE.ToLower());
            return this;
        }
        public Home VerifyHowItWorksParagraph()
        {
            Debug.WriteLine(textHowItWorksParagraph.Text.ToLower());
            Assert.IsTrue(textHowItWorksParagraph.Text.ToLower() == HomeTexts.HOW_IT_WORKS_PARAGRAPH.ToLower());
            return this;
        }

        public Home VerifyHowItWorksStepsTitles()
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.WriteLine(textHowItWorksStepsTitle[i].Text.ToLower());
                Assert.IsTrue(textHowItWorksStepsTitle[i].Text.ToLower() == HomeTexts.TITLES_STEPS[i].ToLower());
            }
            return this;
        }

        public Home VerifyHowItWorksStepsParagraphs()
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.WriteLine(textHowItWorksStepsParagraph[i].Text.ToLower());
                Assert.IsTrue(textHowItWorksStepsParagraph[i].Text.ToLower() == HomeTexts.PARAGRAPHS_STEPS[i].ToLower());
            }
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
