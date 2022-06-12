namespace Report.Application.Features.LocationReport.Dtos
{
    public class LocationReportResultDto
    {
        public Guid Id { get; set; }
        public Guid LocationReportId { get; set; }
        public string Location { get; set; }
        public long PersonCount { get; set; }
        public long PhoneNumberCount { get; set; }

    }
}
