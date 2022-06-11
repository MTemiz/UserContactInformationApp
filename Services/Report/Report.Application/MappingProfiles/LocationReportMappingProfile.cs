using AutoMapper;
using Report.Application.Features.LocationReport.Commands;
using Report.Application.Features.LocationReport.Dtos;
using Report.Domain.Entities;

namespace Report.Application.MappingProfiles
{
    public class LocationReportMappingProfile : Profile
    {
        public LocationReportMappingProfile()
        {
            CreateMap<RequestLocationReportCommand, LocationReport>()
                 .BeforeMap((s, d) => d.State = Domain.Enums.EnmLocationReportState.Preparing);

            CreateMap<LocationReport, LocationReportDto>()
                .ForMember(
                            dest => dest.State,
                            opt => opt.MapFrom((s, d) => d.State = s.State.ToString()));
        }
    }
}
