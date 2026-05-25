using System.ComponentModel.DataAnnotations;

namespace Practical_17.Models.Entity
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
