
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RaffleAutomationTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    public class ClickHelper
    {
        public static IWebElement Clicker(IWebElement element)
        {
            IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser._Driver;
            ex.ExecuteScript("arguments[0].click();", element);
            return element;
        }
        
    }

    public class Button
    {
        public static void Click(IWebElement element)
        {
            WaitUntil.WaitSomeInterval(150);
            WaitUntil.CustomElementIsVisible(element, 10);
            element.Click();

        }

    }
    public class InputBox
    {
        public static IWebElement Element(IWebElement element, int seconds, string data)
        {
            WaitUntil.CustomElementIsVisible(element, seconds);
            element.SendKeys(Keys.Control + "A" + Keys.Delete);
            WaitUntil.WaitSomeInterval(150);
            element.SendKeys(data);

            return element;
        }
        public static IWebElement CbbxElement(IWebElement element, int seconds, string data)
        {

            WaitUntil.CustomElementIsVisible(element, seconds);
            element.SendKeys(data + Keys.Enter);

            return element;
        }


    }

    public class TextBox
    {
        public static string GetText(IWebElement element)
        {
            WaitUntil.CustomElementIsVisible(element);
            return element.Text;
        }

        public static string GetAttribute(IWebElement element, string attribute)
        {
            WaitUntil.CustomElementIsVisible(element);
            return element.GetAttribute(attribute);

        }
    }

    public class Element
    {
        public static IWebElement FindSpecificDreamhome(string titleDreamhome)
        {
            WebDriverWait wait = new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            try
            {
                wait.Until(e =>
                {
                    try { return Browser._Driver.FindElement(By.XPath($"//tbody/tr/td[text()='{titleDreamhome}']")).Enabled; }
                    catch (NoSuchElementException) { return false; }
                    catch (StaleElementReferenceException) { return false; }

                });
            }
            catch (NoSuchElementException) {  }
            catch (StaleElementReferenceException) {  }

            var _element = Browser._Driver.FindElement(By.XPath($"//tbody/tr/td[text()='{titleDreamhome}']"));


            return _element;
        }
    }
}
