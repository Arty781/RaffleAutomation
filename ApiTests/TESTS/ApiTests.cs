using ApiTests.BASE;
using NUnit.Framework;
using RaffleAutomationTests.APIHelpers.Admin;
using RaffleAutomationTests.APIHelpers.Admin.UsersPage;
using RaffleAutomationTests.APIHelpers.Web;
using RaffleAutomationTests.APIHelpers.Web.ForgotPasswordWeb;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;
using RaffleAutomationTests.APIHelpers.Web.Subscriptions;
using RaffleAutomationTests.APIHelpers.Web.Weekly;
using RaffleAutomationTests.Helpers;
using Telegram.Bot.Types;
using static RaffleAutomationTests.Helpers.AppDbHelper;

namespace API
{
    [TestFixture]
    public class DemoTests : TestBaseApi
    {
        [Test]

        public void Demo()
        {
            #region Preconditions

            //var response = SignUpRequest.RegisterNewUser();
            //var s = SubscriptionsRequest.GetEmailsCount(response.User.Email);
            //SubscriptionsRequest.CheckEmailsCountFor17Minutes(s, response.User.Email);
            //s = SubscriptionsRequest.GetEmailsCount(response.User.Email);
            //string email = response.User.Email;
            //Elements.GgetAllEmailData(email);
            #endregion

        }
    }


    [TestFixture]
    public class ApiTests : TestBaseApi
    {


        [Test]
        public static void AddTicketsToBasket()
        {
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var competitionId = CountdownRequestWeb.GetWeeklyPrizesCompetitionId(token);
            var listOfWeeklyPrizes = CountdownRequestWeb.GetWeeklyPrizes(token, competitionId[2].Id);
            for (int i = 0; i < 5; i++)
            {
                WeeklyPrizesRequestWeb.AddWeeklyPrizes(token, listOfWeeklyPrizes, "151");
            }

        }

        [Test]
        public static void DeleteUsers()
        {
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(tokenAdmin, "");
            foreach (var user in users.Users)
            {
                if (user.Email.Contains("@putsbox.com"))
                {
                    UsersRequest.DeleteUser(tokenAdmin, user.Id);
                }

            }

        }

        [Test]
        public static void Registerreferrals()
        {
            var response = SignUpRequest.RegisterNewUser();
            for (int i = 0; i < 10; i++)
            {
                SignUpRequest.RegisterNewReferral(response.User.ReferralKey);
            }

        }

        [Test]
        public static void AddCreditsToUserForVerifyingOfExpirationEmailsTomorrow()
        {
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(token, response.User.Email);
            UsersRequest.AddCreditsToUser(token, users.Users.FirstOrDefault().Id, "tomorrow");
        }

        [Test]
        [Repeat(250)]
        public static void RegisterNewUser()
        {
            var response = SignUpRequest.RegisterNewUser();
            //var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
        }

        [Test]
        public static void ResetPassword()
        {
            var response = SignUpRequest.RegisterNewUser();
            RequestForgotPassword.ForgotPassword(response.User.Email);
            string s = PutsBox.GetLinkFromEmailWithValue(response.User.Email, "Reset Password").Substring(29);
            var token = RequestForgotPassword.GetResetLink(s).Substring(47);
            var reset = RequestForgotPassword.ResetPassword(token);
            Console.WriteLine(reset.Message);
        }
    }

    [TestFixture]
    public class DbApi : TestBaseApi
    {
        [Test]

        public void RemoveSubscriptionsByUserId()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);


        }

        [Test]

        public void RemoveSubscriptionsOrders()
        {            
            AppDbHelper.Orders.DeleteSubscriptionsOrders();
        }

        [Test]

        public void InsertSubscriptionsByUsersEmail()
        {
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles();
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@xitroo.com")).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertSubscriptionsToUsers(users, raffle, subscriptionsModel);

        }

        [Test]

        public void UpdateSubscriptionsToNextPurchase()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@xitroo.com")).Select(x => x).ToList();            
            foreach (var user in users)
            {
                AppDbHelper.Subscriptions.UpdateSubscriptionDateByIdToNextPurchase(user);
            }

        }

        [Test]

        public void DeleteUsersByEmail()
        {
            //var users = AppDbHelper.Users.GetUserByEmailpattern("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");
        }

        [Test]
        public void CreateUsersAndAddSubscription()
        {
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            for (int i = 0; i < 1; i++)
            {
                AppDbHelper.Insert.InsertUser(raffle);
            }
            var users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertSubscriptionsToUsers(users, raffle, subscriptionsModel);
            
        }

        [Test]
        public void AddUsers()
        {
            var raffle = DreamHome.GetAciveRaffles();
            for (int i = 0; i < 1; i++)
            {
                Insert.InsertUser(raffle);
            }

        }

        [Test]
        public void CreateUsersAndAddSubscriptionForFailPayment()
        {
            #region Preconditions

            var email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fff"), "@putsbox.com");

            var raffle = DreamHome.GetAciveRaffles();
            Insert.InsertSubscriptionModel(ErrorTotalCost.ERROR_BAD_TRACK_DATA);
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            Insert.InsertUser(raffle, email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            Insert.InsertSubscriptionsToUserForFailPayment(user, raffle, subscriptionsModel);
            EmailVerificator.VerifyPurchaseFailedEmail(email);

            #endregion

            #region PostConditions

            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(user);
            AppDbHelper.Users.DeleteUsersByEmail(email);
            AppDbHelper.Subscriptions.DeleteLastSubscriptionModel(subscriptionsModel.LastOrDefault());

            #endregion


        }



        [Test]

        public void RemoveSubscriptions()
        {
            
            AppDbHelper.Subscriptions.DeleteSubscriptions();


        }
    }
}