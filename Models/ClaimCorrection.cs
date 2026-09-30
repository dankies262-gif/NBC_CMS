using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC_CMS.Models
{
    [Table("claimCorrection")]
    public class ClaimCorrection
    {
        [Key]
        public int correctionID { get; set; }

        [Required]
        public int claimID { get; set; }

        [Required]
        public int requestedBy { get; set; }

        [Required]
        public string correctionComment { get; set; } = string.Empty;

        public DateTime requestedAt { get; set; }

        public DateTime? correctedAt { get; set; }
    }
}