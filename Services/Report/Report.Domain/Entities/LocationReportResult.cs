using BuildingBlocks.Domain;

namespace Report.Domain.Entities
{
    public class LocationReportResult : BaseEntity
    {
        public Guid LocationReportId { get; set; }
        public string Location { get; set; }
        public long PersonCount { get; set; }
        public long PhoneNumberCount { get; set; }
    }
}
