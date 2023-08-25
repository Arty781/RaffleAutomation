using PlaywrightAutomation.Pages.CMS.SidebarPage;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.CMS.LoginPage
{
    public partial class Login
    {
        public static async Task MakeLoginCMS(string email, string password)
        {
            await GoToPage(Endpoints.loginPage, btnSignIn);
            await InputBox.TypeText(inputEmail, email); 
            await InputBox.TypeText(inputPassword, password);
            await Button.Click(btnSignIn);
            await WaitUntil.ElementIsVisible(Sidebar.linkHomePage);
        }
    }
}
