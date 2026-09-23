using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC_CMS.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int userID { get; set; }

        [Required]
        [MaxLength(150)]
        public string username { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string firstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string lastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string email { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? contactNumber { get; set; }

        [Required]
        public int roleID { get; set; }

        [Required]
        public bool isActive { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}