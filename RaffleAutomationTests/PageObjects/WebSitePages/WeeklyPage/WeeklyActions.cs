using NUnit.Allure.Steps;
using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using System.Linq;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Weekly
    {
        [AllureStep("Open WeeklyPrizes page")]
        public Weekly OpenWeeklyPrizesPage()
        {
            Browser._Driver.Navigate().GoToUrl(WebEndpoints.LIFESTYLE);
            return this;
        }

        [AllureStep("Close Weekly PopUp")]
        public Weekly CloseWeeklyPopUp()
        {
            WaitUntil.CustomElementIsVisible(closeWeeklyPopUp, 10);
            closeWeeklyPopUp.Click();

            return this;
        }

        [AllureStep("Select Category {0}")]
        public Weekly SelectCategory(string category)
        {
            WaitUntil.CustomElementIsVisible(categorySlider.Last(), 30);
            var catList = categorySlider.Where(x => x.Enabled);
            foreach (var cat in catList)
            {
                if (cat.Displayed == true && cat.Text == category)
                {
                    cat.Click();
                    WaitUntil.WaitSomeInterval(500);
                }
            }

            return this;
        }

        [AllureStep("Select SubCategory {0}")]
        public Weekly SelectSubCategory(string subcategory)
        {
            btnSubCategoryFilter.Click();
            WaitUntil.WaitSomeInterval(1000);
            foreach (var subCat in listSubCategory)
            {
                if (subCat.Displayed == true && subCat.Text == subcategory)
                {
                    subCat.Click();
                    WaitUntil.WaitSomeInterval(500);
                }
            }

            return this;
        }

        [AllureStep("Select prize {0}")]
        public Weekly SelectPrize(string title)
        {
            WaitUntil.WaitSomeInterval(250);
            var prizeList = weeklyProductCard.Where(x => x.Enabled).ToList();
            for (int i = 1; i < prizeList.Count; ++i)
            {
                string prizeTitle = "//div[@class='lifestyleProductList__card-wrapper'][" + i + "]//article//h3";
                IWebElement PrizeTitle = Browser._Driver.FindElement(By.XPath(prizeTitle));

                if (PrizeTitle.Text == title)
                {
                    string prizeEnterBtn = "//div[@class='lifestyleProductList__card-wrapper'][" + i + "]//article/div/button";
                    IWebElement PrizeEnterBtn = Browser._Driver.FindElement(By.XPath(prizeEnterBtn));
                    PrizeEnterBtn.SendKeys("");
                    WaitUntil.WaitSomeInterval(500);

                    PrizeEnterBtn.Click();
                    break;
                }


            }

            return this;
        }


    }
}
