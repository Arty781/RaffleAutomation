using NUnit.Framework;
using RaffleAutomationTests.Helpers;

namespace WebsiteTests.BASE
{

    public class TestBaseWeb : BaseWeb
    {
        [SetUp]
        public void Initialize()
        {
            Browser.Initialize();
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.WEBSITE_HOST);
        }
    }
}
