using System.ComponentModel.DataAnnotations;

namespace NBC_CMS.Requests
{
    public class ClaimCorrectionRequest
    {
        [Required]
        public int claimID { get; set; }

        [Required]
        public int requestedBy { get; set; }

        [Required]
        public string correctionComment { get; set; } = string.Empty;
    }
}