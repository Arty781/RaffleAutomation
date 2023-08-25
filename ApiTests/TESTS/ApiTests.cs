using ApiTests.BASE;
using MongoDB.Driver;
using NUnit.Framework;
using RaffleAutomationTests.APIHelpers.Admin;
using RaffleAutomationTests.APIHelpers.Admin.DreamHomePage;
using RaffleAutomationTests.APIHelpers.Admin.UsersPage;
using RaffleAutomationTests.APIHelpers.Web;
using RaffleAutomationTests.APIHelpers.Web.ForgotPasswordWeb;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;
using RaffleAutomationTests.APIHelpers.Web.Subscriptions;
using RaffleAutomationTests.APIHelpers.Web.Weekly;
using RaffleAutomationTests.Helpers;
using RimuTec.Faker;
using System.Globalization;
using System.Linq;
using Telegram.Bot.Types;
using static RaffleAutomationTests.APIHelpers.Web.Subscriptions.SubsriptionsResponse;
using static RaffleAutomationTests.Helpers.AppDbHelper;

namespace API
{
    [TestFixture]
    public class DemoTests : TestBaseApi
    {
        [Test]

        public void Demo()
        {
            var customDayOrder = new Dictionary<string, int>
            {
                { "Monday", 1 },
                { "Tuesday", 2 },
                { "Wednesday", 3 },
                { "Thursday", 4 },
                { "Friday", 5 },
                { "Saturday", 6 },
                { "Sunday", 7 }
            };

            var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
            var database = client.GetDatabase(DbConnection.DB_STAGING);
            var collection = database.GetCollection<DbModels.Orders>("orders");
            var collection2 = database.GetCollection<DbModels.Orders>("archiveorders");
            var filter = Builders<DbModels.Orders>.Filter.And(
                Builders<DbModels.Orders>.Filter.Gte("purchaseDate", new DateTime(2023, 2, 07)),
                Builders<DbModels.Orders>.Filter.Eq("paymentStatus", "ACCEPTED"),
                Builders<DbModels.Orders>.Filter.Nin("orderType","SUBSCRIPTION")
            );
            var orders = collection.FindSync(filter).ToList();
            var archiveorders = collection2.FindSync(filter).ToList();
            var combinedData = new List<DbModels.Orders>();
            combinedData.AddRange(orders);
            combinedData.AddRange(archiveorders);

            var groupedData = combinedData
            .GroupBy(record => (record.PurchaseDate.Value.Date, record.PurchaseDate.Value.Hour))
            .OrderBy(group => group.Key.Date)
            .ThenBy(group => group.Key.Hour)
            .Select(group => new
            {
                DateAndHour = $"{group.Key.Date:yyyy-MM-dd} {group.Key.Hour:00}:00:00",
                Count = group.Count()
            })
            .OrderByDescending(rec => rec.Count)
            .ToList();
            string path = Browser.RootPath() + "output.csv";
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("Date and Time,Total Count");

                foreach (var result in groupedData)
                {
                    writer.WriteLine($"{result.DateAndHour}; {result.Count}"); 
                }
            }

            Console.WriteLine("CSV file saved successfully.");
        }
    }


    [TestFixture]
    public class ApiTests : TestBaseApi
    {


        [Test]
        public static void AddTicketsToBasket()
        {
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
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
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            for (int i = 0; i < 10; i++)
            {
                SignUpRequest.RegisterNewReferral(response.User.ReferralKey);
            }

        }

        [Test]
        public static void AddCreditsToUserForVerifyingOfExpirationEmailsTomorrow()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(token, response.User.Email);
            UsersRequest.AddCreditsToUser(token, users.Users.FirstOrDefault().Id, "tomorrow");
        }

        [Test]
        //[Repeat(250)]
        public static void RegisterNewUser()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out _);
        }

        [Test]
        public static void ResetPassword()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            RequestForgotPassword.ForgotPassword(response.User.Email);
            string s = PutsBox.GetLinkFromEmailWithValue(response.User.Email, "Reset Password")[29..];
            var token = RequestForgotPassword.GetResetLink(s)[47..];
            var reset = RequestForgotPassword.ResetPassword(token);
            Console.WriteLine(reset.Message);
        }

        [Test]
        public static void EditTwoDreamhome()
        {
            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x=>x).ToList();
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, 720, -1);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, 50, -7920);
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

        public void RemoveOrdersAndSubscriptionsByUserId()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            AppDbHelper.Orders.DeleteOrdersByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");
        }

        [Test]

        public void RemoveSubscriptionsOrders()
        {            
            AppDbHelper.Orders.DeleteSubscriptionsOrders();
        }

        [Test]

        public void InsertSubscriptionsByUsersEmail()
        {
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x=>x).ToList();
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@xitroo.com")).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

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
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");
        }

        [Test]
        public void CreateUsersAndAddSubscription()
        {
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x=>x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            for (int i = 0; i < 1; i++)
            {
                AppDbHelper.Insert.InsertUser(raffle);
            }
            var users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

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

            var raffle = DreamHome.GetAciveRaffles().FirstOrDefault();
            Insert.InsertSubscriptionModel(Errors.ErrorTotalCost.ERROR_BAD_TRACK_DATA);
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            Insert.InsertUser(raffle, email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            Insert.InsertSubscriptionsToUserForFailPayment(user, raffle, subscriptionsModel);
            EmailVerificator.VerifyPurchaseFailedEmail(email, user.Name);

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

        [Test]

        public void UpdateTwoActiveDreamhomes()
        {
            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
        }

        [Test]

        public void UpdateOneActiveDreamhome()
        {
            int addFirstStartHours = -3600;
            int addFirstEndHours = 3600;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateOneClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours);
        }

        [Test]

        public void ReplaceUserIdInOrders()
        {
            var users = Users.GetAllUsers().Where(predicate: x => x.Email == "qatester91311@gmail.com").Select(x => x).ToList();
            foreach (var user in users)
            {
                Orders.UpdateOrderByUserId(user, "64c25b1438658f0035652fbf");
            }

        }
    }
}
