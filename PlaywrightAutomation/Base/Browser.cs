using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit;
using NUnit.Allure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation
{
    public class Browser
    {
        public static IPage page { get; set; }
        private static IBrowserContext browserContext { get; set; }

        public static async Task Initialize()
        {
            var pl = await Playwright.CreateAsync();
            var browser = await pl.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false

            });
            browserContext = await browser.NewContextAsync();
            page = await browserContext.NewPageAsync();
            await Driver.SetViewportSizeAsync(width: 1920, height: 1020);
        }

        public static IPage Driver => page;
        public static IBrowserContext BrowserContext => browserContext;
    }

    public class Base : PlaywrightTest
    {

        [SetUp]
        public async Task SetUp()
        {
            await Browser.Initialize();
            await Helpers.GoToPage(Endpoints.Web.WEBSITE_HOST, "//h1");
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.Driver.CloseAsync();
            await Browser.BrowserContext.CloseAsync();
        }

    }

}
