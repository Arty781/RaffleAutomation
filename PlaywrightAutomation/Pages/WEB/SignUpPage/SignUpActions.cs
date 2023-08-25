
using PlaywrightAutomation.Pages.WEB.UserProfilePage;
using RimuTec.Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.SignUpPage
{
    public partial class SignUp
    {
        public static async Task<string> EnterUserData()
        {
            string email = "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com";
            await InputBox.TypeText(inputFirstName, Name.FirstName());
            await InputBox.TypeText(inputSurname, Name.LastName());
            await InputBox.TypeText(inputEmail, email);
            await InputBox.TypeText(inputPhone, "");
            await InputBox.TypeText(inputPassword, "Qaz11111");
            await Button.Click(btnRememberMe);
            return email.ToLower();
        }

        public static async Task EnterUserDataForNonActivated(string email)
        {
            await InputBox.TypeText(inputFirstName, Name.FirstName());
            await InputBox.TypeText(inputSurname, Name.LastName());
            await InputBox.TypeText(inputEmail, email);
            await InputBox.TypeText(inputPhone, PhoneNumber.CellPhone());
            await InputBox.TypeText(inputPassword, "Qaz11111");
            await Button.Click(btnRememberMe);
        }

        public static async Task ClickSignUpBtn()
        {
            await Button.Click(btnSignUp);
        }

        public static async Task EnterFirstname(int charNumber, string charBefore, string charAfter)
        {
            await InputBox.TypeText(inputFirstName, String.Concat(charBefore, Lorem.Characters(charNumber), charAfter));
        }

        public static async Task EnterLastname(int charNumber, string charBefore, string charAfter)
        {
            await InputBox.TypeText(inputSurname, String.Concat(charBefore, Lorem.Characters(charNumber), charAfter));
        }

        public static async Task EnterEmail(string charBefore, string charInto, string charAfter)
        {
            await InputBox.TypeText(inputEmail, String.Concat(charBefore, "qatester-", DateTime.Now.ToString("yyyy-MM-dThh-mm-ss"), charInto, "@putsbox.com", charAfter));
        }

        public static async Task EnterPhone(int charNumber)
        {
            await InputBox.TypeText(inputPhone, RandomHelper.RandomPhone(charNumber));
        }

        public static async Task EnterPassword(string password)
        {
            await InputBox.TypeText(inputPassword, password);
        }

        public static async Task<string> GetEmail()
        {
            await WaitUntil.ElementIsVisible(SignUp.inputEmail);
            var getEmail = await Browser.Driver.GetAttributeAsync(inputEmail, "value");
            return getEmail.ToLower();
        }

        
         public static async Task VerifyEmail(string email)
        {
            await WaitUntil.ElementIsVisible(UserProfile.inputEmail);
            var emailFld = await Browser.Driver.GetAttributeAsync(inputEmail, "value");
            Assert.That(emailFld.ToLower(), Is.EqualTo(email));
        }

        
         public static async Task VerifyVisibilityOfToaster(string email)
        {
            string s = SMTP_API.PutsBox.GetLinkFromEmailWithValue(email, "Verify");
            await Browser.Driver.GotoAsync(s);
            await WaitUntil.ElementIsVisible(toasterSuccessMessage);
        }

        
         public static async Task VerifyDisplayingFirstNameErrorMessage()
        {
            await WaitUntil.ElementIsVisible(textFirstNameErrorMessage);
            Assert.That(await Browser.Driver.QuerySelectorAsync(textFirstNameErrorMessage).Result.IsVisibleAsync(), Is.True, "First name error message is not displayed");
        }

        
         public static async Task  VerifyDisplayingLastNameErrorMessage()
        {
            await WaitUntil.ElementIsVisible(textLastNameErrorMessage);
            Assert.That(await Browser.Driver.QuerySelectorAsync(textLastNameErrorMessage).Result.IsVisibleAsync(), Is.True, "Last name error message is not displayed");
        }

        
         public static async Task  VerifyDisplayingEmailErrorMessage()
        {
            await WaitUntil.ElementIsVisible(textEmailErrorMessage);
            Assert.IsTrue(await Browser.Driver.QuerySelectorAsync(textEmailErrorMessage).Result.IsVisibleAsync(), "Email error message is not displayed");
        }

        
         public static async Task  VerifyDisplayingPhoneErrorMessage()
        {
            await WaitUntil.ElementIsVisible(textPhoneErrorMessage);
            Assert.IsTrue(await Browser.Driver.QuerySelectorAsync(textPhoneErrorMessage).Result.IsVisibleAsync(), "Phone error message is not displayed");
        }

        
         public static async Task  VerifyDisplayingPasswordErrorMessage()
        {
            await WaitUntil.ElementIsVisible(textPasswordErrorMessage);
            Assert.IsTrue(await Browser.Driver.QuerySelectorAsync(textPasswordErrorMessage).Result.IsVisibleAsync(), "Password error message is not displayed");
        }

        
         public static async Task  VerifyFirstnameValidationOnSignUp()
        {
            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, "");
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, "q");
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Lorem.ParagraphByChars(51).Trim(' ')); //51 characters
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, "qwe1234");
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, "Qqweqe!@#$%");
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                }
            }
        }

        
         public static async Task  VerifyLastnameValidationOnSignUp()
        {
            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, "");
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, "q");
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Lorem.ParagraphByChars(51).Trim(' ')); //51 characters
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, "qqweq123132");
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, "QWaass$%^&*");
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                }
            }
        }

        
         public static async Task  VerifyEmailValidationOnSignUp()
        {
            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + " @putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;


                }
            }
        }

        
         public static async Task  VerifyPasswordValidationOnSignUp()
        {
            for (int i = 0; i <= 5; i++)
            {
                switch (i)
                {

                    case 0:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz11");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "Qaz123456789012345678"); //21 characters
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "qwertyi");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "1234567");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 5:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputSurname, Name.LastName());
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await InputBox.TypeText(inputPassword, "!@#$%^&");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;

                }
            }
        }
    }
}
