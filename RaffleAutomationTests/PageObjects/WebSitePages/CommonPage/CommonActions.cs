using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Common
    {
        [AllureStep("Close cookies pop-up")]
        public Common CloseCookiesPopUp()
        {
            WaitUntil.CustomElementIsVisible(confirmCookieBtn);
            confirmCookieBtn.Click();

            return this;
        }

        [AllureStep("Click add +10 tickets")]
        public Common ClickAddTenTickets()
        {
            WaitUntil.WaitSomeInterval(1);
            addTenTicketBtn.Click();
            return this;
        }

        [AllureStep("Click add +1 ticket")]
        public Common ClickAddOneTicket()
        {
            WaitUntil.WaitSomeInterval(1);
            addOneTicketBtn.Click();
            return this;
        }

        [AllureStep("Click add +25 tickets")]
        public Common ClickAdd25Tickets()
        {
            WaitUntil.WaitSomeInterval(1);
            add25TicketBtn.Click();
            return this;
        }

        [AllureStep("Click remove 10 tickets")]
        public Common ClickRemoveTenTickets()
        {
            WaitUntil.WaitSomeInterval(1);
            removeTenTicketBtn.Click();
            return this;
        }

        [AllureStep("Click remove 1 ticket")]
        public Common ClickRemoveOneTicket()
        {
            WaitUntil.WaitSomeInterval(1);
            removeOneTicketBtn.Click();
            return this;
        }

        [AllureStep("Click remove 25 tickets")]
        public Common ClickRemove25Tickets()
        {
            WaitUntil.WaitSomeInterval(1);
            remove25TicketBtn.Click();
            return this;
        }

        [AllureStep("Click Add To Basket button")]
        public Common ClickAddToBasketBtn()
        {
            WaitUntil.WaitSomeInterval(1);
            btnAddToBasket.Click();
            return this;
        }

        [AllureStep("Click Enter button")]
        public Common ClickEnterBtn()
        {
            WaitUntil.WaitSomeInterval(1);
            WaitUntil.CustomElementIsVisible(enterBtn);
            enterBtn.SendKeys("");
            enterBtn.Click();
            return this;
        }

        public Common ScrollToElement()
        {
            new Actions(Browser._Driver)
                    .SendKeys(Keys.End)
                    .Build()
                    .Perform();

            return this;
        }

    }
}
