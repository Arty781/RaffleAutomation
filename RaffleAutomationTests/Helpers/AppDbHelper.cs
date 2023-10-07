using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json.Bson;
using RaffleAutomationTests.APIHelpers.Admin.DreamHomePage;
using System.Text.RegularExpressions;

namespace RaffleAutomationTests.Helpers
{
    public class ItemNameEqualityComparer : IEqualityComparer<DbModels.Raffle>
    {
        public bool Equals(DbModels.Raffle? x, DbModels.Raffle? y) =>
            // Compare the "Name" property of the items for equality
            x.Title == y.Title;

        public int GetHashCode(DbModels.Raffle obj)
        {
            // Generate a hash code based on the "Name" property
            return obj.Title.GetHashCode();
        }
    }

    public class AppDbHelper
    {
        public class Users
        {
            public static void DeleteTestUserData(string email)
            {
                var users = GetAllUsers().Where(x => x.Email.Contains(email)).Select(x => x).ToList();
                Subscriptions.DeleteSubscriptionsByUserId(users);
                Orders.DeleteOrdersByUserId(users);
                DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");
            }

            public static List<DbModels.UserResponse> GetAllUsers()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserResponse>("users");
                var filter = Builders<DbModels.UserResponse>.Filter.Empty;
                var result = collection.Find(filter).ToList();

                return result;
            }
            public static List<DbModels.UserResponse> GetUserByEmailpattern(string emailPattern)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserResponse>("users");
                var filter = Builders<DbModels.UserResponse>.Filter.Regex(u=>u.Email, new BsonRegularExpression(emailPattern));
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static DbModels.UserResponse GetUserByEmail(string email)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserResponse>("users");
                var filter = Builders<DbModels.UserResponse>.Filter.Regex(u => u.Email, new BsonRegularExpression(email));
                var preresult = collection.Find(filter).ToList();
                var result = preresult.LastOrDefault();
                return result ?? throw new Exception("Content is null.");
            }

