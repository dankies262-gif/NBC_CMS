namespace NBC_CMS.Responses
{
    public class UserRoleResponse
    {
        public int roleID { get; set; }

        public string roleName { get; set; } = string.Empty;

        public string? description { get; set; }

        public bool isActive { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}