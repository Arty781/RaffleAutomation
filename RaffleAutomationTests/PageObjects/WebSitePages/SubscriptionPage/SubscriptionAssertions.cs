namespace RaffleAutomationTests.PageObjects.WebSitePages
{
    public partial class Subscription
    {
        public Subscription VerifyDisplayingH1()
        {
            WaitUntil.CustomElementIsVisible(titleH1);
            string expectedText = SubscriptionTexts.TITLE_H1;
            string actualText = titleH1.Text;

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

            return this;
        }

        public Subscription VerifyDisplayingH2()
        {
            WaitUntil.CustomElementIsVisible(titleH2List.FirstOrDefault());
            List<string> expectedText = SubscriptionTexts.TITLES_H2.Where(x => x.Any()).Select(x => x.ToLower()).ToList();
            int index = 4;
            expectedText.Insert(index, ""); // adds an empty string at the specified index
            List<string> actualText = titleH2List.Where(x => x.Enabled).Select(x => x.Text.Trim().ToLower()).ToList();

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

            return this;
        }

        public Subscription VerifyDisplayingH3()
        {
            WaitUntil.CustomElementIsVisible(titleH2List.FirstOrDefault());
            List<string> expectedText = SubscriptionTexts.TITLES_H3.Where(x => x.Any()).Select(x => x.Trim().ToLower()).ToList();
            List<string> actualText = titleH3List.Where(x => x.Enabled).Select(x => x.Text.Trim().ToLower()).ToList();

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

            return this;
        }

        public Subscription VerifyDisplayingParagraphs()
        {
            WaitUntil.CustomElementIsVisible(paragraphList.FirstOrDefault());
            List<string> expectedText = SubscriptionTexts.PARAGRAPHS.Where(x => x.Any()).Select(x => x.Trim().ToLower()).ToList();
            int[] indexesToInsert = new int[] { 2, 26, 27, 28 };

            foreach (int index in indexesToInsert)
            {
                expectedText.Insert(index, "");
            }
            List<string> actualText = paragraphList.Where(x => x.Enabled).Select(x => x.Text.Trim().ToLower()).ToList();

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

            return this;
        }
    }
}
