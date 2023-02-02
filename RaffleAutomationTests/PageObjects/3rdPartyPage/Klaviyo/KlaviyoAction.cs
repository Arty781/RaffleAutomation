using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects._3rdPartyPage.Klaviyo
{
    public partial class Klaviyo
    {
        public Klaviyo Login() 
        {
            Browser.Navigate("https://www.klaviyo.com/login");
            WaitUntil.CustomElementIsVisible(inputEmail);
            InputBox.Element(inputEmail, 10, "benno@raffle-house.com");
            InputBox.Element(inputPassword, 10, "2312Hanford2312!");
            WaitUntil.WaitSomeInterval(5000);
            Button.Click(btnSubmit);
            return this;
        }

        public Klaviyo DeleteUsers()
        {
            WaitUntil.CustomElementIsVisible(titleHome);
            Browser.Navigate("https://www.klaviyo.com/people");
            return this;
        }
    }
}
