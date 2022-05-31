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
        [AllureStep("Click Add More button")]
        public Basket ClickAddMoreBtn()
        {
            WaitUntil.ElementIsVisibleAndClickable(_addMoreTicketsBtn);
            addMoreTicketsBtn.Click();

            return this;
        }

        [AllureStep("Apply coupon Code")]
        public Basket ApplyCouponCode(string coupon)
        {
            WaitUntil.ElementIsVisible(_couponInput);
            couponInput.SendKeys(coupon);
            applyCouponBtn.Click();

            return this;
        }

        [AllureStep("Click Checkout Now button")]
        public Basket ClickCheckoutNowBtn()
        {
            
            
            WaitUntil.ElementIsInvisible(Common._addToBasketBtn);
            WaitUntil.ElementIsVisibleAndClickable(_checkOutNowBtn);
            ClickHelper.Clicker(checkOutNowBtn);

            return this;
        }

        [AllureStep("Open Order summary")]
        public Basket OpenOrderSummary()
        {
            WaitUntil.ElementIsVisible(_orderSummaryBtn);
            orderSummaryBtn.Click();

            return this;
        }

        [AllureStep("Enter card details")]
        public Basket EnterCardDetails()
        {
            WaitUntil.ElementIsVisible(_ageControlSection, 10);
            
            ageControlSection.Click();

            WaitUntil.WaitSomeInterval(5);
            Browser._Driver.SwitchTo().Frame(paymentForm);
            WaitUntil.ElementIsVisible(_cardNumberInput, 25);
            cardNumberInput.SendKeys("4242424242424242");
            WaitUntil.WaitSomeInterval(1);
            cardExpDate.SendKeys("11/28");
            WaitUntil.WaitSomeInterval(1);
            cardCvvInpt.SendKeys("100");

            return this;
        }

        [AllureStep("Click Pay Now button")]
        public Basket ClickPayNowBtn()
        {
            Browser._Driver.SwitchTo().DefaultContent();
            WaitUntil.ElementIsClickable(payBtn, 20);

            ClickHelper.Clicker(payBtn);
            
            WaitUntil.VisibilityOfAllElementsLocatedBy(By.XPath("//h1[@class='orderCompleted']"),15);
            

            return this;
        }
    }
}
