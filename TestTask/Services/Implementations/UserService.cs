using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DataManager _dataManager;
        public UserService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public async Task<User> GetUser()
        {
            var orders = _dataManager.Orders.GetOrders();
            var user=orders.GroupBy(o => o.UserId).Select(o => new { UserId = o.Key, OrderCount = o.Count() }).OrderByDescending(o => o.OrderCount).FirstOrDefault();
            return  _dataManager.Users.GetUserById(user.UserId);
        }
        
        public Task<List<User>> GetUsers()
        {
            var users = _dataManager.Users.GetUsers();
            return users.Where(x => x.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
