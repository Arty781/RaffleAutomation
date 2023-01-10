using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;

namespace RaffleAutomationTests.PageObjects
{
    public partial class gr4vy
    {
        public IWebElement externalNumValue => Browser._Driver.FindElement(_externalNumValue);
        public readonly static By _externalNumValue = By.XPath("//*/tr/td[@class=\"ant-table-cell\"][8]/span");














    }
}
