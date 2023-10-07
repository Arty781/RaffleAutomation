using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.WEB.UserProfilePage
{
    public partial class UserProfile
    {
        public const string tabSubscriptions = "div.profile-sidebar-side > button:nth-child(3)";

        #region My Details 

        public const string titleProfile = "//h1[contains(text(),'My Details')]";
        public const string btnEditPersonal = "//button[@data-edit='personal']";
        public const string inputFirstName = "//input[@name='name']";
        public const string inputLastName = "//input[@name='surname']";
        public const string btnEditPassword = "//button[@data-edit='password']";
        public const string inputCurrentPassword = "//input[@name='oldPassword']";
        public const string inputNewPassword = "//input[@name='newPassword']";
        public const string inputConfirmPassword = "//input[@name='confirmPassword']";
        public const string btnEditAccount = "//button[@data-edit='account']";
        public const string inputEmail = "//input[@name='email']";
        public const string inputPhone = "//input[@name='phone']";
        public const string inputEmailCommunication = "//input[@value='emailCommunication']";
        public const string inputCorporateNotification = "//input[@value='corporateNotification']";
        public const string btnSave = "//button[contains(@class,'savingNewPassword visible')]";
        public const string SuccessUpdateDialog = "//div[contains(text(), 'Profile info update success')]";
        public const string SuccessUpdatePasswordDialog = "//div[contains(text(), 'Password update success')]";
        public const string textErrorMessage = "//input[@id='outlined-basic-helper-text'";
        public const string textFirstNameErrorMessage = "//label[contains(text(), 'First name')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textLastNameErrorMessage = "//label[contains(text(), 'Last name')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textEmailErrorMessage = "//label[contains(text(), 'Email')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textPhoneErrorMessage = "//label[contains(text(), 'Phone')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textOldPasswordErrorMessage = "//input[@name='oldPassword']/ancestor::label/div/p[@id='outlined-basic-helper-text']";
        public const string textNewPasswordErrorMessage = "//input[@name='newPassword']/ancestor::label/div/p[@id='outlined-basic-helper-text']";
        public const string textConfirmPasswordErrorMessage = "//input[@name='confirmPassword']/ancestor::label/div/p[@id='outlined-basic-helper-text']";

        #endregion

        #region Order History

        public const string tabMyTicketsCompetitions = "//span[text()='My Tickets & Competitions']/parent::button";
        public const string listDreamHomeHistory = "//span[text()='Dream Home']/ancestor::div[@class='history-accordion-inner']/div";
        public const string listWeeklyHistory = "//span[text()='Lifestyle Competitions']/ancestor::div[@class='history-accordion-inner']/div";
        public const string listFixedOddsHistory = "//span[text()='Fixed Odds']/ancestor::div[@class='history-accordion-inner']/div";
        public const string prizeName = "//table[@class='historyAreaTable']/tbody/tr/td[1]";
        public const string prizeTickets = "//table[@class='historyAreaTable']/tbody/tr/td[3]";
        public const string prizePrice = "//table[@class='historyAreaTable']/tbody/tr/td";
        public const string listHistory = "#history-accordion-droplist";

        #endregion

        #region Subscriptions

        public const string titleSubscriptionProfile = "//h1[text()='My Subscription']";
        public const string btnDetails = "//div[contains(@class,'profile-subscription-card ')]//p[text()='Details']";
        public const string titleSubscriptionStatus = "//div[contains(@class,'profile-subscription-card ')]/div[contains(@class, 'header')]";
        public const string cbbxCharitySelector = "//div[@class='select-charity-wrapper']/div";
        public const string listCharities = "//div[@role='presentation']/div/ul/li";
        public const string inputCharity = "//div[@class='select-charity-wrapper']/div//input";
        public const string inputPause = "paused";
        public const string btnCancelSubscription = "//button[text()='Cancel Subscription']";
        public const string btnReactivateSubscription = "//button[text()='Reactivate Subscription']";
        public const string btnPausePopUp = "//button[text()='Pause']";
        public const string btnUnpausePopUp = "//button[text()='Unpause']";
        public const string btnCancelPopUp = "//button[text()='Cancel']";
        public const string btnReactivatePopUp = "//button[text()='Reactivate']";
        public const string btnBackPopUp = "//button[text()='Back']";
        public const string textActiveSubscription = "//h3[.='Active Subscription']";
        public const string textPausedSubscription = "//h3[.='Paused Subscription']";
        public const string textCancelledSubscription = "//h3[.='Cancelled Subscription']";

        public const string btn10BundleWithSub = "div:nth-child(1) > div.button-group > button";
        public const string btn25BundleWithSub = "div:nth-child(2) > div.button-group > button";

        public const string btn10BundleWithoutSub = "div:nth-child(1) > div.buttons > button";
        public const string btn25BundleWithoutSub = "div:nth-child(2) > div.buttons > button";

        #endregion
    }
}
