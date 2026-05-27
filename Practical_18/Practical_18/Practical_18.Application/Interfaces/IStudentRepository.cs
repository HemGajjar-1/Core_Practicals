using Practical_18.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_18.Application.Interfaces
{
    public interface IStudentRepository : IRepository<Student> 
    {
        // Student specific methods declarations
    }
}
