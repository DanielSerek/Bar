using AutoMapper;
using Bar.DataAcess.Repository.IRepository;
using Bar.Helpers;
using Bar.Models;
using Bar.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Bar.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public OrderAppService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateOrderAsync(OrderViewModel input, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var order = _mapper.Map<OrderViewModel, Order>(input);
            user.Credit -= order.OrderTotal;
            order.UserId = user.Id;
            order.Number = OrderNumberGenerator.GenerateOrderNumber();
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllOrders()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);
        }

        public async Task<List<OrderViewModel>> GetUsersOrders(AppUser user)
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            var filteredOrders = orders.Where(o => o.UserId.Contains(user.Id));
            var ordersViewModels = _mapper.Map<IEnumerable<Order>, List<OrderViewModel>>(filteredOrders);
            return ordersViewModels;
        }
    }
}
