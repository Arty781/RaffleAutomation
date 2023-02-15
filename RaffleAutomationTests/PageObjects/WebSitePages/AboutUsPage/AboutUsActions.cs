namespace RaffleAutomationTests.PageObjects
{
    public partial class AboutUs
    {
        public AboutUs OpenAboutPage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);
            WaitUntil.CustomElementIsVisible(titleAboutPage);


            return this;
        }
    }
}
