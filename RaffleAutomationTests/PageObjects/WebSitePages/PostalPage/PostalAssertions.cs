namespace RaffleAutomationTests.PageObjects
{
    public partial class Postal
    {
        public Postal VerifyDisplayingTitle()
        {
            WaitUntil.CustomElementIsVisible(textTitlePostPage);
            Assert.IsTrue(textTitlePostPage.Text.ToLower() == PostText.TITLE_POST.ToLower());
            return this;
        }
        public Postal VerifyDisplayingParagraphs()
        {
            WaitUntil.CustomElementIsVisible(textParagraphsPostPage.FirstOrDefault());
            List<string> expectedText = PostText.PARAGRAPH_POST.Where(x => x.Any()).Select(x => x.Trim().ToLower()).ToList();
            List<string> actualText = textParagraphsPostPage.Where(x => x.Enabled).Select(x => x.Text.Trim().ToLower()).ToList();

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
        public Postal VerifyDisplayingLinks()
        {
            WaitUntil.CustomElementIsVisible(textLinksPostPage.FirstOrDefault());
            for (int i = 0; i < textLinksPostPage.Count; i++)
            {
                Assert.IsTrue(textLinksPostPage[i].Text.ToLower() + " " == PostText.PARAGRAPH_LINKS_POST[i].TrimEnd().ToLower(), string.Concat("\"", textLinksPostPage[i].Text, "\"", "\r\nnot matched with ", "\"", PostText.PARAGRAPH_LINKS_POST[i].TrimEnd(' '), "\""));
            }

            return this;
        }
    }
}
