using System.ComponentModel.DataAnnotations;

namespace NBC_CMS.Requests
{
    public class ProgrammeRequest
    {
        [Required]
        [MaxLength(150)]
        public string programmeName { get; set; } = string.Empty;
    }
}