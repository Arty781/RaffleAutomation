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
            WaitUntil.VisibilityOfAllElementsLocatedBy(_categorySlider, 30);
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
            int i =0;
            foreach (var prize in prizeList)
            {
                ++i;
                string prizeTitle = "//div[@class='lifestyleProductList__card-wrapper'][" + i + "]//article//h3";
                IWebElement PrizeTitle = Browser._Driver.FindElement(By.XPath(prizeTitle));
                
                    if (PrizeTitle.Text == title)
                    {
                        string prizeEnterBtn = "//div[@class='lifestyleProductList__card-wrapper'][" + i + "]//article/div/button";
                        IWebElement PrizeEnterBtn = Browser._Driver.FindElement(By.XPath(prizeEnterBtn));
                        PrizeEnterBtn.SendKeys("");
                        WaitUntil.WaitSomeInterval(2);

                        PrizeEnterBtn.Click();
                        break;
                    }
                
               
            }

            return this;
        }

        
    }
}
