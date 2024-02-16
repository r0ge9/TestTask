using TestTask.Data.Repositories.Abstract;
using TestTask.Models;

namespace TestTask.Data.Repositories.EF
{
    public class EfOrder : IOrder
    {
        private readonly ApplicationDbContext _context;
        public EfOrder(ApplicationDbContext context)
        {
            _context = context;
        }
        public Order GetOrderById(int id)
        {
            NullContextException();
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
        private void NullContextException()
        {
            try { _context.SaveChanges(); } catch {throw new NullReferenceException(); } 
        }
       

        public IQueryable<Order> GetOrders()
        {
            NullContextException();
            return _context.Orders;
        }
    }
}
