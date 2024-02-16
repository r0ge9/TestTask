using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly DataManager _dataManager;
        public OrderService(DataManager dataManager)
        {
            _dataManager=dataManager;
        }
        public  Task<Order> GetOrder()
        {
            var orders = _dataManager.Orders.GetOrders();
            return orders.OrderByDescending(order => order.Price).FirstAsync();

        }

        public Task<List<Order>> GetOrders()
        {
            var orders=_dataManager.Orders.GetOrders();
            return orders.Where(x => x.Quantity > 10).ToListAsync();
        }
    }
}
