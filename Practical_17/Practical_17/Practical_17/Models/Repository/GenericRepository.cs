using Microsoft.EntityFrameworkCore;
using Practical_17.Models.Data;

namespace Practical_17.Models.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(object id)
        {
            T entity = _dbSet.Find(id);
            if(entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
