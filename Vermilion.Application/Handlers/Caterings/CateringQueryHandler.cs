using Ardalis.Specification;
using AutoMapper;
using FluentResults;
using MediatR;
using Vermilion.Application.Common.Exceptions;
using Vermilion.Contracts.Caterings.Queries.GetAll;
using Vermilion.Contracts.Caterings.Queries.GetCateringDetails;
using Vermilion.Contracts.Caterings.Queries.GetPageCaterings;
using Vermilion.Contracts.Responses.Caterings;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;
using Vermilion.Domain.Specifications.SpecsCatering;

namespace Vermilion.Application.Handlers.Caterings
{
    public class CateringQueryHandler :
        IRequestHandler<GetCateringDetailsQuery, Result<ResponseCateringInfo>>,
        IRequestHandler<GetAllCateringQuery, Result<IEnumerable<ResponseCatering>>>,
        IRequestHandler<GetPageCateringsQuery, Result<IEnumerable<ResponseCatering>>>
    {
        private readonly IRepositoryReadOnly<Catering> _cateringRepository;
        private readonly IRepositoryReadOnly<Review> _reviewRepository;
        private readonly IMapper _mapper;
        const int PAGE_SIZE = 10;

        public CateringQueryHandler(IRepositoryReadOnly<Catering> cateringRepository, IMapper mapper, IRepositoryReadOnly<Review> reviewRepository)
        {
            _cateringRepository = cateringRepository;
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<Result<ResponseCateringInfo>> Handle(GetCateringDetailsQuery request, CancellationToken cancellationToken)
        {
            var existCatering = await _cateringRepository.GetBySpecAsync(new CateringByIdSpec(request.Id), cancellationToken);
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
    }
}
