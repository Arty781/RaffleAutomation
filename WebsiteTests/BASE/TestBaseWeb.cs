﻿namespace WebsiteTests.BASE
{

    public class TestBaseWeb : BaseWeb
    {
        [SetUp]
        public void Initialize()
        {
            Browser.Initialize();
            Browser.Driver.Navigate().GoToUrl(WebEndpoints.WEBSITE_HOST);
        }
    }
}
