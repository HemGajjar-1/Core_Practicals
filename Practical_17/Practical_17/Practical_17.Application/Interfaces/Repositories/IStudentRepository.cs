using Practical_17.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Application.Interfaces.Repositories
{
    public interface IStudentRepository :IGenericRepository<Student>
    {
        // Currently empty
        // Future use : Task<Student?> GetByEmailAsync(string email);
    }
}
