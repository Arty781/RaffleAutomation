using static PlaywrightAutomation.Base.Helpers.Helpers;

namespace PlaywrightAutomation.Pages.CMS.SidebarPage
{
    public partial class Sidebar
    {
        #region Opening sidebar menu's tabs

        
        public static async Task OpenPrizeManagementList(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pagePrizeManagement);
            await Button.Click(page, pagePrizeManagement);
        }

        public static async Task OpenDreamHomePage(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pageDreamHome);
            await Button.Click(page, pageDreamHome);
        }

        public static async Task OpenLifestylePrizesPage(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pagePrizes);
            await Button.Click(page, pagePrizes);
        }

        public static async Task OpenCompetitionsPage(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pageCompetitions);
            await Button.Click(page, pageCompetitions);
        }

        public static async Task OpenUserManagementPage(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pageUsers);
            await Button.Click(page, pageUsers);
        }

        public static async Task OpenStaffManagementPage(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pageStaff);
            await Button.Click(page, pageStaff);
        }

        public static async Task OpenSettingsList(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pageSettings);
            await Button.Click(page, pageSettings);
        }

        public static async Task OpenGeneralPage(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pageSettingsGeneral);
            await Button.Click(page, pageSettingsGeneral);
        }

        public static async Task OpenWinnersPage(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pageSettingsWinners);
            await Button.Click(page, pageSettingsWinners);
        }

        public static async Task OpenReferralsPage(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pageSettingsReferrals);
            await Button.Click(page, pageSettingsReferrals);
        }

        public static async Task OpenReportsPage(IPage page)
        {
            await WaitUntil.ElementIsVisible(page, pageSettingsReports);
            await Button.Click(page, pageSettingsReports);
        }

        #endregion
    }
}
