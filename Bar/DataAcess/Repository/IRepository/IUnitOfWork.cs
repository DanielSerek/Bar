namespace Bar.DataAcess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        IOrderRepository Orders { get; }

        Task SaveAsync();
    }
}
