using Microsoft.Playwright;
using PlaywrightAutomation.Base.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Base.Helpers.Helpers;

namespace PlaywrightAutomation.Pages.CMS.DreamHomePage
{
    public partial class Dreamhome
    {
        public static async Task OpenDreamHomePage(IPage page)
        {
            await GoToPage(page, Endpoints.dreamhomePage, btnEditDreamHome);
        }

        public static async Task EditDreamHome(IPage page, int dreamNumber)
        {
            await WaitUntil.ElementIsVisible(page, btnEditDreamHome);
            var btnEditRaffle = page.GetByRole(AriaRole.Button, new() { Name = "Edit" }).Nth(dreamNumber);
            await btnEditRaffle.ClickAsync();
        }

        public static async Task<int> MoveImages(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, listImgMobileLast10);
            var sourceElement = await page.QuerySelectorAllAsync(listImgDesktop);
            var targetElement = await page.QuerySelectorAllAsync(listImgDesktop);
            var sourceBoundingBox = await sourceElement[2].BoundingBoxAsync();
            var targetBoundingBox = await targetElement[6].BoundingBoxAsync();
            await page.Mouse.MoveAsync(sourceBoundingBox.X + sourceBoundingBox.Width / 2, sourceBoundingBox.Y + sourceBoundingBox.Height / 2);
            await page.Mouse.DownAsync();
            await page.Mouse.MoveAsync(targetBoundingBox.X + targetBoundingBox.Width / 2, targetBoundingBox.Y + targetBoundingBox.Height / 2);
            await page.Mouse.UpAsync();
            return sourceElement.Count;
        }

        public static async Task ClickSave(IPage page)
        {
            await page.WaitForSelectorAsync("//button[.='Save']");
            var btnEditRaffle = page.GetByRole(AriaRole.Button, new() { Name = "Save" });
            await btnEditRaffle.ClickAsync();
        }

        public static async Task VerifyDisplayingOfDreamhome(IPage page, IBrowserContext context, int count)
        {
            await WaitUntil.ElementIsVisible(page, "//div[@id='root']//div[contains(text(), 'Dream home updated')]");
            await WaitUntil.ElementIsInvisible(page, "//div[@id='root']//div[contains(text(), 'Dream home updated')]");
        }



    }
}
