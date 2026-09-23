using System.ComponentModel.DataAnnotations;

namespace NBC_CMS.Requests
{
    public class UserRequest
    {
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
        [EmailAddress]
        public string email { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? contactNumber { get; set; }

        [Required]
        public int roleID { get; set; }

        [Required]
        public bool isActive { get; set; }
    }
}