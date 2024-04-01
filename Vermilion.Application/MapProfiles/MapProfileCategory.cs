using AutoMapper;
using Vermilion.Contracts.Categories.Commands.UpdateCategory;
using Vermilion.Contracts.Responses;
using Vermilion.Domain.Entities;

namespace Vermilion.Application.MapProfiles
{
    public class MapProfileCategory : Profile
    {
        public MapProfileCategory()
        {
            CreateMap<Category, ResponseCategory>();
        }
    }
}
