using Microsoft.AspNetCore.Mvc;
using Practical_20.Application.DTOs;
using Practical_20.Application.Interfaces;
using Practical_20.Domain.Entities;

namespace Practical_20.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeeAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if(employee==null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto employee)
        {
            var createdEmployee = await _employeeService.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, createdEmployee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateEmployeeDto employee)
        {
            if(id != employee.Id)
            {
                return BadRequest("Employee ID Mismatch..");
            }
            var updated = await _employeeService.UpdateEmployeeAsync(employee);
            if(!updated)
            {
                return NotFound("Employee not found...");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(id);
            if(!deleted)
            {
                return NotFound("Employee not found...");
            }
            return NoContent();
        }
    }
}
