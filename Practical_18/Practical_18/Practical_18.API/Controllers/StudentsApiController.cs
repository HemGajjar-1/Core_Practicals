using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Practical_18.Application.Interfaces;
using Practical_18.Application.Services;
using Practical_18.Application.ViewModels;

namespace Practical_18.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsApiController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsApiController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentViewModel>> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult> Create(StudentViewModel model)
        {
            await _studentService.CreateAsync(model);
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,StudentViewModel model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }
            var updated = await _studentService.UpdateAsync(model);
            if(!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _studentService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
