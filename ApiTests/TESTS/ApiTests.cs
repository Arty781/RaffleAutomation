using ApiTests.BASE;
using Chilkat;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using NUnit.Framework;
using PutsboxWrapper;
using RaffleAutomationTests.APIHelpers.Admin;
using RaffleAutomationTests.APIHelpers.Admin.DreamHomePage;
using RaffleAutomationTests.APIHelpers.Admin.UsersPage;
using RaffleAutomationTests.APIHelpers.Web;
using RaffleAutomationTests.APIHelpers.Web.Basket;
using RaffleAutomationTests.APIHelpers.Web.ForgotPasswordWeb;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;
using RaffleAutomationTests.APIHelpers.Web.Subscriptions;
using RaffleAutomationTests.APIHelpers.Web.Weekly;
using RaffleAutomationTests.Helpers;
using RestSharp;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace API
{
    [TestFixture]
    public class DemoTests : TestBaseApi
    {
        [Test]

        public void Demo()
        {
            #region Preconditions

            var raffle = AppDbHelper.DreamHome.GetAciveRaffles();
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach(var user in users)
            {
                AppDbHelper.Users.DeleteUsersByEmail(user.Email);
            }            
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
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
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                AppDbHelper.Users.DeleteUsersByEmail(user.Email);
            }
        }

        [Test]
        public void CreateUsersAndAddSubscription()
        {
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            for (int i = 0; i < 20; i++)
            {
                AppDbHelper.Insert.InsertUser(raffle);
            }
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Insert.InsertSubscriptionsToUsers(users, raffle, subscriptionsModel);
            
        }
    }
}