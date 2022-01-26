using OpenQA.Selenium;
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
        public readonly static By _ageControlSection = By.XPath("//*/div[@class='age-control-section']/label/span");
        public IWebElement paymentForm => Browser._Driver.FindElement(_paymentForm);
        public readonly static By _paymentForm = By.XPath("//*/iframe[@title=\"Secure payment frame - Gr4vy\"]");
        public IWebElement cardNumberInput => Browser._Driver.FindElement(_cardNumberInput);
        public readonly static By _cardNumberInput = By.XPath("//*[@id='card-number']");
        public IWebElement cardExpDate => Browser._Driver.FindElement(_cardExpDate);
        public readonly static By _cardExpDate = By.XPath("//*[@id='card-expiration-date']");
        public IWebElement cardCvvInpt => Browser._Driver.FindElement(_cardCvvInpt);
        public readonly static By _cardCvvInpt = By.XPath("//*[@id='card-security-code']");
        public IWebElement payBtn => Browser._Driver.FindElement(_payBtn);
        public readonly static By _payBtn = By.XPath("//*/button[@id=\"pay-button\"]");
        public IWebElement orderSummaryBtn => Browser._Driver.FindElement(_orderSummaryBtn);
        public readonly static By _orderSummaryBtn = By.XPath("//*/div[@class='checkout-header']");

        
    }
}