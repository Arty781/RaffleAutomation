namespace End2EndTests.BASE
{

    public class TestBaseE2E : BaseWeb
    {
        [SetUp]
        public void Initialize()
        {
            Browser.Initialize();
            Browser._Driver.Navigate().GoToUrl(AdminEndpoints.ADMIN_HOST);
        }
    }
}
