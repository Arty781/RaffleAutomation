namespace RaffleAutomationTests.PageObjects
{
    public partial class Footer
    {
        public Footer VerifyIsDisplayedFooterTitle()
        {
            WaitUntil.CustomElementIsVisible(textTitleFooter);
            Assert.IsTrue(textTitleFooter.Text.ToLower() == FooterText.FOOTER_TITLE.ToLower(), string.Concat("\"", textTitleFooter.Text, "\"", " not matched with ", FooterText.FOOTER_TITLE));

            return this;
        }

        public Footer VerifyIsDisplayedFooterParagraph()
        {
            WaitUntil.CustomElementIsVisible(textParagraphFooter);
            Assert.IsTrue(textParagraphFooter.Text.ToLower() == FooterText.FOOTER_PARAGRAPH.ToLower(), string.Concat("\"", textParagraphFooter.Text, "\"", " not matched with ", FooterText.FOOTER_PARAGRAPH));

            return this;
        }

        public Footer VerifyIsDisplayedContactLinks()
        {
            WaitUntil.CustomElementIsVisible(textLinkContactsFooter.FirstOrDefault());
            for (int i = 0; i < textLinkContactsFooter.Count; i++)
            {
                string expectedLink = FooterText.FOOTER_CONTACTS_LINKS[i].ToLower();
                string actualLink = textLinkContactsFooter[i].Text.ToLower();
                Assert.AreEqual(expectedLink, actualLink, $"Not matched. Expected: \"{expectedLink}\". Actual: \"{actualLink}\"");
            }

            return this;
        }

        public Footer VerifyIsDisplayedSponsorLinks()
        {
            WaitUntil.CustomElementIsVisible(textLinkSponsorFooter.FirstOrDefault());
            for (int i = 0; i < textLinkSponsorFooter.Count; i++)
            {
                Assert.IsTrue(textLinkSponsorFooter[i].Text.ToLower() == FooterText.FOOTER_SPONSORS_LINKS[i].ToLower(), string.Concat("\"", textLinkSponsorFooter[i].Text, "\"", " not matched with ", FooterText.FOOTER_SPONSORS_LINKS[i]));
            }


            return this;
        }
    }
}
