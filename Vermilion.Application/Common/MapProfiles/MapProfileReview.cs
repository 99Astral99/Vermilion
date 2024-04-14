using AutoMapper;
using Vermilion.Contracts.Responses.Reviews;
using Vermilion.Domain.Entities;

namespace Vermilion.Application.Common.MapProfiles
{
    public class MapProfileReview : Profile
    {
        public MapProfileReview()
        {
            CreateMap<Review, ResponseReview>();
        }
    }
}
