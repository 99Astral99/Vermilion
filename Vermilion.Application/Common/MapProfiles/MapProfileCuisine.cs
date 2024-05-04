using AutoMapper;
using Vermilion.Contracts.Responses.Cuisines;
using Vermilion.Domain.Entities;

namespace Vermilion.Application.Common.MapProfiles
{
    public class MapProfileCuisine : Profile
    {
        public MapProfileCuisine()
        {
            CreateMap<Cuisine, ResponseCuisine>();
        }
    }
}
