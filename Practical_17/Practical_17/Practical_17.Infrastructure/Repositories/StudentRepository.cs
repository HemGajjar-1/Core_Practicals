using Practical_17.Application.Interfaces.Repositories;
using Practical_17.Domain.Entities;
using Practical_17.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            // Future scope
        }
    }
}
