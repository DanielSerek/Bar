using AutoMapper;
using Bar.DataAcess.Repository.IRepository;
using Bar.Models;
using Bar.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Bar.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly UserManager<AppUser> _userManager;

        public UserAppService(IUnitOfWork unitOfWork, IMapper mapper, AuthenticationStateProvider authenticationStateProvider, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authenticationStateProvider = authenticationStateProvider;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<AppUser>, List<UserViewModel>>(users);
        }

        public async Task<UserViewModel> GetUserAsync(string? id)
        {
            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<AppUser, UserViewModel>(user);
        }

        public async Task UpdateUserAsync(UserViewModel user)
        {
            var userFromDb = await _unitOfWork.Users.GetFirstOrDefaultAsync(u => u.Email == user.Email);
            if (userFromDb != null)
            {
                userFromDb.Credit = user.Credit;
            }

            _unitOfWork.Users.Update(userFromDb);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<UserViewModel>> FilterUsersAsync(string firstName, string lastName)
        {
            var allUsers = await _unitOfWork.Users.GetAllAsync();
            List<AppUser> filteredUsers = new List<AppUser>();

            if (firstName != null && lastName != null)
                filteredUsers = allUsers.Where(u => u.FirstName.Contains(firstName) && u.LastName.Contains(lastName)).ToList();

            if (firstName != null && lastName == null)
                filteredUsers = allUsers.Where(u => u.FirstName.Contains(firstName)).ToList();

            if (lastName != null && firstName == null)
                filteredUsers = allUsers.Where(u => u.LastName.Contains(lastName)).ToList();

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName)) 
                filteredUsers.AddRange(allUsers.ToList());

            return _mapper.Map<IEnumerable<AppUser>, IEnumerable<UserViewModel>>(filteredUsers.Distinct());
        }

        public async Task<decimal> GetCurrentUsersCreditAsync()
        {
            var user = await GetCurrentUserAsync();
            if (user is not null) return user.Credit;
            else return 0;
        }

        public async Task<AppUser> GetCurrentUserAsync()
        {
            var userName = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.Name;
            return await _unitOfWork.Users.GetFirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
