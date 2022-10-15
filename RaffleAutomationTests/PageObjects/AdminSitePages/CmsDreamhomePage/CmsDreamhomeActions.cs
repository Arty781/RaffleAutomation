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
           
            Button.Click(btnAddDreamHome);

            return this;
        }

        #region General tab
        [AllureStep("Upload Dreamhome slider images")]
        public CmsDreamhome UploadImages()
        {
            inputDesktopImage.SendKeys(Browser.RootPath() + UploadedImages.RaffleOutspace);
            inputMobileImage.SendKeys(Browser.RootPath() + UploadedImages.RaffleOutspace);

            return this;
        }

        [AllureStep("Enter Title")]
        public CmsDreamhome EnterTitle()
        {
            InputBox.Element(inputTitle, 5, "Dream London flat " + DateTime.UtcNow.ToString("dd-MMMM-yyyy' 'HH-mm-ss"));

            return this;
        }

        [AllureStep("Enter Address")]
        public CmsDreamhome EnterAddress()
        {
            InputBox.Element(inputAddress, 5, "42 Broadway London E35 0VE 767 Manor Road");

            return this;
        }

        [AllureStep("Enter Start date")]
        public CmsDreamhome EnterStartDate()
        {
           
            InputBox.Element(inputStartDay, 5, "1");
            InputBox.Element(inputStartMonth, 5, "1");
            InputBox.Element(inputStartYear, 5, "2022");
            InputBox.Element(inputStartHour, 5, "00");
            InputBox.Element(inputStartMinute, 5, "0");
            InputBox.Element(inputStartSecond, 5, "0");
            InputBox.Element(inputStartAmPm, 5, Keys.ArrowDown);

            return this;
        }

        [AllureStep("Enter Finish date")]
        public CmsDreamhome EnterFinishDate()
        {
            InputBox.Element(inputFinishDay, 5, "1");
            InputBox.Element(inputFinishMonth, 5, "1");
            InputBox.Element(inputFinishYear, 5, "2022");
            InputBox.Element(inputFinishHour, 5, "00");
            InputBox.Element(inputFinishMinute, 5, "0");
            InputBox.Element(inputFinishSecond, 5, "0");
            InputBox.Element(inputFinishAmPm, 5, Keys.ArrowDown + Keys.ArrowDown);

            return this;
        }

        [AllureStep("Enter Meta tags")]
        public CmsDreamhome EnterMetaTags()
        {
            InputBox.Element(inputMetaTitle, 5, "Dream home");
            InputBox.Element(inputMetaDescr, 5, "Dream home description");

            return this;
        }

        #endregion

        #region Description tab

        [AllureStep("Open \"Description\" tab")]
        public CmsDreamhome OpenDescriptionTab()
        {
            WaitUntil.CustomElevemtIsVisible(tabDescrDream);
            int elemPos = tabDescrDream.Location.Y;
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            tabDescrDream.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Upload Dreamhome card image")]
        public CmsDreamhome UploadDreamhomeCardImage()
        {
            WaitUntil.CustomElevemtIsVisible(imgDesktopSelect);
            dreamhomeCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleOutspace);

            return this;
        }

        [AllureStep("Upload Bedroom card image")]
        public CmsDreamhome UploadBedroomCardImage()
        {
            bedroomCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleBedroom);

            return this;
        }

        [AllureStep("Upload Bathroom card image")]
        public CmsDreamhome UploadBathroomCardImage()
        {
            bathroomCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleBathroom);

            return this;
        }

        [AllureStep("Upload Outspace card image")]
        public CmsDreamhome UploadOutspaceCardImage()
        {
            outspaceCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleOutspace);

            return this;
        }

        [AllureStep("Upload Floor plan card image")]
        public CmsDreamhome UploadFloorPlanCardImage()
        {
            floorPlanCardImg.SendKeys(Browser.RootPath() + UploadedImages.RaffleFloorPlan);

            return this;
        }

        [AllureStep("Enter Bedroom text")]
        public CmsDreamhome EnterBedroomText(string bedroomText)
        {
            InputBox.Element(bedroomsTextArea, 5, bedroomText);

            return this;
        }

        [AllureStep("Enter Bathroom text")]
        public CmsDreamhome EnterBathroomText(string bathroomText)
        {
            InputBox.Element(bathroomsTextArea, 5, bathroomText);

            return this;
        }

        [AllureStep("Enter OutSpace text")]
        public CmsDreamhome EnterOutSpaceText(string outspaceText)
        {
            InputBox.Element(outspaceTextArea, 5, outspaceText);

            return this;
        }

        [AllureStep("Enter About text")]
        public CmsDreamhome EnterAboutText(string aboutText)
        {
            InputBox.Element(aboutTextArea, 5, aboutText);

            return this;
        }

        [AllureStep("Enter Product CTA text")]
        public CmsDreamhome EnterProductCTAText(string ctaText)
        {
            InputBox.Element(productCTATextArea, 5, ctaText);

            return this;
        }

        [AllureStep("Enter Heading text")]
        public CmsDreamhome EnterHeadingText(string headingText)
        {
            InputBox.Element(headingTextArea, 5, headingText);

            return this;
        }

        [AllureStep("Enter TakeTourWithSara link")]
        public CmsDreamhome EnterTakeTourWithSara(string TakeTourWithSaraLink)
        {
            InputBox.Element(headingTextArea, 5, TakeTourWithSaraLink);

            return this;
        }

        [AllureStep("Add Overview rows")]
        public CmsDreamhome ClickAddOverviewRowsBtn()
        {
            WaitUntil.WaitSomeInterval(1);
            for (int i = 0; i < 4; i++)
            {
                
                Button.Click(addOverviewBtn);

            }
            return this;
        }

        [AllureStep("Enter Overview title")]
        public CmsDreamhome EnterOverviewTitle()
        {
            WaitUntil.WaitSomeInterval(1500);
            foreach (var title in RowOverviewTitle)
            {
                InputBox.Element(title,5,RandomHelper.RandomNumber());
            }
            return this;
        }

        [AllureStep("Enter Overview Value")]
        public CmsDreamhome EnterOverviewValue()
        {
            WaitUntil.WaitSomeInterval(1500);

            foreach (var value in RowOverviewValue)
            {
                Button.Click(value);
                InputBox.Element(value, 5, RandomHelper.RandomNumber());
            }

            return this;
        }

        #endregion

        #region Discount & Tickets tab

        [AllureStep("Enter Price")]
        public CmsDreamhome EnterPrice()
        {
            WaitUntil.ElementIsVisibleAndClickable(_ticketPriceInput);
            ticketPriceInput.SendKeys("0.99");

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