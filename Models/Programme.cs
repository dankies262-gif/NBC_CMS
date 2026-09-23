using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC_CMS.Models
{
    [Table("programme")]
    public class Programme
    {
        [Key]
        public int programmeID { get; set; }

        [Required]
        [MaxLength(150)]
        public string programmeName { get; set; } = string.Empty;

        public string? description { get; set; }

        public bool isActive { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}