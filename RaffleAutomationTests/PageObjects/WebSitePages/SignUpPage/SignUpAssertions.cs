namespace RaffleAutomationTests.PageObjects
{
    public partial class SignUp
    {
        public static string GetEmail()
        {
            string getEmail = Browser._Driver.FindElement(By.XPath("//input[@name='email']")).GetAttribute("value");
            string email = getEmail.ToLower();

            return email;
        }


        public SignUp VerifyEmail(string email)
        {
            WaitUntil.CustomElementIsVisible(Pages.Profile.titleProfile);
            string emailFld = inputEmail.GetAttribute("value").ToLower();

            Assert.AreEqual(email, emailFld);

            return this;
        }

        public SignUp VerifyVisibilityOfToaster(string email)
        {
            string s = Putsbox.GetLinkFromEmailWithValue(email, "Verify");
            Browser._Driver.Navigate().GoToUrl(s);
            WaitUntil.CustomElementIsVisible(toasterSuccessMessage);


            return this;
        }

        public void VerifyDisplayingFirstNameErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textFirstNameErrorMessage);
            Assert.IsTrue(textFirstNameErrorMessage.Displayed, "First name error message is not displayed");
        }

        public void VerifyDisplayingLastNameErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textLastNameErrorMessage);
            Assert.IsTrue(textLastNameErrorMessage.Displayed, "Last name error message is not displayed");
        }

        public void VerifyDisplayingEmailErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textEmailErrorMessage);
            Assert.IsTrue(textEmailErrorMessage.Displayed, "Email error message is not displayed");
        }

        public void VerifyDisplayingPhoneErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textPhoneErrorMessage);
            Assert.IsTrue(textPhoneErrorMessage.Displayed, "Phone error message is not displayed");
        }

        public void VerifyDisplayingPasswordErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textPasswordErrorMessage);
            Assert.IsTrue(textPasswordErrorMessage.Displayed, "Password error message is not displayed");
        }

        public void VerifyValidationOnSignUp()
        {
            for (int i = 0; i < 19; i++)
            {
                switch (i)
                {
                    case 0:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, "");
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 1:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, "q");
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 2:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Lorem.ParagraphByChars(51).Trim(' ')); //51 characters
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 3:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, "qwe1234");
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 4:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, "Qqweqe!@#$%");
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 5:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, "");
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 6:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, "q");
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 7:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Lorem.ParagraphByChars(51).Trim(' ')); //51 characters
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 8:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, "qqweq123132");
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 9:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, "QWaass$%^&*");
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;

                    case 10:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 11:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 12:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + " @putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 13:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 14:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "");
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 15:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11");
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 16:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz123456789012345678"); //21 characters
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 17:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "qwertyi");
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 18:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "1234567");
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 19:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "!@#$%^&");
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;

                }
            }
        }
    }
}
