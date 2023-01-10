using NUnit.Allure.Steps;
using RaffleAutomationTests.Helpers;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsDreamhome
    {
        [AllureStep("Get dreamhome title")]
        public string GetDreamhomeTitle()
        {
            WaitUntil.CustomElementIsVisible(inputTitle);
            string dreamhomeTitle = inputTitle.GetAttribute("value");
            return dreamhomeTitle;
        }
    }
}