using ImportBackend.Models;

namespace ImportBackend.Services.Users
{
    public interface IUserService
    {
        void CreateUser(User user);
        void DeleteUser(int id);
        User GetUser(int id);
        void UpsertUser(User user);
        IEnumerable<User> GetUsers();
        bool UserNameExists(string userName);
    }
}
