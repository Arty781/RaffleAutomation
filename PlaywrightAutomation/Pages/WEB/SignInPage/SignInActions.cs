
using PlaywrightAutomation.Pages.WEB.UserProfilePage;
using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.SignInPage
{
    public partial class SignIn
    {
        public static async Task EnterLoginAndPass(string login, string password)
        {
            await WaitUntil.ElementIsVisible(inputLogin);
            await InputBox.TypeText(inputLogin, login);
            await InputBox.TypeText(inputPassword, password);
            await Button.Click(btnSignIn);
        }
        public static async Task MakeSignIn(string login, string password)
        {
            await GoToPage(Endpoints.Web.SIGN_IN, btnSignIn);
            await InputBox.TypeText(inputLogin, login);
            await InputBox.TypeText(inputPassword, password);
            await Button.Click(btnSignIn);
        }

        public static async Task ClickForgotPassword()
        {
            await Button.Click(btnForgotPassword);
        }

        
        public static async Task<string> VerifyIsSignIn()
        {
            await WaitUntil.ElementIsVisible(UserProfile.inputFirstName);
            return await TextBox.GetAttribute(UserProfile.inputFirstName, "value");
        }

        
        public static async Task<string> GetFirstName()
        {
            await WaitUntil.ElementIsVisible(UserProfile.inputFirstName);
            return await TextBox.GetAttribute(UserProfile.inputFirstName, "value");
        }

        
        public static async Task VerifyDisplayingEmailErrorMessage()
        {
            await WaitUntil.ElementIsVisible(textEmailErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textEmailErrorMessage)).IsVisibleAsync().Result, Is.True, "Email error message is not displayed");
        }

        
        public static async Task VerifyDisplayingPasswordErrorMessage()
        {
            await WaitUntil.ElementIsVisible(textPasswordErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textPasswordErrorMessage)).IsVisibleAsync().Result, Is.True, "Password error message is not displayed");
        }

        public static async Task VerifyValidationOnSignIn(SignUpResponse response)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        await EnterLoginAndPass("", Credentials.USER_PASSWORD);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 1:
                        await EnterLoginAndPass(response.User.Email.Replace("@p", "@ p"), Credentials.USER_PASSWORD);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 2:
                        await EnterLoginAndPass(response.User.Email.Replace(".com", ""), Credentials.USER_PASSWORD);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 3:
                        await EnterLoginAndPass(response.User.Email, "");
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 4:
                        await EnterLoginAndPass(response.User.Email, "qwertyzaq");
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 5:
                        await EnterLoginAndPass(response.User.Email, "123456789");
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 6:
                        await EnterLoginAndPass(response.User.Email, "Qaz1");
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                }
            }
        }
    }
}
