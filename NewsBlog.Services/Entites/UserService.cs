using Microsoft.AspNetCore.Identity;
using NewsBlog.DTO.User;
using NewsBlog.Entities.UserEntity;
using NewsBlog.Interfaces.EntitySerivices;
using System.Threading.Tasks;

namespace NewsBlog.Services.Entites
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Create(UserDTO userDTO)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.UserName = userDTO.Name;
            applicationUser.Email = userDTO.Email;
            return await _userManager.CreateAsync(applicationUser, userDTO.Password);
        }
    }
}