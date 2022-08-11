using Bar.Data;
using Bar.DataAcess.Repository.IRepository;
using Bar.Models;

namespace Bar.DataAcess.Repository
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AppUser user)
        {
            _db.Users.Update(user);
        }
    }
}
