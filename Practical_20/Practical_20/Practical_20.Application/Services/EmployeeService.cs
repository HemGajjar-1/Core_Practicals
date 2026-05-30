using Practical_20.Application.DTOs;
using Practical_20.Application.Interfaces;
using Practical_20.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_20.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeeAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return employees.Select(e => new EmployeeResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                Department = e.Department,
                Salary = e.Salary,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            });
        }
        public async Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id)
        {
            var employee =  await _unitOfWork.Employees.GetByIdAsync(id);
            if(employee==null)
            {
                return null;
            }
            return new EmployeeResponseDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Salary = employee.Salary,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }
        public async Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeDto model)
        {
            var employee = new Employee
            {
                Name = model.Name,
                Department = model.Department,
                Salary = model.Salary
            };
            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.CompleteAsync();
            return new EmployeeResponseDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Salary = employee.Salary,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }
        public async Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto dto)
        {
            var existingEmployee = await _unitOfWork.Employees.GetByIdAsync(dto.Id);
            if(existingEmployee == null)
            {
                return false;
            }
            
            existingEmployee.Name = dto.Name;
            existingEmployee.Salary = dto.Salary;
            existingEmployee.Department = dto.Department;

            _unitOfWork.Employees.Update(existingEmployee);

            await _unitOfWork.CompleteAsync();
            
            return true;
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var existingEmployee = await _unitOfWork.Employees.GetByIdAsync(id);
            if(existingEmployee == null)
            {
                return false;
            }
            _unitOfWork.Employees.Delete(existingEmployee);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
