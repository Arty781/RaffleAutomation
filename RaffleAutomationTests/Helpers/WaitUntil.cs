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
            WebDriverWait wait = new(Browser._Driver, TimeSpan.FromSeconds(seconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50)
            };
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element != null && element.Enabled)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception) { return false; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }
        }

        public static void CustomElevemtIsInvisible(IWebElement element, int seconds = 10)
        {
            System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(150)).Wait();
            WebDriverWait wait = new(Browser._Driver, TimeSpan.FromSeconds(seconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
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
                    catch (Exception) { return true; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }

        }

        public static void CustomCheckoutIsDisplayed(int sec = 10)
        {
            System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(150)).Wait();
            WebDriverWait wait = new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(sec));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

            wait.Until(driver =>
            {
                try
                {
                    if (driver.Url.Contains("/pending/?cko-session-id="))
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            });
        }

    }
}
