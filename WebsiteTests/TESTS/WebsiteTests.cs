using MongoDB.Bson;
using MongoDB.Bson.IO;
using OpenQA.Selenium.Interactions;
using RaffleAutomationTests.APIHelpers.Web.Subscriptions;
using RaffleAutomationTests.PageObjects.WebSitePages;
using RimuTec.Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using static RaffleAutomationTests.Helpers.AppDbHelper;

namespace RaffleHouseAutomation.WebSiteTests
{
    [TestFixture]
    [AllureNUnit]
    public class Demo : TestBaseWeb
    {
        [Test]
        //[Ignore("Demo test")]
        
        public void Demotest()
        {
            #region Preconditions
            string name = "";
            double value = 0;
            int quantity = 0;
            var response = SignUpRequest.RegisterNewUser();
            
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Subscription
                .OpenSubscriptionPage()
                .AddTenSubscriptionToBasket(out value, out quantity);
            string charity = string.Empty;
            Pages.Basket
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();

            EmailVerificator.VerifyInitialEmailAuth(response.User.Email, name, charity);

            #region Postconditions


            #endregion
        }


    }

    [TestFixture]
    [AllureNUnit]
    public class Authorization : TestBaseWeb
    {
        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Authorisation")]
        public void LoginByEmail()
        {
            #region Preconditions

            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Authorisation")]
        public void RegisterNewUser()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .EnterUserData();
            string email = SignUp.GetEmail();
            Pages.SignUp
                .ClickSignUpBtn()
                .VerifyEmail(email);

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Authorisation")]
        public void RegisterNewNonActivatedUser()
        {
            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            Pages.Home
                .AddTicketsToBasket(0);
            Pages.Basket
                .MakeAPurchaseAsUnauthorizedUser(email);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .EnterUserDataForNonActivated(email);
            Pages.SignUp
                .ClickSignUpBtn()
                .VerifyEmail(email);

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            #endregion

        }

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Authorisation")]
        public void EditUserData()
        {
            #region Preconditions

            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn(out name);
            Pages.Profile
                .ClickEditPersonalDataBtn()
                .EditPersonalData()
                .VerifyDisplayingSuccessfullToaster();
            Pages.Profile
                .ClickEditPasswordBtn()
                .EditPassword()
                .VerifyUpdatePasswordSuccessfullToaster();
            Pages.Profile
                .ClickEditAccountBtn()
                .EditAccountData()
                .VerifyDisplayingSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Authorisation")]
        public void ResetPassword()
        {
            #region Preconditions

            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .ClickForgotPassword();
            Pages.ResetPassword
                .RequestForgotPassword(response.User.Email)
                .VerifySuccessfullMessageAppeared(response.User.Email);
            Pages.ResetPassword
                .ClickOkBtn()
                .GoToResetPassLink(response.User.Email)
                .GetResetPassword();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.NEW_PASWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void ResetPasswordAfterPaymentAsUnauthorized()
        {
            #region Preconditions
            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            Pages.Home
                .AddTicketsToBasket(0);
            Pages.Basket
                .MakeAPurchaseAsUnauthorizedUser(email);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .ClickForgotPassword();
            Pages.ResetPassword
                .RequestForgotPassword(response.User.Email)
                .VerifySuccessfullMessageAppeared(response.User.Email);
            Pages.ResetPassword
                .ClickOkBtn()
                .GoToResetPassLink(response.User.Email)
                .GetResetPassword();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.NEW_PASWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }
    }

    [TestFixture]
    [AllureNUnit]
    public class SubscriptionsCommon : TestBaseWeb
    {
        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PurchaseTenPoundsSubscriptionAsUnauthorizedUser()
        {
            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed(); 
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();

            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PurchaseTwentyFivePoundsSubscriptionAsUnauthorizedUser()
        {
            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PurchaseMultipleofSubscriptionAsUnauthorizedUser()
        {
            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        Pages.Basket
                            .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
                        Pages.ThankYou
                            .VerifyThankYouPageIsDisplayed();
                        break;
                    case 1:
                        Pages.Basket
                            .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
                        Pages.ThankYou
                            .VerifyThankYouPageIsDisplayed();
                        WaitUntil.WaitSomeInterval(120000);
                        break;
                    case 2:
                        Pages.Basket
                            .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
                        Pages.ThankYou
                            .VerifyThankYouPageIsDisplayed();
                        break;
                    case 3:
                        Pages.Basket
                            .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
                        Pages.ThankYou
                            .VerifyThankYouPageIsDisplayed();
                        break;
                }
            }
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();

            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PurchaseTenPoundsSubscriptionAsAuthorizedUserLive()
        {
            string name = "";
            double value = 0.0;
            int quantity = 0;

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Subscription
                .OpenSubscriptionPage()
                .AddTenSubscriptionToBasket(out value, out quantity);
            Pages.Basket
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
            var user = AppDbHelper.Users.GetUserByEmail(Credentials.LOGIN);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PurchaseTwentyFivePoundsSubscriptionAsAuthorizedUser()
        {
            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .MakeAPurchaseSubscriptionAsAuthorizedUser(subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
            var user = AppDbHelper.Users.GetUserByEmail(response.User.Email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PauseSubscriptionAsAuthorizedUser()
        {
            var response = SignUpRequest.RegisterNewUser();
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();
            string name = "";
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .MakeAPurchaseSubscriptionAsAuthorizedUser(subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
            var user = AppDbHelper.Users.GetUserByEmail(response.User.Email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
            Pages.Profile
                .OpenSubscriptionInProfile()
                .PauseSubscription()
                .VerifyPauseEmail(response.User.Email, name);
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void UnpauseSubscriptionAsAuthorizedUser()
        {
            var response = SignUpRequest.RegisterNewUser();
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();
            string name = "";
            var raffle = DreamHome.GetAciveRaffles();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .MakeAPurchaseSubscriptionAsAuthorizedUser(subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
            var user = AppDbHelper.Users.GetUserByEmail(response.User.Email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
            Pages.Profile
                .OpenSubscriptionInProfile()
                .PauseSubscription()
                .OpenSubscriptionInProfile()
                .UnpauseSubscription()
                .VerifyUnpauseEmail(response.User.Email,
                                    name,
                                    "None Selected",
                                    raffle.Count);
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void CancelSubscriptionAsAuthorizedUser()
        {
            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .MakeAPurchaseSubscriptionAsAuthorizedUser(subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
            var user = AppDbHelper.Users.GetUserByEmail(response.User.Email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
            Pages.Profile
                .OpenSubscriptionInProfile()
                .CancelSubscription()
                .VerifyCancelationEmail(response.User.Email, name);


        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PurchaseNormalTicketsAsSubscribedAuthorizedUser()
        {
            string name = "";
            double value = 0;
            int quantity = 0;
            var response = SignUpRequest.RegisterNewUser();
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Subscription
                .OpenSubscriptionPage()
                .AddTenSubscriptionToBasket(out value, out quantity);
            Pages.Basket
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
            Pages.Home
                .AddTicketsToBasket(2);
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
            var user = AppDbHelper.Users.GetUserByEmail(response.User.Email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PurchaseSubFromSubscriptionPageAsUnauthorizedUser()
        {
            string name = "";
            double value = 0;
            int quantity = 0;
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Subscription
                .OpenSubscriptionPage()
                .AddTenSubscriptionToBasket(out value, out quantity);
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifyTextsOnSubscriptionsPage()
        {
            Pages.Subscription
                .OpenSubscriptionPage();
            Pages.Common
                .CloseCookiesPopUp();
            Element.Action(Keys.End);
            Pages.Subscription
                .VerifyDisplayingH1()
                .VerifyDisplayingH2()
                .VerifyDisplayingH3()
                .VerifyDisplayingParagraphs();
        }

    }

    [TestFixture]
    [AllureNUnit]
    public class SubscriptionsDoubleTickets : TestBaseWeb
    {
        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("DoubleTickets")]
        public void PurchaseTenPoundsSubscriptionUnauthorized()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails

            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 1000).Select(x=>x).FirstOrDefault();

            #endregion


            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(2)
                .VerifyAddingTickets((double)subscriptionsList.TotalCost/100, 2);

            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("DoubleTickets")]
        public void Purchase25PoundsSubscriptionOneRaffleExpired()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = -80;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails

            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();

            #endregion


            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(1)
                .VerifyAddingTickets((double)subscriptionsList.TotalCost / 100, 1);

            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }

        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("DoubleTickets")]
        public void Purchase10PoundsSubscriptionOneRaffleActive()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateOneClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails

            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();

            #endregion


            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(1)
                .VerifyAddingTickets((double)subscriptionsList.TotalCost / 100, 1);

            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("DoubleTickets")]
        public void PurchaseSubscriptionOneRaffleExpired()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = -80;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
            Subscriptions.DeleteSubscriptions();
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails

            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();

            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x=>x.EndsAt < DateTime.Now).Select(x=>x).FirstOrDefault();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            for (int i = 0; i < 1; i++)
            {
                AppDbHelper.Insert.InsertUser(raffle, email);

            }
            var users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com").FirstOrDefault();
            AppDbHelper.Insert.InsertSubscriptionsToUsers(users, raffle, subscriptionsModel);

            #endregion


            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .WaitUntilScriptRuning(activeDreamhomeList.Count)
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(1)
                .VerifyAddingTickets((double)subscriptionsList.TotalCost / 100, 1);


        }

    }

    [TestFixture]
    [AllureNUnit]
    public class PrepareForMailingSub : TestBaseWeb
    {
        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PrepareUserToNextPurchase()
        {
            string name = "";
            string email = string.Concat("nextpurchase", DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss"), "@putsbox.com");
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();

            var user = AppDbHelper.Users.GetUserByEmail(email);
            
            Pages.Profile
                .OpenSubscriptionInProfile();
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }

            AppDbHelper.Subscriptions.UpdateSubscriptionDateByIdToNextPurchase(user);
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PrepareUserToUnpause()
        {
            string name = "";
            string email = string.Concat("aftermonth", DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss"), "@putsbox.com");
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();

            var user = AppDbHelper.Users.GetUserByEmail(email);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .PauseSubscription();
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
            AppDbHelper.Subscriptions.UpdateSubscriptionDateByIdToUnpause(user);
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void PrepareUserToSevenDaysPrior()
        {
            string name = "";
            string email = string.Concat("sevendaysprior", DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss"), "@putsbox.com");
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();

            var user = AppDbHelper.Users.GetUserByEmail(email);
            
            Pages.Profile
                .OpenSubscriptionInProfile()
                .PauseSubscription();
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
            AppDbHelper.Subscriptions.UpdateSubscriptionDateByIdToSendEmail7DaysPrior(user);
        }
    }

    [TestFixture]
    [AllureNUnit]
    public class SubscriptionsMailing : TestBaseWeb
    {
        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifyInitialSubscriptionEmailAsUnauthorizedUser(int activeRaffles)
        {
            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .VerifyInitialEmailUnauth(email,
                                    name,
                                    (int)(subscriptionsList.SubscriptionModels.FirstOrDefault().NumOfTickets + subscriptionsList.SubscriptionModels.FirstOrDefault().Extra),
                                    (double)subscriptionsList.SubscriptionModels.FirstOrDefault().TotalCost,
                                    "None Selected",
                                    activeRaffles);
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifyPauseSubscriptionEmailAsUnauthorizedUser()
        {
            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Elements
                .ClearEmailHistory(email);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .PauseSubscription()
                .VerifyPauseEmail(email, name);

        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifyUnpauseSubscriptionEmailAsUnauthorizedUser()
        {
            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();
            var raffle = DreamHome.GetAciveRaffles();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Elements
                .ClearEmailHistory(email);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .PauseSubscription();
            Elements
                .ClearEmailHistory(email);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .UnpauseSubscription()
                .VerifyUnpauseEmail(email,
                                    name,
                                    "None Selected",
                                    raffle.Count);

        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifyCancelSubscriptionEmailAsUnauthorizedUser()
        {
            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Elements
                .ClearEmailHistory(email);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .CancelSubscription()
                .VerifyCancelationEmail(email, name);
            

        }
    }

    [TestFixture]
    [AllureNUnit]
    public class CheckingEmailAfterScriptRunning 
    { 


        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifySubscriptionEmailsAfterRunScript()
        {
            #region Preconditions

            string name = "";
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            var raffle = AppDbHelper.DreamHome.GetAciveRaffles();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);                
                EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
                                                        user.Name,
                                                        charity,
                                                        raffle.Count);
                EmailVerificator.VerifyUnpauseEmail(user.Email,
                                                    user.Name,
                                                    charity,
                                                    raffle.Count);
                EmailVerificator.VerifyReminderEmail(user.Email, 
                                                     user.Name);
            }
            

        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifyPauseSubscriptionWithTwoRafflesActive()
        {
            #region Preconditions

            //Delete all subscritions and test users 
            var users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            Subscriptions.DeleteSubscriptionsByUserId(users);
            Orders.DeleteOrdersByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            var raffle = DreamHome.GetAciveRaffles();
            
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, 50);
            var subscriptionsModel = Subscriptions.GetAllSubscriptionModels();
            Insert.InsertUser(raffle);
            users = Users.GetUserByEmailpattern("@putsbox.com");
            var charity = "None Selected";
            int nextPurchaseDate = 100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);

            #endregion

            users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                EmailVerificator.VerifyUnpauseEmail(user.Email, user.Name, charity, raffle.Count);
            }


        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifyPauseSubscriptionWithTwoRafflesOneExpire()
        {
            #region Preconditions

            //Delete all subscritions and test users 
            var users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            Subscriptions.DeleteSubscriptionsByUserId(users);
            Orders.DeleteOrdersByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            var raffle = DreamHome.GetAciveRaffles();

            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, -50);
            var subscriptionsModel = Subscriptions.GetAllSubscriptionModels();
            Insert.InsertUser(raffle);
            users = Users.GetUserByEmailpattern("@putsbox.com");
            var charity = "None Selected";
            int nextPurchaseDate = 100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);

            #endregion

            users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                EmailVerificator.VerifyUnpauseEmail(user.Email, user.Name, charity, raffle.Count);
            }


        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifyActiveSubscriptionWithTwoRafflesActive()
        {
            #region Preconditions

            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles();
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, 50);
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                var emailsList = Elements.GgetAllEmailData(user.Email);
                SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, user.Email);
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);
                foreach (var subscription in subscriptionList)
                {
                    Assert.IsNotNull(subscription.Refference);
                    Assert.IsNotNull(subscription.CardSource);
                    Assert.IsNotNull(subscription.CheckoutId);
                }
                EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
                                                        user.Name,
                                                        charity,
                                                        raffle.Count);
            }


        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Subscriptions")]
        public void VerifyActiveSubscriptionWithTwoRafflesOneExpire()
        {
            #region Preconditions

            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles();
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, -50);
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                var emailsList = Elements.GgetAllEmailData(user.Email);
                SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, user.Email);
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);
                foreach (var subscription in subscriptionList)
                {
                    Assert.IsNotNull(subscription.Refference);
                    Assert.IsNotNull(subscription.CardSource);
                    Assert.IsNotNull(subscription.CheckoutId);
                }
                EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
                                                        user.Name,
                                                        charity,
                                                        raffle.Count);
            }


        }



    }


    [TestFixture]
    [AllureNUnit]
    public class Payment : TestBaseWeb
    {
        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void ActivateNewUserFromEmail()
        {
            string name = "";
            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            Pages.Home
                .AddTicketsToBasket(0);
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .MakeAPurchaseAsUnauthorizedUser(email);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
                    .OpenSignInPage();
            Pages.SignIn
                    .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);


            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void ActivateNewUserFromEmailAfterThreePayments()
        {
            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            for (int i = 0; i < 5; i++)
            {
                Pages.Home
                    .AddTicketsToBasket(0);
                Pages.Basket
                    .MakeAPurchaseAsUnauthorizedUser(email);
                Pages.ThankYou
                    .VerifyThankYouPageIsDisplayed();
            }

            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();


            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void ActivateNewUserAfterPayment()
        {
            string name = "";
            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            Pages.Home
                .AddTicketsToBasket(0);
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .MakeAPurchaseAsUnauthorizedUser(email);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.ThankYou
                .ClickActivateMyAccount();
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
                    .OpenSignInPage();
            Pages.SignIn
                    .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);



            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void ActivateNewUserAfterThreePayments()
        {
            string name = "";
            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            Pages.Home
                .AddTicketsToBasket(2);
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .MakeAPurchaseAsUnauthorizedUser(email);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.ThankYou
                .ClickActivateMyAccount();
            Pages.Activate
                .ActivateUser(email);
            Pages.Activate
                .VerifySuccessfullActivation();
            Pages.Header
                    .OpenSignInPage();
            Pages.SignIn
                    .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);


            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
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
        public void MakePurchaseWithDelayAndClosingTab()
        {
            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            Pages.Common
                    .CloseCookiesPopUp();
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                    .OpenSignInPage();
            Pages.SignIn
                    .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Home
                    .OpenHomePage();
            Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectFirstBundleBtn();
            Pages.Common
                    .CloseTabAndWait30Seconds();
            Pages.Home
                    .OpenHomePage();
            Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectFirstBundleBtn();
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .SelectCharity()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchaseDreamHome()
        {
            #region Update two active dreamhomes

            string name = "";
            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateOneClosedDreamHome(dreamhomeList, -3600, 3600);

            #endregion

            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest
                .DeleteOrders(token, basketOrders);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Home
                .AddTicketsToBasket(0);
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders); ;
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchaseTwoActiveDreamHome()
        {
            #region Update two active dreamhomes
            string name = "";
            int addFirstStartHours = -3600;
            int addFirstEndHours = 3600;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 80;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            #endregion

            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest
                .DeleteOrders(token, basketOrders);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Home
                .AddTicketsToBasket(0);
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders); ;
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void SignUpAddTicketsMakePurchase()
        {
            string name = "";
            Pages.Common
                .CloseCookiesPopUp();
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn();
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            for (int i = 0; i < 15; i++)
            {
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                WaitUntil.WaitSomeInterval(250);
            }
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);
            Pages.Basket
                .ClickCartBtn();
            countOrders = Pages.Basket.GetOrderCount();
            totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void SignUpAddReferralsAndTicketsMakePurchase()
        {
            string name = "";
            Pages.Common
                .CloseCookiesPopUp();
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn();
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder, countOrders);
            Pages.Header
                .DoLogout();
            for (int i = 0; i < 2; i++)
            {
                var responseReferral = SignUpRequest.RegisterNewReferral(response.User.ReferralKey);
                var tokenReferral = SignInRequestWeb.MakeSignIn(responseReferral.User.Email, Credentials.PASSWORD);
                var prizesListReferral = CountdownRequestWeb.GetDreamHomeCountdown(tokenReferral);
                DreamHomeOrderRequestWeb
                    .AddDreamhomeTickets(tokenReferral, prizesListReferral.FirstOrDefault());                
                Pages.Header
                    .OpenSignInPage();
                Pages.SignIn
                    .EnterLoginAndPass(responseReferral.User.Email, Credentials.PASSWORD);
                Pages.SignIn
                .VerifyIsSignIn(out name);
                Pages.Basket
                    .ClickCartBtn();
                countOrders = Pages.Basket.GetOrderCount();
                double totalOrderReferral = Pages.Basket.GetOrderTotal();
                Pages.Basket
                    .MakeAPurchaseAsAuthorizedUser();
                Pages.ThankYou
                    .VerifyThankYouPageIsDisplayed();
                Pages.Profile
                    .OpenMyTicketsCompetitions()
                    .OpenDreamHomeHistoryList()
                    .VerifyAddingTickets(totalOrderReferral, countOrders);
                Pages.Header
                    .DoLogout();
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
        public void GetPurchaseDreamHome()
        {
            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < RandomHelper.RandomIntNumber(2); q++)
                {
                    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                    WaitUntil.WaitSomeInterval(250);
                }

                Pages.Basket
                    .ClickCartBtn();
                int countOrders = Pages.Basket.GetOrderCount();
                double totalOrder = Pages.Basket.GetOrderTotal();
                Pages.Basket
                    .MakeAPurchaseAsAuthorizedUser();
                Pages.ThankYou
                    .VerifyThankYouPageIsDisplayed();
                Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);
            }

            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
        }

        [Test, Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchaseTicketsFromWinAndDiscountPages()
        {
            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            Pages.Common
                .CloseCookiesPopUp();
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < RandomHelper.RandomIntNumber(2); q++)
                {
                    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                    WaitUntil.WaitSomeInterval(250);
                }
            }
            Pages.PageDiscountPage
                .OpenPageDiscount();

            int bundleNumber = RandomHelper.RandomIntNumber(3);
            string bunlePrice = Pages.PageDiscountPage.textTicketBundlePrice[bundleNumber].Text;

            Pages.PageDiscountPage
                .SelectTicketBundle(bundleNumber)
                .VerifyPriceOfAddedOrder(bunlePrice);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.WinRafflePage
                .OpenWinRaffle();

            int bundleWinNumber = RandomHelper.RandomIntNumber(3);
            string bunleWinPrice = Pages.WinRafflePage.textTicketBundlePrice[bundleWinNumber].Text;

            Pages.WinRafflePage
                .SelectTicketBundle(bundleWinNumber)
                .VerifyPriceOfAddedOrder(bunleWinPrice);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn();
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders); ;
        }

        [Test, Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchaseTicketsWin()
        {
            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            Pages.Common
                .CloseCookiesPopUp();

            Pages.WinRafflePage
                .OpenWinRaffle();

            int bundleWinNumber = RandomHelper.RandomIntNumber(3);
            string bunleWinPrice = Pages.WinRafflePage.textTicketBundlePrice[bundleWinNumber].Text;

            Pages.WinRafflePage
                .SelectTicketBundle(bundleWinNumber)
                .VerifyPriceOfAddedOrder(bunleWinPrice);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn();
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders); ;
        }

        [Test, Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchaseTicketsFromPageDiscount()
        {
            string name = "";
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.PageDiscountPage
                .OpenPageDiscount();

            int bundleNumber = RandomHelper.RandomIntNumber(3);
            string bunlePrice = Pages.PageDiscountPage.textTicketBundlePrice[bundleNumber].Text;

            Pages.PageDiscountPage
                .SelectTicketBundle(bundleNumber)
                .VerifyPriceOfAddedOrder(bunlePrice);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn();
            int countOrders = Pages.Basket.GetOrderCount();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders); ;
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void AddDreamHomeToBasketAndPurchaseSubscription()
        {
            string name = "";
            double value = 0;
            int quantity = 0;
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < 1; q++)
                {
                    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                    WaitUntil.WaitSomeInterval(250);
                }

            }
            Pages.Subscription
                .OpenSubscriptionPage()
                .AddTenSubscriptionToBasket(out value, out quantity);
            Pages.Basket
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < 1; q++)
                {
                    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                    WaitUntil.WaitSomeInterval(250);
                }

                Pages.Basket
                    .ClickCartBtn();
                Pages.Basket
                    .MakeAPurchaseAsAuthorizedUser();
                Pages.ThankYou
                    .VerifyThankYouPageIsDisplayed();
            }

            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
            var user = AppDbHelper.Users.GetUserByEmail(response.User.Email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
        }

    }

