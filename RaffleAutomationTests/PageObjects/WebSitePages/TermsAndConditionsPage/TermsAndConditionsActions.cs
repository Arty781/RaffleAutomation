namespace RaffleAutomationTests.PageObjects.WebSitePages.TermsAndConditionsPage
{
    public partial class TermsAndConditions
    {
        public string GetTextTerms()
        {
            WaitUntil.CustomElementIsVisible(titleTermsAndConditions);
            var str = textTerms.Text;
            return str;
        }

        public string GetTextPrivacy()
        {
            WaitUntil.CustomElementIsVisible(titleTermsAndConditions);
            var str = textPrivacy.Text;
            return str;
        }
    }
}
