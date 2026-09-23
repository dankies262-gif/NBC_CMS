using System.ComponentModel.DataAnnotations;

namespace NBC_CMS.Requests
{
    public class UserRoleRequest
    {
        [Required]
        [MaxLength(100)]
        public string roleName { get; set; } = string.Empty;

        public string? description { get; set; }

        public bool isActive { get; set; } = true;
    }
}