using Bar.ViewModels;

namespace Bar.Services
{
    public interface IProductAppService
    {
        Task<ProductViewModel> GetProductAsync(int id);
        Task<IEnumerable<ProductViewModel>> GetProductsAsync();
        Task AddProductAsync(ProductViewModel product);
        Task UpdateProductAsync(ProductViewModel product);

        Task UpdateProducts(Dictionary<int, ProductViewModel> input);
    }
}
