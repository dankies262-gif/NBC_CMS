using System.ComponentModel.DataAnnotations;

namespace NBC_CMS.Requests
{
    public class ClaimStatusRequest
    {
        [Required]
        [MaxLength(100)]
        public string statusName { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? description { get; set; }
    }
}