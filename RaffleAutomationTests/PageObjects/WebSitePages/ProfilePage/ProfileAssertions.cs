using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Profile
    {
        public Profile VerifyDisplayingToaster()
        {
            WaitUntil.CustomElementIsVisible(SuccessUpdateDialog);
            Assert.IsTrue(SuccessUpdateDialog.Displayed);

            return this;
        }
    }
}
