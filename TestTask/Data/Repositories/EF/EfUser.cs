using TestTask.Data.Repositories.Abstract;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Data.Repositories.EF
{
    public class EfUser : IUser
    {
        private readonly ApplicationDbContext _context;
        public EfUser(ApplicationDbContext context)
        {
            _context = context;
        }
        public User GetUserById(int id)
        {
            NullContextException();
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        private void NullContextException()
        {
            try { _context.SaveChanges(); } 
            catch 
            {
                throw new NullReferenceException();
            }
        }

        public User GetUserByStatus(UserStatus userStatus)
        {
            NullContextException();
            return _context.Users.FirstOrDefault(x => x.Status == userStatus);
        }

        public IQueryable<User> GetUsers()
        {
            NullContextException();
            return _context.Users;
        }
    }
}
