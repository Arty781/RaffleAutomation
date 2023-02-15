namespace RaffleAutomationTests.Helpers
{
    public class Elements
    {
        public static void Click(IWebElement element)
        {
            WaitUntil.CustomElementIsVisible(element);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser._Driver;
            ex.ExecuteScript("arguments[0].click();", element);

        }

        public static void EnterText(IWebElement element, string text)
        {
            WaitUntil.CustomElementIsVisible(element);
            element.SendKeys(Keys.Control + "A" + Keys.Delete);
            element.SendKeys(text);
        }

        public static string GetAttribute(IWebElement element, string attribute)
        {
            WaitUntil.CustomElementIsVisible(element);
            return element.GetAttribute(attribute);
        }

        public static void ScrollTo(int xPosition, int yPosition)
        {
            try
            {
                IJavaScriptExecutor jsi = (IJavaScriptExecutor)Browser._Driver;
                jsi.ExecuteScript("window.scrollTo({0}, {1})", xPosition, yPosition);
            }
            catch (Exception) { }
        }
    }
}
