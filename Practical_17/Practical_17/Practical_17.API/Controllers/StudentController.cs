using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practical_17.Application.DTOs.Student;
using Practical_17.Application.Interfaces.Services;

namespace Practical_17.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Authorize(Roles ="Admin,User")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            return Ok(student);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            await _studentService.CreateAsync(dto);
            return Ok("Student Created Successfully");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteAsync(id);
            return Ok("Student deleted successfully");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateStudentDto dto)
        {
            await _studentService.UpdateAsync(id, dto);
            return Ok("Student updated successfully");
        }

    }
}
