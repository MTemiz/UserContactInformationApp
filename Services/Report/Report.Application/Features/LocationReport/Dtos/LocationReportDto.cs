namespace Report.Application.Features.LocationReport.Dtos
{
    public class LocationReportDto
    {
        public Guid Id { get; set; }
        public DateTime RequestedDate { get; set; }
        public string State { get; set; }
    }
}
