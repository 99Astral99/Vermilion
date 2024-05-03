using Ardalis.Specification;
using AutoMapper;
using FluentResults;
using MediatR;
using Vermilion.Contracts.Features.Commands.CreateFeature;
using Vermilion.Contracts.Responses.Features;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.Features
{
    public class FeatureCommandHandler
        : IRequestHandler<CreateFeatureCommand, Result<ResponseFeature>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Feature> _featureRepository;
        public FeatureCommandHandler(IRepository<Feature> featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<Result<ResponseFeature>> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var featureToCreate = Feature.Create(request.Name).Value;
            var createdFeature = await _featureRepository.AddAsync(featureToCreate, cancellationToken);

            return Result.Ok(_mapper.Map<ResponseFeature>(createdFeature));
        }
    }
}
