using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    public class AssertHelper
    {
            public static Boolean ElementIsInvisible(IWebElement element)
            {
                WaitUntil.WaitSomeInterval(250);
                try
                {
                    if (element.Enabled == true)
                    {
                        Console.WriteLine(element.Text);

                        return false;
                    }

                    return true;


                }
                catch (NoSuchElementException) { return true; }

                catch (StaleElementReferenceException) { return true; }
            }

        public static Boolean ElementIsVisible(IWebElement element)
        {
            WaitUntil.WaitSomeInterval(250);
            try
            {
                if (element.Enabled == true)
                {
                    Console.WriteLine(element.Text);

                    return true;
                }

                return false;


            }
            catch (NoSuchElementException) { return false; }

            catch (StaleElementReferenceException) { return false; }
        }
    }

    
}
