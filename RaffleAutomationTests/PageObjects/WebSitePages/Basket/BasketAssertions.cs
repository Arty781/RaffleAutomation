namespace RaffleAutomationTests.PageObjects
{
    public partial class Basket
    {
        public Basket VerifyUrl()
        {
            string expectedUrl = $"{WebEndpoints.WEBSITE_HOST}";
            string currentUrl = Browser._Driver.Url;

            if (!currentUrl.Contains(expectedUrl))
            {
                WebDriverWait wait = new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(10));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

                wait.Until(driver =>
                {
                    try
                    {
                        var url = driver.Url;
                        return url.Contains("localhost");
                    }
                    catch
                    {
                        return false;
                    }
                });

                currentUrl = currentUrl.Replace("http://localhost:8000", expectedUrl);
                Browser._Driver.Navigate().GoToUrl(currentUrl);
            }

            return this;
        }


        public Basket VerifyErrorMessageIsDisplayed()
        {
            VerifyUrl();
            WaitUntil.CustomElementIsVisible(Pages.Common.toaster);
            Console.WriteLine(Pages.Common.toaster.Text);
            WaitUntil.CustomElementIsVisible(checkOutNowBtn);

            return this;
        }


    }
}
