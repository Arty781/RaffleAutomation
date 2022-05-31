using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsDreamhome
    {
        public IWebElement addDreamHomeBtn => Browser._Driver.FindElement(_addDreamHomeBtn);
        public readonly By _addDreamHomeBtn = By.XPath("//span[contains(text(), 'Add new dream home')]");

        #region General tab
        public IWebElement desktopImageInput => Browser._Driver.FindElement(_desktopImageInput);
        public readonly By _desktopImageInput = By.XPath("//div[@class='dropzone'][1]//input[@type='file']");

        public IWebElement mobileImageInput => Browser._Driver.FindElement(_mobileImageInput);
        public readonly By _mobileImageInput = By.XPath("//div[@class='dropzone'][2]//input[@type='file']");

        public IWebElement titleInput => Browser._Driver.FindElement(_titleInput);
        public readonly By _titleInput = By.XPath("//input[@id='title']");

        public IWebElement addressInput => Browser._Driver.FindElement(_addressInput);
        public readonly By _addressInput = By.XPath("//div[contains(@class, 'address-field')]//input[@type='text']");

        public IWebElement statusSwitcher => Browser._Driver.FindElement(_statusSwitcher);
        public readonly By _statusSwitcher = By.XPath("//input[@name='active']");

        public IWebElement selectDesktopImg => Browser._Driver.FindElement(_selectDesktopImg);
        public readonly By _selectDesktopImg = By.XPath("//section[1]//img[@class='file-img']");

        public IWebElement selectMobileImg => Browser._Driver.FindElement(_selectMobileImg);
        public readonly By _selectMobileImg = By.XPath("//section[2]//img[@class='file-img']");

        #region Date picker StartDate
        public IWebElement enterDayStart => Browser._Driver.FindElement(_enterDayStart);
        public readonly By _enterDayStart = By.XPath("//div[2]//input[@name='day']");

        public IWebElement enterMonthStart => Browser._Driver.FindElement(_enterMonthStart);
        public readonly By _enterMonthStart = By.XPath("//div[2]//input[@name='month']");

        public IWebElement enterYearStart => Browser._Driver.FindElement(_enterYearStart);
        public readonly By _enterYearStart = By.XPath("//div[2]//input[@name='year']");

        public IWebElement enterHourStart => Browser._Driver.FindElement(_enterHourStart);
        public readonly By _enterHourStart = By.XPath("//div[2]//input[@name='hour12']");

        public IWebElement enterMinuteStart => Browser._Driver.FindElement(_enterMinuteStart);
        public readonly By _enterMinuteStart = By.XPath("//div[2]//input[@name='minute']");

        public IWebElement enterSecondStart => Browser._Driver.FindElement(_enterSecondStart);
        public readonly By _enterSecondStart = By.XPath("//div[2]//input[@name='second']");

        public IWebElement selectAmPmStart => Browser._Driver.FindElement(_selectAmPmStart);
        public readonly By _selectAmPmStart = By.XPath("//div[2]//select[@name='amPm']");

        #endregion

        #region Date picker FinishDate
        public IWebElement enterDayFinish => Browser._Driver.FindElement(_enterDayFinish);
        public readonly By _enterDayFinish = By.XPath("//div[3]//input[@name='day']");

        public IWebElement enterMonthFinish => Browser._Driver.FindElement(_enterMonthFinish);
        public readonly By _enterMonthFinish = By.XPath("//div[3]//input[@name='month']");

        public IWebElement enterYearFinish => Browser._Driver.FindElement(_enterYearFinish);
        public readonly By _enterYearFinish = By.XPath("//div[3]//input[@name='year']");

        public IWebElement enterHourFinish => Browser._Driver.FindElement(_enterHourFinish);
        public readonly By _enterHourFinish = By.XPath("//div[3]//input[@name='hour12']");

        public IWebElement enterMinuteFinish => Browser._Driver.FindElement(_enterMinuteFinish);
        public readonly By _enterMinuteFinish = By.XPath("//div[3]//input[@name='minute']");

        public IWebElement enterSecondFinish => Browser._Driver.FindElement(_enterSecondFinish);
        public readonly By _enterSecondFinish = By.XPath("//div[3]//input[@name='second']");

        public IWebElement selectAmPmFinish => Browser._Driver.FindElement(_selectAmPmFinish);
        public readonly By _selectAmPmFinish = By.XPath("//div[3]//select[@name='amPm']");

        #endregion

        #region Options

        public IWebElement isTrendingSwitcher => Browser._Driver.FindElement(_isTrendingSwitcher);
        public readonly By _isTrendingSwitcher = By.XPath("//input[@id='isTrending']");

        public IWebElement isPopularSwitcher => Browser._Driver.FindElement(_isPopularSwitcher);
        public readonly By _isPopularSwitcher = By.XPath("//input[@id='isPopular']");

        #endregion

        #region Meta Tags

        public IWebElement metaTitle => Browser._Driver.FindElement(_metaTitle);
        public readonly By _metaTitle = By.XPath("//input[@id='metaTitle']");

        public IWebElement metaDescription => Browser._Driver.FindElement(_metaDescription);
        public readonly By _metaDescription = By.XPath("//input[@id='metaDescription']");

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
        public readonly By _bedroomsTextArea = By.XPath("//div[contains(@class, 'text-parent')][1]//div[@class='ql-editor ql-blank']");

        public IWebElement bathroomsTextArea => Browser._Driver.FindElement(_bathroomsTextArea);
        public readonly By _bathroomsTextArea = By.XPath("//div[contains(@class, 'text-parent')][2]//div[@class='ql-editor ql-blank']");

        public IWebElement outspaceTextArea => Browser._Driver.FindElement(_outspaceTextArea);
        public readonly By _outspaceTextArea = By.XPath("//div[contains(@class, 'text-parent')][3]//div[@class='ql-editor ql-blank']");

        public IWebElement aboutTextArea => Browser._Driver.FindElement(_aboutTextArea);
        public readonly By _aboutTextArea = By.XPath("//div[contains(@class, 'text-parent')][4]//div[@class='ql-editor ql-blank']");

        public IWebElement productCTATextArea => Browser._Driver.FindElement(_productCTATextArea);
        public readonly By _productCTATextArea = By.XPath("//div[contains(@class, 'text-parent')][5]//div[@class='ql-editor ql-blank']");

        public IWebElement headingTextArea => Browser._Driver.FindElement(_headingTextArea);
        public readonly By _headingTextArea = By.XPath("//div[contains(@class, 'text-parent')][6]//div[@class='ql-editor ql-blank']");

        #endregion

        #region Overview section
        public IWebElement addOverviewBtn => Browser._Driver.FindElement(_addOverviewBtn);
        public readonly By _addOverviewBtn = By.XPath("//div[contains(@class, 'overview')]//*[contains(@class, 'add-discount')]");

        public IWebElement removeOverviewBtn => Browser._Driver.FindElement(_removeOverviewBtn);
        public readonly By _removeOverviewBtn = By.XPath("//div[contains(@class, 'deletePropertyRowBtn')]");

        #region Overview element rows
        public IWebElement RowOverviewTitle => Browser._Driver.FindElement(_RowOverviewTitle);
        public readonly By _RowOverviewTitle = By.XPath("//div[contains(@class, 'dreamHomeProperty_row')]//*[contains(@name, 'title')]");

        public IWebElement RowOverviewValue => Browser._Driver.FindElement(_RowOverviewValue);
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