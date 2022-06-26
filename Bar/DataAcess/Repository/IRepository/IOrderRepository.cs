using Bar.Models;
using Bar.ViewModels;
using System.Collections;

namespace Bar.DataAcess.Repository.IRepository
{
    public interface IOrderRepository : Repository<Order>
    {
        Task CreateOrderAsync(OrderViewModel order);
    }
}
