using Microsoft.AspNetCore.Mvc;
using Practical_18.Application.Interfaces;
using Practical_18.Application.Services;
using Practical_18.Application.ViewModels;

namespace Practical_18.API.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _studentService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updated = await _studentService.UpdateAsync(model);
            if (!updated)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _studentService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
