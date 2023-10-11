using Web_Services.Models;

namespace Web_Services.Services
{
    public interface IUserService
    {
        User CreateUser(User user);
        List<User> GetUsers(int page);
        User GetUserById(string id);
        string FindByUserName(string username, string NIC);
        void UpdateUser(string id, User user);
        void DeleteUser(string id);
    }
}
