using AutoMapper;
using FluentResults;
using MediatR;
using Vermilion.Application.Common.Exceptions;
using Vermilion.Contracts.Categories.Queries.GetAll;
using Vermilion.Contracts.Categories.Queries.GetCategory;
using Vermilion.Contracts.Responses;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.Categories
{
    public class CategoryQueryHandler :
        IRequestHandler<GetCategoryQuery, Result<ResponseCategory>>,
        IRequestHandler<GetAllCategoriesQuery, Result<IEnumerable<ResponseCategory>>>
    {
        private readonly IRepositoryReadOnly<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryQueryHandler(IRepositoryReadOnly<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Result<ResponseCategory>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existCategory is null)
                return Result.Fail(new ExceptionalError($"\"{nameof(Category)}\" with ID: {request.Id.Value} was not found", new NotFoundException()));

            return Result.Ok(_mapper.Map<ResponseCategory>(existCategory));
        }

        public async Task<Result<IEnumerable<ResponseCategory>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var allCategories = await _categoryRepository.ListAsync(cancellationToken);
            return Result.Ok(allCategories.Select(category => _mapper.Map<ResponseCategory>(category)));
        }
    }
}
