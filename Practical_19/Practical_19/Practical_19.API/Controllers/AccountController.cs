using Microsoft.AspNetCore.Mvc;
using Practical_19.API.Models;
using Practical_19.Application.DTOs;
using Practical_19.Application.Repositories;
using Practical_19.Application.Services;

namespace Practical_19.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authService.RegisterAsync(model);

            ViewBag.Message = result;

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authService.LoginAsync(model);

            if (result == "Login successful")
            {
                return RedirectToAction(
                    "Index",
                    "Home");
            }

            ViewBag.Message = result;

            return View();
        }

        public async Task<IActionResult> SeedRoles()
        {
            await _authService.SeedRolesAsync();

            return Content("Roles Created");
        }
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();

            return RedirectToAction("Login");
        }
        public async Task<IActionResult> MakeAdmin(string email)
        {
            var result = await _authService
                .AssignAdminRoleAsync(email);

            return Content(result);
        }
    }
}
