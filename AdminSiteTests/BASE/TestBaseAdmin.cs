namespace AdminSiteTests.BASE
{

    public class TestBaseAdmin : BaseWeb
    {

        [SetUp]

        public void SetUp()
        {
            Browser.Initialize();
            Browser._Driver.Navigate().GoToUrl(AdminEndpoints.ADMIN_HOST);
        }

    }
}
