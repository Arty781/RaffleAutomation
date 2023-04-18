using OpenQA.Selenium.Interactions;
using RaffleAutomationTests.APIHelpers.Web.Subscriptions;
using RaffleAutomationTests.PageObjects.WebSitePages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RaffleHouseAutomation.WebSiteTests
{
    [TestFixture]
    [AllureNUnit]
    public class Demo : TestBaseWeb
    {
        [Test]
        
        public void Demotest()
        {
            #region Preconditions

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
                .VerifyIsSignIn();
            Pages.Subscription
                .OpenSubscriptionPage()
                .AddTenSubscriptionToBasket();
            Pages.Basket
                .EnterCardDetails()
                .SelectCharity()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();

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
        [AllureSubSuite("Login")]
        public void LoginByEmail()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();

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
        [AllureSubSuite("Payment")]
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
        [AllureSubSuite("Payment")]
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
        [AllureSubSuite("Payment")]
        public void EditUserData()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn();
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
        [AllureSubSuite("Payment")]
        public void ResetPassword()
        {
            #region Preconditions
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
                .VerifyIsSignIn();

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
                .VerifyIsSignIn();

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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
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
        public void PurchaseTenPoundsSubscriptionAsAuthorizedUser()
        {
            var response = SignUpRequest.RegisterNewUser();
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Subscription
                .OpenSubscriptionPage()
                .AddTenSubscriptionToBasket();
            Pages.Basket
                .EnterCardDetails()
                .SelectCharity()
                .ClickPayNowBtn();
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
        public void PurchaseTwentyFivePoundsSubscriptionAsAuthorizedUser()
        {
            var response = SignUpRequest.RegisterNewUser();
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
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

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
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
                .PauseSubscription();
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

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
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
                .UnpauseSubscription();
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
            var response = SignUpRequest.RegisterNewUser();
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
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
                .CancelSubscription();
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
            var response = SignUpRequest.RegisterNewUser();
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Subscription
                .OpenSubscriptionPage()
                .AddTenSubscriptionToBasket();
            Pages.Basket
                .EnterCardDetails()
                .SelectCharity()
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
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Subscription
                .OpenSubscriptionPage()
                .AddTenSubscriptionToBasket();
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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
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
        public void VerifyInitialSubscriptionEmailAsUnauthorizedUser()
        {
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            var emailInitial = Elements.GgetHtmlBody(email);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.INITIAL_UNAUTH);

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
                .VerifyIsSignIn();
            Elements
                .ClearEmailHistory(email);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .PauseSubscription();
            var emailPause = Elements.GgetHtmlBody(email);
            ParseHelper.ParseHtmlAndCompare(emailPause, SubscriptionEmailsTemplate.PAUSE);

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
                .VerifyIsSignIn();
            Elements
                .ClearEmailHistory(email);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .PauseSubscription();
            Elements
                .ClearEmailHistory(email);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .UnpauseSubscription();
            var emailPause = Elements.GgetHtmlBody(email);
            ParseHelper.ParseHtmlAndCompare(emailPause, SubscriptionEmailsTemplate.UNPAUSE);

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
                .VerifyIsSignIn();
            Elements
                .ClearEmailHistory(email);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .CancelSubscription();
            var emailPause = Elements.GgetHtmlBody(email);
            ParseHelper.ParseHtmlAndCompare(emailPause, SubscriptionEmailsTemplate.CANCEL);

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
        public void VerifyNextPaymentSubscriptionEmailAfterRunScript()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);
                Assert.That(ordersList.Count >= 1, $"New order is not created, current subscription orders count is \"{ordersList.Count}\"");

                foreach (var subscription in subscriptionList)
                {
                    Assert.IsNotNull(subscription.Refference);
                    Assert.IsNotNull(subscription.CardSource);
                    Assert.IsNotNull(subscription.CheckoutId);
                }
                var emailPause = Elements.GgetHtmlBody(user.Email);
                ParseHelper.ParseHtmlAndCompare(emailPause, SubscriptionEmailsTemplate.INITIAL_AUTH);
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
        public void VerifyUnpauseSubscriptionEmailAfterRunScript()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);
                Assert.That(subscriptionList.LastOrDefault().Status == "ACTIVE", $"Subscription staus is not changed, the status is \"{subscriptionList.LastOrDefault().Status}\"");
                foreach (var subscription in subscriptionList)
                {
                    Assert.IsNotNull(subscription.Refference);
                    Assert.IsNotNull(subscription.CardSource);
                    Assert.IsNotNull(subscription.CheckoutId);
                }
                var emailPause = Elements.GgetHtmlBody(user.Email);
                ParseHelper.ParseHtmlAndCompare(emailPause, SubscriptionEmailsTemplate.UNPAUSE);
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
        public void VerifySevenDaysPriorSubscriptionEmailAfterRunScript()
        {
            string email = "sevendaysprior";
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            Assert.That(subscriptionList.LastOrDefault().Status == "PAUSED", $"Subscription staus is not changed, the status is \"{subscriptionList.LastOrDefault().Status}\"");
            foreach (var subscription in subscriptionList)
            {
                Assert.IsNotNull(subscription.Refference);
                Assert.IsNotNull(subscription.CardSource);
                Assert.IsNotNull(subscription.CheckoutId);
            }
            var emailPause = Elements.GgetHtmlBody(user.Email);
            ParseHelper.ParseHtmlAndCompare(emailPause, SubscriptionEmailsTemplate.UNPAUSE);

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
            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            Pages.Home
                .AddTicketsToBasket(0);
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
            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            Pages.Home
                .AddTicketsToBasket(0);
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
            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            Pages.Home
                .AddTicketsToBasket(2);
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
            var response = SignUpRequest.RegisterNewUser();
            Pages.Common
                    .CloseCookiesPopUp();
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                    .OpenSignInPage();
            Pages.SignIn
                    .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
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
            Pages.Basket
                .ClickCheckoutNowBtn()
                .SelectCharity()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
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
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            //var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            //for (int i = 0; i < 10; i++)
            //{
            //    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            //    WaitUntil.WaitSomeInterval(250);
            //}

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Home
                .AddTicketsToBasket(1);
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
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
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            for (int i = 0; i < 5; i++)
            {
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                WaitUntil.WaitSomeInterval(250);
            }
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder);
            Pages.Basket
                .ClickCartBtn();
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
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
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder);
            Pages.Header
                .DoLogout();
            for (int i = 0; i < 10; i++)
            {
                var responseReferral = SignUpRequest.RegisterNewReferral(response.User.ReferralKey);
                var tokenReferral = SignInRequestWeb.MakeSignIn(responseReferral.User.Email, Credentials.PASSWORD);
                var prizesListReferral = CountdownRequestWeb.GetDreamHomeCountdown(tokenReferral);
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(tokenReferral, prizesListReferral.FirstOrDefault());
                WaitUntil.WaitSomeInterval(250);
                Pages.Header
                    .OpenSignInPage();
                Pages.SignIn
                    .EnterLoginAndPass(responseReferral.User.Email, Credentials.PASSWORD);
                Pages.SignIn
                .VerifyIsSignIn();
                Pages.Basket
                    .ClickCartBtn();
                double totalOrderReferral = Pages.Basket.GetOrderTotal();
                Pages.Basket
                    .MakeAPurchaseAsAuthorizedUser();
                Pages.ThankYou
                    .VerifyThankYouPageIsDisplayed();
                Pages.Profile
                    .OpenMyTicketsCompetitions()
                    .OpenDreamHomeHistoryList()
                    .VerifyAddingTickets(totalOrderReferral);
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
                .VerifyIsSignIn();
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < RandomHelper.RandomIntNumber(2); q++)
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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
            Pages.Basket
                    .ClickCartBtn();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
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
        public void PurchaseTicketsWin()
        {
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
                .VerifyIsSignIn();
            Pages.Basket
                    .ClickCartBtn();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
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
        public void PurchaseTicketsFromPageDiscount()
        {
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
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn();
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
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
                .VerifySecondaryBannerSubitle()
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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
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
                .VerifyIsSignIn();
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
        [AllureSubSuite("Login")]
        public void VerifyValidationOnSignInPage()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            
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
                .VerifyIsSignIn();

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
        [AllureSubSuite("Payment")]
        public void VerifyValidationOnSignUpPage()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .VerifyValidationOnSignUp();
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

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void VerifyValidationOnProfilePage()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn();
            Pages.Profile
                .ClickEditPersonalDataBtn()
                .VerifyValidationOnProfilePersonalDetails();
            Pages.Profile
                .EditPersonalData()
                .VerifyDisplayingSuccessfullToaster();
            Pages.Profile
                .ClickEditPasswordBtn()
                .VerifyValidationOnProfilePassword();
            Pages.Profile
                .EditPassword()
                .VerifyUpdatePasswordSuccessfullToaster();
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