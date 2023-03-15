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

        public CmsUserManagement ClickEditUser(string email)
        {
            Button.Click(Element.FindSpecificUser(email).btnEdit);
            return this;
        }

        public CmsUserManagement OpenSecurityTab()
        {
            Button.Click(tabSecurity);
            WaitUntil.CustomElementIsVisible(inputNewPassword);

            return this;
        }

        public CmsUserManagement SetNewPassword()
        {
            InputBox.Element(inputNewPassword, 10, "Qaz11111");
            InputBox.Element(inputConfirmPassword, 10, "Qaz11111");
            Pages.CmsCommon.ClickSaveChangesBtn();
            WaitUntil.CustomElementIsVisible(Pages.CmsCommon.textAlertMessage);
            Assert.IsTrue("Password changed" == Pages.CmsCommon.textAlertMessage.Text, "Password is not changed");

            return this;
        }
    }
}