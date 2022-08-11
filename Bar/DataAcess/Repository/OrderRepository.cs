using AutoMapper;
using Bar.Data;
using Bar.DataAcess.Repository.IRepository;
using Bar.Models;
using Bar.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Bar.DataAcess.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public OrderRepository(ApplicationDbContext db, IMapper mapper) : base(db)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task CreateOrderAsync(OrderViewModel order)
        {
            try
            {
                var obj = _mapper.Map<OrderViewModel, Order>(order);
                _db.Orders.Add(obj);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public new async Task<IEnumerable<Order>> GetAllAsync()
        {
            IQueryable<Order> query = _db.Set<Order>();
            return await query.Include(o=>o.Items).Include(o=>o.User).ToListAsync();
        }
    }
}
