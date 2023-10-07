using PlaywrightAutomation.Pages.WEB.BasketPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.ThankYouPage
{
    public partial class ThankYou
    {
        public static async Task ClickActivateMyAccount()
        {
            await Button.Click(btnActivateMyAccount);
        }

        public static async Task ClickViewTickets()
        {
            await Button.Click(btnViewTickets);
        }

        public static async Task VerifyThankYouPageIsDisplayed()
        {
            await Basket.VerifyUrl();
            await WaitUntil.ElementIsVisible(titleThankYouPage);
        }
    }
}
