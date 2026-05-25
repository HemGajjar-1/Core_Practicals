using Microsoft.AspNetCore.Mvc;
using Practical_17.Models.Entity;
using Practical_17.Models.Service;

namespace Practical_17.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _service.GetAll();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _service.GetById(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _service.Add(student);
            return Ok("Student Added Successfully");
        }
        [HttpPut]
        public IActionResult Update(Student student)
        {
            _service.Update(student);
            return Ok("Student Updated Successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Student Deleted Successfully");
        }
    }
}