    [TestFixture]
    [AllureNUnit]
    public class CheckingTextsOnPages : TestBaseWeb
    {
        [Test, Category("Home")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        //[Ignore("")]
        public void VerifiedHomePage()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Home
                .OpenHomePage(WebEndpoints.WEBSITE_HOST)
                .VerifySecondaryBannerTitle()
                .VerifySecondaryBannerSubtitle()
                .VerifyBottomSliderTitle()
                .VerifyBottomSliderSubitle();
            Element.Action(Keys.End);
            Pages.Home
                .VerifyInfoBlockTitles()
                .VerifyInfoBlockParagraphs()
                .VerifyHowItWorksTitle()
                .VerifyHowItWorksParagraph()
                .VerifyHowItWorksStepsTitles()
                .VerifyHowItWorksStepsParagraphs();

        }


        [Test, Category("Postal")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Postal Page")]
        public void VerifyTextOnPostalPage()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenPostPage();
            Pages.Postal
                .VerifyDisplayingParagraphs();
        }

        [Test, Category("Privacy Policy and Terms & Conditions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Terms&Conditions Page")]
        public void VerifyTextOfTermsAndConditions()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Footer
                .OpenTerms();
            var actualTerms = Pages.TermsAndConditions.GetTextTerms();
            Pages.Header
                .OpenHomePage(WebEndpoints.WEBSITE_HOST);
            Pages.Footer
                .OpenPrivacy();
            var actualPrivacy = Pages.TermsAndConditions.GetTextPrivacy();

