using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.ResetPasswordPage
{
    public partial class ResetPassword
    {
        public static async Task VerifySuccessfullMessageAppeared(string email)
        {
            await WaitUntil.ElementIsVisible(titleResetSuccess);
            Assert.That((await Browser.Driver.QuerySelectorAsync(titleResetSuccessEmail)).TextContentAsync().Result == email, Is.True, $"Expected {email}, but was {(await Browser.Driver.QuerySelectorAsync(titleResetSuccessEmail)).TextContentAsync().Result}");

        }
    }
}