            public static DbModels.UserResponse GetOneUserByEmail(string email)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserResponse>("users");
                var filter = Builders<DbModels.UserResponse>.Filter.Regex("email", new BsonRegularExpression(email));
                var result = collection.Find(filter).ToList();
                return result.Select(x=>x).FirstOrDefault() ?? throw new Exception("Content is null.");
            }

            public static DbModels.UserResponse GetUserById(string id)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserResponse>("users");
                var filter = Builders<DbModels.UserResponse>.Filter.Eq(u=>u.Id, new ObjectId(id));
                var result = collection.Find(filter).ToList();
                return result.Select(x => x).FirstOrDefault() ?? throw new Exception("Content is null.");
            }

            public static void UpdateUsers(List<DbModels.UserResponse> users)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserResponse>("users");
                var filter = Builders<DbModels.UserResponse>.Filter.Empty;
                var update = Builders<DbModels.UserResponse>.Update
                    .Set(u=>u.Email, string.Concat("test", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff"), "@dot.co"))
                    .Set(u=>u.Phone, "000000000");
                collection.UpdateMany(filter, update);
            }

            public static void DeleteUsersByUserId(List<DbModels.UserResponse> users)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserResponse>("users");
                for (int i = 0; i < 4000; i++)
                {
                    foreach (var user in users)
                    {
                        var filter = Builders<DbModels.UserResponse>.Filter.Eq(u => u.Id, new ObjectId(user.Id.ToString()));
                        collection.DeleteMany(filter);
                    }
                }

            }

            public static void DeleteUsersByEmail(string email)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserResponse>("users");
                var filter = Builders<DbModels.UserResponse>.Filter.Regex(u => u.Email, new BsonRegularExpression(email));
                collection.DeleteMany(filter);

            }
        }
        
        public class DreamHome
        {

            public static List<DbModels.Raffle> GetAllRaffles()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Raffle>("raffles");
                var filter = Builders<DbModels.Raffle>.Filter.Empty;
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static List<DbModels.Raffle> GetAciveRaffles()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Raffle>("raffles");
                var filter = Builders<DbModels.Raffle>.Filter.Where(x => x.Active == true);
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static List<DbModels.Property> GetAllProperties()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Property>("properties");
                var filter = Builders<DbModels.Property>.Filter.Empty;
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static List<DbModels.Competitions> GetAllCompetitions()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Competitions>("competitions");
                var filter = Builders<DbModels.Competitions>.Filter.Empty;
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static void UpdateActiveDreamHomeToLowestPrice(List<DbModels.Raffle> raffle)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Raffle>("raffles");
                var filter = Builders<DbModels.Raffle>.Filter.Eq("_id", new ObjectId(raffle.First().Id.ToString()));
                var update = Builders<DbModels.Raffle>.Update
                    .Set("ticketPrice", 0.01)
                    .Set("discountCategory", "percent")
                    .Set("discountRates.0.percent", 16.666666666).Set("discountRates.0.newPrice", 0.01)
                    .Set("discountRates.1.percent", 0).Set("discountRates.1.newPrice", 0.01);
                
                collection.UpdateOne(filter, update);
            }

            public static void UpdateActiveDreamHomeToNormalPrice(List<DbModels.Raffle> raffle)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Raffle>("raffles");
                var filter = Builders<DbModels.Raffle>.Filter.Eq("Id", new ObjectId(raffle.First().Id.ToString()));
                var update = Builders<DbModels.Raffle>.Update
                    .Set("ticketPrice", 2)
                    .Set("discountCategory", "percent")
                    .Set("discountRates.0.percent", 16.666666666).Set("discountRates.0.newPrice", 1.6666666)
                    .Set("discountRates.1.percent", 0).Set("discountRates.1.newPrice", 2);
                collection.UpdateOne(filter, update);
            }

            public static void ActivateOneClosedDreamHome(List<DbModels.Raffle> raffle, int addHoursStartFisrtDH, int addHoursEndFisrtDH)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (i == 0)
                    {
                        var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                        var database = client.GetDatabase(DbConnection.DB_STAGING);
                        var collection = database.GetCollection<DbModels.Raffle>("raffles");
                        var filter = Builders<DbModels.Raffle>.Filter.Eq(r => r.Id, raffle[i].Id);
                        var update = Builders<DbModels.Raffle>.Update
                            .Set(r => r.StartAt, DateTime.Now.AddHours(addHoursStartFisrtDH))
                            .Set(r => r.EndsAt, DateTime.Now.AddHours(addHoursEndFisrtDH))
                            .Set(r => r.IsClosed, false)
                            .Set(r => r.Active, true);

                        collection.UpdateOne(filter, update);
                        Competitions.ActivateRafflesComp(raffle[i], addHoursStartFisrtDH, addHoursEndFisrtDH);
                    }
                }
                
            }

            public static void ActivateTwoClosedDreamHome(List<DbModels.Raffle> raffle, int addHoursStartFisrtDH, int addHoursEndFisrtDH, int addHoursStartSecondDH, int addHoursEndSecondDH)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                        var database = client.GetDatabase(DbConnection.DB_STAGING);
                        var collection = database.GetCollection<DbModels.Raffle>("raffles");
                        var filter = Builders<DbModels.Raffle>.Filter.Eq(r => r.Id, raffle[i].Id);
                        var update = Builders<DbModels.Raffle>.Update
                            .Set(r => r.StartAt, DateTime.Now.AddHours(addHoursStartFisrtDH))
                            .Set(r => r.EndsAt, DateTime.Now.AddHours(addHoursEndFisrtDH))
                            .Set(r => r.IsClosed, false)
                            .Set(r => r.Active, true);

                        collection.UpdateOne(filter, update);
                        Competitions.ActivateRafflesComp(raffle[i], addHoursStartFisrtDH, addHoursEndFisrtDH);
                    }
                    if (i == 1)
                    {
                        var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                        var database = client.GetDatabase(DbConnection.DB_STAGING);
                        var collection = database.GetCollection<DbModels.Raffle>("raffles");
                        var filter = Builders<DbModels.Raffle>.Filter.Eq(r => r.Id, raffle[i].Id);
                        var update = Builders<DbModels.Raffle>.Update
                            .Set(r => r.StartAt, DateTime.Now.AddHours(addHoursStartSecondDH))
                            .Set(r => r.EndsAt, DateTime.Now.AddHours(addHoursEndSecondDH))
                            .Set(r => r.IsClosed, false)
                            .Set(r => r.Active, true);

                        collection.UpdateOne(filter, update);
                        Competitions.ActivateRafflesComp(raffle[i], addHoursStartSecondDH, addHoursEndSecondDH);
                    }

                }
            }

            public static void UpdateClosedDreamHome()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Raffle>("raffles");
                var filter = Builders<DbModels.Raffle>.Filter.Eq(r => r.IsClosed, true);
                var sorting = Builders<DbModels.Raffle>.Sort.Descending(r => r.CreatedAt);
                var limit = collection.Find(filter).Sort(sorting).Limit(10).ToList();
                var update = Builders<DbModels.Raffle>.Update
                    .Set(r => r.StartAt, DateTime.Now.AddDays(-100))
                    .Set(r => r.EndsAt, DateTime.Now.AddDays(-7));
                var updatedFilter = Builders<DbModels.Raffle>.Filter.In(r => r.Id, limit.Select(r => r.Id));
                collection.UpdateMany(updatedFilter, update);

            }

            public static void DeleteClosedDreamHome()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collectionRaffles = database.GetCollection<DbModels.Raffle>("raffles");
                var filterRaffles = Builders<DbModels.Raffle>.Filter.Eq(r => r.IsClosed, true);
                var raffles = collectionRaffles.Find(filterRaffles).ToList();
                var collectionCompetitions = database.GetCollection<DbModels.CompetitionsR>("competitions");
                var filterCompetitions = Builders<DbModels.CompetitionsR>.Filter.In(c => c.DreamHome, raffles.Select(c => c.Id));
                var collectionProperties = database.GetCollection<DbModels.Property>("properties");
                var filterProperties = Builders<DbModels.Property>.Filter.In(p => p.Id, raffles.Select(p => p.Property));
                var comp = collectionCompetitions.Find(filterCompetitions).ToList();
                var prop = collectionProperties.Find(filterProperties).ToList();


            }

            public static void DeactivateDreamHome(List<DbModels.Raffle> raffles)
            {
                foreach (var raffle in raffles)
                {
                    var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                    var database = client.GetDatabase(DbConnection.DB_STAGING);
                    var collection = database.GetCollection<DbModels.Raffle>("raffles");
                    var filter = Builders<DbModels.Raffle>.Filter.Eq(r => r.Id, raffle.Id);
                    var update = Builders<DbModels.Raffle>.Update
                        .Set(r => r.IsClosed, true)
                        .Set(r => r.Active, false);

                    collection.UpdateOne(filter, update);
                    Competitions.DeactivateRafflesComp(raffle);
                    Orders.DeactivateOrdersByDreamHome(raffle);
                }
                
            }

            public static void DeactivateDreamHome(Raffles raffle)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Raffle>("raffles");
                var filter = Builders<DbModels.Raffle>.Filter.Eq(r => r.Id, ObjectId.Parse(raffle.Id));
                var update = Builders<DbModels.Raffle>.Update
                    .Set(r => r.IsClosed, true)
                    .Set(r => r.Active, false);

                collection.UpdateOne(filter, update);
                Competitions.DeactivateRafflesComp(raffle);
                Orders.DeactivateOrdersByDreamHome(raffle);


            }
        }
        
        public class Subscriptions
        {
            public static List<DbModels.Subscriptions> GetAllSubscriptions()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filter = Builders<DbModels.Subscriptions>.Filter.Empty;
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static List<DbModels.Subscriptions> GetAllSubscriptionsByUserId(DbModels.UserResponse user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filter = Builders<DbModels.Subscriptions>.Filter.Eq(s=>s.User, user.Id);
                var result = collection.Find(filter).ToList();

                foreach (var subscription in result)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.IsNotNull(subscription.Refference);
                        Assert.IsNotNull(subscription.CardSource);
                        Assert.IsNotNull(subscription.CheckoutId);
                    });

                }

                return result;
            }

            public static DbModels.Subscriptions GetSubscriptionByUserId(DbModels.UserResponse user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filter = Builders<DbModels.Subscriptions>.Filter.Eq(s => s.User, user.Id);
                var preresult = collection.Find(filter).ToList();
                var result = preresult.FirstOrDefault();
                return result ?? throw new Exception("Content is null.");
            }

            public static List<DbModels.SubscriptionsModels> GetAllSubscriptionModels()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.SubscriptionsModels>("subscriptionmodels");
                var filter = Builders<DbModels.SubscriptionsModels>.Filter.Empty;
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static void UpdateSubscriptionDateByIdToNextPurchase(DbModels.UserResponse user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filterBuilder = Builders<DbModels.Subscriptions>.Filter;
                var filter = filterBuilder
                    .Eq("user", new ObjectId(user.Id.ToString())) &
                    (filterBuilder.Eq("status", "ACTIVE"));
                var updateBuilder = Builders<DbModels.Subscriptions>.Update;
                var update = updateBuilder
                    .Set(u=>u.NextPurchaseDate, DateTime.Now.AddDays(-1));
                collection.UpdateMany(filter, update);
            }
            
            public static void UpdateSubscriptionDateByIdToUnpause(DbModels.UserResponse user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filterBuilder = Builders<DbModels.Subscriptions>.Filter;
                var filter = filterBuilder.Eq(s => s.User, new ObjectId(user.Id.ToString())) &
                    (filterBuilder.Eq(s=>s.Status, "PAUSED"));
                var updateBuilder = Builders<DbModels.Subscriptions>.Update;
                var update = updateBuilder
                    .Set(s => s.PausedAt, DateTime.Now.AddMonths(-1))
                    .Set(s => s.PauseEnd, DateTime.Now.AddMonths(-1).AddDays(-1));                
                collection.UpdateMany(filter, update);
            }
            public static void UpdateSubscriptionDateByIdToSendEmail7DaysPrior(DbModels.UserResponse user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filterBuilder = Builders<DbModels.Subscriptions>.Filter;
                var filter = filterBuilder.Eq(s => s.User, new ObjectId(user.Id.ToString())) &
                    (filterBuilder.Eq(s => s.Status, "PAUSED"));
                var updateBuilder = Builders<DbModels.Subscriptions>.Update;
                var update = updateBuilder
                    .Set(s => s.PausedAt, DateTime.Now.AddMonths(-1))
                    .Set(s => s.PauseEnd, DateTime.Now.AddMonths(-1).AddDays(6));
                collection.UpdateMany(filter, update);
            }

            public static void DeleteSubscriptionsByUserId(List<DbModels.UserResponse> users)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                foreach (var user in users)
                {
                    var filter = Builders<DbModels.Subscriptions>.Filter.Eq(s=>s.User, user.Id);
                    collection.DeleteMany(filter);
                }

            }

            public static void DeleteSubscriptionsByUserId(DbModels.UserResponse user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filter = Builders<DbModels.Subscriptions>.Filter.Eq(s => s.User, user.Id);
                    collection.DeleteMany(filter);

            }

            public static void DeleteSubscriptions()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filter = Builders<DbModels.Subscriptions>.Filter.Empty;
                collection.DeleteMany(filter);

            }

            public static void DeleteLastSubscriptionModel(DbModels.SubscriptionsModels subscriptionModel)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.SubscriptionsModels>("subscriptionmodels");
                var filter = Builders<DbModels.SubscriptionsModels>.Filter.Eq(sm=>sm.Id, subscriptionModel.Id);
                collection.DeleteOne(filter);
            }

        }
        
        public class Orders
        {
            public static List<DbModels.Orders> GetAllOrders()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                var filter = Builders<DbModels.Orders>.Filter.Empty;
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static List<DbModels.Orders> GetAllOrdersByUserId(List<DbModels.UserResponse> user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                var filter = Builders<DbModels.Orders>.Filter.Eq("user", new ObjectId(user.FirstOrDefault().Id.ToString())); ;
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static List<DbModels.Orders> GetAllSubscriptionOrdersByUserId(DbModels.UserResponse user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                var filterBuilder = Builders<DbModels.Orders>.Filter;
                var filter = filterBuilder
                    .Eq("user", new ObjectId(user.Id.ToString())) & (filterBuilder
                    .Eq("orderType", "SUBSCRIPTION"));
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static void DeleteOrdersByUserId(List<DbModels.UserResponse> users)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                var collectionArchive = database.GetCollection<DbModels.ArchiveOrders>("archiveorders");
                foreach (var user in users)
                {
                    var filter = Builders<DbModels.Orders>.Filter.Eq(o=>o.User, user.Id);
                    var filterArchive = Builders<DbModels.ArchiveOrders>.Filter.Eq(o => o.User, user.Id);
                    collection.DeleteMany(filter);
                    collectionArchive.DeleteMany(filterArchive);
                }
                
            }

            public static void DeleteSubscriptionsOrders()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                var filter = Builders<DbModels.Orders>.Filter.Eq("orderType", "SUBSCRIPTION");
                    collection.DeleteMany(filter);
                

            }

            public static void DeleteOrdersByUserId(DbModels.UserRequest user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                var filter = Builders<DbModels.Orders>.Filter.Eq(o=>o.User, user.Id);
                collection.DeleteMany(filter);


            }

            public static void DeactivateOrdersByDreamHome(DbModels.Raffle raffle)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                var filter = Builders<DbModels.Orders>.Filter.Eq(o => o.Raffle, raffle.Id);
                var update = Builders<DbModels.Orders>.Update
                    .Set(o => o.IsArchive, true);

                collection.UpdateMany(filter, update);
            }

            public static void DeactivateOrdersByDreamHome(Raffles raffle)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                var filter = Builders<DbModels.Orders>.Filter.Eq(o => o.Raffle, ObjectId.Parse(raffle.Id));
                var update = Builders<DbModels.Orders>.Update
                    .Set(o => o.IsArchive, true);

                collection.UpdateMany(filter, update);
            }

            public static void UpdateOrderByUserId(DbModels.UserResponse user, string oldUserId)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.ArchiveOrders>("archiveorders");
                var filterBuilder = Builders<DbModels.ArchiveOrders>.Filter;
                var filter = filterBuilder
                    .Eq(u=>u.User, new ObjectId(oldUserId));
                var updateBuilder = Builders<DbModels.ArchiveOrders>.Update;
                var update = updateBuilder
                    .Set(u => u.User, user.Id);
                collection.UpdateMany(filter, update);
            }
        }

        public class Insert
        {
            public static void InsertPauseSubscriptionToUser(List<DbModels.UserResponse> users, List<DbModels.Raffle> raffle, List<DbModels.SubscriptionsModels> subscriptionModels, string charity, int nextPurchaseDate, int purchaseDate, int pausedAt, int pauseEnd)
            {

                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.SubscriptionsInsert>("subscriptions");
                foreach (var user in users)
                {
                    int pauseCount = RandomHelper.RandomIntNumber(20);
                    var update = new List<DbModels.SubscriptionsInsert>()
                    {
                        new DbModels.SubscriptionsInsert
                        {
                        Status = "PAUSED",
                        Count= 1,
                        Charity= charity,
                        IsReminderSent= false,
                        CreatedAt = DateTime.Now,
                        TotalCost= 2500,
                        NumOfTickets = 15,
                        Extra= 135,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.LastOrDefault().Id,
                        User=  user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[pauseCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[pauseCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[pauseCount],
                        NextPurchaseDate = DateTime.Now.AddHours(nextPurchaseDate),
                        PurchaseDate = DateTime.Now.AddMonths(purchaseDate),
                        PausedAt= DateTime.Now.AddHours(pausedAt),
                        PauseEnd= DateTime.Now.AddHours(pauseEnd)
                        }

                    };

                    collection.InsertMany(update);
                }

            }

            public static void InsertReminderSubscriptionToUser(List<DbModels.UserResponse> users, List<DbModels.Raffle> raffle, List<DbModels.SubscriptionsModels> subscriptionModels, string charity, int nextPurchaseDate, int purchaseDate, int pausedAt, int pauseEnd)
            {

                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.SubscriptionsInsert>("subscriptions");
                foreach (var user in users)
                {
                    int pauseCount = RandomHelper.RandomIntNumber(20);
                    var update = new List<DbModels.SubscriptionsInsert>()
                    {
                        new DbModels.SubscriptionsInsert
                        {
                        Status = "PAUSED",
                        Count= 1,
                        Charity= charity,
                        IsReminderSent= false,
                        CreatedAt = DateTime.Now,
                        TotalCost= 2500,
                        NumOfTickets = 15,
                        Extra= 135,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.LastOrDefault().Id,
                        User=  user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[pauseCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[pauseCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[pauseCount],
                        NextPurchaseDate = DateTime.Now.AddHours(nextPurchaseDate),
                        PurchaseDate = DateTime.Now.AddMonths(purchaseDate),
                        PausedAt= DateTime.Now.AddHours(pausedAt),
                        PauseEnd= DateTime.Now.AddHours(pauseEnd)
                        }

                    };

                    collection.InsertMany(update);
                }

            }

            public static void InsertActiveSubscriptionToUser(List<DbModels.UserResponse> users, List<DbModels.Raffle> raffle, List<DbModels.SubscriptionsModels> subscriptionModels, string charity, int nextPurchaseDate, int purchaseDate)
            {

                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collectionActive = database.GetCollection<DbModels.SubscriptionsActiveInsert>("subscriptions");
                foreach (var user in users)
                {
                    int i = RandomHelper.RandomIntNumber(subscriptionModels.Count);
                    int activeCount = RandomHelper.RandomIntNumber(20);                   
                    var updateActive = new List<DbModels.SubscriptionsActiveInsert>()
                    {
                        new DbModels.SubscriptionsActiveInsert
                        {
                        Status = "ACTIVE",
                        Count= 1,
                        Charity= charity,
                        IsReminderSent= false,
                        CreatedAt = DateTime.Now,
                        TotalCost= subscriptionModels[i].TotalCost,
                        NumOfTickets = subscriptionModels[i].NumOfTickets,
                        Extra= subscriptionModels[i].Extra,
                        SubscriptionModel= new ObjectId(subscriptionModels[i].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.LastOrDefault().Id,
                        User= user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[activeCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[activeCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[activeCount],
                        NextPurchaseDate = DateTime.Now.AddHours(nextPurchaseDate),
                        PurchaseDate = DateTime.Now.AddMonths(purchaseDate)
                        }
                    };

                    collectionActive.InsertMany(updateActive);
                }

            }

            public static void InsertActiveSubscriptionToUser(List<DbModels.UserResponse> users, Raffles raffle, List<DbModels.SubscriptionsModels> subscriptionModels, string charity, int nextPurchaseDate, int purchaseDate)
            {

                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collectionActive = database.GetCollection<DbModels.SubscriptionsActiveInsert>("subscriptions");
                foreach (var user in users)
                {
                    int i = RandomHelper.RandomIntNumber(subscriptionModels.Count);
                    int activeCount = RandomHelper.RandomIntNumber(20);
                    var updateActive = new List<DbModels.SubscriptionsActiveInsert>()
                    {
                        new DbModels.SubscriptionsActiveInsert
                        {
                        Status = "ACTIVE",
                        Count= 1,
                        Charity= charity,
                        IsReminderSent= false,
                        CreatedAt = DateTime.Now,
                        TotalCost= subscriptionModels[i].TotalCost,
                        NumOfTickets = subscriptionModels[i].NumOfTickets,
                        Extra= subscriptionModels[i].Extra,
                        SubscriptionModel= new ObjectId(subscriptionModels[i].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= ObjectId.Parse(raffle.Id),
                        User= user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[activeCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[activeCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[activeCount],
                        NextPurchaseDate = DateTime.Now.AddHours(nextPurchaseDate),
                        PurchaseDate = DateTime.Now.AddMonths(purchaseDate)
                        }
                    };

                    collectionActive.InsertMany(updateActive);
                }

            }

            public static void InsertSubscriptionsToUsers(DbModels.UserResponse user, DbModels.Raffle raffle, List<DbModels.SubscriptionsModels> subscriptionModels)
            {
                int firstSub = RandomHelper.RandomIntNumber(subscriptionModels.Count);
                int secondSub = RandomHelper.RandomIntNumber(subscriptionModels.Count);
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.SubscriptionsInsert>("subscriptions");
                var update = new List<DbModels.SubscriptionsInsert>()
                    {
                        new DbModels.SubscriptionsInsert
                        {
                        Status = "ACTIVE",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTime.Now,
                        TotalCost= subscriptionModels[firstSub].TotalCost,
                        NumOfTickets = subscriptionModels[firstSub].NumOfTickets,
                        Extra= subscriptionModels[firstSub].Extra,
                        SubscriptionModel= new ObjectId(subscriptionModels[firstSub].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.Id,
                        User= user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.REFFERENCE.Count)],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CARD_SOURCE.Count)],
                        CheckoutId= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CHECKOUT_ID.Count)],
                        NextPurchaseDate = DateTime.Now.AddMonths(-1),
                        PurchaseDate = DateTime.Now

                        },
                        new DbModels.SubscriptionsInsert
                        {
                        Status = "PAUSED",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= subscriptionModels[secondSub].TotalCost,
                        NumOfTickets = subscriptionModels[secondSub].NumOfTickets,
                        Extra= subscriptionModels[secondSub].Extra,
                        SubscriptionModel= new ObjectId(subscriptionModels[secondSub].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.Id,
                        User=  user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.REFFERENCE.Count)],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CARD_SOURCE.Count)],
                        CheckoutId= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CHECKOUT_ID.Count)],
                        NextPurchaseDate = DateTime.Now.AddMonths(1),
                        PurchaseDate = DateTime.Now.AddMonths(-1),
                        PausedAt= DateTime.Now.AddMonths(-1),
                        PauseEnd= DateTime.Now.AddMonths(-1).AddDays(-1),

                        }

                    };

                collection.InsertMany(update);


            }

            public static void InsertSubscriptionsToUserForFailPayment(DbModels.UserResponse user, DbModels.Raffle raffle, List<DbModels.SubscriptionsModels> subscriptionModels)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.SubscriptionsInsert>("subscriptions");
                var update = new List<DbModels.SubscriptionsInsert>()
                    {
                        new DbModels.SubscriptionsInsert
                        {
                        Status = "FINISHED",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 2500,
                        NumOfTickets = 15,
                        Extra= 135,
                        SubscriptionModel= new ObjectId(subscriptionModels.LastOrDefault().Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.Id,
                        User= user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.REFFERENCE.Count)],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CARD_SOURCE.Count)],
                        CheckoutId= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CHECKOUT_ID.Count)],
                        NextPurchaseDate = DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PurchaseDate = DateTimeOffset.Now.DateTime

                        }
                        
                    };

                collection.InsertMany(update);


            }

            public static void InsertUser(List<DbModels.Raffle> raffle)
            {
                
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserRequest>("users");
                var update = new DbModels.UserRequest()
                {
                    Id = ObjectId.GenerateNewId(),
                    IsAdmin = false,
                    IsManager = false,
                    IsVerified = true,
                    FreeEntries = 0,
                    SuccessfullReferralCount = 0,
                    TotalTicketsBought = 0,
                    EmailCommunication = true,
                    RegisterReferrals = new List<object>(),
                    FreeTickets = 0,
                    IsSocialRegistration =false,
                    IsBlocked = false,
                    Notifications = new DbModels.Notification()
                    {
                        all= true,
                        dreamHome= true,
                        fixedOdds= true,
                        lifestyle= true,
                        myCompetitions= true,
                        newPrizes= true
                    },
                    SpentMoney = 0,
                    Name = Name.FirstName(),
                    Surname  = Name.LastName(),
                    Email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fff"), "@putsbox.com"),
                    Password = "$2a$10$Gg.YWboloxu8Xq8uBXXVE.Zhbxc.fRAKLrUTYHDC.1gQP9yRrFi4a",
                    Phone = string.Empty,
                    Country = "Ukraine",
                    CreatedAt = DateTime.Now,
                    RegisterRaffle = raffle.FirstOrDefault().Id,
                    ReferralKey = Guid.NewGuid().ToString(),
                    NeededSpend = 0,
                    ReferralCredits = 0,
                    IsEmailValid = true,
                    UpdatedAt = DateTime.Now,
                    CorporateNotification = true
                };
                collection.InsertOne(update);
            }

            public static void InsertUser(DbModels.Raffle raffle)
            {

                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserRequest>("users");
                var update = new DbModels.UserRequest()
                {
                    Id = ObjectId.GenerateNewId(),
                    IsAdmin = false,
                    IsManager = false,
                    IsVerified = true,
                    FreeEntries = 0,
                    SuccessfullReferralCount = 0,
                    TotalTicketsBought = 0,
                    EmailCommunication = true,
                    RegisterReferrals = new List<object>(),
                    FreeTickets = 0,
                    IsSocialRegistration = false,
                    IsBlocked = false,
                    Notifications = new DbModels.Notification()
                    {
                        all = true,
                        dreamHome = true,
                        fixedOdds = true,
                        lifestyle = true,
                        myCompetitions = true,
                        newPrizes = true
                    },
                    SpentMoney = 0,
                    Name = Name.FirstName(),
                    Surname = Name.LastName(),
                    Email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fff"), "@putsbox.com"),
                    Password = "$2a$10$UT3uN3YZaIZSVPCFUSw.cezZLNTp4Jdz0MWVa..eubmSve1SKpcyS",
                    Phone = string.Empty,
                    Country = "Ukraine",
                    CreatedAt = DateTime.Now,
                    RegisterRaffle = raffle.Id,
                    ReferralKey = Guid.NewGuid().ToString(),
                    NeededSpend = 0,
                    ReferralCredits = 0,
                    IsEmailValid = true,
                    UpdatedAt = DateTime.Now,
                    CorporateNotification = true
                };
                collection.InsertOne(update);
            }

            public static void InsertUser(Raffles raffle)
            {

                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserRequest>("users");
                var update = new DbModels.UserRequest()
                {
                    Id = ObjectId.GenerateNewId(),
                    IsAdmin = false,
                    IsManager = false,
                    IsVerified = true,
                    FreeEntries = 0,
                    SuccessfullReferralCount = 0,
                    TotalTicketsBought = 0,
                    EmailCommunication = true,
                    RegisterReferrals = new List<object>(),
                    FreeTickets = 0,
                    IsSocialRegistration = false,
                    IsBlocked = false,
                    Notifications = new DbModels.Notification()
                    {
                        all = true,
                        dreamHome = true,
                        fixedOdds = true,
                        lifestyle = true,
                        myCompetitions = true,
                        newPrizes = true
                    },
                    SpentMoney = 0,
                    Name = Name.FirstName(),
                    Surname = Name.LastName(),
                    Email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fff"), "@putsbox.com"),
                    Password = "$2a$10$UT3uN3YZaIZSVPCFUSw.cezZLNTp4Jdz0MWVa..eubmSve1SKpcyS",
                    Phone = string.Empty,
                    Country = "Ukraine",
                    CreatedAt = DateTime.Now,
                    RegisterRaffle = ObjectId.Parse(raffle.Id),
                    ReferralKey = Guid.NewGuid().ToString(),
                    NeededSpend = 0,
                    ReferralCredits = 0,
                    IsEmailValid = true,
                    UpdatedAt = DateTime.Now,
                    CorporateNotification = true
                };
                collection.InsertOne(update);
            }

            public static void InsertUser(DbModels.Raffle raffle, string email)
            {

                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.UserRequest>("users");
                var update = new DbModels.UserRequest()
                {
                    Id = ObjectId.GenerateNewId(),
                    IsAdmin = false,
                    IsManager = false,
                    IsVerified = true,
                    FreeEntries = 0,
                    SuccessfullReferralCount = 0,
                    TotalTicketsBought = 0,
                    EmailCommunication = true,
                    RegisterReferrals = new List<object>(),
                    FreeTickets = 0,
                    IsSocialRegistration = false,
                    IsBlocked = false,
                    Notifications = new DbModels.Notification()
                    {
                        all = true,
                        dreamHome = true,
                        fixedOdds = true,
                        lifestyle = true,
                        myCompetitions = true,
                        newPrizes = true
                    },
                    SpentMoney = 0,
                    Name = Name.FirstName(),
                    Surname = Name.LastName(),
                    Email = email,
                    Password = "$2a$10$Gg.YWboloxu8Xq8uBXXVE.Zhbxc.fRAKLrUTYHDC.1gQP9yRrFi4a",
                    Phone = string.Empty,
                    Country = "Ukraine",
                    CreatedAt = DateTime.Now,
                    RegisterRaffle = raffle.Id,
                    ReferralKey = Guid.NewGuid().ToString(),
                    NeededSpend = 0,
                    ReferralCredits = 0,
                    IsEmailValid = true,
                    UpdatedAt = DateTime.Now,
                    CorporateNotification = true
                };
                collection.InsertOne(update);
            }

            public static void InsertSubscriptionModel(int totalCost)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.SubscriptionsModels>("subscriptionmodels");
                var insert = new DbModels.SubscriptionsModels()
                {
                    Id = ObjectId.GenerateNewId(),
                    IsActive = true,
                    TotalCost = totalCost,
                    NumOfTickets = 1,
                    Extra = 1,
                    CreatedAt= DateTimeOffset.Now.DateTime                   
                };
                collection.InsertOne(insert);
            }
        }
        
        public class Competitions
        {
            public static List<DbModels.Competitions.Raffle> GetAllRafflesComp(DbModels.Raffle raffle)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Competitions.Raffle>("competitions");
                var filterBuilder = Builders<DbModels.Competitions.Raffle>.Filter;
                var filter = filterBuilder.Eq(r => r.CompetitionType, "DREAMHOME") &
                    (filterBuilder.Eq(r => r.DreamHome, raffle.Id));
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static void DeactivateRafflesComp(DbModels.Raffle raffle)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Competitions.Raffle>("competitions");
                var filterBuilder = Builders<DbModels.Competitions.Raffle>.Filter;
                var filter = filterBuilder.Eq(r => r.CompetitionType, "DREAMHOME") &
                    (filterBuilder.Eq(r => r.DreamHome, raffle.Id));
                var updateBuilder = Builders<DbModels.Competitions.Raffle>.Update;
                var update = updateBuilder
                    .Set(c => c.IsActive, false);
                collection.UpdateMany(filter, update);
            }

            public static void DeactivateRafflesComp(Raffles raffle)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Competitions.Raffle>("competitions");
                var filterBuilder = Builders<DbModels.Competitions.Raffle>.Filter;
                var filter = filterBuilder.Eq(r => r.CompetitionType, "DREAMHOME") &
                    (filterBuilder.Eq(r => r.DreamHome, ObjectId.Parse(raffle.Id)));
                var updateBuilder = Builders<DbModels.Competitions.Raffle>.Update;
                var update = updateBuilder
                    .Set(c => c.IsActive, false);
                collection.UpdateMany(filter, update);
            }

            public static void ActivateRafflesComp(DbModels.Raffle raffle, int addHoursStart, int addHoursEnd)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Competitions.Raffle>("competitions");
                var filterBuilder = Builders<DbModels.Competitions.Raffle>.Filter;
                var filter = filterBuilder.Eq(r => r.CompetitionType, "DREAMHOME") &
                    (filterBuilder.Eq(r => r.DreamHome, raffle.Id));
                var updateBuilder = Builders<DbModels.Competitions.Raffle>.Update;
                var update = updateBuilder
                    .Set(c => c.IsActive, true)
                    .Set(r => r.StartAt, DateTime.Now.AddHours(addHoursStart))
                    .Set(r => r.EndsAt, DateTime.Now.AddHours(addHoursEnd));
                collection.UpdateMany(filter, update);
            }
        }
        

        
    }


}
