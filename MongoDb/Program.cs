using MongoDb.Models;
using MongoDb.Services;
using MongoDB.Driver;

namespace MongoDb
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            UpdateDefinition<User> update = Builders<User>.Update
            .Set("Password", "sanjarbek20061008");

            await GenericService.UpdateAsync("655df0d43804711158ce0f1d", update, "Users");

            IEnumerable<User> users = await GenericService.GetAllAsync<User>("Users");

            foreach (User i in users)
            {
                Console.Out.WriteLine($"{i.UserId}: {i.UserName} {i.Password}");
            }
        }
    }
}