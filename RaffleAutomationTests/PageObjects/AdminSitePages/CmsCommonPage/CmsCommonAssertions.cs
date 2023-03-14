

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsCommon
    {
        [AllureStep("Verify is login successfully")]
        public CmsCommon VerifyIsLoginSuccessfull()
        {
            WaitUntil.CustomElementIsVisible(pagePrizeManagement);
            Assert.IsTrue(pagePrizeManagement.Displayed);
            return this;
        }

        [AllureStep("Verify that dreamhome {0} created successfully")]
        public CmsCommon VerifyIsDreamhomeCreatedSuccessfully(string dreamhomeTitle)
        {
            WaitUntil.CustomElementIsVisible(Pages.CmsDreamhome.titleAddedDreamhome, 25);
            Element.Action(Keys.End);
            Button.Click(btnLastPage);
            WaitUntil.CustomElementIsVisible(Element.FindSpecificDreamhome(dreamhomeTitle));
            Assert.IsTrue(dreamhomeTitle == Element.FindSpecificDreamhome(dreamhomeTitle).Text);
            return this;
        }
    }
}
