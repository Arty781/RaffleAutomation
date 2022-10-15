using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class AboutUs
    {
        public AboutUs OpenAboutPage(string url)
        {
            Browser._Driver.Navigate().GoToUrl(url);
            WaitUntil.CustomElementIsVisible(titleAboutPage);


            return this;
        }
    }
}
