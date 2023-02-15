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
            for (int i = 0; i < textParagraphsPostPage.Count; i++)
            {
                string t = textParagraphsPostPage[i].Text.Trim().ToLower();
                string q = textParagraphsPostPage[i].Text.Trim().ToLower(); //PostText.PARAGRAPH_POST[i].Trim().ToLower();
                Assert.IsTrue(t == q, "\r\n" + textParagraphsPostPage[i].Text + "\r\n not matched with " + "\r\n" + PostText.PARAGRAPH_POST[i]);
            }

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
