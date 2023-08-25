using SMTP_API;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.ResetPasswordPage
{
    public partial class ResetPassword
    {
        public static async Task RequestForgotPassword(string email)
        {
            await InputBox.TypeText(inputEmail, email);
            await Button.Click(btnRequest);
        }

        public static async Task ClickOkBtn()
        {
            await Button.Click(btnOk);
        }

        public static async Task GoToResetPassLink(string email)
        {
            var resetPassLink = PutsBox.GetLinkFromEmailWithValue(email, "Reset Password");
            await GoToPage(resetPassLink, btnSetNewPassword);
        }

        public static async Task GetResetPassword()
        {
            await InputBox.TypeText(inputPassword, Credentials.NEW_PASWORD);
            await InputBox.TypeText(inputConfirmPassword, Credentials.NEW_PASWORD);
            await Button.Click(btnSetNewPassword);
        }
    }
}
