using Practical_20.Application.DTOs;
using Practical_20.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_20.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeeAsync();
        Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id);
        Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeDto employee);
        Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
