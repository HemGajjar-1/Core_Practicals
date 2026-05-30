using Practical_19.Application.DTOs;
using Practical_19.Application.Repositories;
using Practical_19.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_19.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<string> RegisterAsync(RegisterDto model)
        {
            return await _authRepository.RegisterAsync(model);
        }

        public async Task<string> LoginAsync(LoginDto model)
        {
            return await _authRepository.LoginAsync(model);
        }

        public async Task SeedRolesAsync()
        {
            await _authRepository.SeedRolesAsync();
        }
        public async Task LogoutAsync()
        {
            await _authRepository.LogoutAsync();
        }
        public async Task<string> AssignAdminRoleAsync(string email)
        {
            return await _authRepository
                .AssignAdminRoleAsync(email);
        }
    }
}
