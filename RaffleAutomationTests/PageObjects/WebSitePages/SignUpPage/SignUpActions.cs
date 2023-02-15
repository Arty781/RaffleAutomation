namespace RaffleAutomationTests.PageObjects
{
    public partial class SignUp
    {
        [AllureStep("Get Country list")]
        public List<string> GetCountryList()
        {
            List<string> countrylist = new List<string>();
            for (int i = 0; i < listCountryAll.Count; i++)
            {
                countrylist.Add(listCountryAll[i].Text);
                Console.WriteLine(countrylist[i]);
            }
            return countrylist;
        }

        [AllureStep("Enter user data")]
        public SignUp EnterUserData()
        {
            WaitUntil.CustomElementIsVisible(inputFirstName);
            InputBox.Element(inputFirstName, 10, Name.FirstName());
            InputBox.Element(inputSurname, 10, Name.LastName());
            InputBox.Element(inputEmail, 10, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
            Button.Click(inputCountry);
            Button.ClickCountryJS(inputCountry);
            InputBox.Element(inputPhone, 10, "");
            InputBox.Element(inputPassword, 10, "Qaz11111");
            Button.Click(btnConfirmOpt);
            Button.Click(btnRememberMe);

            return this;
        }

        [AllureStep("Click \"Sign Up\" button")]
        public SignUp ClickSignUpBtn()
        {
            WaitUntil.CustomElementIsVisible(btnSignUp);
            btnSignUp.Click();

            return this;
        }

        [AllureStep("Enter Firstname")]
        public SignUp EnterFirstname(int charNumber, string charBefore, string charAfter)
        {
            WaitUntil.CustomElementIsVisible(inputFirstName);
            InputBox.Element(inputFirstName, 10, String.Concat(charBefore, Lorem.Characters(charNumber), charAfter));

            return this;
        }

        [AllureStep("Enter Lastname")]
        public SignUp EnterLastname(int charNumber, string charBefore, string charAfter)
        {
            WaitUntil.CustomElementIsVisible(inputSurname);
            InputBox.Element(inputSurname, 10, String.Concat(charBefore, Lorem.Characters(charNumber), charAfter));

            return this;
        }

        [AllureStep("Enter Email")]
        public SignUp EnterEmail(string charBefore, string charInto, string charAfter)
        {
            WaitUntil.CustomElementIsVisible(inputEmail);
            InputBox.Element(inputEmail, 10, String.Concat(charBefore, "qatester-", DateTime.Now.ToString("yyyy-MM-dThh-mm-ss"), charInto, "@putsbox.com", charAfter));

            return this;
        }

        [AllureStep("Enter Phone")]
        public SignUp EnterPhone(int charNumber)
        {
            WaitUntil.CustomElementIsVisible(inputPhone);
            InputBox.Element(inputPhone, 10, RandomHelper.RandomPhone(charNumber));

            return this;
        }

        [AllureStep("Enter Password")]
        public SignUp EnterPassword(string password)
        {
            WaitUntil.CustomElementIsVisible(inputPassword);
            InputBox.Element(inputPassword, 10, password);

            return this;
        }

    }
}
