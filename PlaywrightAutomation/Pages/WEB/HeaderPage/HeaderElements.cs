using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.WEB.HeaderPage
{
    public partial class Header
    {
        public const string logo = "//a[@class='headerLogo']";
        public const string btnBurgerMenu = "//button[@class='headerBurgerMenu']";
        public const string liveCompetitionsList = "//button[contains(@class,'toggle-live-btn toggle-live-btn-desk')]";
        public const string linkDreamHome = "//a[@href='/dreamhome']";
        public const string winnersLink = "//nav[@class='headerNav']/a[@href='/winners']";
        public const string freeEntryBtn = "//button[@class='rafflebtn entry-button']";
        public const string btnCart = "//button[@class='headerBtnCart']";
        public const string btnDropDownAccount = "//button[@class='dropdownAccount ']";
        public const string btnLogOut = "//button[text()='Logout']";
    }
}
