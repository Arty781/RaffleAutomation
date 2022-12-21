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
    public partial class Basket
    {
        [AllureStep("Open cart")]
        public Basket ClickCartBtn()
        {
            Button.Click(Pages.Header.btnCart);
            WaitUntil.CustomElementIsVisible(btncheckOutNow);

            return this;
        }

        [AllureStep("Get Order Total")]
        public double GetOrderTotal()
        {
            WaitUntil.CustomElementIsVisible(orderTotalVal);
            double total = double.Parse(orderTotalVal.Text.Trim('£'));

            return total;
        }

        [AllureStep("Click Add More button")]
        public Basket ClickAddMoreBtn()
        {
            Button.Click(addMoreTicketsBtn);

            return this;
        }

        [AllureStep("Apply coupon Code")]
        public Basket ApplyCouponCode(string coupon)
        {
            InputBox.Element(couponInput, 5, coupon);
            Button.Click(applyCouponBtn);
            WaitUntil.WaitSomeInterval(1500);

            return this;
        }

        [AllureStep("Click Checkout Now button")]
        public Basket ClickCheckoutNowBtn()
        {
            Elements.Click(checkOutNowBtn);
            return this;
        }

        [AllureStep("Open Order summary")]
        public Basket OpenOrderSummary()
        {
            Elements.Click(orderSummaryBtn);
            return this;
        }

        [AllureStep("Enter card details")]
        public Basket EnterCardDetails()
        {
            
            WaitUntil.CustomElementIsVisible(framePaymentNumber);
            Browser._Driver.SwitchTo().Frame(framePaymentNumber);
            InputBox.Element(inputCardNumber,15, "4242424242424242");
            Browser._Driver.SwitchTo().DefaultContent();
            Browser._Driver.SwitchTo().Frame(framePaymentExpiry);
            InputBox.Element(inputExpiryDate, 15, "07/26");
            Browser._Driver.SwitchTo().DefaultContent();
            Browser._Driver.SwitchTo().Frame(framePaymentCvv);
            InputBox.Element(inputCvv, 15, "100");
            Browser._Driver.SwitchTo().DefaultContent();
            WaitUntil.CustomElementIsClickable(btnPay, 5);

            return this;
        }

        [AllureStep("Click Pay Now button")]
        public Basket ClickPayNowBtn()
        {
            Button.ClickJS(btnPay);

            return this;
        }

        [AllureStep("Confirm purchase")]
        public Basket ConfirmPurchaseStage()
        {
            WaitUntil.CustomElementIsVisible(frameCheckout);
            Browser._Driver.SwitchTo().Frame(frameCheckout);
            InputBox.Element(inputPasswordCheckout, 5, "Checkout1!");
            Button.Click(btnContinueCheckout);
            WaitUntil.CustomElevemtIsInvisible(frameCheckout, 12000);
            Browser._Driver.SwitchTo().DefaultContent();


            return this;
        }

        [AllureStep("Confirm purchase")]
        public Basket ConfirmPurchaseLive()
        {
            WaitUntil.CustomElementIsVisible(frameCheckout);
            WaitUntil.CustomElevemtIsInvisible(frameCheckout, 12000);


            return this;
        }

        [AllureStep("Confirm purchase")]
        public Basket WaitForTimeout()
        {
            WaitUntil.WaitSomeInterval(10000);
            WaitUntil.CustomElementIsVisible(frameCheckout);
            Browser._Driver.SwitchTo().Frame(frameCheckout);
            inputPasswordCheckout.SendKeys("Checkout1!");
            WaitUntil.CustomElevemtIsInvisible(frameCheckout, 12000);
            Browser._Driver.SwitchTo().DefaultContent();
            WaitUntil.CustomElementIsVisible(btncheckOutNow, 120);


            return this;
        }


    }
}
