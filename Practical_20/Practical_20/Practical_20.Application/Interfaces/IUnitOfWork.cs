using Practical_20.Application.Interfaces;
using Practical_20.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_20.Application.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Employee> Employees { get; }
        Task<int> CompleteAsync();
    }
}
