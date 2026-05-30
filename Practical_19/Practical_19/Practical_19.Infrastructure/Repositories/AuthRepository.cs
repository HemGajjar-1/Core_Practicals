using Microsoft.AspNetCore.Identity;
using Practical_19.Application.DTOs;
using Practical_19.Application.Repositories;
using Practical_19.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_19.Infrastructure.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthRepository(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<string> RegisterAsync(RegisterDto model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if(userExists != null)
            {
                return "User already exists";
            }
            ApplicationUser user = new()
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return "Registration failed";
            }
            await _userManager.AddToRoleAsync(user, "User");
            return "Registration Successful";
        }
        public async Task<string> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return "Invalid email or password";
            }

            var result = await _signInManager
                .PasswordSignInAsync(
                    user.UserName,
                    model.Password,
                    false,
                    false);

            if (!result.Succeeded)
            {
                return "Invalid email or password";
            }

            return "Login successful";
        }
        public async Task SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(
                    new IdentityRole("Admin"));
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(
                    new IdentityRole("User"));
            }
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<string> AssignAdminRoleAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return "User not found";
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (isAdmin)
            {
                return "User is already Admin";
            }

            await _userManager.AddToRoleAsync(user, "Admin");

            return "Admin role assigned successfully";
        }
    }
}
