using Practical_17.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetById(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
