namespace Report.Application.Features.LocationReport.Dtos
{
    public class LocationReportDetailDto
    {
        public Guid Id { get; set; }
        public DateTime RequestedDate { get; set; }
        public string State { get; set; } 
        public ICollection<LocationReportResultDto> ReportResults { get; set; }
    }
}
