using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Practical_17.Application.Interfaces.Repositories;
using Practical_17.Domain.Common;
using Practical_17.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
        }
    }
}
