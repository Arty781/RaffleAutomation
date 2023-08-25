using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.CMS.SidebarPage
{
    public partial class Sidebar
    {
        #region Opening sidebar menu's tabs

        
        public static async Task OpenPrizeManagementList()
        {
            await WaitUntil.ElementIsVisible(pagePrizeManagement);
            await Button.Click(pagePrizeManagement);
        }

        public static async Task OpenDreamHomePage()
        {
            await WaitUntil.ElementIsVisible(pageDreamHome);
            await Button.Click(pageDreamHome);
        }

        public static async Task OpenLifestylePrizesPage()
        {
            await WaitUntil.ElementIsVisible(pagePrizes);
            await Button.Click(pagePrizes);
        }

        public static async Task OpenCompetitionsPage()
        {
            await WaitUntil.ElementIsVisible(pageCompetitions);
            await Button.Click(pageCompetitions);
        }

        public static async Task OpenUserManagementPage()
        {
            await WaitUntil.ElementIsVisible(pageUsers);
            await Button.Click(pageUsers);
        }

        public static async Task OpenStaffManagementPage()
        {
            await WaitUntil.ElementIsVisible(pageStaff);
            await Button.Click(pageStaff);
        }

        public static async Task OpenSettingsList()
        {
            await WaitUntil.ElementIsVisible(pageSettings);
            await Button.Click(pageSettings);
        }

        public static async Task OpenGeneralPage()
        {
            await WaitUntil.ElementIsVisible(pageSettingsGeneral);
            await Button.Click(pageSettingsGeneral);
        }

        public static async Task OpenWinnersPage()
        {
            await WaitUntil.ElementIsVisible(pageSettingsWinners);
            await Button.Click(pageSettingsWinners);
        }

        public static async Task OpenReferralsPage()
        {
            await WaitUntil.ElementIsVisible(pageSettingsReferrals);
            await Button.Click(pageSettingsReferrals);
        }

        public static async Task OpenReportsPage()
        {
            await WaitUntil.ElementIsVisible(pageSettingsReports);
            await Button.Click(pageSettingsReports);
        }

        #endregion
    }
}
