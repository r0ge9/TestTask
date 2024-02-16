using TestTask.Data.Repositories.Abstract;
using TestTask.Data.Repositories.EF;

namespace TestTask.Data
{
    public class DataManager
    {
        public IUser Users { get; set; }
        public IOrder Orders { get; set; }
        public DataManager(IOrder efOrder, IUser efUser) 
        {
            Users = efUser;
            Orders = efOrder;
        }
    }
}
