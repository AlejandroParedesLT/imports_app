using ImportBackend.Data;
using ImportBackend.Models;
using ImportBackend.Services.Users;

namespace ImportBackend.Services.Users
{
    public class UserService : IUserService
    {
        public void CreateUser(User user)
        {
            using (var db = new OracleDBContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public User GetUser(int id)
        {
            using (var db = new OracleDBContext())
            {
                var user = db.Users.Find(id);
                return user;
            }
        }

        public void DeleteUser(int id)
        {
            using (var db = new OracleDBContext())
            {
                var user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }

        public void UpsertUser(User user)
        {
            using (var db = new OracleDBContext())
            {
                db.Users.Attach(user);
                var entry = db.Entry(user);
                entry.Property(e => e.GivenName).IsModified = true;
                entry.Property(e => e.LastName).IsModified = true;
                entry.Property(e => e.UserName).IsModified = true;
                entry.Property(e => e.Email).IsModified = true;
                entry.Property(e => e.Password).IsModified = true;
                entry.Property(e => e.DateUpdated).IsModified = true;
                db.SaveChanges();
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var db = new OracleDBContext())
            {
                var users = db.Users.ToList();
                return users;
            }
        }

        public bool UserNameExists(string userName)
        {
            using (var db = new OracleDBContext())
            {
                return db.Users.Any(u=>u.UserName == userName);
            }
        }
    }
}
