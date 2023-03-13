using System.Linq;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Footer
    {
        public Footer OpenTerms()
        {
            var linkTerms = textLinkContactsFooter.Where(x => x.Text.Contains("Terms & Conditions")).Select(x => x).First();
            Button.ClickJS(linkTerms);

            return this;
        }

        public Footer OpenPrivacy()
        {
            var linkTerms = textLinkContactsFooter.Where(x => x.Text.Contains("Privacy Policy")).Select(x => x).First();
            Button.ClickJS(linkTerms);

            return this;
        }
    }
}
