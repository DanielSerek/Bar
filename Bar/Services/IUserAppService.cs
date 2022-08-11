using Bar.Models;
using Bar.ViewModels;

namespace Bar.Services
{
    public interface IUserAppService
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserAsync(string? id);
        Task UpdateUserAsync(UserViewModel user);
        Task<IEnumerable<UserViewModel>> FilterUsersAsync(string? firstName, string? lastName);
        Task<decimal> GetCurrentUsersCreditAsync();
        Task<AppUser> GetCurrentUserAsync();
    }
}
