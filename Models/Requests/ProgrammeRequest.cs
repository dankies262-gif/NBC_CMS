using System.ComponentModel.DataAnnotations;

namespace NBC_CMS.Requests
{
    public class ProgrammeRequest
    {
        [Required]
        [MaxLength(200)]
        public string programmeName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? description { get; set; }
    }
}