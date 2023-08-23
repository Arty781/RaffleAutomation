using PlaywrightAutomation.Base.Helpers;
using PlaywrightAutomation.Pages.CMS.SidebarPage;
using static PlaywrightAutomation.Base.Helpers.Helpers;

namespace PlaywrightAutomation.Pages.CMS.LoginPage
{
    public partial class Login
    {
        public static async Task MakeLogin(IPage page, string email, string password)
        {
            await GoToPage(page, Endpoints.loginPage, btnSignIn);
            await InputBox.TypeText(page, inputEmail, email); 
            await InputBox.TypeText(page, inputPassword, password);
            await Button.Click(page, btnSignIn);
            await WaitUntil.ElementIsVisible(page, Sidebar.linkHomePage);
        }
    }
}
