using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC_CMS.Models
{
    [Table("userRole")]
    public class UserRole
    {
        [Key]
        public int roleID { get; set; }

        [Required]
        [MaxLength(100)]
        public string roleName { get; set; } = string.Empty;

        public string? description { get; set; }

        public bool isActive { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}