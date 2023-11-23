using MongoDb.Models;
using MongoDb.Services;

namespace MongoDb
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            List<User> insertUsers = new List<User>()
            {
                new User() { UserName = "JurayevKh",FirstName = "Rustambek",LastName = "Jurayev",Password = "2008"},
                new User() { UserName = "Suhrob06",FirstName = "Suhrob",LastName = "Hasanov",Password = "2006"}
            };

            await GenericService.CreateRangeAsync<User>(insertUsers, "Users");

            IEnumerable<User> users = await GenericService.GetAllAsync<User>("Users");

            foreach (User i in users)
            {
                Console.Out.WriteLine($"{i.UserId}: {i.UserName} {i.Password}");
            }
        }
    }
}