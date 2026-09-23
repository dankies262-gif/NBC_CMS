namespace NBC_CMS.Responses
{
    public class ProgrammeResponse
    {
        public int programmeID { get; set; }

        public string programmeName { get; set; } = string.Empty;

        public string? description { get; set; }

        public bool isActive { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}