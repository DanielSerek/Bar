using AutoMapper;
using Bar.Data;
using Bar.DataAcess.Repository.IRepository;
using Bar.Models;
using Bar.ViewModels;

namespace Bar.DataAcess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper) : base(db)
        {
            _db = db;
            _mapper = mapper;
        }

        public void Update(Product product)
        {
            _db.Products.Update(product);
        }
    }
}
