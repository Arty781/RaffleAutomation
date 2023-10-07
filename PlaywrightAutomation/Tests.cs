using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightAutomation.Pages.CMS.DreamHomePage;
using PlaywrightAutomation.Pages.CMS.LoginPage;
using PlaywrightAutomation.Pages.CMS.UserManagementPage;
using PlaywrightAutomation.Pages.WEB.SignUpPage;
using RaffleAutomationTests.APIHelpers.Admin.UsersPage;
using RaffleAutomationTests.APIHelpers.Admin;
using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;
using static PlaywrightAutomation.Helpers;
using PlaywrightAutomation.Pages.WEB.UserProfilePage;
using PlaywrightAutomation.Pages.WEB.SignInPage;
using PlaywrightAutomation.Pages.WEB.CommonPage;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using RaffleAutomationTests.APIHelpers.Web.Basket;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using RaffleAutomationTests.APIHelpers.Web;
using PlaywrightAutomation.Pages.WEB.HomePage;
using PlaywrightAutomation.Pages.WEB.BasketPage;
using PlaywrightAutomation.Pages.WEB.ThankYouPage;
using PlaywrightAutomation.Pages.WEB.ActivateUserPage;
using PlaywrightAutomation.Pages.WEB.SubscriptionPage;

namespace PlaywrightAutomation
{
    [TestFixture]
    public class CmsTests : Base
    {
        [Test]
        public async Task EditDreamhomeAndMoveImages()
        {
            await Login.MakeLoginCMS(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            await Dreamhome.OpenDreamHomePage();
            await Dreamhome.EditDreamHome(0);
            int count = await Dreamhome.MoveImages();
            await Dreamhome.ClickSave();
            await Dreamhome.ClickSave();
            await Dreamhome.ClickSave();
            await Dreamhome.VerifyDisplayingOfDreamhome(count);
            await Dreamhome.EditDreamHome(0);
            await WaitUntil.ElementIsVisible(Dreamhome.listImgMobileLast10);


        }

        [Test]
        public async Task CreateUserOnCms()
        {

            var email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"), "@putsbox.com");
            await Login.MakeLoginCMS(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            await UserManagement.OpenUserManagement();
            await UserManagement.ClickAddNewBtn();
            await UserManagement.EnterUserData(email);
            await UserManagement.ClickSave();
            await UserManagement.SearchUser(email);
            Assert.That(actual: SMTP_API.PutsBox.CheckEmailBySubject(email, "Create account", "Your temporary password is: "), expression: Is.Not.Null);
        }
    }

    [TestFixture]
    public class Validation : Base
    {


        [Test, Category("Validation")]
        public async Task VerifyFirstnameValidationOnSignUpPage()
        {

            await GoToPage(Endpoints.Web.SIGN_UP, SignUp.btnSignUp);
            await SignUp.VerifyFirstnameValidationOnSignUp();

        }

        [Test, Category("Validation")]
        public async Task VerifyLastnameValidationOnSignUpPage()
        {

            await GoToPage(Endpoints.Web.SIGN_UP, SignUp.btnSignUp);
            await SignUp.VerifyLastnameValidationOnSignUp();

        }

        [Test, Category("Validation")]
        public async Task VerifyEmailValidationOnSignUpPage()
        {

            await GoToPage(Endpoints.Web.SIGN_UP, SignUp.btnSignUp);
            await SignUp.VerifyEmailValidationOnSignUp();

        }

        [Test, Category("Validation")]
        public async Task VerifyPasswordValidationOnSignUpPage()
        {

            await GoToPage(Endpoints.Web.SIGN_UP, SignUp.btnSignUp);
            await SignUp.VerifyPasswordValidationOnSignUp();

        }

        [Test, Category("Validation")]
        public async Task VerifyValidationAccountDetailsOnProfilePage()
        {
            #region Preconditions

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);

            #endregion

            await SignIn.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
            await Common.CloseCookiesPopUp();
            await UserProfile.ClickEditAccountBtn();
            await UserProfile.VerifyValidationOnProfileAccountDetails();
            await UserProfile.EditAccountData();
            await UserProfile.VerifyDisplayingSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion
        }

        [Test, Category("Validation")]
        public async Task VerifyValidationPasswordOnProfilePage()
        {
            #region Preconditions

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);

            #endregion

            await SignIn.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
            await Common.CloseCookiesPopUp();
            await UserProfile.ClickEditPasswordBtn();
            await UserProfile.VerifyValidationOnProfilePassword();
            await UserProfile.EditPassword();
            await UserProfile.VerifyUpdatePasswordSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Validation")]
        public async Task VerifyValidationPersonalDetailsOnProfilePage()
        {
            #region Preconditions

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);

            #endregion

            await SignIn.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
            await Common.CloseCookiesPopUp();
            await UserProfile.ClickEditPersonalDataBtn();
            await UserProfile.VerifyValidationOnProfilePersonalDetails();
            await UserProfile.EditPersonalData();
            await UserProfile.VerifyDisplayingSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion
        }

