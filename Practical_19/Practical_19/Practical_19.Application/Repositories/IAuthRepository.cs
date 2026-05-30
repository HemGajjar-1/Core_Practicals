using Practical_19.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_19.Application.Repositories
{
    public interface IAuthRepository
    {
        Task<string> RegisterAsync(RegisterDto model);
        Task<string> LoginAsync(LoginDto model);
        Task SeedRolesAsync();
        Task LogoutAsync();
        Task<string> AssignAdminRoleAsync(string email);

    }
}
