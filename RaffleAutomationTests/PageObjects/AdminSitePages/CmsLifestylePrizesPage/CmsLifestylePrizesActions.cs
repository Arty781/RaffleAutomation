using NUnit.Allure.Steps;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsLifestylePrizes
    {
        public CmsLifestylePrizes OpenLifestylePizesPage()
        {
            Browser._Driver.Navigate().GoToUrl(AdminEndpoints.LIFESTYLE_PRIZES);
            return this;
        }

        public CmsLifestylePrizes SetRowsPerPageAs100()
        {
            WaitUntil.CustomElementIsVisible(rowPerPage);
            rowPerPage.Click();
            listOfRowValues.Last().Click();

            return this;
        }

        public CmsLifestylePrizes ClickNextBtn()
        {
            if(buttonNextPage.Enabled == true)
            {
                buttonNextPage.Click();
            }
            
            return this;
        }

        public CmsLifestylePrizes ActivatePrizesOnPage()
        {
            WaitUntil.WaitSomeInterval(1);
            WaitUntil.CustomElementIsVisible(switcher.First());
            for(int i =0; i < switcher.Count; i++)
            {
                switcher[i].Click();
            }
            
            return this;
        }
    }
}