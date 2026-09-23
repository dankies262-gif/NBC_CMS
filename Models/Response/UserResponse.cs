namespace NBC_CMS.Responses
{
    public class UserResponse
    {
        public int userID { get; set; }

        public string username { get; set; } = string.Empty;

        public string firstName { get; set; } = string.Empty;

        public string lastName { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string? contactNumber { get; set; }

        public int roleID { get; set; }

        public bool isActive { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}