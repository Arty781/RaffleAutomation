using RimuTec.Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.CMS.UserManagementPage
{
    public partial class UserManagement
    {
        public static async Task OpenUserManagement()
        {
            await Browser.Driver.GotoAsync(Endpoints.Admin.USER_MANAGEMENT);
            await WaitUntil.ElementIsVisible("//div[.='User Management']");
        }

        public static async Task ClickAddNewBtn()
        {
            await Button.Click(btnAddUser);
        }

        public static async Task ClickSave()
        {
            await Browser.Driver.WaitForSelectorAsync("//button[.='Save']");
            var btnEditRaffle = Browser.Driver.GetByRole(AriaRole.Button, new() { Name = "Save" });
            await btnEditRaffle.ClickAsync();
        }

        public static async Task EnterUserData(string email)
        {
            await WaitUntil.ElementIsVisible(inputFirstName);
            await InputBox.TypeText(inputFirstName, Name.FirstName());
            await InputBox.TypeText(inputLastName, Name.LastName());
            await InputBox.TypeText(inputEmail, email);
            await InputBox.TypeText(inputPhone, RandomHelper.RandomPhone());
        }

        public async Task<RequestModels.UserRowModel> GetUserData()
        {
            await WaitUntil.ElementIsVisible(inputFirstName);
            RequestModels.UserRowModel user = new()
            {
                Name = await TextBox.GetAttribute(inputFirstName, "value"),
                Surname = await TextBox.GetAttribute(inputLastName, "value"),
                Email = await TextBox.GetAttribute(inputEmail, "value"),
                Phone = await TextBox.GetAttribute(inputPhone, "value"),
            };
            return user;
        }

        public static async Task ClickEditUser(string email)
        {
            await Button.Click(SpecificSearch.FindSpecificUser(email).Result.btnEdit);
        }

        public static async Task OpenSecurityTab()
        {
            await Button.Click(tabSecurity);
            await WaitUntil.ElementIsVisible(inputNewPassword);
        }

        public static async Task SetNewPassword()
        {
            await InputBox.TypeText(inputNewPassword, "Qaz11111");
            await InputBox.TypeText(inputConfirmPassword, "Qaz11111");
            await Button.Click(btnSave);
            await WaitUntil.ElementIsVisible(textAlertMessage);
            Assert.That(await Browser.Driver.QuerySelectorAsync(textAlertMessage).Result.TextContentAsync(), Is.EqualTo("Password changed"), "Password is not changed");
        }

        public static async Task DeleteUser(string email)
        {
            await Button.Click(SpecificSearch.FindSpecificUser(email).Result.btnDelete.ToString());
            await Button.Click(btnRemove);
            await Browser.Driver.WaitForTimeoutAsync(500);
        }

        public static async Task OpenTicketsTab()
        {
            await Button.Click(tabTickets);
            await Browser.Driver.WaitForTimeoutAsync(500);
        }

        public static async Task ClickAddTicketBtn()
        {
            await Button.Click(btnAddTicket);
            await WaitUntil.ElementIsVisible(inputNumberOfTickets);
        }

        public static async Task AddTicketsToUser(int numOfTickets)
        {
            await InputBox.TypeText(inputNumberOfTickets, $"{numOfTickets}");
            await Button.Click(btnSaveInPopup);
        }

        public static async Task<List<RequestModels.CompetitionRowModel>> SelectTicketsDataByCompetition(string competition)
        {
            return await SpecificSearch.FindSpecificCompetitionRows(competition);
        }

        public static async Task ClickEditTicketBtn(List<RequestModels.CompetitionRowModel> competitionRow)
        {
            await Button.Click(competitionRow.FirstOrDefault().btnEditTickets.ToString());
            await Button.Click(btnAddTicketsInPopUp);
            await WaitUntil.ElementIsVisible(inputNumberOfTickets);
        }

        public static async Task ClickDeleteTicketBtn(List<RequestModels.CompetitionRowModel> competitionRow)
        {
            await Button.Click(competitionRow.FirstOrDefault().btnDeleteTickets.ToString());
            await Button.Click(btnRemove);
            await WaitUntil.ElementIsInvisible(competitionRow.FirstOrDefault().btnDeleteTickets.ToString());
        }

        public static async Task SearchUser(string email)
        {
            await WaitUntil.ElementIsVisible(textTitleUserManagement, 25000);
            await Element.Action("End");
            await Button.Click(btnLastPage);
            await WaitUntil.ElementIsVisible(SpecificSearch.FindSpecificUser(email).Result.btnEdit);
        }
    }
}
