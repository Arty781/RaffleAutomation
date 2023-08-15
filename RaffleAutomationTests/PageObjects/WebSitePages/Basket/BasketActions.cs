namespace RaffleAutomationTests.PageObjects
{
    public partial class Basket
    {
        [AllureStep("Open cart")]
        public Basket ClickCartBtn()
        {
            Browser.Driver.Navigate().GoToUrl(WebEndpoints.BASKET);
            WaitUntil.CustomElementIsVisible(btncheckOutNow);

            return this;
        }

        [AllureStep("Get Order count")]
        public Basket GetOrderCount(out int countOrders)
        {
            WaitUntil.CustomElementIsVisible(orderTotalVal);
            WaitUntil.WaitSomeInterval(500);
            countOrders = textPrice.Count;
            return this;
        }

        [AllureStep("Get Order Total")]
        public Basket GetOrderTotal(out double total)
        {
            WaitUntil.CustomElementIsVisible(orderTotalVal);
            WaitUntil.WaitSomeInterval(500);
            total = double.Parse(orderTotalVal.Text.Substring(1));
            return this;
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
            Browser.Driver.SwitchTo().Frame(framePaymentNumber);
            InputBox.Element(inputCardNumber, 15, CardDetails.CARD_NUMBER[RandomHelper.RandomIntNumber(CardDetails.CARD_NUMBER.Count)]);
            Browser.Driver.SwitchTo().DefaultContent();
            Browser.Driver.SwitchTo().Frame(framePaymentExpiry);
            InputBox.Element(inputExpiryDate, 15, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            Browser.Driver.SwitchTo().DefaultContent();
            Browser.Driver.SwitchTo().Frame(framePaymentCvv);
            InputBox.Element(inputCvv, 15, "100");
            Browser.Driver.SwitchTo().DefaultContent();
            WaitUntil.CustomElementIsVisible(btnPay, 5);

            return this;
        }

        [AllureStep("Enter card details")]
        public Basket EnterCardDetails(string cvv)
        {

            WaitUntil.CustomElementIsVisible(framePaymentNumber);
            Browser.Driver.SwitchTo().Frame(framePaymentNumber);
            InputBox.Element(inputCardNumber, 15, "372688581899681");
            Browser.Driver.SwitchTo().DefaultContent();
            Browser.Driver.SwitchTo().Frame(framePaymentExpiry);
            InputBox.Element(inputExpiryDate, 15, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            Browser.Driver.SwitchTo().DefaultContent();
            Browser.Driver.SwitchTo().Frame(framePaymentCvv);
            InputBox.Element(inputCvv, 15, cvv);
            Browser.Driver.SwitchTo().DefaultContent();
            WaitUntil.CustomElementIsVisible(btnPay, 5);

            return this;
        }


        //[AllureStep("Enter card details")]
        //public Basket EnterCardDetailsLive()
        //{

        //    WaitUntil.CustomElementIsVisible(framePaymentNumber);
        //    Browser.Driver.SwitchTo().Frame(framePaymentNumber);
        //    InputBox.Element(inputCardNumber, 15, "5373010046212228");
        //    Browser.Driver.SwitchTo().DefaultContent();
        //    Browser.Driver.SwitchTo().Frame(framePaymentExpiry);
        //    InputBox.Element(inputExpiryDate, 15, "07/26");
        //    Browser.Driver.SwitchTo().DefaultContent();
        //    Browser.Driver.SwitchTo().Frame(framePaymentCvv);
        //    InputBox.Element(inputCvv, 15, "937");
        //    Browser.Driver.SwitchTo().DefaultContent();
        //    WaitUntil.CustomElementIsVisible(btnPay, 5);

        //    return this;
        //}

        [AllureStep("Click Pay Now button")]
        public Basket ClickPayNowBtn()
        {
            Button.ClickJS(btnPay);

            return this;
        }

        [AllureStep("Confirm purchase")]
        public Basket ConfirmPurchaseStage()
        {

            WaitUntil.CustomElementIsVisible(frameCheckout, 30);
            WaitUntil.WaitSomeInterval(1000);
            Browser.Driver.SwitchTo().Frame(frameCheckout);
            InputBox.Element(inputPasswordCheckout, 15, "Checkout1!");
            Button.Click(btnContinueCheckout);
            WaitUntil.CustomElevemtIsInvisible(frameCheckout, 120);
            Browser.Driver.SwitchTo().DefaultContent();


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
            WaitUntil.CustomElementIsVisible(frameCheckout, 30);
            Browser.Driver.SwitchTo().Frame(frameCheckout);
            inputPasswordCheckout.SendKeys("Checkout1!");
            Browser.Driver.SwitchTo().DefaultContent();
            WaitUntil.CustomElevemtIsInvisible(frameCheckout, 720);
            Browser.Driver.SwitchTo().DefaultContent();
            WaitUntil.CustomElementIsVisible(btncheckOutNow, 120);


            return this;
        }

        public Basket EnterEmail(string email)
        {
            WaitUntil.CustomElementIsVisible(inputEmail, 10);
            InputBox.Element(inputEmail, 10, email);

            return this;
        }

        [AllureStep("Make a purchase as unauthorized user")]
        public Basket MakeAPurchaseAsUnauthorizedUser(string email)
        {
            ClickCheckoutNowBtn();
            EnterEmail(email);
            EnterCardDetails();
            ClickPayNowBtn();

            return this;
        }

        [AllureStep("Make a purchase as unauthorized user")]
        public Basket MakeAPurchaseAsAuthorizedUser()
        {
            ClickCheckoutNowBtn();
            EnterCardDetails();
            ClickPayNowBtn();

            return this;
        }

        [AllureStep("Make a purchase as unauthorized user")]
        public Basket MakeAPurchaseSubscriptionAsUnauthorizedUser(string email, string subscriptionId)
        {
            GoToBasket(subscriptionId);
            EnterEmail(email);
            EnterCardDetails();
            ClickPayNowBtn();

            return this;
        }

        [AllureStep("Make a purchase as authorized user")]
        public Basket MakeAPurchaseSubscriptionAsAuthorizedUser(string subscriptionId)
        {
            GoToBasket(subscriptionId);
            EnterCardDetails();
            ClickPayNowBtn();
            return this;
        }

        [AllureStep("Make a purchase as authorized user")]
        private Basket GoToBasket(string subscriptionId)
        {
            Browser.Driver.Navigate().GoToUrl(WebEndpoints.WEBSITE_HOST + $"/subscriptions/{subscriptionId}/payment");
            WaitUntil.WaitSomeInterval(10000);
            Browser.Driver.Navigate().Refresh();

            return this;
        }

        public Basket SelectCharity()
        {
            Button.Click(inputCharity);
            WaitUntil.WaitSomeInterval(1000);
            var charity = listCharities
                .Where(x => x.Text == Charities.CHARITY[RandomHelper.RandomCharityNumber(7)])
                .Select(x => x)
                .FirstOrDefault();
            Button.ClickJS(charity);
            WaitUntil.WaitSomeInterval();

            return this;
        }
    }
}
