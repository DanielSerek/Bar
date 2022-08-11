using Bar.Models;
using Bar.ViewModels;

namespace Bar.Services
{
    public interface IOrderAppService
    {
        Task CreateOrderAsync(OrderViewModel order, string userName);
        Task<List<OrderViewModel>> GetUsersOrders(AppUser user);
        Task<IEnumerable<OrderViewModel>> GetAllOrders();
    }
}
