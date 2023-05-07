namespace AdvoSecure.Domain.Interfaces.Requests
{
    public class MatterSearchRequest
    {
        public string Status { get; set; }

        public string ContactName { get; set; }

        public string Description { get; set; }

        public string CaseNumber { get; set; }

        public int? MatterAreaId { get; set; }

        public int? CourtGeographicalJurisdictionId { get; set; }
    }
}
