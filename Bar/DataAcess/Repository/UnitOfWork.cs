using AutoMapper;
using Bar.Data;
using Bar.DataAcess.Repository.IRepository;

namespace Bar.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public IProductRepository Products { get; private set; }
        public IUserRepository Users { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            Products = new ProductRepository(_db, _mapper);
            Users = new UserRepository(_db);
            Orders = new OrderRepository(_db, _mapper);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
