using ApiTests.BASE;
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
using RaffleAutomationTests.APIHelpers.Web.Weekly;
using RaffleAutomationTests.Helpers;
using RestSharp;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace API
{
    [TestFixture]
    public class ApiTests : TestBaseApi
    {
        [Test]

        public void Demo()
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

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.66666666, 2, bundles);

            //var response = SignUpRequest.RegisterNewUser();
            //var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            //var basketOrders = BasketRequest.GetBasketOrders(token);
            //BasketRequest.DeleteOrders(token, basketOrders);
            //var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            //DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 151);
            //WaitUntil.WaitSomeInterval(250);

            #endregion

        }

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
        public static void RegisterNewUser()
        {
            var response = SignUpRequest.RegisterNewUser();
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
}