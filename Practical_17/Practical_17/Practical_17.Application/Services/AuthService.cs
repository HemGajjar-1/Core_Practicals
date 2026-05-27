using Microsoft.AspNetCore.Identity;
using Practical_17.Application.DTOs.Auth;
using Practical_17.Application.Interfaces.Services;
using Practical_17.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
    
        public AuthService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email,
                PhoneNumber = dto.MobileNumber
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }
            await _userManager.AddToRoleAsync(user, "User");
            return "User registered successfully";
        }
        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new Exception("Invalid Credentials");
            }
            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid credentials");
            }
            return "Login Successful";
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
