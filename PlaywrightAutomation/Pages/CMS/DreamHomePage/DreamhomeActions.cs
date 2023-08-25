using Microsoft.Playwright;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.CMS.DreamHomePage
{
    public partial class Dreamhome
    {
        public static async Task OpenDreamHomePage()
        {
            await GoToPage(Endpoints.dreamhomePage, btnEditDreamHome);
        }

        public static async Task EditDreamHome(int dreamNumber)
        {
            await WaitUntil.ElementIsVisible(btnEditDreamHome);
            var btnEditRaffle = Browser.Driver.GetByRole(AriaRole.Button, new() { Name = "Edit" }).Nth(dreamNumber);
            await btnEditRaffle.ClickAsync();
        }

        public static async Task<int> MoveImages()
        {
            await WaitUntil.ElementIsVisible(listImgMobileLast10);
            var sourceElement = await Browser.Driver.QuerySelectorAllAsync(listImgDesktop);
            var targetElement = await Browser.Driver.QuerySelectorAllAsync(listImgDesktop);
            var sourceBoundingBox = await sourceElement[2].BoundingBoxAsync();
            var targetBoundingBox = await targetElement[6].BoundingBoxAsync();
            await Browser.Driver.Mouse.MoveAsync(sourceBoundingBox.X + sourceBoundingBox.Width / 2, sourceBoundingBox.Y + sourceBoundingBox.Height / 2);
            await Browser.Driver.Mouse.DownAsync();
            await Browser.Driver.Mouse.MoveAsync(targetBoundingBox.X + targetBoundingBox.Width / 2, targetBoundingBox.Y + targetBoundingBox.Height / 2);
            await Browser.Driver.Mouse.UpAsync();
            return sourceElement.Count;
        }

        public static async Task ClickSave()
        {
            await Browser.Driver.WaitForSelectorAsync("//button[.='Save']");
            var btnEditRaffle = Browser.Driver.GetByRole(AriaRole.Button, new() { Name = "Save" });
            await btnEditRaffle.ClickAsync();
        }

        public static async Task VerifyDisplayingOfDreamhome(int count)
        {
            await WaitUntil.ElementIsVisible("//div[@id='root']//div[contains(text(), 'Dream home updated')]");
            await WaitUntil.ElementIsInvisible("//div[@id='root']//div[contains(text(), 'Dream home updated')]");
        }



    }
}
