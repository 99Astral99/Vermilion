using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Vermilion.Application.Common.Exceptions;
using Vermilion.Contracts.Caterings.Commands.AddCuisine;
using Vermilion.Contracts.Caterings.Commands.AddFeature;
using Vermilion.Contracts.Caterings.Commands.CreateCatering;
using Vermilion.Contracts.Caterings.Commands.DeleteCatering;
using Vermilion.Contracts.Caterings.Commands.UpdateCateringCommand;
using Vermilion.Contracts.Responses.Caterings;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.Caterings
{
    public class CateringCommandHandler :
        IRequestHandler<CreateCateringCommand, Result<ResponseCatering>>,
        IRequestHandler<UpdateCateringCommand, Result<ResponseCatering>>,
        IRequestHandler<DeleteCateringCommand, Result>,
        IRequestHandler<AddCuisineCommand, Result>,
        IRequestHandler<AddFeatureCommand, Result>
    {
        private readonly IRepository<Catering> _cateringRepository;
        private readonly IRepository<Cuisine> _cuisineRepository;
        private readonly IRepository<Feature> _featureRepository;
        private readonly IDistributedCache _cache;

        private readonly IMapper _mapper;

        public CateringCommandHandler(IRepository<Catering> categoryRepository, IMapper mapper, IRepository<Cuisine> cuisineRepository, IRepository<Feature> featureRepository, IDistributedCache cache)
        {
            _cateringRepository = categoryRepository;
            _mapper = mapper;
            _cuisineRepository = cuisineRepository;
            _featureRepository = featureRepository;
            _cache = cache;
        }
        public async Task<Result<ResponseCatering>> Handle(CreateCateringCommand request, CancellationToken cancellationToken)
        {
            var cateringToCreate = Catering.Create(request.Name, request.Description, request.ContactInfo, request.Address).Value;

            var createdCatering = await _cateringRepository.AddAsync(cateringToCreate);

            return Result.Ok(_mapper.Map<ResponseCatering>(createdCatering));
        }

        public async Task<Result<ResponseCatering>> Handle(UpdateCateringCommand request, CancellationToken cancellationToken)
        {
            var existCatering = await _cateringRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existCatering is null)
                return Result.Fail(new ExceptionalError($"\"{nameof(Catering)}\" with ID: {request.Id.Value} was not found", new NotFoundException()));

            existCatering.UpdateDetails(request.ContactInfo, request.Name, request.Description, request.Address);
            await _cateringRepository.UpdateAsync(existCatering, cancellationToken);

            var updatedCatering = await _cateringRepository.GetByIdAsync(existCatering.Id, cancellationToken);
            await _cache.RemoveAsync($"caterings-{request.Id}");

            return Result.Ok(_mapper.Map<ResponseCatering>(updatedCatering));
        }

        public async Task<Result> Handle(DeleteCateringCommand request, CancellationToken cancellationToken)
        {
            var existCatering = await _cateringRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existCatering is null)
                return Result.Fail(new ExceptionalError($"\"{nameof(Catering)}\" with ID: {request.Id.Value} was not found", new NotFoundException()));

            await _cateringRepository.DeleteAsync(existCatering, cancellationToken);

            await _cache.RemoveAsync($"caterings-{request.Id}");

            return Result.Ok();
        }

        public async Task<Result> Handle(AddCuisineCommand request, CancellationToken cancellationToken)
        {
            var catering = await _cateringRepository.GetByIdAsync(request.CateringId, cancellationToken);
            if (catering is null) return Result.Fail(new ExceptionalError($"\"{nameof(Catering)}\" with ID: {request.CateringId.Value} was not found", new NotFoundException()));
            var cuisine = await _cuisineRepository.GetByIdAsync(request.CuisineId, cancellationToken);
            if (cuisine is null) return Result.Fail(new ExceptionalError($"\"{nameof(Cuisine)}\" with ID: {request.CuisineId.Value} was not found", new NotFoundException()));

            catering.AddCuisine(cuisine);
            await _cateringRepository.UpdateAsync(catering);

            await _cache.RemoveAsync($"caterings-{catering.Id}");
            return Result.Ok();
        }

        public async Task<Result> Handle(AddFeatureCommand request, CancellationToken cancellationToken)
        {
            var catering = await _cateringRepository.GetByIdAsync(request.CateringId, cancellationToken);
            if (catering is null) return Result.Fail(new ExceptionalError($"\"{nameof(Catering)}\" with ID: {request.CateringId.Value} was not found", new NotFoundException()));
            var feature = await _featureRepository.GetByIdAsync(request.FeatureId, cancellationToken);
            if (feature is null) return Result.Fail(new ExceptionalError($"\"{nameof(Feature)}\" with ID: {request.FeatureId.Value} was not found", new NotFoundException()));
            catering.AddFeature(feature);
            await _featureRepository.UpdateAsync(feature);

            await _cache.RemoveAsync($"caterings-{catering.Id}");
            return Result.Ok();
        }
    }
}
