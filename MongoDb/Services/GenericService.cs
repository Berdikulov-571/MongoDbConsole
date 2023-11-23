using MongoDB.Driver;

namespace MongoDb.Services
{
    public class GenericService
    {
        static string connectionString = "mongodb://127.0.0.1:27017";
        static string databaseName = "demoDb";

        public static async ValueTask<IEnumerable<T>> GetAllAsync<T>(string collectionName)
        {
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<T>(collectionName);

            List<T> result = await collection.Find(_ => true).ToListAsync();

            return result;
        }

        public static async ValueTask CreateAsync<T>(T model,string collectionName)
        {
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<T>(collectionName);

            await collection.InsertOneAsync(model);
        }
    }
}
