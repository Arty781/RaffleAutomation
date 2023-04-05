namespace RaffleAutomationTests.PageObjects
{
    public partial class Home
    {
        public Home VerifySecondaryBannerTitle()
        {
            Debug.WriteLine(textTitleBannerSecondary.Text);
            Assert.IsTrue(textTitleBannerSecondary.Text.ToLower() == HomeTexts.SECONDARY_BANNER_TITLE.ToLower(), $"Texts are not matched. Expected \"{HomeTexts.SECONDARY_BANNER_TITLE}\" but was \"{textTitleBannerSecondary.Text}\"");

            return this;
        }
        public Home VerifySecondaryBannerSubitle()
        {
            Debug.WriteLine(textSubtitleBannerSecondary.Text);
            Assert.IsTrue(textSubtitleBannerSecondary.Text.ToLower() == HomeTexts.SECONDARY_BANNER_SUBTITLE.ToLower(), $"Texts are not matched. Expected \"{HomeTexts.SECONDARY_BANNER_SUBTITLE}\" but was \"{textSubtitleBannerSecondary.Text}\"");

            return this;
        }

        public Home VerifyBottomSliderTitle()
        {
            Debug.WriteLine(textBottomSliderTitle.Text);
            Assert.IsTrue(textBottomSliderTitle.Text.ToLower() == HomeTexts.BOTTOM_SLIDER_TITLE.ToLower(), $"Texts are not matched. Expected \"{HomeTexts.BOTTOM_SLIDER_TITLE}\" but was \"{textBottomSliderTitle.Text}\"");

            return this;
        }
        public Home VerifyBottomSliderSubitle()
        {
            Debug.WriteLine(textBottomSliderParagraph.FirstOrDefault().Text);
            for (int i = 0; i < textBottomSliderParagraph.Count; i++)
            {
                Assert.IsTrue(textBottomSliderParagraph[i].Text.ToLower() == HomeTexts.BOTTOM_SLIDER_SUBTITLE[i].ToLower(), $"Texts are not matched. Expected \"{HomeTexts.BOTTOM_SLIDER_SUBTITLE[i]}\" but was \"{textBottomSliderParagraph[i].Text}\"");
            }
            return this;
        }

        public Home VerifyInfoBlockTitles()
        {
            for (int i = 0; i < HomeTexts.TITLES_INFO_BLOCKS.Count; i++)
            {
                string expectedTitle = HomeTexts.TITLES_INFO_BLOCKS[i].ToLower();
                string actualTitle = textTitle[i].Text.ToLower();
                Debug.WriteLine(actualTitle);
                Assert.AreEqual(expectedTitle, actualTitle, $"Not matched. Expected: \"{expectedTitle}\". Actual: \"{actualTitle}\"");
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
            Assert.IsTrue(textHowItWorksTitle.Text.ToLower() == HomeTexts.HOW_IT_WORKS_TITLE.ToLower(), $"Texts are not matched. Expected \"{HomeTexts.HOW_IT_WORKS_TITLE}\" but was \"{textHowItWorksTitle.Text}\"");
            return this;
        }
        public Home VerifyHowItWorksParagraph()
        {
            Debug.WriteLine(textHowItWorksParagraph.Text.ToLower());
            Assert.IsTrue(textHowItWorksParagraph.Text.ToLower() == HomeTexts.HOW_IT_WORKS_PARAGRAPH.ToLower(), $"Texts are not matched. Expected \"{HomeTexts.HOW_IT_WORKS_PARAGRAPH}\" but was \"{textHowItWorksParagraph.Text}\"");
            return this;
        }

        public Home VerifyHowItWorksStepsTitles()
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.WriteLine(textHowItWorksStepsTitle[i].Text.ToLower());
                Assert.IsTrue(textHowItWorksStepsTitle[i].Text.ToLower() == HomeTexts.TITLES_STEPS[i].ToLower(), $"Texts are not matched. Expected \"{HomeTexts.TITLES_STEPS[i]}\" but was \"{textHowItWorksStepsTitle[i].Text}\"");
            }
            return this;
        }

        public Home VerifyHowItWorksStepsParagraphs()
        {
            for (int i = 0; i < 3; i++)
            {
                string expectedParagraph = HomeTexts.PARAGRAPHS_STEPS[i].ToLower();
                string actualParagraph = textHowItWorksStepsParagraph[i].Text.ToLower();
                Debug.WriteLine(actualParagraph);
                Assert.AreEqual(expectedParagraph, actualParagraph, $"Not matched. Expected: \"{expectedParagraph}\". Actual: \"{actualParagraph}\"");
            }

            return this;
        }

    }
}
