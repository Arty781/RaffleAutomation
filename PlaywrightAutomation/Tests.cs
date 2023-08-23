using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightAutomation.Base.Helpers;
using PlaywrightAutomation.Pages;
using PlaywrightAutomation.Pages.CMS.DreamHomePage;
using PlaywrightAutomation.Pages.CMS.LoginPage;
using PlaywrightAutomation.Pages.CMS.UserManagementPage;
using static PlaywrightAutomation.Base.Helpers.Helpers;

namespace PlaywrightAutomation
{
    [TestFixture]
    public class Tests : PlaywrightTest
    {
        [Test]
        public async Task EditDreamhomeAndMoveImages()
        {
            var (page, context) = await BrowserClass.Initialize();

            await Login.MakeLogin(page, Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            await Dreamhome.OpenDreamHomePage(page);
            await Dreamhome.EditDreamHome(page, 0);
            int count = await Dreamhome.MoveImages(page);
            await Dreamhome.ClickSave(page);
            await Dreamhome.ClickSave(page);
            await Dreamhome.ClickSave(page);
            await Dreamhome.VerifyDisplayingOfDreamhome(page, context, count);
            await Dreamhome.EditDreamHome(page, 0);
            await WaitUntil.ElementIsVisible(page, Dreamhome.listImgMobileLast10);
            await page.CloseAsync(); // Close the page when you're done
            await context.CloseAsync();
        }

        [Test]
        public async Task CreateUserOnCms()
        {
            var (page, context) = await BrowserClass.Initialize();
            var email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"), "@putsbox.com");
            await Login.MakeLogin(page, Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            await UserManagement.OpenUserManagement(page);
            await UserManagement.ClickAddNewBtn(page);
            await UserManagement.EnterUserData(page, email);
            await UserManagement.ClickSave(page);
            await UserManagement.SearchUser(page, email);
            Assert.That(actual: SMTP_API.PutsBox.CheckEmailBySubject(email, "Create account", "Your temporary password is: "), expression: Is.Not.Null);
        } 
    }
}