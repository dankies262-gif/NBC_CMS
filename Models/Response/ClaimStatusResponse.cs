namespace NBC_CMS.Responses
{
    public class ClaimStatusResponse
    {
        public int statusID { get; set; }

        public string statusName { get; set; } = string.Empty;

        public string? description { get; set; }
    }
}