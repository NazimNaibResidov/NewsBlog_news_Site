using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsBlog.DTO.User;
using NewsBlog.Entities.UserEntity;
using NewsBlog.Interfaces.EntitySerivices;
using System.Threading.Tasks;

namespace NewsBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IUserService userService;

        public HomeController(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            _userManager = userManager;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            UserDTO applicationUser = new UserDTO();
            applicationUser.Name = "zzzz";
            applicationUser.Email = "Residovs@gmail.com";
            applicationUser.Password = "123$dsr4";

            IdentityResult result =await userService.Create(applicationUser);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}