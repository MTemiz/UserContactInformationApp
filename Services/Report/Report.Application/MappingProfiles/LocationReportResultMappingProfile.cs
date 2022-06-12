using AutoMapper;
using Report.Application.Features.LocationReport.Dtos;
using Report.Domain.Entities;

namespace Report.Application.MappingProfiles
{
    public class LocationReportResultMappingProfile : Profile
    {
        public LocationReportResultMappingProfile()
        {
            CreateMap<LocationReportResult, LocationReportResultDto>();
        }
    }
}
