namespace RaffleAutomationTests.PageObjects.WebSitePages.TermsAndConditionsPage
{
    public partial class TermsAndConditions
    {
        public TermsAndConditions VerifyDisplayingParagraphs(string actualTerms, string actualPrivacy)
        {
            WaitUntil.CustomElementIsVisible(titleTermsAndConditions);

            Assert.Multiple(() =>
            {
                Assert.That(actualTerms, Is.EqualTo(TermsConditions.TERMS), "Texts don't match");
                Assert.That(TermsConditions.TERMS.Length, Is.EqualTo(actualTerms.Length), "Text length doesn't match");

                var mismatchedIndicesTerms = TermsConditions.TERMS.Select((text, index) => new { text, index })
                    .Where(predicate: item => !actualTerms[item.index].Equals(item.text))
                    .Select(item => item.index)
                    .ToList();

                if (mismatchedIndicesTerms.Count > 0)
                {
                    string errorMessage = $"Expected text does not match the actual text at index(es): {string.Join(", ", mismatchedIndicesTerms)}";
                    Assert.Fail(errorMessage);
                }

                Assert.That(actualPrivacy, Is.EqualTo(TermsConditions.POLICY), "Texts don't match");
                Assert.That(TermsConditions.POLICY.Length, Is.EqualTo(actualPrivacy.Length), "Text length doesn't match");

                var mismatchedIndicesPrivacy = TermsConditions.POLICY.Select((text, index) => new { text, index })
                    .Where(predicate: item => !actualPrivacy[item.index].Equals(item.text))
                    .Select(item => item.index)
                    .ToList();

                if (mismatchedIndicesPrivacy.Count > 0)
                {
                    string errorMessage = $"Expected text does not match the actual text at index(es): {string.Join(", ", mismatchedIndicesPrivacy)}";
                    Assert.Fail(errorMessage);
                }
            });



            return this;
        }
    }
}
