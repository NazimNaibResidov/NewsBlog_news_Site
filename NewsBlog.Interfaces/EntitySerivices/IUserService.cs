using Microsoft.AspNetCore.Identity;
using NewsBlog.DTO.User;
using System.Threading.Tasks;

namespace NewsBlog.Interfaces.EntitySerivices
{
    public interface IUserService
    {
        Task<IdentityResult> Create(UserDTO userDTO);
    }
}