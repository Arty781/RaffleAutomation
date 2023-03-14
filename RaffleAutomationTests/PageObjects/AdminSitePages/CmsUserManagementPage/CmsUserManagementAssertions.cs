namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsUserManagement
    {
        public void SearchIsUserDisplayed(string email)
        {
            WaitUntil.CustomElementIsVisible(textTitleUserManagement, 25);
            Element.Action(Keys.End);
            Button.Click(Pages.CmsCommon.btnLastPage);
            WaitUntil.CustomElementIsVisible(Element.FindSpecificUser(email));
            Assert.IsTrue(email == Element.FindSpecificUser(email).Text);
        }
    }
}