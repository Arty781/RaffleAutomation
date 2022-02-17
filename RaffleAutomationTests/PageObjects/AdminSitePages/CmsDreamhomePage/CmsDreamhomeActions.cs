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
    partial class CmsDreamhome
    {
        [AllureStep("Click \"Add new dreamhome\" button")]
        public CmsDreamhome ClickAddDreamhomeBtn()
        {
            WaitUntil.ElementIsVisible(_addDreamHomeBtn);
            addDreamHomeBtn.Click();
            WaitUntil.WaitSomeInterval(2);

            return this;
        }

        #region General tab
        [AllureStep("Upload Dreamhome slider images")]
        public CmsDreamhome UploadImages()
        {
            
            desktopImageInput.SendKeys(Browser.RootPath() + UploadedImages.RaffleOutspace);
            mobileImageInput.SendKeys(Browser.RootPath() + UploadedImages.RaffleOutspace);

            return this;
        }

        [AllureStep("Enter Title")]
        public CmsDreamhome EnterTitle()
        {
            WaitUntil.ElementIsVisible(_titleInput);
            titleInput.SendKeys("Dream London flat " + DateTime.UtcNow.ToString("dd-MMMM-yyyy' 'HH-mm-ss"));

            return this;
        }

        [AllureStep("Enter Address")]
        public CmsDreamhome EnterAddress()
        {
            WaitUntil.ElementIsVisible(_addressInput);
            addressInput.SendKeys("42 Broadway London E35 0VE 767 Manor Road");
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Enter Start date")]
        public CmsDreamhome EnterStartDate()
        {
            WaitUntil.ElementIsVisible(_enterDayStart);
            enterDayStart.Clear();
            enterDayStart.SendKeys("10");
            enterMonthStart.Clear();
            enterMonthStart.SendKeys("1");
            enterYearStart.Clear();
            enterYearStart.SendKeys("2022");
            enterHourStart.Clear();
            enterHourStart.SendKeys("00");
            enterMinuteStart.Clear();
            enterMinuteStart.SendKeys("0");
            enterSecondStart.Clear();
            enterSecondStart.SendKeys("0");
            selectAmPmStart.SendKeys(Keys.ArrowDown);
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Enter Finish date")]
        public CmsDreamhome EnterFinishDate()
        {
            WaitUntil.ElementIsVisible(_enterDayFinish);
            enterDayFinish.Clear();
            enterDayFinish.SendKeys("10");
            enterMonthFinish.Clear();
            enterMonthFinish.SendKeys("1");
            enterYearFinish.Clear();
            enterYearFinish.SendKeys("2023");
            enterHourFinish.Clear();
            enterHourFinish.SendKeys("11");
            enterMinuteFinish.Clear();
            enterMinuteFinish.SendKeys("59");
            enterSecondFinish.Clear();
            enterSecondFinish.SendKeys("59");
            selectAmPmFinish.SendKeys(Keys.ArrowDown);
            selectAmPmFinish.SendKeys(Keys.ArrowDown);
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Enter Meta tags")]
        public CmsDreamhome EnterMetaTags()
        {
            WaitUntil.ElementIsVisible(_metaTitle);
            metaTitle.Clear();
            metaTitle.SendKeys("Dream home");
            metaDescription.Clear();
            metaDescription.SendKeys("Dream home description");
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        #endregion

        #region Description tab

        [AllureStep("Upload Dreamhome card image")]
        public CmsDreamhome UploadDreamhomeCardImage()
        {
            WaitUntil.WaitSomeInterval(1);
            dreamhomeCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleOutspace);

            return this;
        }

        [AllureStep("Upload Bedroom card image")]
        public CmsDreamhome UploadBedroomCardImage()
        {
            WaitUntil.WaitSomeInterval(1);
            bedroomCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleBedroom);

            return this;
        }

        [AllureStep("Upload Bathroom card image")]
        public CmsDreamhome UploadBathroomCardImage()
        {
            WaitUntil.WaitSomeInterval(1);
            bathroomCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleBathroom);

            return this;
        }

        [AllureStep("Upload Outspace card image")]
        public CmsDreamhome UploadOutspaceCardImage()
        {
            WaitUntil.WaitSomeInterval(1);
            outspaceCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleOutspace);

            return this;
        }

        [AllureStep("Upload Floor plan card image")]
        public CmsDreamhome UploadFloorPlanCardImage()
        {
            WaitUntil.WaitSomeInterval(1);
            floorPlanCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleFloorPlan);

            return this;
        }

        [AllureStep("Enter Bedroom text")]
        public CmsDreamhome EnterBedroomText(string bedroomText)
        {
            WaitUntil.WaitSomeInterval(1);
            bedroomsTextArea.SendKeys(bedroomText);

            return this;
        }

        [AllureStep("Enter Bathroom text")]
        public CmsDreamhome EnterBathroomText(string bathroomText)
        {
            WaitUntil.WaitSomeInterval(1);
            bathroomsTextArea.SendKeys(bathroomText);

            return this;
        }

        [AllureStep("Enter OutSpace text")]
        public CmsDreamhome EnterOutSpaceText(string outspaceText)
        {
            WaitUntil.WaitSomeInterval(1);
            outspaceTextArea.SendKeys(outspaceText);

            return this;
        }

        [AllureStep("Enter About text")]
        public CmsDreamhome EnterAboutText(string aboutText)
        {
            WaitUntil.WaitSomeInterval(1);
            aboutTextArea.SendKeys(aboutText);

            return this;
        }

        [AllureStep("Enter Product CTA text")]
        public CmsDreamhome EnterProductCTAText(string ctaText)
        {
            WaitUntil.WaitSomeInterval(1);
            productCTATextArea.SendKeys(ctaText);

            return this;
        }

        [AllureStep("Enter Heading text")]
        public CmsDreamhome EnterHeadingText(string headingText)
        {
            WaitUntil.WaitSomeInterval(1);
            headingTextArea.SendKeys(headingText);

            return this;
        }

        [AllureStep("Enter TakeTourWithSara link")]
        public CmsDreamhome EnterTakeTourWithSara(string TakeTourWithSaraLink)
        {
            WaitUntil.WaitSomeInterval(1);
            headingTextArea.SendKeys(TakeTourWithSaraLink);

            return this;
        }

        [AllureStep("Add Overview rows")]
        public CmsDreamhome ClickAddOverviewRowsBtn()
        {
            WaitUntil.WaitSomeInterval(1);
            for (int i = 0; i < 4; i++)
            {
                
                addOverviewBtn.Click();

            }
            return this;
        }

        [AllureStep("Enter Overview title")]
        public CmsDreamhome EnterOverviewTitle()
        {
            WaitUntil.WaitSomeInterval(3);
            IReadOnlyCollection<IWebElement> titlesList = Browser._Driver.FindElements(_RowOverviewTitle);

            foreach (var title in titlesList)
            {
                /*WaitUntil.WaitSomeInterval(1);*/
                title.Clear();
                title.SendKeys(RandomHelper.RandomNumber());
            }
            return this;
        }

        [AllureStep("Enter Overview Value")]
        public CmsDreamhome EnterOverviewValue()
        {
            
            
            IReadOnlyCollection<IWebElement> valuesList = Browser._Driver.FindElements(_RowOverviewValue);
            int i = 0;
            foreach (var value in valuesList)
            {
                ++i;
                if(i == 4)
                {
                    break;
                }
                value.Click();
                value.SendKeys(RandomHelper.RandomNumber());
                
                
            }

            IReadOnlyCollection<IWebElement> valuesSecondList = Browser._Driver.FindElements(_RowOverviewValue);

            foreach (var valueSecond in valuesSecondList)
            {

                string value = valueSecond.GetAttribute("value");
                if (value == "")
                {
                    valueSecond.Click();
                    valueSecond.SendKeys(RandomHelper.RandomNumber());
                }      

                
            }

            return this;
        }

        #endregion

        #region Discount & Tickets tab

        [AllureStep("Enter Price")]
        public CmsDreamhome EnterPrice()
        {
            WaitUntil.ElementIsVisibleAndClickable(_ticketPriceInput);
            ticketPriceInput.SendKeys("0.5");

            return this;
        }

        [AllureStep("Enter default numbers of tickets")]
        public CmsDreamhome EnterNumOfTickets()
        {
            WaitUntil.WaitSomeInterval(1);
            defaultTicketsInput.SendKeys("10");

            return this;
        }

        #endregion

    }
}