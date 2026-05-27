using Practical_18.Application.Interfaces;
using Practical_18.Domain.Entities;
using Practical_18.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_18.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student> , IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            // Student specific method implementation
        }
    }
}
