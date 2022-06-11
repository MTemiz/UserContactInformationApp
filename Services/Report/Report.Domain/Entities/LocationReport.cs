using Report.Domain.Enums;

namespace Report.Domain.Entities
{
    public class LocationReport : BaseEntity
    {
        public DateTime RequestedDate { get; set; }
        public EnmLocationReportState State { get; set; }
        public virtual LocationReportResult ReportResult { get; set; }
    }
}
