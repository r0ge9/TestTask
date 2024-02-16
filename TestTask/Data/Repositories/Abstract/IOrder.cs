using TestTask.Models;

namespace TestTask.Data.Repositories.Abstract
{
    public interface IOrder
    {
        public IQueryable<Order> GetOrders();
        public Order GetOrderById(int id);
        
    }
}
