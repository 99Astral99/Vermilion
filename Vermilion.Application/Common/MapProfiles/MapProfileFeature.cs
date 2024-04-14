using AutoMapper;
using Vermilion.Contracts.Responses.Features;
using Vermilion.Domain.Entities;

namespace Vermilion.Application.Common.MapProfiles
{
    public class MapProfileFeature : Profile
    {
        public MapProfileFeature()
        {
            CreateMap<Feature, ResponseFeature>();
        }
    }
}
