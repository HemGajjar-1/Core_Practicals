using Practical_17.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        Task<int> SaveChangesAsync();
    }
}
