
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.HomePage
{
    public partial class Home
    {
        
        public static async Task OpenHomePage()
        {
            await GoToPage(Endpoints.Web.WEBSITE_HOST, btnDreamTicketSelector);
            await WaitUntil.ElementIsVisible(titleMain);
        }

        public static async Task SwitchingSliderImages()
        {
            for (int i = 0; i < 3; i++)
            {
                await Helpers.Button.Click(btnNextTopSlider);
            }
            for (int i = 0; i < 5; i++)
            {
                await Helpers.Button.Click(btnPrevTopSlider);
            }
        }

        public static async Task OpenFloorPlan()
        {
            await Helpers.Button.ClickOnNthElement(tbsSlider, 1);
            Assert.That((await Browser.Driver.QuerySelectorAsync(imgFloorPlan)).IsVisibleAsync(), Is.True, "Floor Plan is not displayed");
        }

        public static async Task OpenMap()
        {
            await Helpers.Button.ClickOnNthElement(tbsSlider, 2);
            Assert.That((await Browser.Driver.QuerySelectorAsync(imgMap)).IsVisibleAsync(), Is.True, "Map is not displayed");
        }

        public static async Task OpenDreamTicketSelector()
        {
            await Helpers.Button.Click(btnDreamTicketSelector);
            await Helpers.WaitUntil.ElementIsVisible(btnBundles);
        }

        public static async Task SelectFirstBundleBtn()
        {
            await Helpers.Button.ClickOnNthElement(btnBundles, 0);
            await Helpers.WaitUntil.Timeout(2000);
        }

        public static async Task SelectSecondBundleBtn()
        {
            await Helpers.Button.ClickOnNthElement(btnBundles, 1);
            await Helpers.WaitUntil.Timeout(2000);
        }

        public static async Task SelectThirdBundleBtn()
        {
            await Helpers.Button.ClickOnNthElement(btnBundles, 2);
            await Helpers.WaitUntil.Timeout(2000);
        }

        public static async Task SelectForthBundleBtn()
        {
            await Helpers.Button.ClickOnNthElement(btnBundles, 3);
            await Helpers.WaitUntil.Timeout(2000);
        }

        public static async Task AddTicketsToBasket(int maxIterations)
        {

            for (int i = 0; i <= maxIterations; i++)
            {
                switch (i)
                {
                    case 0:
                        await Browser.Driver.QuerySelectorAsync(btnDreamTicketSelector).Result.ScrollIntoViewIfNeededAsync();
                        await OpenDreamTicketSelector();
                        await SelectFirstBundleBtn();
                        break;
                    case 1:
                        await OpenHomePage();
                        await Browser.Driver.QuerySelectorAsync(btnDreamTicketSelector).Result.ScrollIntoViewIfNeededAsync();
                        await OpenDreamTicketSelector();
                        await SelectSecondBundleBtn();
                        break;
                    case 2:
                        await OpenHomePage();
                        await Browser.Driver.QuerySelectorAsync(btnDreamTicketSelector).Result.ScrollIntoViewIfNeededAsync();
                        await OpenDreamTicketSelector();
                        await SelectForthBundleBtn();
                        break;
                    case 3:
                        await OpenHomePage();
                        await Browser.Driver.QuerySelectorAsync(btnDreamTicketSelector).Result.ScrollIntoViewIfNeededAsync();
                        await OpenDreamTicketSelector();
                        await SelectThirdBundleBtn();
                        break;
                    default:
                        await OpenHomePage();
                        await Browser.Driver.QuerySelectorAsync(btnDreamTicketSelector).Result.ScrollIntoViewIfNeededAsync();
                        await OpenDreamTicketSelector();
                        await SelectFirstBundleBtn();
                        break;
                }
            }
        }

        
        public static async Task VerifySecondaryBannerTitle()
        {
            Assert.That((await Helpers.TextBox.GetText(textTitleBannerSecondary)).ToLower(), Is.EqualTo(RaffleAutomationTests.Helpers.HomeTexts.SECONDARY_BANNER_TITLE.ToLower()), $"Texts are not matched. Expected \"{RaffleAutomationTests.Helpers.HomeTexts.SECONDARY_BANNER_TITLE}\" but was \"{(await Helpers.TextBox.GetText(textTitleBannerSecondary))}\"");
        }

        
        public static async Task VerifySecondaryBannerSubtitle()
        {
            Assert.That((await Helpers.TextBox.GetText(textSubtitleBannerSecondary)).ToLower(), Is.EqualTo(RaffleAutomationTests.Helpers.HomeTexts.SECONDARY_BANNER_SUBTITLE.ToLower()), $"Texts are not matched. Expected \"{RaffleAutomationTests.Helpers.HomeTexts.SECONDARY_BANNER_SUBTITLE}\" but was \"{(await Helpers.TextBox.GetText(textSubtitleBannerSecondary))}\"");
        }

        
        public static async Task VerifyBottomSliderTitle()
        {
            Assert.That((await Helpers.TextBox.GetText(textBottomSliderTitle)).ToLower(), Is.EqualTo(RaffleAutomationTests.Helpers.HomeTexts.BOTTOM_SLIDER_TITLE.ToLower()), $"Texts are not matched. Expected \"{RaffleAutomationTests.Helpers.HomeTexts.BOTTOM_SLIDER_TITLE}\" but was \"{(await Helpers.TextBox.GetText(textBottomSliderTitle))}\"");
        }

        
        public static async Task VerifyBottomSliderSubitle()
        {
            await Helpers.WaitUntil.ElementIsVisible(textBottomSliderParagraph);
            for (int i = 0; i < (await Browser.Driver.QuerySelectorAllAsync(textBottomSliderParagraph)).Count; i++)
            {
                var actual = (await Browser.Driver.QuerySelectorAllAsync(textBottomSliderParagraph))[i].TextContentAsync().Result.ToLower();
                Assert.That(actual, Is.EqualTo(RaffleAutomationTests.Helpers.HomeTexts.BOTTOM_SLIDER_SUBTITLE[i].ToLower()), 
                    $"Texts are not matched. Expected \"{RaffleAutomationTests.Helpers.HomeTexts.BOTTOM_SLIDER_SUBTITLE[i]}\" but was \"{actual}\"");
            }
        }

        
        public static async Task VerifyInfoBlockTitles()
        {
            for (int i = 0; i < RaffleAutomationTests.Helpers.HomeTexts.TITLES_INFO_BLOCKS.Count; i++)
            {
                string expectedTitle = RaffleAutomationTests.Helpers.HomeTexts.TITLES_INFO_BLOCKS[i].ToLower();
                string actualTitle = (await Browser.Driver.QuerySelectorAllAsync(textTitle))[i].TextContentAsync().Result.ToLower();
                Assert.That(actualTitle, Is.EqualTo(expectedTitle), 
                    $"Not matched. Expected: \"{expectedTitle}\". Actual: \"{actualTitle}\"");
            }
        }

        
        public static async Task VerifyInfoBlockParagraphs()
        {
            for (int i = 0; i < 5; i++)
            {
                var actual = (await Browser.Driver.QuerySelectorAllAsync(textParagraph))[i].TextContentAsync().Result.ToLower();
                Assert.That(actual == RaffleAutomationTests.Helpers.HomeTexts.PARAGRAPHS_INFO_BLOCKS[i].ToLower(), Is.True, 
                    string.Concat("Not matched ", "\"", actual, "\"", "\r\nwith ", "\"", RaffleAutomationTests.Helpers.HomeTexts.PARAGRAPHS_INFO_BLOCKS[i], "\""));
            }
        }

        
        public static async Task VerifyHowItWorksTitle()
        {
            var actual = (await Browser.Driver.QuerySelectorAsync(textHowItWorksTitle)).TextContentAsync().Result.ToLower();
            Assert.That(actual == RaffleAutomationTests.Helpers.HomeTexts.HOW_IT_WORKS_TITLE.ToLower(), Is.True, 
                $"Texts are not matched. Expected \"{RaffleAutomationTests.Helpers.HomeTexts.HOW_IT_WORKS_TITLE}\" but was \"{actual}\"");
        }

        
        public static async Task VerifyHowItWorksParagraph()
        {
            var actual = (await Browser.Driver.QuerySelectorAsync(textHowItWorksParagraph)).TextContentAsync().Result.ToLower();
            Assert.That(actual == RaffleAutomationTests.Helpers.HomeTexts.HOW_IT_WORKS_PARAGRAPH.ToLower(), Is.True, 
                $"Texts are not matched. Expected \"{RaffleAutomationTests.Helpers.HomeTexts.HOW_IT_WORKS_PARAGRAPH}\" but was \"{actual}\"");
        }

        
        public static async Task VerifyHowItWorksStepsTitles()
        {
            for (int i = 0; i < 3; i++)
            {
                var actual = (await Browser.Driver.QuerySelectorAllAsync(textHowItWorksStepsTitle))[i].TextContentAsync().Result.ToLower();
                Assert.That(actual == RaffleAutomationTests.Helpers.HomeTexts.TITLES_STEPS[i].ToLower(), Is.True, 
                    $"Texts are not matched. Expected \"{RaffleAutomationTests.Helpers.HomeTexts.TITLES_STEPS[i]}\" but was \"{actual}\"");
            }
        }

        
        public static async Task VerifyHowItWorksStepsParagraphs()
        {
            for (int i = 0; i < 3; i++)
            {
                string expectedParagraph = RaffleAutomationTests.Helpers.HomeTexts.PARAGRAPHS_STEPS[i].ToLower();
                string actualParagraph = (await Browser.Driver.QuerySelectorAllAsync(textHowItWorksStepsParagraph))[i].TextContentAsync().Result.ToLower();
                Debug.WriteLine(actualParagraph);
                Assert.That(actualParagraph, Is.EqualTo(expectedParagraph), 
                    $"Not matched. Expected: \"{expectedParagraph}\". Actual: \"{actualParagraph}\"");
            }
        }
    }
}
