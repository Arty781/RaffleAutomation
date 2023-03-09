

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsDreamhome
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
            WaitUntil.WaitSomeInterval(250);
            InputBox.ElementImage(inputDesktopImage, 5, String.Concat(Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_1 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_2 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_3 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_4 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_5 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_6 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_7 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_8));

            InputBox.ElementImage(inputMobileImage, 5, String.Concat(Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_1 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_2 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_3 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_4 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_5 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_6 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_7 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_8));

            return this;
        }

        [AllureStep("Enter Title")]
        public CmsDreamhome EnterTitle()
        {
            InputBox.Element(inputTitle, 5, "Dream New flat " + DateTime.UtcNow.ToString("dd-MMMM-yyyy' 'HH-mm-ss"));

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
            for (int i = 0; i < inputStartDate.Count; i++)
            {
                if (i == 0)
                {
                    InputBox.Element(inputStartDate[i], 5, DateTime.Now.ToString("dd"));
                }
                else if (i == 1)
                {
                    InputBox.Element(inputStartDate[i], 5, DateTime.Now.ToString("MM"));
                }
                else if (i == 2)
                {
                    InputBox.Element(inputStartDate[i], 5, DateTime.Now.ToString("yyyy"));
                }
                else if (i == 3)
                {
                    InputBox.Element(inputStartDate[i], 5, DateTime.Now.ToString("hh"));
                }
                else if (i == 4)
                {
                    InputBox.Element(inputStartDate[i], 5, DateTime.Now.ToString("mm"));
                }
                else if (i == 5)
                {
                    InputBox.Element(inputStartDate[i], 5, DateTime.Now.ToString("ss"));
                }
            }
            InputBox.Element(inputStartAmPm, 5, Keys.ArrowDown);

            return this;
        }

        [AllureStep("Enter Finish date")]
        public CmsDreamhome EnterFinishDate()
        {
            for (int i = 0; i < inputFinishDate.Count; i++)
            {
                if (i == 0)
                {
                    InputBox.Element(inputFinishDate[i], 5, DateTime.Now.ToString("dd"));
                }
                else if (i == 1)
                {
                    InputBox.Element(inputFinishDate[i], 5, DateTime.Now.ToString("MM"));
                }
                else if (i == 2)
                {
                    InputBox.Element(inputFinishDate[i], 5, DateTime.Now.AddYears(1).ToString("yyyy"));
                }
                else if (i == 3)
                {
                    InputBox.Element(inputFinishDate[i], 5, DateTime.Now.ToString("hh"));
                }
                else if (i == 4)
                {
                    InputBox.Element(inputFinishDate[i], 5, DateTime.Now.ToString("mm"));
                }
                else if (i == 5)
                {
                    InputBox.Element(inputFinishDate[i], 5, DateTime.Now.ToString("ss"));
                }
            }
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
            WaitUntil.CustomElementIsVisible(tabDescrDream);
            int elemPos = tabDescrDream.Location.Y;
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            tabDescrDream.Click();
            WaitUntil.WaitSomeInterval(1);

            return this;
        }

        [AllureStep("Upload Dreamhome card image")]
        public CmsDreamhome UploadDreamhomeCardImage()
        {
            WaitUntil.CustomElementIsVisible(imgDesktopSelect);
            dreamhomeCardImg.SendKeys(Browser.RootPath() + UploadedImages.RAFFLE_OUTSPACE);

            return this;
        }

        [AllureStep("Upload Bedroom card image")]
        public CmsDreamhome UploadBedroomCardImage()
        {
            bedroomCardImg.SendKeys(Browser.RootPath() + UploadedImages.RAFFLE_BEDROOM);

            return this;
        }

        [AllureStep("Upload Bathroom card image")]
        public CmsDreamhome UploadBathroomCardImage()
        {
            bathroomCardImg.SendKeys(Browser.RootPath() + UploadedImages.RAFFLE_BATHROOM);

            return this;
        }

        [AllureStep("Upload Outspace card image")]
        public CmsDreamhome UploadOutspaceCardImage()
        {
            outspaceCardImg.SendKeys(Browser.RootPath() + UploadedImages.RAFFLE_OUTSPACE);

            return this;
        }

        [AllureStep("Upload Floor plan card image")]
        public CmsDreamhome UploadFloorPlanCardImage()
        {
            floorPlanCardImg.SendKeys(Browser.RootPath() + UploadedImages.RAFFLE_FLOOR_PLAN);

            return this;
        }

        [AllureStep("Upload Floor plan card image")]
        public CmsDreamhome UploadLocationImage()
        {
            mapCardImg.SendKeys(Browser.RootPath() + UploadedImages.RAFFLE_FLOOR_PLAN);

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
            WaitUntil.WaitSomeInterval(150);
            for (int i = 0; i < 4; i++)
            {

                Button.Click(addOverviewBtn);
                WaitUntil.WaitSomeInterval(450);
                WaitUntil.CustomElementIsVisible(RowOverviewValue.Last());
                WaitUntil.WaitSomeInterval(550);
                InputBox.Element(RowOverviewValue[i], 5, RandomHelper.RandomNumber());
                WaitUntil.WaitSomeInterval(200);
                WaitUntil.CustomElementIsVisible(RowOverviewTitle.Last());
                WaitUntil.WaitSomeInterval(250);
                InputBox.Element(RowOverviewTitle[i], 5, Lorem.Characters(25));


            }
            return this;
        }

        [AllureStep("Enter Overview title")]
        public CmsDreamhome EnterOverviewTitle()
        {
            WaitUntil.WaitSomeInterval(250);
            Console.WriteLine(RowOverviewTitle.Count);
            WaitUntil.CustomElementIsVisible(RowOverviewTitle.Last());
            foreach (var title in RowOverviewTitle)
            {
                WaitUntil.WaitSomeInterval(250);
                title.SendKeys(RandomHelper.RandomNumber());
            }
            return this;
        }

        [AllureStep("Enter Overview Value")]
        public CmsDreamhome EnterOverviewValue()
        {
            WaitUntil.WaitSomeInterval(250);
            Console.WriteLine(RowOverviewValue.Count);
            WaitUntil.CustomElementIsVisible(RowOverviewValue.Last());
            foreach (var value in RowOverviewValue)
            {
                WaitUntil.WaitSomeInterval(250);
                value.SendKeys(RandomHelper.RandomNumber());
            }

            return this;
        }

        #endregion

        #region Discount & Tickets tab

        [AllureStep("Enter Price")]
        public CmsDreamhome EnterPrice()
        {
            InputBox.Element(ticketPriceInput, 5, "2");

            return this;
        }

        [AllureStep("Enter default numbers of tickets")]
        public CmsDreamhome EnterNumOfTickets()
        {
            WaitUntil.CustomElementIsVisible(defaultTicketsInput);
            InputBox.Element(defaultTicketsInput, 5, "10");

            return this;
        }

        public CmsDreamhome SetDiscountThreshold()
        {
            WaitUntil.CustomElementIsVisible(btnDiscountStepsToggle);
            Button.Click(btnDiscountStepsToggle);
            Button.Click(btnDiscountStepsRadio.LastOrDefault());
            Button.Click(btnAddThresholds);
            InputBox.Element(inputDiscountThreshold.FirstOrDefault(), 10, "15");
            InputBox.Element(inputDiscountValue.FirstOrDefault(), 10, "1.666666666666");
            InputBox.Element(inputDiscountThreshold.LastOrDefault(), 10, "16");
            InputBox.Element(inputDiscountValue.LastOrDefault(), 10, "2");
            return this;
        }

        public CmsDreamhome AddTicketsBundles()
        {
            WaitUntil.CustomElementIsVisible(btnAddBundles);
            Button.Click(btnAddBundles);
            Button.Click(btnAddBundles);
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    InputBox.Element(inputBundles[i], 10, "5");
                }
                else if (i == 1)
                {
                    InputBox.Element(inputBundles[i], 10, "15");
                }
                else if (i == 2)
                {
                    InputBox.Element(inputBundles[i], 10, "20");
                }
                else if (i == 3)
                {
                    InputBox.Element(inputBundles[i], 10, "50");
                }

            }

            return this;
        }

        #endregion

        public CmsDreamhome EditDreamHome(string dreamhomeTitle)
        {
            WebDriverWait wait = new(Browser._Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50)
            };
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (Browser._Driver.FindElement(By.XPath($"//td[text()='{dreamhomeTitle}']/ancestor::tbody//td//a[@aria-label='Edit']"))
                        != null && Browser._Driver.FindElement(By.XPath($"//td[text()='{dreamhomeTitle}']/ancestor::tbody//td//a[@aria-label='Edit']")).Enabled)
                        {
                            var btnEditDreamhome = Browser._Driver.FindElement(By.XPath($"//td[text()='{dreamhomeTitle}']/ancestor::tbody//td//a[@aria-label='Edit']"));
                            btnEditDreamhome.Click();
                            return true;
                        }
                        return false;
                    }
                    catch (Exception) { return false; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }


            return this;
        }

    }
}