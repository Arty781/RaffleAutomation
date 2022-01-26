using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using RaffleAutomationTests.PageObjects;
using AdminSiteTests.BASE;
using NUnit.Allure.Core;

namespace RaffleHouseAutomation.AdminSiteTests
{
    [TestFixture]
    [AllureNUnit]
    public class AdminSiteTests : TestBaseAdmin
    {

       [Test]
        public void LoginInCms()
        {
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.loginAdmin, Credentials.passwordAdmin)
                .ClickSignInBtn();
            Pages.CmsCommon
                 .VerifyIsLoginSuccessfull();
        }

    }
}