using AutoMapper;
using Bar.DataAcess.Repository.IRepository;
using Bar.Models;
using Bar.ViewModels;

namespace Bar.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddProductAsync(ProductViewModel input)
        {
            if (input.Amount < 1) return;
            var product = _mapper.Map<ProductViewModel, Product>(input);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ProductViewModel> GetProductAsync(int id)
        {
            var product = await _unitOfWork.Products.GetFirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<Product, ProductViewModel>(product);
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
        }

        public async Task UpdateProductAsync(ProductViewModel input)
        {
            var product = await _unitOfWork.Products.GetFirstOrDefaultAsync(u => u.Id == input.Id);
            
            product.Name = input.Name;
            product.Price = input.Price;
            product.Amount = input.Amount;

            _unitOfWork.Products.Update(product);

            await _unitOfWork.SaveAsync();
        }

        // The method is used for transmitting data from dictionary to database
        public async Task UpdateProducts(Dictionary<int, ProductViewModel> input)
        {
            foreach (var product in input)
            {
                await UpdateProductAsync(product.Value);
            }
        }
    }
}
