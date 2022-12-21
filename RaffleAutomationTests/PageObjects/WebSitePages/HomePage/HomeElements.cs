using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Home
    {
        #region Top Slider

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'change-button')]/button")]
        public IList<IWebElement> tbsSlider;

        [FindsBy(How = How.XPath, Using = "//section[@class='startpage-slider']//button[@class='slick-arrow slick-prev']")]
        public IWebElement btnPrevTopSlider;

        [FindsBy(How = How.XPath, Using = "//section[@class='startpage-slider']//button[@class='slick-arrow slick-next']")]
        public IWebElement btnNextTopSlider;

        [FindsBy(How = How.XPath, Using = "//img[@alt='floorplan']")]
        public IWebElement imgFloorPlan;

        [FindsBy(How = How.XPath, Using = "//img[@alt='dreamhome location']")]
        public IWebElement imgMap;


        #endregion

        #region Banner Secondary Section

        [FindsBy(How = How.XPath, Using = "//section[@class='banner-secondary ']//p")]
        public IWebElement textTitleBannerSecondary;


        #endregion

        #region Info blocks

#if DEBUG || RELEASE

        [FindsBy(How = How.XPath, Using = "//div[@class='info-block']/div[@class='desktop']//h2")]
        public IList<IWebElement> textTitle;

        [FindsBy(How = How.XPath, Using = "//div[@class='info-block']/div[@class='desktop']//p")]
        public IList<IWebElement> textParagraph;

        [FindsBy(How = How.XPath, Using = "//div[@class='dream-slider-bg']/div[@class='container']//h2")]
        public IWebElement textBottomSliderTitle;

        [FindsBy(How = How.XPath, Using = "//div[@class='dream-slider-bg']/div[@class='container']//p")]
        public IWebElement textBottomSliderParagraph;

        [FindsBy(How = How.XPath, Using = "//section[@class='charitable-home-block']//div[@class='givingAbout']//h2")]
        public IWebElement textCharityTitle;

        [FindsBy(How = How.XPath, Using = "//section[@class='charitable-home-block']//div[@class='givingAbout']//p")]
        public IWebElement textCharityParagraph;

        [FindsBy(How = How.XPath, Using = "//section[@class='charitable-home-block']//div[@class='givingAbout']//section//p")]
        public IWebElement textCharityCard;

#endif

#if DEBUG_MOBILE || RELEASE_MOBILE

        [FindsBy(How = How.XPath, Using = "//div[@class='info-block']/div[@class='mobile']//h2")]
        public IList<IWebElement> textTitle;

        [FindsBy(How = How.XPath, Using = "//div[@class='info-block']/div[@class='mobile']//p")]
        public IList<IWebElement> textParagraph;

        [FindsBy(How = How.XPath, Using = "//div[@class='dream-slider-bg']/div[@class='container']//h2")]
        public IWebElement textBottomSliderTitle;

        [FindsBy(How = How.XPath, Using = "//div[@class='dream-slider-bg']/div[@class='container']//p")]
        public IWebElement textBottomSliderParagraph;

        [FindsBy(How = How.XPath, Using = "//section[@class='charitable-home-block']//div[@class='givingAboutSlider']//h2")]
        public IWebElement textCharityTitle;

        [FindsBy(How = How.XPath, Using = "//section[@class='charitable-home-block']//div[@class='givingAboutSlider']//p")]
        public IWebElement textCharityParagraph;

        [FindsBy(How = How.XPath, Using = "//section[@class='charitable-home-block']//div[@class='givingAboutSlider']//div[@class='cardText']/p")]
        public IWebElement textCharityCard;

#endif

        #endregion

        #region How It Works

        [FindsBy(How = How.XPath, Using = "//section[@class='how-it-works-home container']//h2")]
        public IWebElement textHowItWorksTitle;

        [FindsBy(How = How.XPath, Using = "//section[@class='how-it-works-home container']//div[@class='howMainContent']/p")]
        public IWebElement textHowItWorksParagraph;

        [FindsBy(How = How.XPath, Using = "//section[@class='how-it-works-home container']//div[@class='howStepper']//h3")]
        public IList<IWebElement> textHowItWorksStepsTitle;

        [FindsBy(How = How.XPath, Using = "//section[@class='how-it-works-home container']//div[@class='howStepper']//p")]
        public IList<IWebElement> textHowItWorksStepsParagraph;


        #endregion


    }
}
