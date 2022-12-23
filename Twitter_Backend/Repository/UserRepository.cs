using Twitter_Backend.Data;
using Twitter_Backend.Models;
using Twitter_Backend.Repository.IRepository;

namespace Twitter_Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Authenticate(string username, string password)
        {
            bool rep;
            var user = _db.Users.FirstOrDefault(x => x.userName == username && x.password == password);
            if (user == null)
            {
                rep = false;
            }
            else
            {
                rep = true;
            }

            return rep;
        }

        public bool ChangePassword(string username, string newPassword)
        {
            User existingUser = _db.Users.FirstOrDefault(x => x.userName == username);
            if (existingUser != null)
            {
                existingUser.password = newPassword;
                _db.Users.Update(existingUser);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ForgotPassword(string username)
        {
            User deleteUser = _db.Users.FirstOrDefault(x => x.userName == username);
            if (deleteUser == null)
            {
                return false;
            }
            else
            {
                _db.Users.Remove(deleteUser);
                _db.SaveChanges();
                return true;
            }

        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.Users.SingleOrDefault(x => x.userName == username);

            // return true if user not found
            if (user == null)
                return true;

            return false;
        }

        public User Register(User user)
        {
            if (user != null)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                user.password = "";
                return user;
            }
            else
            {
                return null;
            }

        }

        ICollection<User> IUserRepository.GetAll()
        {
            return _db.Users.OrderBy(x => x.userName).ToList();
        }
    }
}