        [Test, Category("Validation")]
        public async Task VerifyValidationOnSignInPage()
        {
            #region Preconditions

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);

            #endregion

            await GoToPage(Endpoints.Web.SIGN_IN, SignIn.btnSignIn);
            await SignIn.VerifyValidationOnSignIn(response);
            await SignIn.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }


    }

    [TestFixture]
    public class Authorization : Base
    {
        [Test, Category("Authorization")]
        public async Task RegisterNewUser()
        {

            await GoToPage(Endpoints.Web.SIGN_UP, SignUp.btnSignUp);
            string email = await SignUp.EnterUserData();
            await SignUp.ClickSignUpBtn();
            await Common.CloseCookiesPopUp();
            await SignUp.VerifyEmail(email);

            #region Postconditions
            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox");
            #endregion

        }
    }

    [TestFixture]
    [AllureNUnit]
    public class Payment : Base
    {
        [Test, Category("Unauthorized")]
        public async Task ActivateNewUserFromEmail()
        {
            string? name = string.Empty;
            string email = string.Concat("qatester", DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss"), "@putsbox.com");

            await Pages.WEB.HeaderPage.Header.OpenHomePage();

            await Common.CloseCookiesPopUp();

            await Home.AddTicketsToBasket(0);
            var countOrders = await Basket.GetOrderCount();
            var totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsUnauthorizedUser(email);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await SMTP_API.PutsBox.GoToActivationLink(email);
            await Activate.ActivateUserEnterData(email);
            await Activate.VerifySuccessfullActivation();
            await SignIn.MakeSignIn(email, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();
            await UserProfile.ScrollToEndOfHistoryList(countOrders);
            await UserProfile.VerifyAddingTickets(totalOrder, countOrders);


            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");



            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public async Task ActivateNewUserFromEmailAfterThreePayments()
        {

            await Pages.WEB.HeaderPage.Header.OpenHomePage();
            await Common.CloseCookiesPopUp();
            string email = string.Concat("qatester", DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss"), "@putsbox.com");
            for (int i = 0; i < 5; i++)
            {
                await Home.AddTicketsToBasket(0);
                await Basket.MakeAPurchaseAsUnauthorizedUser(email);
                await ThankYou.VerifyThankYouPageIsDisplayed();
            }
            await SMTP_API.PutsBox.GoToActivationLink(email);
            await Activate.ActivateUserEnterData(email);
            await Activate.VerifySuccessfullActivation();

            #region Postconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");



            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public async Task ActivateNewUserAfterPayment()
        {

            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            await Pages.WEB.HeaderPage.Header.OpenHomePage();
            await Common.CloseCookiesPopUp();
            await Home.AddTicketsToBasket(3);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsUnauthorizedUser(email);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickActivateMyAccount();
            await Activate.ActivateUserEnterData(email);
            await Activate.VerifySuccessfullActivation();
            await SignIn.MakeSignIn(email, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();
            //await UserProfile.ScrollToEndOfHistoryList(countOrders);
            await UserProfile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            UsersRequest.GetUser(tokenAdmin, email);
            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");


            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public async Task ActivateNewUserAfterThreePayments()
        {

            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            await Pages.WEB.HeaderPage.Header.OpenHomePage();
            await Common.CloseCookiesPopUp();
            await Home.AddTicketsToBasket(2);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsUnauthorizedUser(email);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickActivateMyAccount();
            await Activate.ActivateUserEnterData(email);
            await Activate.VerifySuccessfullActivation();
            await SignIn.MakeSignIn(email, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();
            await UserProfile.ScrollToEndOfHistoryList(countOrders);
            await UserProfile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.ADMIN_LOGIN, Credentials.ADMIN_PASSWORD);
            UsersRequest.GetUser(tokenAdmin, email);
            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");


            #endregion

        }

        [Test, Category("Payment")]
        public async Task MakePurchaseWithDelayAndClosingTab()
        {

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            await Pages.WEB.HeaderPage.Header.OpenHomePage();
            await Common.CloseCookiesPopUp();
            await SignIn.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Home.OpenHomePage();
            await Home.OpenDreamTicketSelector();
            await Home.SelectFirstBundleBtn();
            var page = await Common.CloseTabAndWait30Seconds();
            await Home.OpenHomePage();
            await Home.OpenDreamTicketSelector();
            await Home.SelectFirstBundleBtn();
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();
            await UserProfile.ScrollToEndOfHistoryList(countOrders);
            await UserProfile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");


            #endregion
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public async Task PurchaseDreamHome()
        {
            //#region Update two active dreamhomes


            //List<RaffleAutomationTests.Helpers.DbModels.Raffle> activeDreamhomeList = RaffleAutomationTests.Helpers.AppDbHelper.DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            //List<RaffleAutomationTests.Helpers.DbModels.Raffle> dreamhomeList = RaffleAutomationTests.Helpers.AppDbHelper.DreamHome.GetAllRaffles().Distinct(new RaffleAutomationTests.Helpers.ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            //RaffleAutomationTests.Helpers.AppDbHelper.DreamHome.DeactivateDreamHome(activeDreamhomeList);
            //dreamhomeList.Reverse();
            //RaffleAutomationTests.Helpers.AppDbHelper.DreamHome.ActivateOneClosedDreamHome(dreamhomeList, -3600, 3600);

            //#endregion

            SignInRequestWeb.MakeSignIn(Credentials.USER_LOGIN, Credentials.USER_PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            await Pages.WEB.HeaderPage.Header.OpenHomePage();
            await Common.CloseCookiesPopUp();
            await SignIn.MakeSignIn(Credentials.USER_LOGIN, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Home.AddTicketsToBasket(0);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();
            await UserProfile.ScrollToEndOfHistoryList(countOrders);
            await UserProfile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public async Task PurchaseTwoActiveDreamHome()
        {

            #region Update two active dreamhomes

            int addFirstStartHours = -3600;
            int addFirstEndHours = 3600;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 80;

            List<RaffleAutomationTests.Helpers.DbModels.Raffle> activeDreamhomeList = RaffleAutomationTests.Helpers.AppDbHelper.DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<RaffleAutomationTests.Helpers.DbModels.Raffle> dreamhomeList = RaffleAutomationTests.Helpers.AppDbHelper.DreamHome.GetAllRaffles().Distinct(new RaffleAutomationTests.Helpers.ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            RaffleAutomationTests.Helpers.AppDbHelper.DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            RaffleAutomationTests.Helpers.AppDbHelper.DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            #endregion

            SignInRequestWeb.MakeSignIn(Credentials.USER_LOGIN, Credentials.USER_PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            await Pages.WEB.HeaderPage.Header.OpenHomePage();
            await Common.CloseCookiesPopUp();
            await SignIn.MakeSignIn(Credentials.USER_LOGIN, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Home.AddTicketsToBasket(0);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();
            await UserProfile.ScrollToEndOfHistoryList(countOrders);
            await UserProfile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");


            #endregion
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public async Task SignUpAddTicketsMakePurchase()
        {

            await Pages.WEB.HeaderPage.Header.OpenHomePage();
            await Common.CloseCookiesPopUp();
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD, out SignInResponseModelWeb? token);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            await SignIn.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            DreamHomeOrderRequestWeb.MultipleAddDreamhomeTickets(token, prizesList.FirstOrDefault(), 15);
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();
            await UserProfile.VerifyAddingTickets(totalOrder, countOrders);
            await Basket.ClickCartBtn();
            countOrders = await Basket.GetOrderCount();
            totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();
            await UserProfile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public async Task SignUpAddReferralsAndTicketsMakePurchase()
        {

            await Pages.WEB.HeaderPage.Header.OpenHomePage();
            await Common.CloseCookiesPopUp();
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD, out SignInResponseModelWeb? token);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            await SignIn.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();
            await UserProfile.VerifyAddingTickets(totalOrder, countOrders);
            await Pages.WEB.HeaderPage.Header.DoLogout();
            for (int i = 0; i < 2; i++)
            {
                var responseReferral = SignUpRequest.RegisterNewReferral(response.User.ReferralKey);
                SignInRequestWeb.MakeSignIn(responseReferral.User.Email, Credentials.USER_PASSWORD, out SignInResponseModelWeb? tokenReferral);
                var prizesListReferral = CountdownRequestWeb.GetDreamHomeCountdown(tokenReferral);
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(tokenReferral, prizesListReferral.FirstOrDefault());
                await SignIn.MakeSignIn(responseReferral.User.Email, Credentials.USER_PASSWORD);
                await SignIn.VerifyIsSignIn();
                await Basket.ClickCartBtn();
                countOrders = await Basket.GetOrderCount();
                double totalOrderReferral = await Basket.GetOrderTotal();
                await Basket.MakeAPurchaseAsAuthorizedUser();
                await ThankYou.VerifyThankYouPageIsDisplayed();
                await UserProfile.OpenMyTicketsCompetitions();
                await UserProfile.OpenDreamHomeHistoryList();
                await UserProfile.VerifyAddingTickets(totalOrderReferral, countOrders);
                await Pages.WEB.HeaderPage.Header.DoLogout();

                #region Postconditions

                RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

                #endregion
            }
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public async Task GetPurchaseDreamHome()
        {

            await Pages.WEB.HeaderPage.Header.OpenHomePage();
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            await Common.CloseCookiesPopUp();
            await SignIn.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < RandomHelper.RandomIntNumber(2); q++)
                {
                    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());

                }
                await Basket.ClickCartBtn();
                int countOrders = await Basket.GetOrderCount();
                double totalOrder = await Basket.GetOrderTotal(); ;
                await Basket.MakeAPurchaseAsAuthorizedUser();
                await ThankYou.VerifyThankYouPageIsDisplayed();
                await UserProfile.OpenMyTicketsCompetitions();
                await UserProfile.OpenDreamHomeHistoryList();
                await UserProfile.ScrollToEndOfHistoryList(countOrders);
                await UserProfile.VerifyAddingTickets(totalOrder, countOrders);
            }
            await UserProfile.OpenMyTicketsCompetitions();
            await UserProfile.OpenDreamHomeHistoryList();

            #region Postconditions

            RaffleAutomationTests.Helpers.AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test]
        public async Task Demotest()
        {
            string name = string.Empty;
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            await Common.CloseCookiesPopUp();
            await SignIn.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Home.OpenHomePage();
            await Home.AddTicketsToBasket(0);
            await Basket.MakeAPurchasePayPal();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickViewTickets();
            await UserProfile.OpenSubscriptionsTab();
            await UserProfile.BuyTenPoundsSub();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await ThankYou.VerifyThankYouPageIsDisplayed();

        }

        //[Test, Category("Payment")]
        //[AllureTag("Regression")]
        //[AllureOwner("Artem Sukharevskyi")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[Author("Artem", "qatester91311@gmail.com")]
        //[AllureSuite("Client")]
        //[AllureSubSuite("Payment")]
        //public async Task PurchaseTicketsFromWinAndDiscountPages()
        //{
        //    
        //    SignUpRequest.RegisterNewUser(out SignUpResponse? response);
        //    SignInRequestWeb.MakeSignIn(Credentials.USER_LOGIN, Credentials.USER_PASSWORD, out SignInResponseModelWeb? token);
        //    var basketOrders = BasketRequest.GetBasketOrders(token);
        //    BasketRequest.DeleteOrders(token, basketOrders);
        //    var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
        //    await Common
        //                    .CloseCookiesPopUp();
        //    DreamHomeOrderRequestWeb
        //        .AddDreamhomeTickets(token, prizesList.FirstOrDefault());
        //    await PageDiscountPage
        //                    .OpenPageDiscount()
        //                    .SelectTicketBundle(out string bunlePrice)
        //                    .VerifyPriceOfAddedOrder(bunlePrice);


        //    await SignIn
        //                    .MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
        //    await SignIn
        //                    .VerifyIsSignIn();
        //    await WinRafflePage
        //                    .OpenWinRaffle()
        //                    .SelectTicketBundle(out string bunleWinPrice)
        //                    .VerifyPriceOfAddedOrder(bunleWinPrice);


        //    await SignIn
        //                    .MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
        //    await SignIn
        //                    .VerifyIsSignIn();
        //    await Basket
        //                    .ClickCartBtn(); ;
        //    await Basket
        //                    int countOrders = await Basket.GetOrderCount();
        //    double totalOrder = await Basket.GetOrderTotal();
        //    await Basket.ClickCheckoutNowBtn();
        //                    .EnterCardDetails()
        //                    .ClickPayNowBtn();
        //    await ThankYou
        //                    .VerifyThankYouPageIsDisplayed();
        //    await UserProfile
        //                    .OpenMyTicketsCompetitions();
        //                    .OpenDreamHomeHistoryList();
        //                    .ScrollToEndOfHistoryList(countOrders);
        //                    .VerifyAddingTickets(totalOrder, countOrders);

        //    #region Postconditions

        //    //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

        //    #endregion
        //}

        //[Test, Category("Payment")]
        //[AllureTag("Regression")]
        //[AllureOwner("Artem Sukharevskyi")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[Author("Artem", "qatester91311@gmail.com")]
        //[AllureSuite("Client")]
        //[AllureSubSuite("Payment")]
        //public async Task PurchaseTicketsWin()
        //{
        //    
        //    await Common
        //                    .CloseCookiesPopUp();
        //    string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";

        //    await WinRafflePage
        //                    .OpenWinRaffle()
        //                    .SelectTicketBundle(out string bunleWinPrice)
        //                    .VerifyPriceOfAddedOrder(bunleWinPrice);
        //    await Basket
        //                    int countOrders = await Basket.GetOrderCount();
        //    double totalOrder = await Basket.GetOrderTotal();
        //                    .MakeAPurchaseAsUnauthorizedUser(email);
        //    await ThankYou
        //                    .VerifyThankYouPageIsDisplayed();
        //    await ThankYou
        //                    .ClickActivateMyAccount();
        //    await Activate
        //                    .ActivateUser(email);
        //    await Activate
        //                    .VerifySuccessfullActivation();


        //    await SignIn
        //                    .MakeSignIn(email, Credentials.USER_PASSWORD);
        //    await SignIn
        //                    .VerifyIsSignIn();
        //    await UserProfile
        //                    .OpenMyTicketsCompetitions();
        //                    .OpenDreamHomeHistoryList();
        //                    .ScrollToEndOfHistoryList(countOrders);
        //                    .VerifyAddingTickets(totalOrder, countOrders);

        //    #region Postconditions

        //    //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

        //    #endregion
        //}

        //[Test, Category("Payment")]
        //[AllureTag("Regression")]
        //[AllureOwner("Artem Sukharevskyi")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[Author("Artem", "qatester91311@gmail.com")]
        //[AllureSuite("Client")]
        //[AllureSubSuite("Payment")]
        //public async Task PurchaseTicketsFromPageDiscount()
        //{
        //    
        //    SignUpRequest.RegisterNewUser(out SignUpResponse? response);
        //    SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.USER_PASSWORD, out SignInResponseModelWeb? token);
        //    var basketOrders = BasketRequest.GetBasketOrders(token);
        //    BasketRequest.DeleteOrders(token, basketOrders);
        //    await Common
        //                    .CloseCookiesPopUp();
        //    await PageDiscountPage
        //                    .OpenPageDiscount()
        //                    .SelectTicketBundle(out string bunlePrice)
        //                    .VerifyPriceOfAddedOrder(bunlePrice);


        //    await SignIn
        //                    .MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
        //    await SignIn
        //                    .VerifyIsSignIn();
        //    await Basket
        //                    .ClickCartBtn(); ;
        //    await Basket
        //                    int countOrders = await Basket.GetOrderCount();
        //    double totalOrder = await Basket.GetOrderTotal(); ;

        //    await Basket
        //                    .MakeAPurchaseAsAuthorizedUser();
        //    await ThankYou
        //                    .VerifyThankYouPageIsDisplayed();
        //    await UserProfile
        //                    .OpenMyTicketsCompetitions();
        //                    .OpenDreamHomeHistoryList();
        //                    .ScrollToEndOfHistoryList(countOrders);
        //                    .VerifyAddingTickets(totalOrder, countOrders);

        //    #region Postconditions

        //    AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

        //    #endregion
        //}

        //[Test]
        //[Category("Payment")]
        //[AllureTag("Regression")]
        //[AllureOwner("Artem Sukharevskyi")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[Author("Artem", "qatester91311@gmail.com")]
        //[AllureSuite("Client")]
        //[AllureSubSuite("Payment")]
        //public async Task AddDreamHomeToBasketAndPurchaseSubscription()
        //{
        //    
        //    SignUpRequest.RegisterNewUser(out SignUpResponse? response);
        //    SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.USER_PASSWORD, out SignInResponseModelWeb? token);
        //    var basketOrders = BasketRequest.GetBasketOrders(token);
        //    BasketRequest.DeleteOrders(token, basketOrders);
        //    var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
        //    await Common
        //                    .CloseCookiesPopUp();


        //    await SignIn
        //                    .MakeSignIn(response.User.Email, Credentials.USER_PASSWORD);
        //    await SignIn
        //                    .VerifyIsSignIn();
        //    for (int i = 0; i <= 0; i++)
        //    {
        //        for (int q = 0; q < 1; q++)
        //        {
        //            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());

        //        }

        //    }
        //    await Subscription
        //                    .OpenSubscriptionPage()
        //                    .AddTenSubscriptionToBasket(out _, out _); ;
        //    await Basket
        //                    .EnterCardDetails()
        //                    .ClickPayNowBtn();
        //    await ThankYou
        //                    .VerifyThankYouPageIsDisplayed();
        //    await UserProfile
        //                    .OpenMyTicketsCompetitions();
        //                    .OpenDreamHomeHistoryList(); ;
        //    for (int i = 0; i <= 0; i++)
        //    {
        //        for (int q = 0; q < 1; q++)
        //        {
        //            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());

        //        }

        //        await Basket
        //                            .ClickCartBtn(); ;
        //        await Basket
        //                            .MakeAPurchaseAsAuthorizedUser();
        //        await ThankYou
        //                            .VerifyThankYouPageIsDisplayed();
        //    }

        //    await UserProfile
        //                    .OpenMyTicketsCompetitions();
        //                    .OpenDreamHomeHistoryList(); ;

        //    #region Postconditions

        //    AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

        //    #endregion
        //}

    }
}