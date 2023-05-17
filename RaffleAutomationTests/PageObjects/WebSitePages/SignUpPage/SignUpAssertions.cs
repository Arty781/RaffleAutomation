namespace RaffleAutomationTests.PageObjects
{
    public partial class SignUp
    {
        [AllureStep("Get email value")]
        public static string GetEmail()
        {
            string getEmail = Browser._Driver.FindElement(By.XPath("//input[@name='email']")).GetAttribute("value");
            string email = getEmail.ToLower();

            return email;
        }

        [AllureStep("Verify Email")]
        public SignUp VerifyEmail(string email)
        {
            WaitUntil.CustomElementIsVisible(Pages.Profile.titleProfile);
            string emailFld = inputEmail.GetAttribute("value").ToLower();

            Assert.AreEqual(email, emailFld);

            return this;
        }

        [AllureStep("Verify Visibility Of Toaster")]
        public SignUp VerifyVisibilityOfToaster(string email)
        {
            string s = Putsbox.GetLinkFromEmailWithValue(email, "Verify");
            Browser._Driver.Navigate().GoToUrl(s);
            WaitUntil.CustomElementIsVisible(toasterSuccessMessage);


            return this;
        }

        [AllureStep("Verify Displaying First Name Error Message")]
        public void VerifyDisplayingFirstNameErrorMessage()
        {
            WaitUntil.WaitSomeInterval(550);
            WaitUntil.CustomElementIsVisible(textFirstNameErrorMessage);
            Assert.IsTrue(textFirstNameErrorMessage.Displayed, "First name error message is not displayed");
        }

        [AllureStep("Verify Displaying Last Name Error Message")]
        public void VerifyDisplayingLastNameErrorMessage()
        {
            WaitUntil.WaitSomeInterval(550);
            WaitUntil.CustomElementIsVisible(textLastNameErrorMessage);
            Assert.IsTrue(textLastNameErrorMessage.Displayed, "Last name error message is not displayed");
        }

        [AllureStep("Verify Displaying Email Error Message")]
        public void VerifyDisplayingEmailErrorMessage()
        {
            WaitUntil.WaitSomeInterval(550);
            WaitUntil.CustomElementIsVisible(textEmailErrorMessage);
            Assert.IsTrue(textEmailErrorMessage.Displayed, "Email error message is not displayed");
        }

        [AllureStep("Verify Displaying Phone Error Message")]
        public void VerifyDisplayingPhoneErrorMessage()
        {
            WaitUntil.WaitSomeInterval(550);
            WaitUntil.CustomElementIsVisible(textPhoneErrorMessage);
            Assert.IsTrue(textPhoneErrorMessage.Displayed, "Phone error message is not displayed");
        }

        [AllureStep("Verify Displaying Password Error Message")]
        public void VerifyDisplayingPasswordErrorMessage()
        {
            WaitUntil.WaitSomeInterval(550);
            WaitUntil.CustomElementIsVisible(textPasswordErrorMessage);
            Assert.IsTrue(textPasswordErrorMessage.Displayed, "Password error message is not displayed");
        }

        [AllureStep("Verify Firstname field Validation On SignUp")]
        public void VerifyFirstnameValidationOnSignUp()
        {
            for (int i = 0; i <= 4; i++)
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
                }
            }
        }

        [AllureStep("Verify Lastname field Validation On SignUp")]
        public void VerifyLastnameValidationOnSignUp()
        {
            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, "");
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 1:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, "q");
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 2:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Lorem.ParagraphByChars(51).Trim(' ')); //51 characters
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 3:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, "qqweq123132");
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 4:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, "QWaass$%^&*");
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                }
            }
        }

        [AllureStep("Verify Email field Validation On SignUp")]
        public void VerifyEmailValidationOnSignUp()
        {
            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 1:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 2:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + " @putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 3:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 4:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11111");
                        ClickSignUpBtn();
                        VerifyDisplayingEmailErrorMessage();
                        break;


                }
            }
        }

        [AllureStep("Verify Password field validation on signUp")]
        public void VerifyPasswordValidationOnSignUp()
        {
            for (int i = 0; i <= 5; i++)
            {
                switch (i)
                {
                    
                    case 0:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "");
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 1:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz11");
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 2:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "Qaz123456789012345678"); //21 characters
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 3:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "qwertyi");
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 4:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputSurname, 10, Name.LastName());
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        InputBox.Element(inputPassword, 10, "1234567");
                        ClickSignUpBtn();
                        VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 5:
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
