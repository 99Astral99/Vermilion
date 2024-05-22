using AutoMapper;
using Vermilion.Contracts.Responses.CateringImage;
using Vermilion.Domain.Entities;

namespace Vermilion.Application.Common.MapProfiles
{
    public class MapCateringImage : Profile
    {
        public MapCateringImage()
        {
            CreateMap<CateringImage, ResponseCateringImage>()
                 .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
