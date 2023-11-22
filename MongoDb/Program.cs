using MongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDb
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "mongodb://127.0.0.1:27017";
            string databaseName = "demoDb";
            string collectionName = "Users";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<User>(collectionName);

            //User user = new User()
            //{
            //    UserName = "Berdikulov",
            //    FirstName = "Sanjarbek",
            //    LastName = "Berdikulov",
            //    Password = "sanjarbek2006",
            //};

            //await collection.InsertOneAsync(user);

            var users = collection.Find(_ => true).ToList();

            foreach (User i in users)
            {
                Console.Out.WriteLine($"{i.UserId}: {i.UserName} {i.Password}");
            }
        }
    }
}