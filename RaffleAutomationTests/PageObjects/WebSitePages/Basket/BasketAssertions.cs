namespace RaffleAutomationTests.PageObjects
{
    public partial class Basket
    {
        public Basket VerifyUrl()
        {
            WaitUntil.CustomCheckoutIsDisplayed();
            string expectedUrl = WebEndpoints.WEBSITE_HOST;
            string currentUrl = Browser.Driver.Url;

            if (!currentUrl.Contains(expectedUrl))
            {
                WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(10));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

                wait.Until(driver =>
                {
                    try
                    {
                        if (driver.Url.Contains("localhost"))
                        {
                            currentUrl = driver.Url;
                            return true;
                        }
                        return false;
                    }
                    catch
                    {
                        return false;
                    }
                });

                currentUrl = currentUrl.Replace("http://localhost:8000", expectedUrl);

                Browser.Driver.Navigate().GoToUrl(currentUrl);
            }

            return this;
        }


        public Basket VerifyErrorMessageIsDisplayed()
        {
            VerifyUrl();
            WaitUntil.CustomElementIsVisible(Pages.Common.toaster);
            WaitUntil.CustomElementIsVisible(checkOutNowBtn);

            return this;
        }

        public Basket VerifyErrorMessageOnPaymentPage(string message)
        {
            WaitUntil.CustomElementIsVisible(textErrorMessage);
            Assert.AreEqual(message.ToLower(), textErrorMessage.Text.ToLower());
            return this;
        }

        public Basket IsErrorDisplayed(string cvv)
        {
            try
            {
                Assert.NotNull(textErrorMessage);
            }
            catch(NoSuchElementException)
            {
                Console.WriteLine(cvv);
            }
            return this;
        }
    }
}
