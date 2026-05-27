using Practical_18.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_18.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GetAllAsync();
        Task<StudentViewModel?> GetByIdAsync(int id);
        Task CreateAsync(StudentViewModel student);
        Task<bool> UpdateAsync(StudentViewModel student);
        Task<bool> DeleteAsync(int id);
    }
}
