using Practical_17.Application.Interfaces.Repositories;
using Practical_17.Application.Interfaces.UnitOfWork;
using Practical_17.Infrastructure.Data;
using Practical_17.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository Students { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new StudentRepository(context);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
