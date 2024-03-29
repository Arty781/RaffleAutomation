﻿using RaffleAutomationTests.PageObjects.WebSitePages;
using RaffleAutomationTests.PageObjects.WebSitePages.ActivatePage;
using RaffleAutomationTests.PageObjects.WebSitePages.ResetPasswordPage;
using RaffleAutomationTests.PageObjects.WebSitePages.TermsAndConditionsPage;

namespace RaffleAutomationTests.PageObjects
{
    public class Pages
    {

        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            IWebDriver driver = Browser.Driver;
            PageFactory.InitElements(driver, page);

            return page;
        }

        public static AboutUs About => GetPage<AboutUs>();
        public static Basket Basket => GetPage<Basket>();
        public static Common Common => GetPage<Common>();
        public static Dreamhome Dreamhome => GetPage<Dreamhome>();
        public static FixedOdds FixedOdds => GetPage<FixedOdds>();
        public static Footer Footer => GetPage<Footer>();
        public static Postal Postal => GetPage<Postal>();
        public static Header Header => GetPage<Header>();
        public static Home Home => GetPage<Home>();
        public static Profile Profile => GetPage<Profile>();
        public static SignIn SignIn => GetPage<SignIn>();
        public static SignUp SignUp => GetPage<SignUp>();
        public static ThankYou ThankYou => GetPage<ThankYou>();
        public static Weekly Weekly => GetPage<Weekly>();
        public static Winners Winners => GetPage<Winners>();
        public static CmsLogin CmsLogin => GetPage<CmsLogin>();
        public static CmsCommon CmsCommon => GetPage<CmsCommon>();
        public static CmsDreamhome CmsDreamhome => GetPage<CmsDreamhome>();
        public static CmsLifestylePrizes CmsLifestylePrizes => GetPage<CmsLifestylePrizes>();
        public static CmsFixedOdds CmsFixedOdds => GetPage<CmsFixedOdds>();
        public static CmsCompetitions CmsCompetitions => GetPage<CmsCompetitions>();
        public static CmsUserManagement CmsUserManagement => GetPage<CmsUserManagement>();
        public static CmsStaffManagement CmsStaffManagement => GetPage<CmsStaffManagement>();
        public static CmsSettingsGeneral CmsSettingsGeneral => GetPage<CmsSettingsGeneral>();
        public static CmsSettingsWinners CmsSettingsWinners => GetPage<CmsSettingsWinners>();
        public static CmsSettingsReferrals CmsSettingsReferrals => GetPage<CmsSettingsReferrals>();
        public static CmsReports CmsReports => GetPage<CmsReports>();
        public static PageDiscountPage PageDiscountPage => GetPage<PageDiscountPage>();
        public static WinRafflePage WinRafflePage => GetPage<WinRafflePage>();
        public static Activate Activate => GetPage<Activate>();
        public static ResetPassword ResetPassword => GetPage<ResetPassword>();
        public static TermsAndConditions TermsAndConditions => GetPage<TermsAndConditions>();
        public static Subscription Subscription => GetPage<Subscription>();
        public static Putsbox Putsbox => GetPage<Putsbox>();
    }
}
