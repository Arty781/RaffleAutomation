namespace RaffleAutomationTests.PageObjects
{
    public partial class Profile
    {
        public Profile VerifyDisplayingSuccessfullToaster()
        {
            WaitUntil.WaitSomeInterval(350);
            WaitUntil.CustomElementIsVisible(SuccessUpdateDialog);
            Assert.IsTrue(SuccessUpdateDialog.Displayed);

            return this;
        }

        public Profile VerifyUpdatePasswordSuccessfullToaster()
        {
            WaitUntil.WaitSomeInterval(350);
            WaitUntil.CustomElementIsVisible(SuccessUpdatePasswordDialog);
            Assert.IsTrue(SuccessUpdatePasswordDialog.Displayed);

            return this;
        }

        public Profile VerifyAddingTickets(double price)
        {
            WaitUntil.CustomElementIsVisible(prizePrice.Last());
            Assert.AreEqual(price, double.Parse(prizePrice.First().Text.Trim('£')));

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

        public void VerifyDisplayingOldPasswordErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textOldPasswordErrorMessage);
            Assert.IsTrue(textOldPasswordErrorMessage.Displayed, "Old Password error message is not displayed");
        }

        public void VerifyDisplayingNewPasswordErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textNewPasswordErrorMessage);
            Assert.IsTrue(textNewPasswordErrorMessage.Displayed, "New Password error message is not displayed");
        }

        public void VerifyDisplayingConfirmPasswordErrorMessage()
        {
            WaitUntil.WaitSomeInterval(250);
            WaitUntil.CustomElementIsVisible(textConfirmPasswordErrorMessage);
            Assert.IsTrue(textConfirmPasswordErrorMessage.Displayed, "Confirm Password error message is not displayed");
        }

        public void VerifyValidationOnProfilePersonalDetails()
        {
            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 0:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, "");
                        InputBox.Element(inputLastName, 10, Name.LastName());
                        Button.ClickJS(btnSave);
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 1:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, "q");
                        InputBox.Element(inputLastName, 10, Name.LastName());
                        Button.ClickJS(btnSave);
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 2:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, "qtweqweqwueyqwyfeasdasgdjadasdasdasgdjadasdasdasgdjadasda"); //51 characters
                        InputBox.Element(inputLastName, 10, Name.LastName());
                        Button.ClickJS(btnSave);
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 3:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, "qwe1234");
                        InputBox.Element(inputLastName, 10, Name.LastName());
                        Button.ClickJS(btnSave);
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 4:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, "Qqweqe!@#$%");
                        InputBox.Element(inputLastName, 10, Name.LastName());
                        Button.ClickJS(btnSave);
                        VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 5:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputLastName, 10, "");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 6:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputLastName, 10, "q");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 7:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputLastName, 10, "qtweqweqwueyqwyfeasdasgdjadasdasdasgdjadasdasdasgdjadasda"); //51 characters
                        Button.ClickJS(btnSave);
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 8:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputLastName, 10, "qqweq123132");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 9:
                        WaitUntil.CustomElementIsVisible(inputFirstName);
                        InputBox.Element(inputFirstName, 10, Name.FirstName());
                        InputBox.Element(inputLastName, 10, "QWaass$%^&*");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingLastNameErrorMessage();
                        break;

                }
            }
        }

        public void VerifyValidationOnProfilePassword()
        {
            for (int i = 0; i < 11; i++)
            {
                switch (i)
                {
                    case 0:
                        InputBox.Element(inputCurrentPassword, 10, "");
                        InputBox.Element(inputNewPassword, 10, "Qaz11111!");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 1:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz11");
                        InputBox.Element(inputNewPassword, 10, "Qaz11111!");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 2:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz123456789012345678");
                        InputBox.Element(inputNewPassword, 10, "Qaz11111!");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 3:
                        InputBox.Element(inputCurrentPassword, 10, "Qwertyui");
                        InputBox.Element(inputNewPassword, 10, "Qaz11111!");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 4:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz11111");
                        InputBox.Element(inputNewPassword, 10, "");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 5:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz11111");
                        InputBox.Element(inputNewPassword, 10, "Qaz11");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 6:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz11111");
                        InputBox.Element(inputNewPassword, 10, "Qaz123456789012345678");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 7:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz11111");
                        InputBox.Element(inputNewPassword, 10, "Qwertyui");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 8:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz11111");
                        InputBox.Element(inputNewPassword, 10, "123456789");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 9:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz11111");
                        InputBox.Element(inputNewPassword, 10, "!@#$%^^&!");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 10:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz11111");
                        InputBox.Element(inputNewPassword, 10, "Qaz11111!");
                        InputBox.Element(inputConfirmPassword, 10, "");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingConfirmPasswordErrorMessage();
                        break;
                    case 11:
                        InputBox.Element(inputCurrentPassword, 10, "Qaz11111");
                        InputBox.Element(inputNewPassword, 10, "Qaz11111!");
                        InputBox.Element(inputConfirmPassword, 10, "Qaz11111");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingConfirmPasswordErrorMessage();
                        break;

                }
            }
        }

        public void VerifyValidationOnProfileAccountDetails()
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        InputBox.Element(inputEmail, 10, "");
                        InputBox.Element(inputPhone, 10, "953214567");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 1:
                        InputBox.Element(inputEmail, 10, string.Join(" qatester-", DateTime.Now.ToString("yyyy-MM-dThh-mm-ss"), "  ","@putsbox.com "));
                        InputBox.Element(inputPhone, 10, "953214567");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 2:
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "putsbox.com");
                        InputBox.Element(inputPhone, 10, "953214567");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 3:
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@@putsbox.com");
                        InputBox.Element(inputPhone, 10, "953214567");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 4:
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox");
                        InputBox.Element(inputPhone, 10, "953214567");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingEmailErrorMessage();
                        break;
                    case 5:
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingPhoneErrorMessage();
                        break;
                    case 6:
                        InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        InputBox.Element(inputPhone, 10, "9532145");
                        Button.ClickJS(btnSave);
                        VerifyDisplayingPhoneErrorMessage();
                        break;

                }
            }
        }
    }
}
