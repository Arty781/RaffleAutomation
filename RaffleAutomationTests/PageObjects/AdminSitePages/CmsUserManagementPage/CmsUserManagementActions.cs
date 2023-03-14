namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsUserManagement
    {
        public CmsUserManagement OpenUserManagement()
        {
            Browser.Navigate(AdminEndpoints.USER_MANAGEMENT);
            return this;
        } 

        public CmsUserManagement ClickAddNewBtn()
        {
            Button.Click(btnAddUser);
            return this;
        }

        public CmsUserManagement EnterUserData(string email)
        {
            WaitUntil.CustomElementIsVisible(inputFirstName);
            InputBox.Element(inputFirstName, 10, Name.FirstName());
            InputBox.Element(inputLastName, 10, Name.LastName());
            InputBox.Element(inputEmail, 10, email);
            InputBox.Element(inputPhone, 10, RandomHelper.RandomPhone());
            return this;
        }

        [AllureStep("Go to activation link")]
        public string GetPassword(string email)
        {
            var activateLink = PutsBox.GetTextFromEmailWithValue(email, "Your temporary password is: ", 1);

            return activateLink;
        }
    }
}