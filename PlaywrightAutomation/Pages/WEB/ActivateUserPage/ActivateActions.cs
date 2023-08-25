
using RimuTec.Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.ActivateUserPage
{
    public partial class Activate
    {
        public static async Task  EnterFirstName()
        {
            await InputBox.TypeText(inputFirstName, Name.FirstName().Replace("'", ""));
        }

        public static async Task  EnterLastName()
        {
            await InputBox.TypeText(inputLastName, Name.LastName().Replace("'", ""));
        }

        public static async Task  EnterPhone()
        {
            await InputBox.TypeText(inputPhone, RandomHelper.RandomPhone());
        }

        public static async Task  EnterPassword()
        {
            await InputBox.TypeText(inputPassword, Credentials.USER_PASSWORD);
        }

        public static async Task  ClickActivateBtn()
        {
            await Button.Click(btnActivateAccount);
        }

        public static async Task  ActivateUserEnterData(string email)
        {
            await EnterFirstName();
            await EnterLastName();
            await EnterPhone();
            await EnterPassword();
            await VerifyIsDisplayedEmail(email);
            await ClickActivateBtn();
        }

        public static async Task VerifyIsDisplayedEmail(string email)
        {
            await WaitUntil.ElementIsVisible(inputEmail);
            Assert.That((await TextBox.GetAttribute(inputEmail, "value")) == email, Is.True, $"Emails are not matched, must be {email} but was {(await TextBox.GetAttribute(inputEmail, "value"))}");
        }

        public static async Task VerifySuccessfullActivation()
        {
            await WaitUntil.ElementIsVisible(titleActivatedAccount);
            Assert.That((await Browser.Driver.QuerySelectorAsync(titleActivatedAccount)).IsVisibleAsync().Result, Is.True, "Thank You page is not displayed");
        }
    }
}
