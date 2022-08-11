using Bar.Models;

namespace Bar.DataAcess.Repository.IRepository
{
    public interface IUserRepository : Repository<AppUser>
    {
        void Update(AppUser user);
    }
}
