using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Dreamhome
    {
        public IWebElement raffleBtn => Browser._Driver.FindElement(_raffleBtn);
        public readonly static By _raffleBtn = By.XPath("//*/div[@class=\"competition-cards\"]//*[@class=\"rafflebtn primary full-width\"]");

        public IWebElement firstBundleBtn => Browser._Driver.FindElement(_firstBundleBtn);
        public readonly static By _firstBundleBtn = By.XPath("//*/ul/li[1]/div[@class=\"popular-ticket-content\"]");

        public IWebElement secondBundleBtn => Browser._Driver.FindElement(_secondBundleBtn);
        public readonly static By _secondBundleBtn = By.XPath("//*/ul/li[2]/div[@class=\"popular-ticket-content\"]");

        public IWebElement thirdBundleBtn => Browser._Driver.FindElement(_thirdBundleBtn);
        public readonly static By _thirdBundleBtn = By.XPath("//*/ul/li[3]/div[@class=\"popular-ticket-content\"]");

        public IWebElement forthBundleBtn => Browser._Driver.FindElement(_forthBundleBtn);
        public readonly static By _forthBundleBtn = By.XPath("//*/ul/li[4]/div[@class=\"popular-ticket-content\"]");

        public IWebElement contactSection => Browser._Driver.FindElement(_contactSection);
        public readonly static By _contactSection = By.XPath("//*/section[@class=\"contacts-submit\"]/*//div[@class=\"winner-club-title\"]");

        public IWebElement enterNowDreamhomeBtn => Browser._Driver.FindElement(_enterNowDreamhomeBtn);
        public readonly static By _enterNowDreamhomeBtn = By.XPath("//*/button[@class=\"rafflebtn secondary full-width sticky-dh-btn\"]");
    }
}
