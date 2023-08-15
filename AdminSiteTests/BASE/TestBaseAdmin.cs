namespace AdminSiteTests.BASE
{

    public class TestBaseAdmin : BaseWeb
    {

        [SetUp]

        public void SetUp()
        {
            Browser.Initialize();
            Browser.Driver.Navigate().GoToUrl(AdminEndpoints.ADMIN_HOST);
        }

    }
}
