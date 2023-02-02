using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsDreamhome
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='#/dreamHome/create']")]
        public IWebElement btnAddDreamHome;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/dreamHome/create']")]
        public IWebElement tabGeneralDream;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/dreamHome/create/1']")]
        public IWebElement tabDescrDream;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/dreamHome/create/3']")]
        public IWebElement tabDiscountTickets;

        #region General tab


        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'desktop *')]/following-sibling::div/input")]
        public IWebElement inputDesktopImage;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'mobile *')]/following-sibling::div/input")]
        public IWebElement inputMobileImage;

        [FindsBy(How = How.XPath, Using = "//input[@id='title']")]
        public IWebElement inputTitle;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'coordinates')]//input")]
        public IWebElement inputAddress;

        [FindsBy(How = How.XPath, Using = "//input[@name='active']")]
        public IWebElement switcherStatus;

        [FindsBy(How = How.XPath, Using = "//section[1]//img[@class='file-img']")]
        public IWebElement imgDesktopSelect;

        [FindsBy(How = How.XPath, Using = "//section[2]//img[@class='file-img']")]
        public IWebElement imgMobileSelect;

        #region Date picker StartDate

        [FindsBy(How = How.XPath, Using = "//p[text()='Start date']/parent::div/div//input[@autocomplete]")]
        public IList<IWebElement> inputStartDate;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Start date')]/parent::div//select[@name='amPm']")]
        public IWebElement inputStartAmPm;

        #endregion

        #region Date picker FinishDate

        [FindsBy(How = How.XPath, Using = "//p[text()='Finish date']/parent::div/div//input[@autocomplete]")]
        public IList<IWebElement> inputFinishDate;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Finish date')]/parent::div//select[@name='amPm']")]
        public IWebElement inputFinishAmPm;

        #endregion

        #region Options

        [FindsBy(How = How.Id, Using = "isTrending")]
        public IWebElement inputIsTrending;

        [FindsBy(How = How.Id, Using = "isPopular")]
        public IWebElement inputIsPopular;

        #endregion

        #region Meta Tags

        [FindsBy(How = How.Id, Using = "metaTitle")]
        public IWebElement inputMetaTitle;

        [FindsBy(How = How.Id, Using = "metaDescription")]
        public IWebElement inputMetaDescr;

        #endregion


        #endregion

        #region Description tab

        #region Images

        [FindsBy(How = How.Id, Using = "property.filesCard")]
        public IWebElement dreamhomeCardImg;

        [FindsBy(How = How.Id, Using = "property.filesBedroom")]
        public IWebElement bedroomCardImg;

        [FindsBy(How = How.Id, Using = "property.filesBathroom")]
        public IWebElement bathroomCardImg;

        [FindsBy(How = How.Id, Using = "property.filesOutspace")]
        public IWebElement outspaceCardImg;

        [FindsBy(How = How.Id, Using = "property.filesFloorPlan")]
        public IWebElement floorPlanCardImg;

        #endregion

        #region Text inputs

        [FindsBy(How = How.XPath, Using = "//span[text()='Bedrooms *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']")]
        public IWebElement bedroomsTextArea;

        [FindsBy(How = How.XPath, Using = "//span[text()='Bathrooms *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']")]
        public IWebElement bathroomsTextArea;

        [FindsBy(How = How.XPath, Using = "//span[text()='Outspace *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']")]
        public IWebElement outspaceTextArea;

        [FindsBy(How = How.XPath, Using = "//span[text()='About *']/ancestor::div[contains(@class,'about-section')]//div[@class='ql-editor ql-blank']")]
        public IWebElement aboutTextArea;

        [FindsBy(How = How.XPath, Using = "//span[text()='Product Page CTA *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']")]
        public IWebElement productCTATextArea;

        [FindsBy(How = How.XPath, Using = "//span[text()='Heading 1 *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']")]
        public IWebElement headingTextArea;

        #endregion

        #region Overview section

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'overview')]//*[contains(@class, 'add-discount')]")]
        public IWebElement addOverviewBtn;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'deletePropertyRowBtn')]")]
        public IWebElement removeOverviewBtn;

        #region Overview element rows

        [FindsBy(How = How.XPath, Using = "//div[@class='dreamHomeProperty_fieldWrapper']//input[@name='title']")]
        public IList<IWebElement> RowOverviewTitle;

        [FindsBy(How = How.XPath, Using = "//input[@name='value']")]
        public IList<IWebElement> RowOverviewValue;

        #endregion

        #endregion

        #endregion

        #region Discount & Tickets tab

        [FindsBy(How = How.Id, Using = "ticketPrice")]
        public IWebElement ticketPriceInput;

        [FindsBy(How = How.Id, Using = "defaultTickets")]
        public IWebElement defaultTicketsInput;

        [FindsBy(How = How.Id, Using = "isActiveDiscount")]
        public IWebElement isActiveDiscountToggle;

        [FindsBy(How=How.XPath,Using = "//h6[contains(text(),'Discount')]/parent::div//input[@type='checkbox']")]
        public IWebElement btnDiscountStepsToggle;

        [FindsBy(How = How.XPath, Using = "//h6[contains(text(),'Discount')]/parent::div//input[@type='radio']")]
        public IList<IWebElement> btnDiscountStepsRadio;

        [FindsBy(How=How.XPath,Using = "//label[contains(text(),'threshold')]/parent::div//input")]
        public IList<IWebElement> inputDiscountThreshold;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'£')]/parent::div//input")]
        public IList<IWebElement> inputDiscountValue;

        [FindsBy(How=How.XPath,Using = "//h6[contains(text(),'Tickets Bundles')]/parent::div//*[@class='MuiSvgIcon-root add-discount']")]
        public IWebElement btnAddBundles;

        [FindsBy(How = How.XPath, Using = "//h6[contains(text(),'Discount')]/parent::div//*[@class='MuiSvgIcon-root add-discount']")]
        public IWebElement btnAddThresholds;

        [FindsBy(How = How.XPath, Using = "//h6[contains(text(),'Tickets Bundles')]/parent::div//input")]
        public IList<IWebElement> inputBundles;

        #endregion




    }

}