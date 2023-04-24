﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json.Bson;
using System.Text.RegularExpressions;
using static RaffleAutomationTests.Helpers.DbModels;

namespace RaffleAutomationTests.Helpers
{


    public class AppDbHelper
    {
        public class Users
        {
            public static List<DbModels.User> GetAllUsers()
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.User>("users");
                var filter = Builders<DbModels.User>.Filter.Empty;
                var result = collection.Find(filter).ToList();

                return result;
            }
            public static List<DbModels.User> GetUserByEmailpattern(string emailPattern)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.User>("users");
                var filter = Builders<DbModels.User>.Filter.Regex(u=>u.Email, new BsonRegularExpression(emailPattern));
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static DbModels.User GetUserByEmail(string email)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.User>("users");
                var filter = Builders<DbModels.User>.Filter.Regex(u => u.Email, new BsonRegularExpression(email));
                var preresult = collection.Find(filter).ToList();
                var result = preresult.LastOrDefault();
                return result;
            }

            public static DbModels.User GetOneUserByEmail(string email)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.User>("users");
                var filter = Builders<DbModels.User>.Filter.Regex("email", new BsonRegularExpression(email));
                var result = collection.Find(filter).ToList();
                return result.Select(x=>x).FirstOrDefault();
            }

            public static DbModels.User GetUserById(string id)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.User>("users");
                var filter = Builders<DbModels.User>.Filter.Eq(u=>u.Id, new ObjectId(id));
                var result = collection.Find(filter).ToList();
                return result.Select(x => x).FirstOrDefault();
            }

            public static void UpdateUsers(List<DbModels.User> users)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.User>("users");
                var filter = Builders<DbModels.User>.Filter.Empty;
                var update = Builders<DbModels.User>.Update
                    .Set(u=>u.Email, string.Concat("test", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff"), "@dot.co"))
                    .Set(u=>u.Phone, "000000000");
                collection.UpdateMany(filter, update);
            }

            public static void DeleteUsersByUserId(List<DbModels.User> users)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.User>("users");
                for (int i = 0; i < 4000; i++)
                {
                    foreach (var user in users)
                    {
                        var filter = Builders<DbModels.User>.Filter.Eq("_id", new ObjectId(user.Id.ToString()));
                        collection.DeleteMany(filter);
                    }
                }

            }

            public static void DeleteUsersByEmail(string email)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.User>("users");
                var filter = Builders<DbModels.User>.Filter.Eq("email", email);
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

            public static List<DbModels.Subscriptions> GetAllSubscriptionsByUserId(DbModels.User user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filter = Builders<DbModels.Subscriptions>.Filter.Eq(s=>s.User, user.Id);
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static DbModels.Subscriptions GetSubscriptionByUserId(DbModels.User user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
                var filter = Builders<DbModels.Subscriptions>.Filter.Eq(s => s.User, user.Id);
                var preresult = collection.Find(filter).ToList();
                var result = preresult.FirstOrDefault();
                return result;
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

            public static void UpdateSubscriptionDateByIdToNextPurchase(DbModels.User user)
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
            public static void UpdateSubscriptionDateByIdToUnpause(DbModels.User user)
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
            public static void UpdateSubscriptionDateByIdToSendEmail7DaysPrior(DbModels.User user)
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

            public static void DeleteSubscriptionsByUserId(List<DbModels.User> users)
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

            public static void DeleteSubscriptionsByUserId(DbModels.User user)
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

            public static List<DbModels.Orders> GetAllOrdersByUserId(List<DbModels.User> user)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                var filter = Builders<DbModels.Orders>.Filter.Eq("user", new ObjectId(user.FirstOrDefault().Id.ToString())); ;
                var result = collection.Find(filter).ToList();
                return result;
            }

            public static List<DbModels.Orders> GetAllSubscriptionOrdersByUserId(DbModels.User user)
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

            public static void DeleteOrdersByUserId(List<DbModels.User> users)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.Orders>("orders");
                foreach(var user in users)
                {
                    var filter = Builders<DbModels.Orders>.Filter.Eq("user", new ObjectId(user.Id.ToString()));
                    collection.DeleteMany(filter);
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
        }

        public class Insert
        {
            public static void InsertSubscriptionsToUsers(List<DbModels.User> users, List<DbModels.Raffle> raffle, List<DbModels.SubscriptionsModels> subscriptionModels)
            {

                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<SubscriptionsInsert>("subscriptions");
                foreach (var user in users)
                {
                    int activeCount = RandomHelper.RandomIntNumber(20);
                    int pauseCount = RandomHelper.RandomIntNumber(20);
                    var update = new List<SubscriptionsInsert>()
                    {
                        new SubscriptionsInsert
                        {
                        Status = "ACTIVE",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 2500,
                        NumOfTickets = 15,
                        Extra= 135,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.FirstOrDefault().Id,
                        User= user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[activeCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[activeCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[activeCount],
                        NextPurchaseDate = DateTimeOffset.Now.AddHours(-720).DateTime,
                        PurchaseDate = DateTimeOffset.Now.DateTime

                        },
                        new SubscriptionsInsert
                        {
                        Status = "ACTIVE",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 2500,
                        NumOfTickets = 15,
                        Extra= 135,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.FirstOrDefault().Id,
                        User= user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[activeCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[activeCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[activeCount],
                        NextPurchaseDate = DateTimeOffset.Now.AddHours(720).DateTime,
                        PurchaseDate = DateTimeOffset.Now.DateTime

                        },
                        new SubscriptionsInsert
                        {
                        Status = "PAUSED",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 1000,
                        NumOfTickets = 5,
                        Extra= 40,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.FirstOrDefault().Id,
                        User=  user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[pauseCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[pauseCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[pauseCount],
                        NextPurchaseDate = DateTimeOffset.Now.AddMonths(1).DateTime,
                        PurchaseDate = DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PausedAt= DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PauseEnd= DateTimeOffset.Now.AddHours(-24).DateTime,

                        },
                        new SubscriptionsInsert
                        {
                        Status = "PAUSED",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 2500,
                        NumOfTickets = 15,
                        Extra= 135,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.FirstOrDefault().Id,
                        User=  user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[pauseCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[pauseCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[pauseCount],
                        NextPurchaseDate = DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PurchaseDate = DateTimeOffset.Now.AddMonths(-2).DateTime,
                        PausedAt= DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PauseEnd= DateTimeOffset.Now.AddHours(168).DateTime
                        },
                        new SubscriptionsInsert
                        {
                        Status = "PAUSED",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 1000,
                        NumOfTickets = 5,
                        Extra= 40,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.FirstOrDefault().Id,
                        User=  user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[pauseCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[pauseCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[pauseCount],
                        NextPurchaseDate = DateTimeOffset.Now.AddMonths(1).DateTime,
                        PurchaseDate = DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PausedAt= DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PauseEnd= DateTimeOffset.Now.AddHours(24).DateTime,

                        },
                        new SubscriptionsInsert
                        {
                        Status = "ACTIVE",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 2500,
                        NumOfTickets = 15,
                        Extra= 135,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.FirstOrDefault().Id,
                        User= user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[activeCount],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[activeCount],
                        CheckoutId= SubscriptionsCardDetails.CHECKOUT_ID[activeCount],
                        NextPurchaseDate = DateTimeOffset.Now.DateTime,
                        PurchaseDate = DateTimeOffset.Now.AddMinutes(20).DateTime

                        },

                    };

                    collection.InsertMany(update);
                }

            }

            public static void InsertSubscriptionsToUsers(DbModels.User user, List<DbModels.Raffle> raffle, List<DbModels.SubscriptionsModels> subscriptionModels)
            {
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
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 2500,
                        NumOfTickets = 15,
                        Extra= 135,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.FirstOrDefault().Id,
                        User= user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.REFFERENCE.Count)],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CARD_SOURCE.Count)],
                        CheckoutId= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CHECKOUT_ID.Count)],
                        NextPurchaseDate = DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PurchaseDate = DateTimeOffset.Now.DateTime

                        },
                        new DbModels.SubscriptionsInsert
                        {
                        Status = "PAUSED",
                        Count= 1,
                        Charity= "",
                        IsReminderSent= false,
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 1000,
                        NumOfTickets = 5,
                        Extra= 40,
                        SubscriptionModel= new ObjectId(subscriptionModels[RandomHelper.RandomIntNumber(subscriptionModels.Count)].ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.FirstOrDefault().Id,
                        User=  user.Id,
                        Refference= SubscriptionsCardDetails.REFFERENCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.REFFERENCE.Count)],
                        CardSource= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CARD_SOURCE.Count)],
                        CheckoutId= SubscriptionsCardDetails.CARD_SOURCE[RandomHelper.RandomIntNumber(SubscriptionsCardDetails.CHECKOUT_ID.Count)],
                        NextPurchaseDate = DateTimeOffset.Now.AddMonths(1).DateTime,
                        PurchaseDate = DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PausedAt= DateTimeOffset.Now.AddMonths(-1).DateTime,
                        PauseEnd= DateTimeOffset.Now.AddMonths(-1).AddDays(-1).DateTime,

                        }

                    };

                    collection.InsertMany(update);
                

            }

            public static void InsertSubscriptionsToUserForFailPayment(DbModels.User user, List<DbModels.Raffle> raffle, List<DbModels.SubscriptionsModels> subscriptionModels)
            {
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
                        CreatedAt = DateTimeOffset.Now.DateTime,
                        TotalCost= 2500,
                        NumOfTickets = 15,
                        Extra= 135,
                        SubscriptionModel= new ObjectId(subscriptionModels.LastOrDefault().Id.ToString()),
                        Emails = new List<string>(),
                        Raffle= raffle.FirstOrDefault().Id,
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
                var collection = database.GetCollection<DbModels.User>("users");
                var update = new DbModels.User()
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
                    Notifications = new Notification()
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
                    CorporateNotification = true,
                    MobileEntry  = false,
                    SpentMobile = 0
                };
                collection.InsertOne(update);
            }

            public static void InsertUser(List<DbModels.Raffle> raffle, string email)
            {

                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<DbModels.User>("users");
                var update = new DbModels.User()
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
                    Notifications = new Notification()
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
                    RegisterRaffle = raffle.FirstOrDefault().Id,
                    ReferralKey = Guid.NewGuid().ToString(),
                    NeededSpend = 0,
                    ReferralCredits = 0,
                    IsEmailValid = true,
                    UpdatedAt = DateTime.Now,
                    CorporateNotification = true,
                    MobileEntry = false,
                    SpentMobile = 0
                };
                collection.InsertOne(update);
            }

            public static void InsertSubscriptionModel(int totalCost)
            {
                var client = new MongoClient(DbConnection.DB_STAGING_CONNECTION_STRING);
                var database = client.GetDatabase(DbConnection.DB_STAGING);
                var collection = database.GetCollection<SubscriptionsModels>("subscriptionmodels");
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
        

        

        
    }


}
