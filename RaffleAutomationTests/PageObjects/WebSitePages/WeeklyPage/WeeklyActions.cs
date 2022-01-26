using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Weekly
    {
        [AllureStep("Close Weekly PopUp")]
        public Weekly CloseWeeklyPopUp()
        {
            WaitUntil.ElementIsVisible(_closeWeeklyPopUp, 10);
            closeWeeklyPopUp.Click();

            return this;
        }

        [AllureStep("Select Category {0}")]
        public Weekly SelectCategory(string category)
        {
           /*WaitUntil.WaitSomeInterval(3);*/
            WaitUntil.ElementIsVisible(_categorySlider);
            IReadOnlyCollection<IWebElement> catList = Browser._Driver.FindElements(_categorySlider);
            foreach(var cat in catList)
            {
                if (cat.Displayed == true && cat.Text == category)
                {
                    cat.Click();
                    Console.WriteLine(cat.Text);
                }
            }
            categorySlider.Click();

            return this;
        }

        [AllureStep("Select SubCategory {0}")]
        public Weekly SelectSubCategory(string subcategory)
        {
            subCategoryFilter.Click();

            WaitUntil.WaitSomeInterval(1);
            IReadOnlyCollection<IWebElement> subCatList = Browser._Driver.FindElements(_selectSubCategory);
            foreach(var subCat in subCatList)
            {
                
                if(subCat.Displayed == true && subCat.Text == subcategory)
                {
                    subCat.Click();
                    Console.WriteLine(subCat.Text);
                }
            }
            
            return this;
        }

        [AllureStep("Select prize {0}")]
        public Weekly SelectPrize(string title)
        {
            WaitUntil.WaitSomeInterval(3);
            IReadOnlyCollection<IWebElement> prizeList = Browser._Driver.FindElements(_weeklyProductCard);
            foreach (var prize in prizeList)
            {
               
                if (prize.FindElement(_weeklyProductCardTitle).Displayed == true)
                {
                   
                    if (prize.FindElement(_weeklyProductCardTitle).Text == title)
                    {
                        var prizeImg = prize.FindElement(_weeklyProductCardEnt);
                        prizeImg.SendKeys(Keys.Control);
                        WaitUntil.WaitSomeInterval(2);

                        prizeImg.Click();
                        break;
                    }
                    
                }
               
            }

            return this;
        }

        
    }
}
