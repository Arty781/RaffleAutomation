﻿using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Common
    {
        [FindsBy(How = How.XPath, Using = "//button[@class='enter-now__button']")]
        public IWebElement enterBtn;

        [FindsBy(How=How.XPath,Using = "//button[@class='cookie-close-button']")]
        public IWebElement confirmCookieBtn;

        [FindsBy(How=How.XPath,Using = "//ul[@class='ticket-selector__grid']/li[5]")]
        public IWebElement addOneTicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[6]")]
        public IWebElement addTenTicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[7]")]
        public IWebElement add25TicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[3]")]
        public IWebElement removeOneTicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[2]")]
        public IWebElement removeTenTicketBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@class='ticket-selector__grid']/li[1]")]
        public IWebElement remove25TicketBtn;
        
        [FindsBy(How = How.XPath, Using = "//button/span[@class='add-basket']")]
        public static IWebElement btnAddToBasket;






    }
}
