using AutoMapper;
using Vermilion.Contracts.Responses.Caterings;
using Vermilion.Domain.Entities;

namespace Vermilion.Application.Common.MapProfiles
{
    public class MapProfileCatering : Profile
    {
        public MapProfileCatering()
        {
            CreateMap<Catering, ResponseCateringInfo>()
                .ForMember(dest => dest.features, opt => opt.MapFrom(src => src.Features))
                .ForMember(dest => dest.cuisines, opt => opt.MapFrom(src => src.Cuisines))
                .ForMember(dest => dest.reviews, opt => opt.MapFrom(src => src.Reviews))
                .ForMember(dest => dest.workSchedules, opt => opt.MapFrom(src => src.WorkSchedules))
                .ForMember(dest => dest.averageRating, opt => opt.MapFrom(src => src.AverageRating));

            CreateMap<Catering, ResponseCatering>()
                .ForMember(dest => dest.features, opt => opt.MapFrom(src => src.Features))
                .ForMember(dest => dest.cuisines, opt => opt.MapFrom(src => src.Cuisines))
                .ForMember(dest => dest.averageRating, opt => opt.MapFrom(src => src.AverageRating));
        }
    }
}
