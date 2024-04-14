using AutoMapper;
using Vermilion.Contracts.Responses.WorkSchedules;
using Vermilion.Domain.Entities;

namespace Vermilion.Application.Common.MapProfiles
{
    public class MapProfileWorkSchedule : Profile
    {
        public MapProfileWorkSchedule()
        {
            CreateMap<WorkSchedule, ResponseWorkSchedule>();
        }
    }
}
