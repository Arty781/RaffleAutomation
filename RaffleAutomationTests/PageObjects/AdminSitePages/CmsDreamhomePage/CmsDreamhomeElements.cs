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
        [FindsBy(How = How.XPath, Using = "//a[@aria-label='Add new dream home']")]
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

        [FindsBy(How = How.XPath, Using = "//input[@id='isTrending']")]
        public IWebElement inputIsTrending;

        [FindsBy(How = How.XPath, Using = "//input[@id='isPopular']")]
        public IWebElement inputIsPopular;

        #endregion

        #region Meta Tags

        [FindsBy(How = How.XPath, Using = "//input[@id='metaTitle']")]
        public IWebElement inputMetaTitle;

        [FindsBy(How = How.XPath, Using = "//input[@id='metaDescription']")]
        public IWebElement inputMetaDescr;

        #endregion


        #endregion

        #region Description tab

        #region Images
        public IWebElement dreamhomeCardImg => Browser._Driver.FindElement(_dreamhomeCardImg);
        public readonly By _dreamhomeCardImg = By.XPath("//input[@id='property.filesCard']");

        public IWebElement bedroomCardImg => Browser._Driver.FindElement(_bedroomCardImg);
        public readonly By _bedroomCardImg = By.XPath("//input[@id='property.filesBedroom']");

        public IWebElement bathroomCardImg => Browser._Driver.FindElement(_bathroomCardImg);
        public readonly By _bathroomCardImg = By.XPath("//input[@id='property.filesBathroom']");

        public IWebElement outspaceCardImg => Browser._Driver.FindElement(_outspaceCardImg);
        public readonly By _outspaceCardImg = By.XPath("//input[@id='property.filesOutspace']");

        public IWebElement floorPlanCardImg => Browser._Driver.FindElement(_floorPlanCardImg);
        public readonly By _floorPlanCardImg = By.XPath("//input[@id='property.filesFloorPlan']");

        #endregion

        #region Text inputs
        public IWebElement bedroomsTextArea => Browser._Driver.FindElement(_bedroomsTextArea);
        public readonly By _bedroomsTextArea = By.XPath("//span[text()='Bedrooms *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']");

        public IWebElement bathroomsTextArea => Browser._Driver.FindElement(_bathroomsTextArea);
        public readonly By _bathroomsTextArea = By.XPath("//span[text()='Bathrooms *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']");

        public IWebElement outspaceTextArea => Browser._Driver.FindElement(_outspaceTextArea);
        public readonly By _outspaceTextArea = By.XPath("//span[text()='Outspace *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']");

        public IWebElement aboutTextArea => Browser._Driver.FindElement(_aboutTextArea);
        public readonly By _aboutTextArea = By.XPath("//span[text()='About *']/ancestor::div[contains(@class,'about-section')]//div[@class='ql-editor ql-blank']");

        public IWebElement productCTATextArea => Browser._Driver.FindElement(_productCTATextArea);
        public readonly By _productCTATextArea = By.XPath("//span[text()='Product Page CTA *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']");

        public IWebElement headingTextArea => Browser._Driver.FindElement(_headingTextArea);
        public readonly By _headingTextArea = By.XPath("//span[text()='Heading 1 *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']");

        #endregion

        #region Overview section
        public IWebElement addOverviewBtn => Browser._Driver.FindElement(_addOverviewBtn);
        public readonly By _addOverviewBtn = By.XPath("//div[contains(@class, 'overview')]//*[contains(@class, 'add-discount')]");

        public IWebElement removeOverviewBtn => Browser._Driver.FindElement(_removeOverviewBtn);
        public readonly By _removeOverviewBtn = By.XPath("//div[contains(@class, 'deletePropertyRowBtn')]");

        #region Overview element rows
        public IList<IWebElement> RowOverviewTitle => Browser._Driver.FindElements(_RowOverviewTitle);
        public readonly By _RowOverviewTitle = By.XPath("//div[contains(@class, 'dreamHomeProperty_row')]//*[contains(@name, 'title')]");

        public IList<IWebElement> RowOverviewValue => Browser._Driver.FindElements(_RowOverviewValue);
        public readonly By _RowOverviewValue = By.XPath("//input[@name='value']");

        public IWebElement TakeTourWithSara => Browser._Driver.FindElement(_TakeTourWithSara);
        public readonly By _TakeTourWithSara = By.XPath("//input[@id='property.tourLink']");

        public IWebElement secondRowOverviewValue => Browser._Driver.FindElement(_secondRowOverviewValue);
        public readonly By _secondRowOverviewValue = By.XPath("//div[contains(@class, 'dreamHomeProperty_row')][2]//*[contains(@name, 'value')]");

        public IWebElement thirdRowOverviewTitle => Browser._Driver.FindElement(_thirdRowOverviewTitle);
        public readonly By _thirdRowOverviewTitle = By.XPath("//div[contains(@class, 'dreamHomeProperty_row')][3]//*[contains(@name, 'title')]");

        public IWebElement thirdRowOverviewValue => Browser._Driver.FindElement(_thirdRowOverviewValue);
        public readonly By _thirdRowOverviewValue = By.XPath("//div[contains(@class, 'dreamHomeProperty_row')][3]//*[contains(@name, 'value')]");

        public IWebElement forthRowOverviewTitle => Browser._Driver.FindElement(_forthRowOverviewTitle);
        public readonly By _forthRowOverviewTitle = By.XPath("//div[contains(@class, 'dreamHomeProperty_row')][4]//*[contains(@name, 'title')]");

        public IWebElement forthRowOverviewValue => Browser._Driver.FindElement(_forthRowOverviewValue);
        public readonly By _forthRowOverviewValue = By.XPath("//div[contains(@class, 'dreamHomeProperty_row')][4]//*[contains(@name, 'value')]");

        #endregion

        #endregion

        #endregion

        #region Discount & Tickets tab

        public IWebElement ticketPriceInput => Browser._Driver.FindElement(_ticketPriceInput);
        public readonly By _ticketPriceInput = By.XPath("//input[@id='ticketPrice']");

        public IWebElement defaultTicketsInput => Browser._Driver.FindElement(_defaultTicketsInput);
        public readonly By _defaultTicketsInput = By.XPath("//input[@id='defaultTickets']");

        public IWebElement isActiveDiscountToggle => Browser._Driver.FindElement(_isActiveDiscountToggle);
        public readonly By _isActiveDiscountToggle = By.XPath("//input[@id='isActiveDiscount']");



        #endregion

        


    }

}