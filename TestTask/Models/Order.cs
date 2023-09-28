using Microsoft.AspNetCore.Identity;

namespace TestTask.Models
{
    public class Order : IComparable<Order>
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; } 

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int CompareTo(Order? other)
        {
            if (other is Order order)
                return Price.CompareTo(order.Price);
            else throw new ArgumentException("Wrong type of object.");
        }
    }
}
