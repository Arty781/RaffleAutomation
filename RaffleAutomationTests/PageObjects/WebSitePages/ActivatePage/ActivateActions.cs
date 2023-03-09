using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects.WebSitePages.ActivatePage
{
    public partial class Activate
    {
        public Activate EnterFirstName()
        {
            InputBox.Element(inputFirstName, 10, Name.FirstName());
            return this;
        }

        public Activate EnterLastName()
        {
            InputBox.Element(inputLastName, 10, Name.LastName());
            return this;
        }

        public Activate EnterPhone()
        {
            InputBox.Element(inputPhone, 10, PhoneNumber.CellPhone());
            return this;
        }

        public Activate EnterPassword()
        {
            InputBox.Element(inputPassword, 10, Credentials.PASSWORD);
            return this;
        }

        public Activate ClickActivateBtn()
        {
            Button.Click(btnActivateAccount);
            return this;
        }

        [AllureStep("Activate user")]
        public Activate ActivateUser(string email)
        {
            EnterFirstName();
            EnterLastName();
            EnterPhone();
            EnterPassword();
            VerifyIsDisplayedEmail(email);
            ClickActivateBtn();
            return this;
        }
    }
}
