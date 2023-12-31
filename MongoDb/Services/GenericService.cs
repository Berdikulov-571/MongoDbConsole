﻿using MongoDb.Models;
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

        public static async ValueTask CreateAsync<T>(T model, string collectionName)
        {
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<T>(collectionName);

            await collection.InsertOneAsync(model);
        }

        public static async ValueTask CreateRangeAsync<T>(List<T> models, string collectionName)
        {
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<T>(collectionName);

            await collection.InsertManyAsync(models);
        }

        public static async ValueTask DeleteAsync(string UserId, string collectionName)
        {
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<User>(collectionName);

            await collection.DeleteOneAsync(x => x.UserId == UserId);
        }

        public static async ValueTask DeleteRangeAsync(List<string> usersIds,string collectionName)
        {
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<User>(collectionName);

            foreach(var i in usersIds)
            {
                await collection.DeleteOneAsync(x => x.UserId == i);
            }
        }

        public static async ValueTask UpdateAsync(string userId, UpdateDefinition<User> newUser,string collectionName)
        {
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<User>(collectionName);

            await collection.UpdateOneAsync(x => x.UserId == userId,newUser);
        }
    }
}