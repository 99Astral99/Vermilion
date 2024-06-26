﻿using Ardalis.Specification;
using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Vermilion.Application.Common.CachingExtensions;
using Vermilion.Application.Common.Exceptions;
using Vermilion.Contracts.Caterings.Queries.GetAll;
using Vermilion.Contracts.Caterings.Queries.GetCateringDetails;
using Vermilion.Contracts.Caterings.Queries.GetCateringsByCuisine;
using Vermilion.Contracts.Caterings.Queries.GetCateringsByFeature;
using Vermilion.Contracts.Caterings.Queries.GetPageCaterings;
using Vermilion.Contracts.Caterings.Queries.GetPendingCaterings;
using Vermilion.Contracts.Responses.Caterings;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;
using Vermilion.Domain.Specifications.SpecsCatering;

namespace Vermilion.Application.Handlers.Caterings
{
    public class CateringQueryHandler :
        IRequestHandler<GetCateringDetailsQuery, Result<ResponseCateringInfo>>,
        IRequestHandler<GetAllCateringQuery, Result<IEnumerable<ResponseCatering>>>,
        IRequestHandler<GetPageCateringsQuery, Result<IEnumerable<ResponseCatering>>>,
        IRequestHandler<GetPendingCateringsQuery, Result<IEnumerable<ResponseCatering>>>,
        IRequestHandler<GetCateringsByFeatureQuery, Result<IEnumerable<ResponseCatering>>>,
        IRequestHandler<GetCateringsByCuisineQuery, Result<IEnumerable<ResponseCatering>>>
    {
        private readonly IRepositoryReadOnly<Catering> _cateringRepository;
        private readonly IRepositoryReadOnly<Review> _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        const int PAGE_SIZE = 10;

        public CateringQueryHandler(IRepositoryReadOnly<Catering> cateringRepository, IMapper mapper, IRepositoryReadOnly<Review> reviewRepository, IDistributedCache cache)
        {
            _cateringRepository = cateringRepository;
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _cache = cache;
        }

        public async Task<Result<ResponseCateringInfo>> Handle(GetCateringDetailsQuery request, CancellationToken cancellationToken)
        {
            var existCatering = await _cache.GetAsync($"caterings-{request.Id}", async token =>
            {
                var existCatering = await _cateringRepository.GetBySpecAsync(new CateringByIdSpec(request.Id), cancellationToken);
                return existCatering;

            }, CacheOptions.DefaultExpiration, cancellationToken);

            if (existCatering is null)
                return Result.Fail(new ExceptionalError($"\"{nameof(Catering)}\" with ID: {request.Id.Value} was not found", new NotFoundException()));

            return Result.Ok(_mapper.Map<ResponseCateringInfo>(existCatering));
        }

        public async Task<Result<IEnumerable<ResponseCatering>>> Handle(GetAllCateringQuery request, CancellationToken cancellationToken)
        {
            var caterings = await _cateringRepository.ListAsync(cancellationToken);
            return Result.Ok(caterings.Select(catering => _mapper.Map<ResponseCatering>(catering)));
        }

        private Specification<Catering> GetPageSpec(int pageNumber)
        {
            var skipSize = (pageNumber - 1) * PAGE_SIZE;
            return new CateringPageSpec(skipSize, PAGE_SIZE);
        }

        public async Task<Result<IEnumerable<ResponseCatering>>> Handle(GetPageCateringsQuery request, CancellationToken cancellationToken)
        {
            var spec = GetPageSpec(request.pageNumber);
            var cateringsPage = await _cateringRepository.ListAsync(spec, cancellationToken);
            return Result.Ok(cateringsPage.Select(catering => _mapper.Map<ResponseCatering>(catering)));
        }

        public async Task<Result<IEnumerable<ResponseCatering>>> Handle(GetPendingCateringsQuery request, CancellationToken cancellationToken)
        {
            var spec = new PendingCateringSpec();
            var pendingCaterings = await _cateringRepository.ListAsync(spec, cancellationToken);
            return Result.Ok(pendingCaterings.Select(catering => _mapper.Map<ResponseCatering>(catering)));
        }

        public async Task<Result<IEnumerable<ResponseCatering>>> Handle(GetCateringsByFeatureQuery request, CancellationToken cancellationToken)
        {
            var spec = new CateringByFeatureSpec(request.featureName);
            var cateringsByFeature = await _cateringRepository.ListAsync(spec, cancellationToken);
            return Result.Ok(cateringsByFeature.Select(catering => _mapper.Map<ResponseCatering>(catering)));
        }

        public async Task<Result<IEnumerable<ResponseCatering>>> Handle(GetCateringsByCuisineQuery request, CancellationToken cancellationToken)
        {
            var spec = new CateringByCuisineSpec(request.cuisineName);
            var cateringsByCuisine = await _cateringRepository.ListAsync(spec, cancellationToken);
            return Result.Ok(cateringsByCuisine.Select(catering => _mapper.Map<ResponseCatering>(catering)));
        }
    }
}
