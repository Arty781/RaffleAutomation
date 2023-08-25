using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.WEB.BasketPage
{
    public partial class Basket
    {
        public const string textPrice = "//div[@class='your-basket-ticket-price']";
        public const string addMoreTicketsBtn = "//button[@class='your-basket-ticket-select']";
        public const string removeOrderBtn = "//button[@class='basket-btn']";
        public const string couponInput = "//input[@name='coupon-input']";
        public const string applyCouponBtn = "//button[@class='apply-coupon-btn']";
        public const string checkOutNowBtn = "//div[@class='itemPrice']/button";
        public const string orderTotalVal = "//div[@class='itemPrice total-credit']/div[2]";
        public const string inputCharity = "//input/ancestor::div[@class='select-wrapper']";
        public const string listCharities = "//div[@id='menu-']//ul/li";
        public const string dropItemCharities = "//div[@id='menu-']//ul/li";
        public const string ageControlSection = "//div[@class='age-control-section']/label//span/input";
        public const string checkboxAgeControl = "//input[@name='checkedB'";
        public const string framePaymentNumber = "//iframe[@id='cardNumber']";
        public const string framePaymentExpiry = "//iframe[@id='expiryDate']";
        public const string framePaymentCvv = "//iframe[@id='cvv']";
        public const string inputCardNumber = "//input[@id='checkout-frames-card-number']";
        public const string inputExpiryDate = "//input[@id='checkout-frames-expiry-date']";
        public const string inputCvv = "//input[@id='checkout-frames-cvv']";
        public const string btnPay = "#pay-button";
        public const string orderSummaryBtn = "//div[@class='checkout-header']";

        #region Checkout Verification page

        public const string frameCheckout = "//iframe[@name='cko-3ds2-iframe']";
        public const string inputPasswordCheckout = "//input[@id='password']";
        public const string btnContinueCheckout = "//input[@value='Continue']";
        public const string btncheckOutNow = "//button[@class='rafflebtn primary full-width']";
        public const string inputEmail = "//input[@name='email']";
        public const string textErrorMessage = "//div[@class='status-payment-container']/span";


        #endregion
    }
}
