using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_20.Application.DTOs
{
    public class UpdateEmployeeDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        [Range(1, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
