using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.Postal
{
    public partial class Postal
    {
        public static async Task VerifyDisplayingTitle()
        {
            await WaitUntil.ElementIsVisible(textTitlePostPage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textTitlePostPage)).TextContentAsync().Result.ToLower() == RaffleAutomationTests.Helpers.PostText.TITLE_POST.ToLower(), Is.True);
        }
        public static async Task VerifyDisplayingParagraphs()
        {
            await WaitUntil.ElementIsVisible(textParagraphsPostPage);
            List<string> expectedText = RaffleAutomationTests.Helpers.PostText.PARAGRAPH_POST.Where(x => x.Any()).Select(x => x.Trim().ToLower()).ToList();
            List<string> actualText = (await Browser.Driver.QuerySelectorAllAsync(textParagraphsPostPage)).ToList().Where(x => x.IsVisibleAsync().Result).Select(x => x.TextContentAsync().Result.Trim().ToLower()).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(actualText, Is.EqualTo(expectedText), "Texts don't match");
                Assert.That(expectedText.Count, Is.EqualTo(actualText.Count), "Number of elements doesn't match");

                var mismatchedIndices = expectedText.Select((text, index) => new { text, index })
                    .Where(item => !actualText[item.index].Equals(item.text))
                    .Select(item => item.index)
                    .ToList();

                if (mismatchedIndices.Count > 0)
                {
                    string errorMessage = $"Expected text does not match the actual text at index(es): {string.Join(", ", mismatchedIndices)}";
                    Assert.Fail(errorMessage);
                }
            });
        }
        public static async Task VerifyDisplayingLinks()
        {
            await WaitUntil.ElementIsVisible(textLinksPostPage);
            for (int i = 0; i < (await Browser.Driver.QuerySelectorAllAsync(textLinksPostPage)).Count; i++)
            {
                Assert.That((await Browser.Driver.QuerySelectorAllAsync(textLinksPostPage))[i].TextContentAsync().Result.ToLower() + " " == RaffleAutomationTests.Helpers.PostText.PARAGRAPH_LINKS_POST[i].TrimEnd().ToLower(), Is.True, 
                    string.Concat("\"", (await Browser.Driver.QuerySelectorAllAsync(textLinksPostPage))[i].TextContentAsync().Result, "\"", "\r\nnot matched with ", "\"", RaffleAutomationTests.Helpers.PostText.PARAGRAPH_LINKS_POST[i].TrimEnd(' '), "\""));
            }
        }
    }
}
