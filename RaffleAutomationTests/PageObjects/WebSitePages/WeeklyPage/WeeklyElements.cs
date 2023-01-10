using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Weekly
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Next Winner Draw In: ')]")]
        public IWebElement counterPop;

        [FindsBy(How = How.XPath, Using = "//div[@class='lifestyle-prizes-banner__info']")]
        public IWebElement mainPageBannerInf;

        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'active')]//div[@class='itemName ']")]
        public IList<IWebElement> categorySlider;

        [FindsBy(How = How.XPath, Using = "//div[@title='Open']")]
        public IWebElement btnSubCategoryFilter;

        [FindsBy(How = How.XPath, Using = "//ul[@class='filter-select__list']/li")]
        public IList<IWebElement> listSubCategory;

        [FindsBy(How = How.XPath, Using = "//article[@class='product-card-component product-card']")]
        public IList<IWebElement> weeklyProductCard;

        [FindsBy(How = How.XPath, Using = "//article/div[1]/button")]
        public IWebElement weeklyProductCardEnt;

        [FindsBy(How = How.XPath, Using = "//article[@class='product-card-component product-card']//h3")]
        public IWebElement weeklyProductCardTitle;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'OK')]")]
        public IWebElement closeWeeklyPopUp;

    }
}
