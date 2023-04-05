using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Bson;
using System.Text.RegularExpressions;

namespace RaffleAutomationTests.Helpers
{


    public class AppDbHelper
    {
        public static List<DbModels.User> GetAllUsers()
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.User>("users");
            var filter = Builders<DbModels.User>.Filter.Empty;
            var result = collection.Find(filter).ToList();

            return result;
        }

        public static List<DbModels.User> GetUserByEmail(string email)
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.User>("users");
            var filter = Builders<DbModels.User>.Filter.Regex("email", new BsonRegularExpression(new Regex(email)));
            var result = collection.Find(filter).ToList();
            return result;
        }

        public static List<DbModels.Raffle> GetAllRaffles()
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Raffle>("raffles");
            var filter = Builders<DbModels.Raffle>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            return result;
        }

        public static List<DbModels.Raffle> GetAciveRaffles()
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Raffle>("raffles");
            var filter = Builders<DbModels.Raffle>.Filter.Where(x=>x.Active == true);
            var result = collection.Find(filter).ToList();
            return result;
        }

        public static List<DbModels.Property> GetAllProperties()
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Property>("properties");
            var filter = Builders<DbModels.Property>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            return result;
        }

        public static List<DbModels.Competitions> GetAllCompetitions()
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Competitions> ("competitions");
            var filter = Builders<DbModels.Competitions>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            return result;
        }

        public static void UpdateActiveDreamHomeToLowestPrice(List<DbModels.Raffle> raffle)
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Raffle>("raffles");
            var filter = Builders<DbModels.Raffle>.Filter.Eq("Id", new ObjectId(raffle.First().Id.ToString()));
            var update = Builders<DbModels.Raffle>.Update.Set("ticketPrice", 0.01);
            update.Set("discountCategory", "percent");
            update.Set("discountRates.0.percent", 16.666666666).Set("discountRates.0.newPrice", 0.01);
            update.Set("discountRates.1.percent", 0).Set("discountRates.1.newPrice", 0.01);
            var result = collection.UpdateOne(filter, update);
        }

        public static void UpdateActiveDreamHomeToNormalPrice(List<DbModels.Raffle> raffle)
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Raffle>("raffles");
            var filter = Builders<DbModels.Raffle>.Filter.Eq("Id", new ObjectId(raffle.First().Id.ToString()));
            var update = Builders<DbModels.Raffle>.Update.Set("ticketPrice", 2);
            update.Set("discountCategory", "percent");
            update.Set("discountRates.0.percent", 16.666666666).Set("discountRates.0.newPrice", 1.6666666);
            update.Set("discountRates.1.percent", 0).Set("discountRates.1.newPrice", 2);
            var result = collection.UpdateOne(filter, update);
        }

        public static List<DbModels.Subscriptions> GetAllSubscriptions()
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
            var filter = Builders<DbModels.Subscriptions>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            return result;
        }

        public static List<DbModels.Orders> GetAllOrders()
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Orders>("orders");
            var filter = Builders<DbModels.Orders>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            return result;
        }

        public static List<DbModels.Orders> GetAllOrdersByUserId(List<DbModels.User> user)
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Orders>("orders");
            var filter = Builders<DbModels.Orders>.Filter.Eq("user", new ObjectId(user.FirstOrDefault().Id.ToString())); ;
            var result = collection.Find(filter).ToList();
            return result;
        }

        public static List<DbModels.Subscriptions> GetAllSubscriptionsByUserId(List<DbModels.User> user)
        {
            var client = new MongoClient("mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging");
            var database = client.GetDatabase("rafflehousedb_staging");
            var collection = database.GetCollection<DbModels.Subscriptions>("subscriptions");
            var filter = Builders<DbModels.Subscriptions>.Filter.Eq("user", new ObjectId(user.FirstOrDefault().Id.ToString())); ;
            var result = collection.Find(filter).ToList();
            return result;
        }
    }


}
