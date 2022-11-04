using HtmlAgilityPack;
using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Basket
    {
        public IWebElement addMoreTicketsBtn => Browser._Driver.FindElement(_addMoreTicketsBtn);
        public readonly static By _addMoreTicketsBtn = By.XPath("//*/button[@class='your-basket-ticket-select']");
        public IWebElement removeOrderBtn => Browser._Driver.FindElement(_removeOrderBtn);
        public readonly static By _removeOrderBtn = By.XPath("//*/button[@class='basket-btn']");
        public IWebElement couponInput => Browser._Driver.FindElement(_couponInput);
        public readonly static By _couponInput = By.XPath("//*/input[@id='coupon-input']");
        public IWebElement applyCouponBtn => Browser._Driver.FindElement(_applyCouponBtn);
        public readonly static By _applyCouponBtn = By.XPath("//*/button[@class='apply-coupon-btn']");
        public IWebElement checkOutNowBtn => Browser._Driver.FindElement(_checkOutNowBtn);
        public readonly static By _checkOutNowBtn = By.XPath("//*/button[@class='rafflebtn primary full-width']");
        public IWebElement orderTotalVal => Browser._Driver.FindElement(_orderTotalVal);
        public readonly static By _orderTotalVal = By.XPath("//*/div[@class='itemPrice total-credit']/div[2]");
        public IWebElement selectCharityHomless => Browser._Driver.FindElement(_selectCharityHomless);
        public readonly static By _selectCharityHomless = By.XPath("//*/label[@class='MuiFormControlLabel-root'][1]");
        public IWebElement selectCharityWomen => Browser._Driver.FindElement(_selectCharityWomen);
        public readonly static By _selectCharityWomen = By.XPath("//*/label[@class='MuiFormControlLabel-root'][2]");
        public IWebElement ageControlSection => Browser._Driver.FindElement(_ageControlSection);
        public readonly static By _ageControlSection = By.XPath("//div[@class='age-control-section']/label//span/input");

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

        public IWebElement orderSummaryBtn => Browser._Driver.FindElement(_orderSummaryBtn);
        public readonly static By _orderSummaryBtn = By.XPath("//div[@class='checkout-header']");

        #region Checkout Verification page

        [FindsBy(How = How.Name, Using = "cko-3ds2-iframe")]
        public IWebElement frameCheckout;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement inputPasswordCheckout;

        [FindsBy(How = How.XPath, Using = "//input[@value='Continue']")]
        public IWebElement btnContinueCheckout;

        [FindsBy(How = How.XPath, Using = "//button[@class='rafflebtn primary full-width']")]
        public IWebElement btncheckOutNow;




        #endregion
    }
}