using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using Web_Services.Models;

namespace Web_Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IUserStoreDatabaseSettings settings, IMongoClient mongoClient)
        {

            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }
        public User CreateUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public User GetUserById(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public string FindByUserName(string username, string NIC)
        {
            var user = _users.Find(user => user.UserName == username).FirstOrDefault();

            if (user == null)
            {
                return "User Not Found";
            }

            var passwordValid = _users.Find(user => user.NIC == NIC).FirstOrDefault();

            if (passwordValid == null)
            {
                return "Password is incorrect";
            }

            return "Authorized";

        }

        public List<User> GetUsers(int page)
        {
            var skip = (page - 1) * 8;
            return _users.Find(_ => true).Skip(skip).Limit(8).ToList();
        }

        public void UpdateUser(string id, User user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }
    }
}
