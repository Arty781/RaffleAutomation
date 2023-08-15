namespace RaffleAutomationTests.Helpers
{
    public class WaitUntil
    {
        public static void WaitSomeInterval(int ms = 2000)
        {
            System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(ms)).Wait();
        }

        public static void CustomElementIsVisible(IWebElement element, int seconds = 10)
        {
            WaitUntil.WaitSomeInterval(500);
            WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(seconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(10);
            wait.Message = $"Element is not visible after {seconds} sec";
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element != null && element.Displayed == true)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch { return false; }

                });
            }
            catch (NoSuchElementException) { throw new NoSuchElementException(); }
            catch (StaleElementReferenceException) { throw new StaleElementReferenceException(); }
        }

        public static void CustomElevemtIsInvisible(IWebElement element, int seconds = 10)
        {
            System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(150)).Wait();
            WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(seconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(10);
            wait.Message = $"Element is visible after {seconds} sec";
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element != null && element.Enabled)
                        {
                            return false;
                        }
                        return true;
                    }
                    catch { return true; }

                });
            }
            catch (NoSuchElementException) { throw new NoSuchElementException(); }
            catch (StaleElementReferenceException) { throw new StaleElementReferenceException(); }

        }

        public static void CustomCheckoutIsDisplayed(int sec = 10)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(sec));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(10);

            wait.Until(driver =>
            {
                try
                {
                    if (driver.Url.Contains("pending?cko-session-id"))
                    {
                        return true;
                    }
                    return false;
                }
                catch { return false; }
            });
        }

    }
}
