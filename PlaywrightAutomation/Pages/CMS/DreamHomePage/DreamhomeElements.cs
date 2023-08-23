using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightAutomation.Pages.CMS.DreamHomePage
{
    public partial class Dreamhome
    {
        public const string btnAddDreamHome = "//a[@href='#/dreamHome/create']";
        public const string tabGeneralDream = "//a[@href='#/dreamHome/create']";
        public const string tabDescrDream = "//a[@href='#/dreamHome/create/1']";
        public const string tabDiscountTickets = "//a[@href='#/dreamHome/create/3']";
        public const string titleAddedDreamhome = "//h6[text()=' New Dream Home ']/parent::div[@class='active-table-title']/parent::div/following::tbody/tr/td[1]";
        public const string btnEditDreamHome = "//td//a[.='Edit']";

        #region General page

        public const string btnDeleteImageDesktop = "//div[text()='Add images for desktop *']/parent::div//section[@class='file-list'][1]//div[contains(@class, 'image-actions')]//*[contains(@class,'remove-image-icon')]";
        public const string btnDeleteImageMobile = "//div[text()='Add images for mobile *']/parent::div//section[@class='file-list'][2]//div[contains(@class, 'image-actions')]//*[contains(@class,'remove-image-icon')]";
        public const string inputDesktopImage = "//div[contains(text(),'desktop *')]/following-sibling::div/input";
        public const string listImgDesktop = "//section[1]/div[./img]";
        public const string inputMobileImage = "//div[contains(text(),'mobile *')]/following-sibling::div/input";
        public const string listImgMobile = "//section[2]/div[./img]";
        public const string listImgMobileLast10 = "//section[2]/div[./img][10]";
        public const string inputTitle = "//input[@id='title']";
        public const string toggleSwitcherStatus = "//input[@name='active']";
        public const string inputStartDate = "//div[./p[text()='Start date']]//input[@autocomplete]";
        public const string inputStartAmPm = "//div[./p[contains(text(),'Start date')]]//select[@name='amPm']";
        public const string inputFinishDate = "//div[./p[text()='Finish date']]//input[@autocomplete]";
        public const string inputFinishAmPm = "//div[./p[contains(text(),'Finish date')]]//select[@name='amPm']";
        public const string inputIsTrending = "//*[@id='isTrending']";
        public const string inputIsPopular = "//*[@id='isPopular']";
        public const string inputMetaTitle = "//*[@id='metaTitle']";
        public const string inputMetaDescr = "//*[@id='metaDescription']";

        #endregion

        #region Description

        public const string dreamhomeCardImg = "//*[@id='property.filesCard']";
        public const string floorPlanCardImg = "//*[@id='property.filesFloorPlan']";
        public const string mapCardImg = "//*[@id='property.filesMapImage']";
        public const string aboutTextArea = "//div[@class='ql-editor']";

        #endregion

        #region Discount & Tickets tab

        public const string inputTicketPrice = "//*[@id='ticketPriceInput']";
        public const string inputDefaultTickets = "//*[@id='defaultTickets']";
        public const string toggleIsActiveDiscount = "//*[@id='isActiveDiscount']";
        public const string btnDiscountStepsToggle = "//div[./h6[contains(text(),'Discount')]]//input[@type='checkbox']";
        public const string btnFreeTicketsToggle = "//div[./h6[text()='Free Tickets']]//div[./h6[text()='Status']]//input";
        public const string btnAddFreeTickets = "//div[./h6[text()='Free Tickets']]//*[@class='MuiSvgIcon-root add-discount']";
        public const string inputFreeTickets = "//div[./h6[text()='Free Tickets']]//input[@type='number']";
        public const string btnDiscountStepsRadio = "//div[./h6[contains(text(),'Discount')]]//input[@type='radio']";
        public const string inputDiscountThreshold = "//div[./label[contains(text(),'threshold')]]//input";
        public const string inputDiscountValue = "//div[./label[contains(text(),'£')]]//input";
        public const string btnAddBundles = "//div[./h6[contains(text(),'Tickets Bundles')]]//*[@class='MuiSvgIcon-root add-discount']";
        public const string btnAddThresholds = "//div[./h6[contains(text(),'Discount')]]//*[@class='MuiSvgIcon-root add-discount']";
        public const string inputBundles = "//div[./h6[contains(text(),'Tickets Bundles')]]//input";

        #endregion
    }
}
