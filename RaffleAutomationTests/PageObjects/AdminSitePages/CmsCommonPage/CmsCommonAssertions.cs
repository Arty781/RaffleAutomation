using NUnit.Allure.Steps;
using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsCommon
    {
        [AllureStep("Verify is login successfull")]
        public CmsCommon VerifyIsLoginSuccessfull()
        {
            WaitUntil.VisibilityOfAllElementsLocatedBy(_prizeManagementBtn);
            Assert.IsTrue(prizeManagementBtn.Displayed);
            return this;
        }
    }
}