            Pages.TermsAndConditions
                .VerifyDisplayingParagraphs(actualTerms, actualPrivacy);
        }

        [Test, Category("Footer")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifiedDisplayingFooterElements()
        {
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Home
                .OpenHomePage(WebEndpoints.WEBSITE_HOST);
            Pages.Footer
                .VerifyIsDisplayedFooterTitle()
                .VerifyIsDisplayedFooterParagraph()
                .VerifyIsDisplayedContactLinks()
                .VerifyIsDisplayedSponsorLinks();
            Pages.Header
                .OpenWinnersPage();
            Pages.Footer
                .VerifyIsDisplayedFooterTitle()
                .VerifyIsDisplayedFooterParagraph()
                .VerifyIsDisplayedContactLinks()
                .VerifyIsDisplayedSponsorLinks();
            Pages.Header
                .OpenCartPage();
            Pages.Footer
                .VerifyIsDisplayedFooterTitle()
                .VerifyIsDisplayedFooterParagraph()
                .VerifyIsDisplayedContactLinks()
                .VerifyIsDisplayedSponsorLinks();
            Pages.Header
                .OpenPostPage();
            Pages.Footer
                .VerifyIsDisplayedFooterTitle()
                .VerifyIsDisplayedFooterParagraph()
                .VerifyIsDisplayedContactLinks()
                .VerifyIsDisplayedSponsorLinks();
        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifyDisplayedWinners2019()
        {
            var winners = WinnersRequest.GetAllWinners();
            winners = WinnersRequest.GetAllWinnersByYear(winners.Years[0]);
            Pages.Header
                .OpenWinnersPage();
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Winners
                .FilterWinnersByYear(winners.Years[0])
                .ScrollToEndOfList(winners.AllCount)
                .VerifyDisplayedFilteredWinnersByYear(winners);

        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifyDisplayedWinners2020()
        {
            var winners = WinnersRequest.GetAllWinners();
            winners = WinnersRequest.GetAllWinnersByYear(winners.Years[1]);
            Pages.Header
                .OpenWinnersPage();
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Winners
                .FilterWinnersByYear(winners.Years[1])
                .ScrollToEndOfList(winners.AllCount)
                .VerifyDisplayedFilteredWinnersByYear(winners);

        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifyDisplayedWinners2021()
        {
            var winners = WinnersRequest.GetAllWinners();
            winners = WinnersRequest.GetAllWinnersByYear(winners.Years[2]);
            Pages.Header
                .OpenWinnersPage();
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Winners
                .FilterWinnersByYear(winners.Years[2])
                .ScrollToEndOfList(winners.AllCount)
                .VerifyDisplayedFilteredWinnersByYear(winners);

        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifyDisplayedCTACards()
        {
            var winners = WinnersRequest.GetAllWinners();
            Pages.Header
                .OpenWinnersPage();
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Winners
                .ScrollToEndOfList(winners.AllCount)
                .VerifyDisplayedCTAButtons(winners.AllCount);

        }
    }

    [TestFixture]
    [AllureNUnit]
    public class ErrorPaymentTests : TestBaseWeb
    {
        #region Test displaying of error messages

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void InsufientFundsError()
        {
            #region Preconditions
            string name = "";
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01, bundles);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 151);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.66666666, 2, bundles);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void RestrictedCardError()
        {
            #region Preconditions
            string name = "";
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01, bundles);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 62);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.66666666, 2, bundles);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void BadTrackDataError()
        {
            #region Preconditions

            string name = "";
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01, bundles);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 154);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.66666666, 2, bundles);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void SecurityVioLationError()
        {
            #region Preconditions
            string name = "";
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01, bundles);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 163);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.66666666, 2, bundles);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void InvalidTransactionError()
        {
            #region Preconditions
            string name = "";
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01, bundles);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 12);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.66666666, 2, bundles);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        #endregion
    }

    [TestFixture]
    [AllureNUnit]
    public class Validation : TestBaseWeb
    {
        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("ValidationOnSignInPage")]
        public void VerifyValidationOnSignInPage()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            string name = "";
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .VerifyValidationOnSignIn(response);
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("ValidationOnSignUpPage")]
        public void VerifyFirstnameValidationOnSignUpPage()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .VerifyFirstnameValidationOnSignUp();

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("ValidationOnSignUpPage")]
        public void VerifyLastnameValidationOnSignUpPage()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .VerifyLastnameValidationOnSignUp();

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("ValidationOnSignUpPage")]
        public void VerifyEmailValidationOnSignUpPage()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .VerifyEmailValidationOnSignUp();

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("ValidationOnSignUpPage")]
        public void VerifyPasswordValidationOnSignUpPage()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .VerifyPasswordValidationOnSignUp();

        }

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("ValidationOnProfilePage")]
        public void VerifyValidationPersonalDetailsOnProfilePage()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            string name = "";
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn(out name);
            Pages.Profile
                .ClickEditPersonalDataBtn()
                .VerifyValidationOnProfilePersonalDetails();
            Pages.Profile
                .EditPersonalData()
                .VerifyDisplayingSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("ValidationOnProfilePage")]
        public void VerifyValidationPasswordOnProfilePage()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            string name = "";
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn(out name);
            Pages.Profile
                .ClickEditPasswordBtn()
                .VerifyValidationOnProfilePassword();
            Pages.Profile
                .EditPassword()
                .VerifyUpdatePasswordSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("ValidationOnProfilePage")]
        public void VerifyValidationAccountDetailsOnProfilePage()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            string name = "";
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn(out name);
            Pages.Profile
                .ClickEditAccountBtn()
                .VerifyValidationOnProfileAccountDetails();
            Pages.Profile
                .EditAccountData()
                .VerifyDisplayingSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }
    }

}