namespace RaffleAutomationTests.PageObjects
{
    public partial class Basket
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='your-basket-ticket-price']")]
        public IList<IWebElement> textPrice;

        [FindsBy(How = How.XPath, Using = "//button[@class='your-basket-ticket-select']")]
        public IWebElement addMoreTicketsBtn;

        [FindsBy(How = How.XPath, Using = "//button[@class='basket-btn']")]
        public IWebElement removeOrderBtn;

        [FindsBy(How = How.Id, Using = "coupon-input")]
        public IWebElement couponInput;

        [FindsBy(How = How.XPath, Using = "//button[@class='apply-coupon-btn']")]
        public IWebElement applyCouponBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='itemPrice']/button")]
        public IWebElement checkOutNowBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='itemPrice total-credit']/div[2]")]
        public IWebElement orderTotalVal;

        [FindsBy(How = How.XPath, Using = "//input/ancestor::div[@class='select-wrapper']")]
        public IWebElement inputCharity;

        [FindsBy(How = How.XPath, Using = "//div[@id='menu-']//ul/li")]
        public IList<IWebElement> listCharities;

        [FindsBy(How = How.XPath, Using = "//div[@id='menu-']//ul/li")]
        public IWebElement dropItemCharities;

        [FindsBy(How = How.XPath, Using = "//div[@class='age-control-section']/label//span/input")]
        public IWebElement ageControlSection;

        [FindsBy(How = How.Name, Using = "checkedB")]
        public IWebElement checkboxAgeControl;

        [FindsBy(How = How.Id, Using = "cardNumber")]
        public IWebElement framePaymentNumber;

        [FindsBy(How = How.Id, Using = "expiryDate")]
        public IWebElement framePaymentExpiry;

        [FindsBy(How = How.Id, Using = "cvv")]
        public IWebElement framePaymentCvv;

        [FindsBy(How = How.Id, Using = "checkout-frames-card-number")]
        public IWebElement inputCardNumber;

        [FindsBy(How = How.Id, Using = "checkout-frames-expiry-date")]
        public IWebElement inputExpiryDate;

        [FindsBy(How = How.Id, Using = "checkout-frames-cvv")]
        public IWebElement inputCvv;

        [FindsBy(How = How.Id, Using = "pay-button")]
        public IWebElement btnPay;

        [FindsBy(How = How.Id, Using = "subscription-pay-button")]
        public IWebElement btnPaySub;

        [FindsBy(How = How.XPath, Using = "//div[@class='checkout-header']")]
        public IWebElement orderSummaryBtn;

        #region Checkout Verification page

        [FindsBy(How = How.Name, Using = "cko-3ds2-iframe")]
        public IWebElement frameCheckout;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement inputPasswordCheckout;

        [FindsBy(How = How.XPath, Using = "//input[@value='Continue']")]
        public IWebElement btnContinueCheckout;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn primary full-width']")]
        public IWebElement btncheckOutNow;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement inputEmail;

        [FindsBy(How = How.XPath, Using = "//div[@class='status-payment-container']/span")]
        public IWebElement textErrorMessage;


        #endregion
    }
}