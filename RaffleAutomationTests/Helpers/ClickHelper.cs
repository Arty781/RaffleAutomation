
using OpenQA.Selenium;
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
            try
            {
                WaitUntil.WaitSomeInterval(500);
                WaitUntil.CustomElevemtIsVisible(element, 30);

                element.Click();
            }
            catch (Exception) { }

        }

    }
    public class InputBox
    {
        public static IWebElement Element(IWebElement element, int seconds, string data)
        {

            try
            {
                WaitUntil.CustomElevemtIsVisible(element, seconds);
                element.SendKeys(Keys.Control + "A" + Keys.Delete);
                WaitUntil.WaitSomeInterval(500);
                element.SendKeys(data);
            }
            catch (Exception) { }

            return element;
        }
        public static IWebElement CbbxElement(IWebElement element, int seconds, string data)
        {

            try
            {
                WaitUntil.CustomElevemtIsVisible(element, seconds);
                element.SendKeys(data + Keys.Enter);
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }
            return element;
        }


    }
    public class TextBox
    {
        public static string GetText(IWebElement element)
        {
            WaitUntil.CustomElevemtIsVisible(element);
            return element.Text;
        }

        public static string GetAttribute(IWebElement element, string attribute)
        {
            WaitUntil.CustomElevemtIsVisible(element);
            return element.GetAttribute(attribute);

        }
    }

    public class Element
    {
        public static IWebElement webElem(string xpathString)
        {
            WaitUntil.WaitSomeInterval(250);
            var elem = Browser._Driver.FindElement(By.XPath(xpathString));
            return elem;
        }

        public static List<IWebElement> webElemList(string xpathString)
        {
            WaitUntil.WaitSomeInterval(250);
            var elem = Browser._Driver.FindElements(By.XPath(xpathString)).ToList();
            return elem;
        }
    }
}
