using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [FindsBy(How = How.XPath, Using = "//p[text()='Start date']/parent::div//input[@name='day']")]
        public IWebElement inputStartDay;

        [FindsBy(How = How.XPath, Using = "//p[text()='Start date']/parent::div//input[@name='month']")]
        public IWebElement inputStartMonth;

        [FindsBy(How = How.XPath, Using = "//p[text()='Start date']/parent::div//input[@name='year']")]
        public IWebElement inputStartYear;

        [FindsBy(How = How.XPath, Using = "//p[text()='Start date']/parent::div//input[@name='hour12']")]
        public IWebElement inputStartHour;

        [FindsBy(How = How.XPath, Using = "//p[text()='Start date']/parent::div//input[@name='minute']")]
        public IWebElement inputStartMinute;

        [FindsBy(How = How.XPath, Using = "//p[text()='Start date']/parent::div//input[@name='second']")]
        public IWebElement inputStartSecond;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Start date')]/parent::div//select[@name='amPm']")]
        public IWebElement inputStartAmPm;

        #endregion

        #region Date picker FinishDate

        [FindsBy(How = How.XPath, Using = "//p[text()='Finish date']/parent::div//input[@name='day']")]
        public IWebElement inputFinishDay;

        [FindsBy(How = How.XPath, Using = "//p[text()='Finish date']/parent::div//input[@name='month']")]
        public IWebElement inputFinishMonth;

        [FindsBy(How = How.XPath, Using = "//p[text()='Finish date']/parent::div//input[@name='year']")]
        public IWebElement inputFinishYear;

        [FindsBy(How = How.XPath, Using = "//p[text()='Finish date']/parent::div//input[@name='hour12']")]
        public IWebElement inputFinishHour;

        [FindsBy(How = How.XPath, Using = "//p[text()='Finish date']/parent::div//input[@name='minute']")]
        public IWebElement inputFinishMinute;

        [FindsBy(How = How.XPath, Using = "//p[text()='Finish date']/parent::div//input[@name='second']")]
        public IWebElement inputFinishSecond;

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

        [FindsBy(How=How.XPath,Using = "//span[text()='Bedrooms *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']")]
        public IWebElement bedroomsTextArea;

        [FindsBy(How=How.XPath,Using = "//span[text()='Bathrooms *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']")]
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

        [FindsBy(How=How.XPath,Using = "//div[contains(@class, 'overview')]//*[contains(@class, 'add-discount')]")]
        public IWebElement addOverviewBtn;

        [FindsBy(How=How.XPath,Using = "//div[contains(@class, 'deletePropertyRowBtn')]")]
        public IWebElement removeOverviewBtn;

        #region Overview element rows

        [FindsBy(How=How.XPath,Using = "//div[@class='dreamHomeProperty_fieldWrapper']//input[@name='title']")]
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



        #endregion

        


    }

}