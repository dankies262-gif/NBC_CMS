using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC_CMS.Models
{
    [Table("claimStatus")]
    public class ClaimStatus
    {
        [Key]
        public int statusID { get; set; }

        [Required]
        [MaxLength(100)]
        public string statusName { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? description { get; set; }
    }
}