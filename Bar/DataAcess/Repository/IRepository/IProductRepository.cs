using Bar.Models;
using Bar.ViewModels;

namespace Bar.DataAcess.Repository.IRepository
{
    public interface IProductRepository : Repository<Product>
    {
        void Update(Product product);
    }
}
