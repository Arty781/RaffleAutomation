using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    class WaitUntil
    {
        public static void WaitSomeInterval(int ms = 2000)
        {
            Task.Delay(TimeSpan.FromMilliseconds(ms)).Wait();
        }

        public static void ElementIsClickable(IWebElement element, int seconds = 10)
        {
            new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(seconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static void ElementIsVisible(By element, int seconds = 10)
        {
            new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(seconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        public static void ElementIsVisibleAndClickable(By element, int seconds = 10)
        {
            new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(seconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(seconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        public static void ElementIsInvisible(By element, int seconds = 10)
        {
            new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(seconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(element));
        }

        public static void VisibilityOfAllElementsLocatedBy(By element, int seconds = 10)
        {
            new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(seconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
        }

        public static void CustomElementIsVisible(IWebElement element, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(seconds));
            wait.PollingInterval = TimeSpan.FromMilliseconds(50);
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element.Enabled == true)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception){ return false; }

                });
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }
        }

        public static void CustomElevemtIsInvisible(IWebElement element, int seconds = 10)
        {
            Task.Delay(TimeSpan.FromMilliseconds(150)).Wait();
            WebDriverWait wait = new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(seconds));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element.Enabled == true)
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

    }
}
