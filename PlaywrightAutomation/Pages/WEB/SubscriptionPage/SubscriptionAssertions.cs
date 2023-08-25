using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.SubscriptionPage
{
    public partial class Subscription
    {
        public static async Task VerifyDisplayingH1()
        {
            await WaitUntil.ElementIsVisible(titleH1);
            string expectedText = RaffleAutomationTests.Helpers.SubscriptionTexts.TITLE_H1;
            string actualText = await TextBox.GetText(titleH1);

            Assert.Multiple(() =>
            {
                Assert.That(actualText, Is.EqualTo(expectedText), "Texts don't match");
                Assert.That(expectedText.Length, Is.EqualTo(actualText.Length), "Number of elements doesn't match");

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

        public static async Task VerifyDisplayingH2()
        {
            await WaitUntil.ElementIsVisible(titleH2List);
            List<string> expectedText = RaffleAutomationTests.Helpers.SubscriptionTexts.TITLES_H2.Where(x => x.Any()).Select(x => x.ToLower()).ToList();
            int index = 4;
            expectedText.Insert(index, ""); // adds an empty string at the specified index
            List<string> actualText = (await Browser.Driver.QuerySelectorAllAsync(titleH2List)).Where(x => x.IsVisibleAsync().Result).Select(x => x.TextContentAsync().Result.Trim().ToLower()).ToList();

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

        public static async Task VerifyDisplayingH3()
        {
            await WaitUntil.ElementIsVisible(titleH2List);
            List<string> expectedText = RaffleAutomationTests.Helpers.SubscriptionTexts.TITLES_H3.Where(x => x.Any()).Select(x => x.Trim().ToLower()).ToList();
            List<string> actualText = (await Browser.Driver.QuerySelectorAllAsync(titleH3List)).Where(x => x.IsVisibleAsync().Result).Select(x => x.TextContentAsync().Result.Trim().ToLower()).ToList();

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

        public static async Task VerifyDisplayingParagraphs()
        {
            await WaitUntil.ElementIsVisible(paragraphList);
            List<string> expectedText = RaffleAutomationTests.Helpers.SubscriptionTexts.PARAGRAPHS.Where(x => x.Any()).Select(x => x.Trim().ToLower()).ToList();
            int[] indexesToInsert = new int[] { 2, 26, 27, 28 };

            foreach (int index in indexesToInsert)
            {
                expectedText.Insert(index, "");
            }
            List<string> actualText = (await Browser.Driver.QuerySelectorAllAsync(paragraphList)).Where(x => x.IsVisibleAsync().Result).Select(x => x.TextContentAsync().Result.Trim().ToLower()).ToList();

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
    }
}
