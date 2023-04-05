using static RaffleAutomationTests.Helpers.Element;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsUserManagement
    {
        public CmsUserManagement OpenUserManagement()
        {
            Browser.Navigate(AdminEndpoints.USER_MANAGEMENT);
            return this;
        }

        public CmsUserManagement ClickAddNewBtn()
        {
            Button.Click(btnAddUser);
            return this;
        }

        public CmsUserManagement EnterUserData(string email)
        {
            WaitUntil.CustomElementIsVisible(inputFirstName);
            InputBox.Element(inputFirstName, 10, Name.FirstName());
            InputBox.Element(inputLastName, 10, Name.LastName());
            InputBox.Element(inputEmail, 10, email);
            InputBox.Element(inputPhone, 10, RandomHelper.RandomPhone());
            return this;
        }

        public Element.UserRowModel GetUserData()
        {
            WaitUntil.CustomElementIsVisible(inputFirstName);
            Element.UserRowModel user = new()
            {
                Name = TextBox.GetAttribute(inputFirstName, "value"),
                Surname = TextBox.GetAttribute(inputLastName, "value"),
                Email = TextBox.GetAttribute(inputEmail, "value"),
                Phone = TextBox.GetAttribute(inputPhone, "value"),
            };
            return user;
        }

        public CmsUserManagement ClickEditUser(string email)
        {
            Button.Click(Element.FindSpecificUser(email).btnEdit);
            return this;
        }

        public CmsUserManagement OpenSecurityTab()
        {
            Button.Click(tabSecurity);
            WaitUntil.CustomElementIsVisible(inputNewPassword);

            return this;
        }

        public CmsUserManagement SetNewPassword()
        {
            InputBox.Element(inputNewPassword, 10, "Qaz11111");
            InputBox.Element(inputConfirmPassword, 10, "Qaz11111");
            Pages.CmsCommon.ClickSaveChangesBtn();
            WaitUntil.CustomElementIsVisible(Pages.CmsCommon.textAlertMessage);
            Assert.IsTrue("Password changed" == Pages.CmsCommon.textAlertMessage.Text, "Password is not changed");

            return this;
        }

        public CmsUserManagement DeleteUser(string email)
        {
            Button.Click(Element.FindSpecificUser(email).btnDelete);
            Pages.CmsCommon.ClickRemoveBtn();
            WaitUntil.WaitSomeInterval();
            return this;
        }

        public CmsUserManagement OpenTicketsTab()
        {
            Button.Click(tabTickets);
            WaitUntil.WaitSomeInterval(1000);

            return this;
        }

        public CmsUserManagement ClickAddTicketBtn()
        {
            Button.Click(btnAddTicket);
            WaitUntil.CustomElementIsVisible(inputNumberOfTickets);

            return this;
        }

        public CmsUserManagement AddTicketsToUser()
        {
            InputBox.Element(inputNumberOfTickets, 10, "10");
            Button.Click(btnSaveInPopup);

            return this;
        }

        public List<CompetitionRowModel> SelectTicketsDataByCompetition(string competition)
        {
            return FindSpecificCompetitionRows(competition);
        }

        public CmsUserManagement ClickEditTicketBtn(List<CompetitionRowModel> competitionRow)
        {
            Button.Click(competitionRow.FirstOrDefault().btnEditTickets);
            Button.Click(btnAddTicketsInPopUp);
            WaitUntil.CustomElementIsVisible(inputNumberOfTickets);

            return this;
        }

        public CmsUserManagement ClickDeleteTicketBtn(List<CompetitionRowModel> competitionRow)
        {
            Button.Click(competitionRow.FirstOrDefault().btnDeleteTickets);
            Pages.CmsCommon.ClickRemoveBtn();
            WaitUntil.CustomElevemtIsInvisible(competitionRow.FirstOrDefault().btnDeleteTickets);

            return this;
        }

    }
}