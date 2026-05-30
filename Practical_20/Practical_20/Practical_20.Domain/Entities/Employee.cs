using Practical_20.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_20.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
