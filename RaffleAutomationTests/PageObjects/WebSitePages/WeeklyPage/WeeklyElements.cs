using OpenQA.Selenium;
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
        public IWebElement counterPop => Browser._Driver.FindElement(_counterPop);
        public readonly static By _counterPop = By.XPath("//*/div[contains(text(), \"Next Winner Draw In: \")]");

        public IWebElement mainPageBannerInf => Browser._Driver.FindElement(_mainPageBannerInf);
        public readonly static By _mainPageBannerInf = By.XPath("//*/div[@class='lifestyle-prizes-banner__info']");


        public IWebElement categorySlider => Browser._Driver.FindElement(_categorySlider);
        public readonly static By _categorySlider = By.XPath("//*/ul/li[contains(@class,\"react-multi-carousel-item\")][contains(@class,\"active\")]/div/div");

        public IWebElement subCategoryFilter => Browser._Driver.FindElement(_subCategoryFilter);
        public readonly static By _subCategoryFilter = By.XPath("//*[contains(text(), 'View subcategories')]");
        
        public IWebElement selectSubCategory => Browser._Driver.FindElement(_selectSubCategory);
        public readonly static By _selectSubCategory = By.XPath("//*/ul[@class=\"filter-select__list\"]/li");

        public IWebElement weeklyProductCard => Browser._Driver.FindElement(_weeklyProductCard);
        public readonly static By _weeklyProductCard = By.XPath("//article[@class='product-card-component product-card']");

        public IWebElement weeklyProductCardEnt => Browser._Driver.FindElement(_weeklyProductCardEnt);
        public readonly static By _weeklyProductCardEnt = By.XPath("//*/article/div[1]/button");

        public IWebElement weeklyProductCardTitle => Browser._Driver.FindElement(_weeklyProductCardTitle);
        public readonly static By _weeklyProductCardTitle = By.XPath("//article[@class='product-card-component product-card']//h3");


        public IWebElement closeWeeklyPopUp => Browser._Driver.FindElement(_closeWeeklyPopUp);
        public readonly static By _closeWeeklyPopUp = By.XPath("//*/button[contains(text(), 'OK')]");

    }
}
