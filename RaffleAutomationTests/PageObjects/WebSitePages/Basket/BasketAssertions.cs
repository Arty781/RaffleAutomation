using RaffleAutomationTests.Helpers;
using System;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Basket
    {

        public Basket VerifyErrorMessageIsDisplayed()
        {


            WaitUntil.CustomElementIsVisible(Pages.Common.toaster);
            Console.WriteLine(Pages.Common.toaster.Text);
            WaitUntil.CustomElementIsVisible(checkOutNowBtn);

            return this;
        }
    }
}
