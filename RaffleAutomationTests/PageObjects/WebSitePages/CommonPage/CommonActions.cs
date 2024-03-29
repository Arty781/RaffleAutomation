﻿

namespace RaffleAutomationTests.PageObjects
{
    public partial class Common
    {
        [AllureStep("Close cookies pop-up")]
        public Common CloseCookiesPopUp()
        {
            Browser.Driver.Navigate().Refresh();
            Button.Click(confirmCookieBtn);
            return this;
        }

        [AllureStep("Click add +10 tickets")]
        public Common ClickAddTenTickets()
        {
            Button.Click(addTenTicketBtn);
            return this;
        }

        [AllureStep("Click add +1 ticket")]
        public Common ClickAddOneTicket()
        {
            Button.Click(addOneTicketBtn);
            return this;
        }

        [AllureStep("Click add +25 tickets")]
        public Common ClickAdd25Tickets()
        {
            Button.Click(add25TicketBtn);
            return this;
        }

        [AllureStep("Click remove 10 tickets")]
        public Common ClickRemoveTenTickets()
        {
            Button.Click(removeTenTicketBtn);
            return this;
        }

        [AllureStep("Click remove 1 ticket")]
        public Common ClickRemoveOneTicket()
        {
            Button.Click(removeOneTicketBtn);
            return this;
        }

        [AllureStep("Click remove 25 tickets")]
        public Common ClickRemove25Tickets()
        {
            Button.Click(remove25TicketBtn);
            return this;
        }

        [AllureStep("Click Add To Basket button")]
        public Common ClickAddToBasketBtn()
        {
            WaitUntil.WaitSomeInterval(1000);
            Button.Click(btnAddToBasket);
            WaitUntil.CustomElementIsVisible(Pages.Basket.checkOutNowBtn);
            return this;
        }

        [AllureStep("Click Enter button")]
        public Common ClickEnterBtn()
        {
            Button.Click(enterBtn);
            return this;
        }

        [AllureStep("Close tab")]
        public Common CloseTabAndWait30Seconds()
        {
            Browser.Driver.SwitchTo().NewWindow(OpenQA.Selenium.WindowType.Tab);
            Browser.Driver.SwitchTo().Window(Browser.Driver.WindowHandles.ToList().FirstOrDefault());
            Browser.Driver.Close();
            Browser.Driver.SwitchTo().Window(Browser.Driver.WindowHandles.ToList().FirstOrDefault());
            WaitUntil.WaitSomeInterval(30000);
            return this;
        }

    }
}
