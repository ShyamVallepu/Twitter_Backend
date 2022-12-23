using Twitter_Backend.Models;

namespace Twitter_Backend.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        bool Authenticate(string username, string password);
        User Register(User user);
        ICollection<User> GetAll();

        bool ChangePassword(string username, string newPassword);

        bool ForgotPassword(string username);
    }
}
