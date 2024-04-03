using AutoMapper;
using Vermilion.Contracts.Responses;
using Vermilion.Domain.Entities;

namespace Vermilion.Application.Common.MapProfiles
{
    public class MapProfileCategory : Profile
    {
        public MapProfileCategory()
        {
            CreateMap<Category, ResponseCategory>();
        }
    }
}
