using ApiTests.BASE;
using Chilkat;
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
        [Ignore("Demo test")]
        
        public void Demotest()
        {
            string name = String.Empty;
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 20);
            WaitUntil.WaitSomeInterval(250);

            //Pages.Common
            //    .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(token.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn();
            for (int i = 1000; i <= 9999; i++)
            {
                string combination = i.ToString("D4");
                Pages.Basket
                .EnterCardDetails(combination)
                .ClickPayNowBtn()
                .ConfirmPurchaseStage()
                .VerifyErrorMessageIsDisplayed()
                .ClickCheckoutNowBtn()
                .IsErrorDisplayed(combination);
            }
            
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
            string? name = string.Empty;
            SignUpResponse? response = null;
            SignUpRequest.RegisterNewUser(out response);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn(out name);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox");

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
            AppDbHelper.Users.DeleteTestUserData("@putsbox");
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
            AppDbHelper.Users.DeleteTestUserData("@putsbox");
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn(out string name);
            Pages.Profile
                .ClickEditPersonalDataBtn()
                .EditPersonalData()
                .VerifyDisplayingSuccessfullToaster()
                .ClickEditPasswordBtn()
                .EditPassword()
                .VerifyUpdatePasswordSuccessfullToaster()
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .ClickForgotPassword();
            Pages.ResetPassword
                .RequestForgotPassword(response.User.Email)
                .VerifySuccessfullMessageAppeared(response.User.Email)
                .ClickOkBtn()
                .GoToResetPassLink(response.User.Email)
                .GetResetPassword();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.NEW_PASWORD)
                .VerifyIsSignIn(out string name);

            #region Postconditions
            AppDbHelper.Users.DeleteTestUserData("@putsbox");
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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
            AppDbHelper.Users.DeleteTestUserData("@putsbox");
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
        public void PurchaseTwentyFivePoundsSubscriptionAsAuthorizedUserLive()
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
                .AddTwentyFiveSubscriptionToBasket(out value, out quantity);
            Pages.Basket
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
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
        public void PauseSubscriptionAsAuthorizedUser()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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
                .OpenDreamHomeHistoryList()
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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
                .OpenDreamHomeHistoryList()
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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
                .OpenDreamHomeHistoryList()
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
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
                .VerifyAddingTickets((double?)subscriptionsList.TotalCost / 100 ?? throw new Exception("TotalCost is null."), 2);

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
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails

            string name = string.Empty;
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();
            var activeRaffles = DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();

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
                .VerifyAddingTickets((double?)subscriptionsList.TotalCost / 100 ?? throw new Exception("TotalCost is null."), activeRaffles.Count);

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
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateOneClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails

            string name = string.Empty;
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();
            var activeRaffles = DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();

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
                .VerifyAddingTickets((double?)subscriptionsList.TotalCost / 100 ?? throw new Exception("TotalCost is null."), activeRaffles.Count);
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
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
            Subscriptions.DeleteSubscriptions();
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails

            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();

            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x=>x.EndsAt > DateTime.Now).Select(x=>x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            for (int i = 0; i < 1; i++)
            {
                AppDbHelper.Insert.InsertUser(raffle.FirstOrDefault(), email);

            }
            var users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com").FirstOrDefault();
            AppDbHelper.Insert.InsertSubscriptionsToUsers(users, raffle.FirstOrDefault(), subscriptionsModel);

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
                .WaitUntilScriptRuning(raffle.Count)
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(1)
                .VerifyAddingTickets((double?)subscriptionsList.TotalCost / 100 ?? throw new Exception("TotalCost is null."), raffle.Count);


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
            string name = "";
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscription = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.FirstOrDefault();
            var activeRaffles = DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Basket
                .MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscription.Id);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .VerifyInitialEmailUnauth(email,
                                    name,
                                    subscription.NumOfTickets + subscription.Extra ?? throw new Exception("NumOfTickets is null."),
                                    (double?)subscription.TotalCost ?? throw new Exception("TotalCost is null."),
                                    "None Selected",
                                    activeRaffles.Count);
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
            var raffle = DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();

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
            PutsBox
                .ClearEmailHistory(email);
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .PauseSubscription();
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
            PutsBox
                .ClearEmailHistory(email);
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenSubscriptionInProfile()
                .CancelSubscription()
                .VerifyCancelationEmail(email, name);
            

        }
    }

    [TestFixture]
    [AllureNUnit]
    public class CheckingEmailAfterScriptRunning : TestBaseApi
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

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            string name = string.Empty;
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            int pauseEndReminder = 168;
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x=>x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);
            AppDbHelper.Insert.InsertReminderSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEndReminder);
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

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            Subscriptions.DeleteSubscriptionsByUserId(users);
            Orders.DeleteOrdersByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, 50);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
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

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            Subscriptions.DeleteSubscriptionsByUserId(users);
            Orders.DeleteOrdersByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, -50);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
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

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, 50);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                Elements.GgetAllEmailData(user.Email, out List<PutsboxEmail>? emailsList);
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

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, -50);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                Elements.GgetAllEmailData(user.Email, out List<PutsboxEmail>? emailsList);
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);
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
        public void VerifyActiveSubscriptionWithInactiveRaffle()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, 50);
            dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out raffleCloseEarlier);
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffleCloseEarlier);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffleCloseEarlier, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);
            DreamHome.DeactivateDreamHome(raffleCloseEarlier);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x=>x).ToList();

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                Elements.GgetAllEmailData(user.Email, out List<PutsboxEmail>? emailsList);
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
        //[Test, Category("Unauthorized")]
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
            string email = string.Concat("qatester", DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss"), "@putsbox.com");
            Pages.Home
                .AddTicketsToBasket(0);
            Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder)
                .MakeAPurchaseAsUnauthorizedUser(email);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Elements
                .GoToActivationLink(email);
            Pages.Activate
                .ActivateUser(email)
                .VerifySuccessfullActivation();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD)
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
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");
            #endregion

        }

        //[Test, Category("Unauthorized")]
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
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");
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
            Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder)
                .MakeAPurchaseAsUnauthorizedUser(email);
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed()
                .ClickActivateMyAccount();
            Pages.Activate
                .ActivateUser(email)
                .VerifySuccessfullActivation();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(email, Credentials.PASSWORD)
                .VerifyIsSignIn(out name);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);



            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            //UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");
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
            Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder);
            
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
            //UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);

            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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
            Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder);
            
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
                .VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

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
        public void PurchaseDreamHome()
        {
            #region Update two active dreamhomes

            string name = "";
            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateOneClosedDreamHome(dreamhomeList, -3600, 3600);

            #endregion

            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
            Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder);
            
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

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
        public void PurchaseTwoActiveDreamHome()
        {
            #region Update two active dreamhomes
            string name = string.Empty;
            int addFirstStartHours = -3600;
            int addFirstEndHours = 3600;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 80;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            #endregion

            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
            Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder);
            
            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

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
        public void SignUpAddTicketsMakePurchase()
        {
            string name = "";
            Pages.Common
                .CloseCookiesPopUp();
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
                .ClickCartBtn()
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder)
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            DreamHomeOrderRequestWeb
                .MultipleAddDreamhomeTickets(token, prizesList.FirstOrDefault(), 15);
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);
            Pages.Basket
                .ClickCartBtn()
                .GetOrderCount(out countOrders)
                .GetOrderTotal(out totalOrder)
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

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
        public void SignUpAddReferralsAndTicketsMakePurchase()
        {
            string name = String.Empty;
            Pages.Common
                .CloseCookiesPopUp();
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
                .ClickCartBtn()
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder)
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
                SignInRequestWeb.MakeSignIn(responseReferral.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? tokenReferral);
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
                    .ClickCartBtn()
                    .GetOrderCount(out countOrders)
                    .GetOrderTotal(out double totalOrderReferral)
                    .MakeAPurchaseAsAuthorizedUser();
                Pages.ThankYou
                    .VerifyThankYouPageIsDisplayed();
                Pages.Profile
                    .OpenMyTicketsCompetitions()
                    .OpenDreamHomeHistoryList()
                    .VerifyAddingTickets(totalOrderReferral, countOrders);
                Pages.Header
                    .DoLogout();

                #region Postconditions

                AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

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
        public void GetPurchaseDreamHome()
        {
            string name = "";
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
                Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder);

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

            #region Postconditions

            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
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
            string name = string.Empty;
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            Pages.Common
                .CloseCookiesPopUp();
            DreamHomeOrderRequestWeb
                .AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            Pages.PageDiscountPage
                .OpenPageDiscount()
                .SelectTicketBundle(out string bunlePrice)
                .VerifyPriceOfAddedOrder(bunlePrice);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.WinRafflePage
                .OpenWinRaffle()
                .SelectTicketBundle(out string bunleWinPrice)
                .VerifyPriceOfAddedOrder(bunleWinPrice);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn();
            Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder)
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
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
            Pages.Common
                .CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";

            Pages.WinRafflePage
                .OpenWinRaffle()
                .SelectTicketBundle(out string bunleWinPrice)
                .VerifyPriceOfAddedOrder(bunleWinPrice);
            Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder)
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

            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.PageDiscountPage
                .OpenPageDiscount()
                .SelectTicketBundle(out string bunlePrice)
                .VerifyPriceOfAddedOrder(bunlePrice);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn(out name);
            Pages.Basket
                .ClickCartBtn();
            Pages.Basket
                .GetOrderCount(out int countOrders)
                .GetOrderTotal(out double totalOrder);

            Pages.Basket
                .MakeAPurchaseAsAuthorizedUser();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .ScrollToEndOfHistoryList(countOrders)
                .VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

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
        public void AddDreamHomeToBasketAndPurchaseSubscription()
        {
            string name = "";
            double value = 0;
            int quantity = 0;
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
            
            #region Postconditions

            //AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
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
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
                .ClickPayNowBtn()
                .VerifyErrorMessageIsDisplayed()
                .ClickCheckoutNowBtn()
                .VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.INSUFFICIENT_FUNDS);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
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
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
                .ClickPayNowBtn()
                .VerifyErrorMessageIsDisplayed()
                .ClickCheckoutNowBtn()
                .VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.RESTRICTED_CARD);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
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

            string name = string.Empty;
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
                .ClickPayNowBtn()
                .VerifyErrorMessageIsDisplayed()
                .ClickCheckoutNowBtn()
                .VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.BAD_TRACK_DATA);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
            //var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            //basketOrders = BasketRequest.GetBasketOrders(token);
            //BasketRequest.DeleteOrders(token, basketOrders);
            //UsersRequest.DeleteLastUser(tokenAdmin, users);

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
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
                .ClickPayNowBtn()
                .VerifyErrorMessageIsDisplayed()
                .ClickCheckoutNowBtn()
                .VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.SECURITY_VIOLATION);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
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
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
                .ClickPayNowBtn()
                .VerifyErrorMessageIsDisplayed()
                .ClickCheckoutNowBtn()
                .VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.INVALID_TRANSACTION);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
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