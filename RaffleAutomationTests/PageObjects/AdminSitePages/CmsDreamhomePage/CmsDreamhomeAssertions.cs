using NUnit.Allure.Steps;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsDreamhome
    {
        [AllureStep("Get dreamhome title")]
        public string GetDreamhomeTitle()
        {
            WaitUntil.ElementIsVisible(_titleInput);
            string dreamhomeTitle = titleInput.GetAttribute("value");
            return dreamhomeTitle;
        }
    }
}