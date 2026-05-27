using Practical_17.Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Application.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateStudentDto dto);
        Task UpdateAsync(int id, UpdateStudentDto dto);
        Task DeleteAsync(int id);
    }
}
