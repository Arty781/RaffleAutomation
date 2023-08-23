using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation
{
    public class BrowserClass 
    {
        public static async Task<(IPage, IBrowserContext)> Initialize()
        {
            var pl = await Playwright.CreateAsync();
            var browser = await pl.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
                
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.SetViewportSizeAsync(width: 1920, height: 1020);
            return (page, context);
        }

    }
}
