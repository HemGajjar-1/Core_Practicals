using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_20.Application.DTOs
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
