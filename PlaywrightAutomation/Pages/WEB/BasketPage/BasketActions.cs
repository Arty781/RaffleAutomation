using PlaywrightAutomation.Pages.WEB.CommonPage;
using PlaywrightAutomation.Pages.WEB.ThankYouPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.BasketPage
{
    public partial class Basket
    {
        public static async Task ClickCartBtn()
        {
            await GoToPage(Endpoints.Web.BASKET, btncheckOutNow);
            await WaitUntil.ElementIsVisible(btncheckOutNow);
        }

        
        public static async Task<int> GetOrderCount()
        {
            await WaitUntil.ElementIsVisible(orderTotalVal);
            return (await Browser.Driver.QuerySelectorAllAsync(textPrice)).Count;
        }

        
        public static async Task<double> GetOrderTotal()
        {
            await WaitUntil.ElementIsVisible(orderTotalVal);
            return double.Parse((await Browser.Driver.QuerySelectorAsync(orderTotalVal)).TextContentAsync().Result[1..]);
        }

        
        public static async Task ClickAddMoreBtn()
        {
            await Button.Click(addMoreTicketsBtn);
        }

        
        public static async Task ApplyCouponCode(string coupon)
        {
            await InputBox.TypeText(couponInput, coupon);
            await Button.Click(applyCouponBtn);
            await WaitUntil.Timeout(1500);
        }

        
        public static async Task ClickCheckoutNowBtn()
        {
            await Button.Click(checkOutNowBtn);
        }

        
        public static async Task OpenOrderSummary()
        {
            await Button.Click(orderSummaryBtn);
        }

        
        public static async Task EnterCardDetails()
        {
            await WaitUntil.ElementIsVisible(framePaymentNumber);
            var frame = await Browser.Driver.QuerySelectorAsync(framePaymentNumber).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCardNumber, RaffleAutomationTests.Helpers.CardDetails.CARD_NUMBER[RandomHelper.RandomIntNumber(RaffleAutomationTests.Helpers.CardDetails.CARD_NUMBER.Count)]);
            var defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentExpiry).Result.ContentFrameAsync();
            await frame.TypeAsync(inputExpiryDate, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentCvv).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCvv, "100");
            defaultFrame = frame.ParentFrame;
            await WaitUntil.ElementIsVisible(btnPay);
        }

        
        public static async Task EnterCardDetails(string cvv)
        {
            await WaitUntil.ElementIsVisible(btnPay);
            var frame = await Browser.Driver.QuerySelectorAsync(framePaymentNumber).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCardNumber, "372688581899681");
            var defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentExpiry).Result.ContentFrameAsync();
            await frame.TypeAsync(inputExpiryDate, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentCvv).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCvv, cvv);
            defaultFrame = frame.ParentFrame;
            await WaitUntil.ElementIsVisible(btnPay);
        }
        
        public static async Task ClickPayNowBtn()
        {
            await Button.Click(btnPay);
        }

        
        public static async Task ConfirmPurchaseStage()
        {
            var frame = await Browser.Driver.QuerySelectorAsync(frameCheckout).Result.ContentFrameAsync();
            await frame.TypeAsync(inputPasswordCheckout, "Checkout1!");
            await frame.ClickAsync(btnContinueCheckout);
            await WaitUntil.FrameIsInvisible(frameCheckout, 120000);
            var defaultFrame = frame.ParentFrame;
        }

        
        public static async Task ConfirmPurchaseLive()
        {
            await WaitUntil.FrameIsInvisible(frameCheckout);
            await WaitUntil.FrameIsInvisible(frameCheckout, 12000);
        }

        
        public static async Task WaitForTimeout()
        {
            var frame = await Browser.Driver.QuerySelectorAsync(frameCheckout).Result.ContentFrameAsync();
            await frame.TypeAsync(inputPasswordCheckout, "Checkout1!");
            await WaitUntil.FrameIsInvisible(frameCheckout, 720000);
            var defaultFrame = frame.ParentFrame;
            await WaitUntil.ElementIsVisible(btncheckOutNow);

        }

        public static async Task EnterEmail(string email)
        {
            await WaitUntil.ElementIsVisible(inputEmail);
            await InputBox.TypeText(inputEmail, email);
        }

        
        public static async Task MakeAPurchaseAsUnauthorizedUser(string email)
        {
            await ClickCheckoutNowBtn();
            await SelectedCharity();
            await EnterEmail(email);
            await EnterCardDetails();
            await ClickPayNowBtn();

            
        }

        
        public static async Task MakeAPurchaseAsAuthorizedUser()
        {
            await ClickCheckoutNowBtn();
            await EnterCardDetails();
            await ClickPayNowBtn();

            
        }

        
        public static async Task MakeAPurchaseSubscriptionAsUnauthorizedUser(string email, string subscriptionId)
        {
            await GoToBasket(subscriptionId);
            await EnterEmail(email);
            await EnterCardDetails();
            await ClickPayNowBtn();

            
        }

        
        public static async Task MakeAPurchaseSubscriptionAsAuthorizedUser(string subscriptionId)
        {
            await GoToBasket(subscriptionId);
            await EnterCardDetails();
            await ClickPayNowBtn();
            
        }

        
        private static async Task GoToBasket(string subscriptionId)
        {
            await GoToPage(Endpoints.Web.WEBSITE_HOST + $"/subscriptions/{subscriptionId}/payment", btncheckOutNow);
            await WaitUntil.Timeout(10000);
            await Browser.Driver.ReloadAsync();

            
        }

        public static async Task SelectedCharity()
        {
            await Button.Click(inputCharity);
            await SelectCharity();
            await WaitUntil.Timeout(2000);

            
        }

        private static async Task SelectCharity()
        {
            string text = RaffleAutomationTests.Helpers.Charities.CHARITY[RandomHelper.RandomCharityNumber(10)];
            await DropdownList.SelectDropdownItemByText(listCharities, text);


        }

        public static async Task VerifyUrl()
        {
            await WaitUntil.CustomCheckoutIsDisplayed();
            string expectedUrl = Endpoints.Web.WEBSITE_HOST;
            string currentUrl = Browser.Driver.Url;

            if (!currentUrl.Contains(expectedUrl))
            {
                Thread.Sleep(250);
                var waitForSelectorOptions = new PageWaitForURLOptions { Timeout = 10000 };
                await Browser.Driver.WaitForURLAsync(url => url.Contains("localhost"), waitForSelectorOptions);
                currentUrl = currentUrl.Replace("http://localhost:8000", expectedUrl);
                await GoToPage(currentUrl, ThankYou.titleThankYouPage);
            }
        }


        public static async Task VerifyErrorMessageIsDisplayed()
        {
            await VerifyUrl();
            await WaitUntil.ElementIsVisible(Common.toaster);
            await WaitUntil.ElementIsVisible(checkOutNowBtn);
        }

        public static async Task VerifyErrorMessageOnPaymentPage(string message)
        {
            await WaitUntil.ElementIsVisible(textErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textErrorMessage)).TextContentAsync().Result.ToLower(), Is.EqualTo(message.ToLower()));
        }

    }
}
