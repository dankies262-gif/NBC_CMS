namespace NBC_CMS.Responses
{
    public class ClaimCorrectionResponse
    {
        public int correctionID { get; set; }

        public int claimID { get; set; }

        public int requestedBy { get; set; }

        public string correctionComment { get; set; } = string.Empty;

        public DateTime requestedAt { get; set; }

        public DateTime? correctedAt { get; set; }
    }
}