using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practical_19.API.Models;
using System.Diagnostics;

namespace Practical_19.API.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}
