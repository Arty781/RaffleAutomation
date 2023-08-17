using Allure.Commons;
using NUnit.Allure.Attributes;
using RaffleAutomationTests.APIHelpers.Admin.UsersPage;
using RaffleAutomationTests.APIHelpers.Web.Basket;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RaffleHouseAutomation.AdminSiteTests
{
    [TestFixture]
    [AllureNUnit]
    public class DemoTest : TestBaseAdmin
    {
        [Test]
        [Ignore("")]
        public void Demo()
        {
            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var userResponse = UsersRequest.CreateUserOnCms(token);
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsUserManagement
                .OpenUserManagement();
            Pages.CmsUserManagement
                .SearchUser(userResponse.Email);
            Pages.CmsUserManagement
                .ClickEditUser(userResponse.Email)
                .EnterUserData(userResponse.Email);
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsUserManagement
                .SearchUser(userResponse.Email);
            Pages.CmsUserManagement
                .ClickEditUser(userResponse.Email)
                .OpenSecurityTab()
                .SetNewPassword();
        }
    }





    [TestFixture]
    [AllureNUnit]
    public class AdminDreamHomeTests : TestBaseAdmin
    {

        [Test]
        public void CreateNewDreamhomeWithFreeTicketsInGeneralSettings()
        {
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .OpenDreamhomePage()
                .ClickAddDreamhomeBtn()
                .EnterTitle();
            string dreamhomeTitle = Pages.CmsDreamhome.GetDreamhomeTitle();
            Pages.CmsDreamhome
                .EnterAddress()
                .EnterStartDate()
                .EnterFinishDate()
                .EnterMetaTags()
                .UploadImages();
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsDreamhome
                .UploadDreamhomeCardImage()
                .UploadFloorPlanCardImage()
                .UploadLocationImage()
                .EnterAboutText(DreamHomeTexts.ABOUT)
                .EnterProductCTAText(DreamHomeTexts.PRODUCT_CTA_BTN)
                .EnterHeadingText(DreamHomeTexts.HEADING);
            Pages.CmsCommon
                .OpenDiscountTab();
            Pages.CmsDreamhome
                .EnterPrice()
                .EnterNumOfTickets()
                .SetDiscountThreshold()
                .AddTicketsBundles();
            Pages.CmsCommon
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);
        }

        [Test]
        public void CreateNewDreamhomeWithFreeTicketsWithin()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out _);
            DreamHomeRequest.DeactivateDreamHome(tokenAdmin, dreamResponse);

            #endregion

            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .OpenDreamhomePage()
                .ClickAddDreamhomeBtn()
                .EnterTitle();
            string dreamhomeTitle = Pages.CmsDreamhome.GetDreamhomeTitle();
            Pages.CmsDreamhome
                .EnterAddress()
                .AcivateDreamHome()
                .EnterStartDate()
                .EnterFinishDate()
                .EnterMetaTags()
                .UploadImages();
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsDreamhome
                .UploadDreamhomeCardImage()
                .UploadFloorPlanCardImage()
                .UploadLocationImage()
                .EnterAboutText(DreamHomeTexts.ABOUT)
                .EnterProductCTAText(DreamHomeTexts.PRODUCT_CTA_BTN)
                .EnterHeadingText(DreamHomeTexts.HEADING);
            Pages.CmsCommon
                .OpenDiscountTab();
            Pages.CmsDreamhome
                .EnterPrice()
                .EnterNumOfTickets()
                .SetDiscountThreshold()
                .SetFreeTickets()
                .AddTicketsBundles();
            Pages.CmsCommon
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);
        }

        [Test]
        public void EditNewDreamhome()
        {
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsDreamhome
                .OpenDreamhomePage()
                .ClickAddDreamhomeBtn()
                .EnterTitle();
            string dreamhomeTitle = Pages.CmsDreamhome.GetDreamhomeTitle();
            Pages.CmsDreamhome
                .EnterAddress()
                .EnterStartDate()
                .EnterFinishDate()
                .EnterMetaTags()
                .UploadImages();
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsDreamhome
                .UploadDreamhomeCardImage()
                .UploadFloorPlanCardImage()
                .UploadLocationImage()
                .EnterAboutText(DreamHomeTexts.ABOUT)
                .EnterProductCTAText(DreamHomeTexts.PRODUCT_CTA_BTN)
                .EnterHeadingText(DreamHomeTexts.HEADING);
            Pages.CmsCommon
                .OpenDiscountTab();
            Pages.CmsDreamhome
                .EnterPrice()
                .EnterNumOfTickets()
                .SetDiscountThreshold()
                .AddTicketsBundles();
            Pages.CmsCommon
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);
            Pages.CmsDreamhome
                .EditDreamHome(dreamhomeTitle)
                .UploadImages();
            Pages.CmsCommon
                .ClickSaveBtn()
                .ClickSaveBtn()
                .ClickSaveBtn()
                .VerifyIsDreamhomeCreatedSuccessfully(dreamhomeTitle);
        }

    }

    [TestFixture]
    [AllureNUnit]
    public class AdminLifestyleTests : TestBaseAdmin
    {
        [Test]
        [Ignore("Not actual")]
        public void ActivateLF()
        {
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsLifestylePrizes
                .OpenLifestylePizesPage()
                .SetRowsPerPageAs100()
                .ActivatePrizesOnPage()
                .ClickNextBtn()
                .ActivatePrizesOnPage()
                .ClickNextBtn()
                .ActivatePrizesOnPage();

        }
    }


    [TestFixture]
    [AllureNUnit]
    public class AdminUserManagementTests : TestBaseAdmin
    {
        [Test]
        [Category("CMS Usermanagement")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("CMS")]
        [AllureSubSuite("Usermanagement")]
        public void CreateUserOnCms()
        {
            var email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"), "@putsbox.com");
            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsUserManagement
                .OpenUserManagement()
                .ClickAddNewBtn()
                .EnterUserData(email);
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsUserManagement
                .SearchUser(email);
            Assert.NotNull(PutsBox.GetTextFromEmailWithValue(email, "Your temporary password is: "));

            #region PostConditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("CMS Usermanagement")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("CMS")]
        [AllureSubSuite("Usermanagement")]
        public void EditUserOnCms()
        {
            #region Preconditions
            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var userResponse = UsersRequest.CreateUserOnCms(token);
            #endregion

            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsUserManagement
                .OpenUserManagement();
            Pages.CmsUserManagement
                .SearchUser(userResponse.Email);
            Pages.CmsUserManagement
                .ClickEditUser(userResponse.Email)
                .EnterUserData(userResponse.Email);
            var userData = Pages.CmsUserManagement.GetUserData();
            Pages.CmsCommon
                .ClickSaveBtn();
            Pages.CmsUserManagement
                .SearchUser(userResponse.Email);
            Pages.CmsUserManagement
                .VerifyUserIsEdited(userData, userResponse.Email);
            Pages.CmsUserManagement
                .ClickEditUser(userResponse.Email)
                .OpenSecurityTab()
                .SetNewPassword();

            #region PostConditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(tokenAdmin, userResponse.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("CMS Usermanagement")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("CMS")]
        [AllureSubSuite("Usermanagement")]
        public void DeleteUserOnCms()
        {
            #region Preconditions
            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var userResponse = UsersRequest.CreateUserOnCms(token);
            #endregion

            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsUserManagement
                .OpenUserManagement()
                .SearchUser(userResponse.Email);
            Pages.CmsUserManagement
                .DeleteUser(userResponse.Email);
        }

        [Test]
        [Category("CMS Usermanagement")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("CMS")]
        [AllureSubSuite("Usermanagement")]
        public void AddDreamHomeTicketToUserOnCms()
        {
            #region Preconditions

            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var userResponse = UsersRequest.CreateUserOnCms(token);
            int numOftickets = 10;
            #endregion

            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsUserManagement
                .OpenUserManagement();
            Pages.CmsUserManagement
                .SearchUser(userResponse.Email);
            Pages.CmsUserManagement
                .ClickEditUser(userResponse.Email)
                .OpenTicketsTab()
                .ClickAddTicketBtn()
                .AddTicketsToUser(numOftickets)
                .SelectTicketsDataByCompetition(Competitions.DREAMHOME);
           


            #region PostConditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(tokenAdmin, userResponse.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("CMS Usermanagement")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("CMS")]
        [AllureSubSuite("Usermanagement")]
        public void EditDreamHomeTicketForUserOnCms()
        {
            #region Preconditions
            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var userResponse = UsersRequest.CreateUserOnCms(token);
            int numOftickets = 10;
            #endregion

            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsUserManagement
                .OpenUserManagement();
            Pages.CmsUserManagement
                .SearchUser(userResponse.Email);
            Pages.CmsUserManagement
                .ClickEditUser(userResponse.Email)
                .OpenTicketsTab()
                .ClickAddTicketBtn()
                .AddTicketsToUser(numOftickets);
            var competitionsList = Pages.CmsUserManagement.SelectTicketsDataByCompetition(Competitions.DREAMHOME);

            Pages.CmsUserManagement
                .ClickEditTicketBtn(competitionsList)
                .AddTicketsToUser(numOftickets)
                .VerifyTicketsIsAdded(competitionsList, Competitions.DREAMHOME, numOftickets);

            #region PostConditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(tokenAdmin, userResponse.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("CMS Usermanagement")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("CMS")]
        [AllureSubSuite("Usermanagement")]
        public void DeleteDreamHomeTicketForUserOnCms()
        {
            #region Preconditions
            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var userResponse = UsersRequest.CreateUserOnCms(token);
            int numOftickets = 10;
            #endregion

            Pages.CmsLogin
                .EnterLoginAndPassword(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN)
                .ClickSignInBtn();
            Pages.CmsCommon
                .VerifyIsLoginSuccessfull();
            Pages.CmsUserManagement
                .OpenUserManagement();
            Pages.CmsUserManagement
                .SearchUser(userResponse.Email);
            Pages.CmsUserManagement
                .ClickEditUser(userResponse.Email)
                .OpenTicketsTab()
                .ClickAddTicketBtn()
                .AddTicketsToUser(numOftickets);
            var competitionsList = Pages.CmsUserManagement.SelectTicketsDataByCompetition(Competitions.DREAMHOME);

            Pages.CmsUserManagement
                .ClickEditTicketBtn(competitionsList)
                .AddTicketsToUser(numOftickets)
                .VerifyTicketsIsAdded(competitionsList, Competitions.DREAMHOME, numOftickets);
            competitionsList = Pages.CmsUserManagement.SelectTicketsDataByCompetition(Competitions.DREAMHOME);
            Pages.CmsUserManagement
                .ClickDeleteTicketBtn(competitionsList);

            #region PostConditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(tokenAdmin, userResponse.Email);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }
    }
}