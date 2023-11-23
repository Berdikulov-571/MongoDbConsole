using MongoDb.Models;
using MongoDb.Services;

namespace MongoDb
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IEnumerable<User> users = await GenericService.GetAllAsync<User>("Users");

            foreach (User i in users)
            {
                Console.Out.WriteLine($"{i.UserId}: {i.UserName} {i.Password}");
            }
        }
    }
}