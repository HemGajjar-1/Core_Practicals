using Practical_20.Application.Interfaces;
using Practical_20.Domain.Entities;
using Practical_20.Infrastructure.Data;
using Practical_20.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_20.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Employee> Employees { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Employees = new GenericRepository<Employee>(_context);
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
