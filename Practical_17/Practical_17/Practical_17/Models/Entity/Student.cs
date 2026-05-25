using System.ComponentModel.DataAnnotations;

namespace Practical_17.Models.Entity
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public string Email { get; set; }
    }
}
