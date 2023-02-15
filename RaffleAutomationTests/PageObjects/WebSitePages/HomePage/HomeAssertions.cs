namespace RaffleAutomationTests.PageObjects
{
    public partial class Home
    {
        public Home VerifySecondaryBannerTitle()
        {
            Debug.WriteLine(textTitleBannerSecondary.Text);
            Assert.IsTrue(textTitleBannerSecondary.Text.ToLower() == HomeTexts.SECONDARY_BANNER_TITLE.ToLower());

            return this;
        }
        public Home VerifySecondaryBannerSubitle()
        {
            Debug.WriteLine(textSubtitleBannerSecondary.Text);
            Assert.IsTrue(textSubtitleBannerSecondary.Text.ToLower() == HomeTexts.SECONDARY_BANNER_SUBTITLE.ToLower());

            return this;
        }

        public Home VerifyBottomSliderTitle()
        {
            Debug.WriteLine(textBottomSliderTitle.Text);
            Assert.IsTrue(textBottomSliderTitle.Text.ToLower() == HomeTexts.BOTTOM_SLIDER_TITLE.ToLower());

            return this;
        }
        public Home VerifyBottomSliderSubitle()
        {
            Debug.WriteLine(textBottomSliderParagraph.FirstOrDefault().Text);
            for (int i = 0; i < textBottomSliderParagraph.Count; i++)
            {
                Assert.IsTrue(textBottomSliderParagraph[i].Text.ToLower() == HomeTexts.BOTTOM_SLIDER_SUBTITLE[i].ToLower());
            }
            return this;
        }

        public Home VerifyInfoBlockTitles()
        {
            for (int i = 0; i < HomeTexts.TITLES_INFO_BLOCKS.Count; i++)
            {
                string t = HomeTexts.TITLES_INFO_BLOCKS[i].ToLower();
                Debug.WriteLine(textTitle[i].Text.ToLower());
                Assert.IsTrue(textTitle[i].Text.ToLower() == t, string.Concat("Not matched ", "\"", textTitle[i].Text), "\"");
            }

            return this;
        }

        public Home VerifyInfoBlockParagraphs()
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.WriteLine(textParagraph[i].Text.ToLower());
                Assert.IsTrue(textParagraph[i].Text.ToLower() == HomeTexts.PARAGRAPHS_INFO_BLOCKS[i].ToLower(), string.Concat("Not matched ", "\"", textParagraph[i].Text, "\"", "\r\nwith ", "\"", HomeTexts.PARAGRAPHS_INFO_BLOCKS[i], "\""));
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
    }
}
