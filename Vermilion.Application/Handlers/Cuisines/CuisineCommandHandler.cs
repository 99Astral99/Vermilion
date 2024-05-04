using AutoMapper;
using FluentResults;
using MediatR;
using Vermilion.Contracts.Cuisines.Commands;
using Vermilion.Contracts.Responses.Cuisines;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.Cuisines
{
    public class CuisineCommandHandler
        : IRequestHandler<CreateCuisineCommand, Result<ResponseCuisine>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Cuisine> _cuisineRepository;
        public CuisineCommandHandler(IRepository<Cuisine> cuisineRepository, IMapper mapper)
        {
            _cuisineRepository = cuisineRepository;
            _mapper = mapper;
        }
        public async Task<Result<ResponseCuisine>> Handle(CreateCuisineCommand request, CancellationToken cancellationToken)
        {
            var cuisineToCreate = Cuisine.Create(request.Name).Value;
            var createdCuisine = await _cuisineRepository.AddAsync(cuisineToCreate);
            return Result.Ok(_mapper.Map<ResponseCuisine>(createdCuisine));
        }
    }
}
