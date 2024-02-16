using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Data.Repositories.Abstract
{
    public interface IUser
    {
        public IQueryable<User> GetUsers();
        public User GetUserById(int id);
        public User GetUserByStatus(UserStatus userStatus);
    }
}
