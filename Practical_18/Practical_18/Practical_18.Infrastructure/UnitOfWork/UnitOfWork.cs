using Microsoft.Identity.Client;
using Practical_18.Application.Interfaces;
using Practical_18.Infrastructure.Data;
using Practical_18.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_18.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository Students { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
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
