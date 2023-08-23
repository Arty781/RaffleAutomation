using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.CMS.UserManagementPage
{
    public partial class UserManagement
    {
        public const string textTitleUserManagement = "//div[text()='User Management']";
        public const string textAlertMessage = "//div[@role='alert']/div";
        public const string btnRemove = "//span[contains(text(),'Remove')]/parent::button";
        public const string btnLastPage = "//div[@title='Last Page']";

        #region Add new User

        public const string btnAddUser = "//a[@aria-label='Add new ']";
        public const string inputFirstName = "//input[@name='name']";
        public const string inputLastName = "//input[@name='surname']";
        public const string inputEmail = "//input[@name='email']";
        public const string inputPhone = "//input[@name='phone']";
        public const string inputSearch = "#search-input";
        public const string listCountry = "//ul[@role='listbox']/li";
        public const string btnSave = "//button[@aria-label='Save']";

        #endregion

        #region Tabs selector

        public const string tabGeneral = "//span[text()='General']/parent::a";
        public const string tabSecurity = "//span[text()='Security & Notifications']/parent::a";
        public const string tabTickets = "//span[text()='Tickets']/parent::a";
        public const string tabCredit = "//span[text()='Credit']/parent::a";
        public const string tabReferral = "//span[text()='Referral']/parent::a";
        public const string tabCoupon = "//span[text()='Coupon']/parent::a";
        public const string tabPayments = "//span[text()='Payments']/parent::a";

        #endregion

        #region Edit User

        public const string inputNewPassword = "//p[text()='New password']/parent::div//input[@id='user-general-input']";
        public const string inputConfirmPassword = "//p[text()='Confirm new password']/parent::div//input[@id='user-general-input']";
        public const string btnSaveChanges = "//span[text()='Save Changes']/parent::button";
        public const string btnAddTicket = "//span[text()='Add Ticket']/parent::button";
        public const string btnAddTicketsInPopUp = "//span[text()='Add Tickets']/parent::button";
        public const string cbbxCompetition = "//input[@name='competition']";
        public const string listCompetitions = "//div/ul/li";
        public const string cbbxProduct = "//input[@name='product']";
        public const string inputNumberOfTickets = "//p[text()='Tickets']/parent::div//input";
        public const string btnAddCredits = "//span[text()='Add Credits']/parent::button";
        public const string inputNumberOfCredits = "//p[text()='Credits']/parent::div//input";
        public const string inputCreditDescription = "//p[text()='Description']/parent::div//div[@class='DraftEditor-root']//span";
        public const string btnSaveInPopup = "//div[@role='dialog']//span[text()='Save']/parent::button";
        public const string btnCancelInPopup = "//div[@role='dialog']//span[text()='Cancel']/parent::button";
        public const string textNoOrders = "//div/span[3]//h6[text()='No ']";
        public const string btnDeletePopUp = "//div[text()='View Tickets']/ancestor::div[@class='MuiDialogContent-root']//table//td[6]";

        #endregion
    }
}
