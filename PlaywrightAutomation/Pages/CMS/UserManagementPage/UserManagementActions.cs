using PlaywrightAutomation.Base.Helpers;
using RimuTec.Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Base.Helpers.Helpers;

namespace PlaywrightAutomation.Pages.CMS.UserManagementPage
{
    public partial class UserManagement
    {
        public static async Task OpenUserManagement(IPage page)
        {
            await page.GotoAsync(Endpoints.Admin.USER_MANAGEMENT);
            await WaitUntil.ElementIsVisible(page, "//div[.='User Management']");
        }

        public static async Task ClickAddNewBtn(IPage page)
        {
            await Button.Click(page, btnAddUser);
        }

        public static async Task ClickSave(IPage page)
        {
            await page.WaitForSelectorAsync("//button[.='Save']");
            var btnEditRaffle = page.GetByRole(AriaRole.Button, new() { Name = "Save" });
            await btnEditRaffle.ClickAsync();
        }

        public static async Task EnterUserData(IPage page, string email)
        {
            await WaitUntil.ElementIsVisible(page, inputFirstName);
            await InputBox.TypeText(page, inputFirstName, Name.FirstName());
            await InputBox.TypeText(page, inputLastName, Name.LastName());
            await InputBox.TypeText(page, inputEmail, email);
            await InputBox.TypeText(page, inputPhone, RandomHelper.RandomPhone());
        }

        public async Task<RequestModels.UserRowModel> GetUserData(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, inputFirstName);
            RequestModels.UserRowModel user = new()
            {
                Name = await TextBox.GetAttribute(page, inputFirstName, "value"),
                Surname = await TextBox.GetAttribute(page, inputLastName, "value"),
                Email = await TextBox.GetAttribute(page, inputEmail, "value"),
                Phone = await TextBox.GetAttribute(page, inputPhone, "value"),
            };
            return user;
        }

        public static async Task ClickEditUser(IPage page, string email)
        {
            await Button.Click(page, SpecificSearch.FindSpecificUser(page, email).Result.btnEdit);
        }

        public static async Task OpenSecurityTab(IPage page)
        {
            await Button.Click(page, tabSecurity);
            await WaitUntil.ElementIsVisible(page, inputNewPassword);
        }

        public static async Task SetNewPassword(IPage page)
        {
            await InputBox.TypeText(page, inputNewPassword, "Qaz11111");
            await InputBox.TypeText(page, inputConfirmPassword, "Qaz11111");
            await Button.Click(page, btnSave);
            await WaitUntil.ElementIsVisible(page, textAlertMessage);
            Assert.That(await page.QuerySelectorAsync(textAlertMessage).Result.TextContentAsync(), Is.EqualTo("Password changed"), "Password is not changed");
        }

        public static async Task DeleteUser(IPage page, string email)
        {
            await Button.Click(page, SpecificSearch.FindSpecificUser(page, email).Result.btnDelete.ToString());
            await Button.Click(page, btnRemove);
            await page.WaitForTimeoutAsync(500);
        }

        public static async Task OpenTicketsTab(IPage page)
        {
            await Button.Click(page, tabTickets);
            await page.WaitForTimeoutAsync(500);
        }

        public static async Task ClickAddTicketBtn(IPage page)
        {
            await Button.Click(page, btnAddTicket);
            await WaitUntil.ElementIsVisible(page, inputNumberOfTickets);
        }

        public static async Task AddTicketsToUser(IPage page, int numOfTickets)
        {
            await InputBox.TypeText(page, inputNumberOfTickets, $"{numOfTickets}");
            await Button.Click(page, btnSaveInPopup);
        }

        public static async Task<List<RequestModels.CompetitionRowModel>> SelectTicketsDataByCompetition(IPage page, string competition)
        {
            return await SpecificSearch.FindSpecificCompetitionRows(page, competition);
        }

        public static async Task ClickEditTicketBtn(IPage page, List<RequestModels.CompetitionRowModel> competitionRow)
        {
            await Button.Click(page, competitionRow.FirstOrDefault().btnEditTickets.ToString());
            await Button.Click(page, btnAddTicketsInPopUp);
            await WaitUntil.ElementIsVisible(page, inputNumberOfTickets);
        }

        public static async Task ClickDeleteTicketBtn(IPage page, List<RequestModels.CompetitionRowModel> competitionRow)
        {
            await Button.Click(page, competitionRow.FirstOrDefault().btnDeleteTickets.ToString());
            await Button.Click(page, btnRemove);
            await WaitUntil.ElementIsInvisible(page, competitionRow.FirstOrDefault().btnDeleteTickets.ToString());
        }

        public static async Task SearchUser(IPage page, string email)
        {
            await WaitUntil.ElementIsVisible(page, textTitleUserManagement, 25000);
            await Element.Action(page, "End");
            await Button.Click(page, btnLastPage);
            await WaitUntil.ElementIsVisible(page, SpecificSearch.FindSpecificUser(page, email).Result.btnEdit);
        }
    }
}
