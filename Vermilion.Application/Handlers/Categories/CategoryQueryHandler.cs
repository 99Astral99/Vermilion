using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Vermilion.Contracts.Categories.Queries.GetAll;
using Vermilion.Contracts.Categories.Queries.GetCategory;
using Vermilion.Contracts.Responses;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.Categories
{
    public class CategoryQueryHandler :
        IRequestHandler<GetCategoryQuery, ResponseCategory>,
        IRequestHandler<GetAllCategoriesQuery, IEnumerable<ResponseCategory>>
    {
        private readonly IRepositoryReadOnly<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryQueryHandler(IRepositoryReadOnly<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseCategory> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            Guard.Against.NotFound(request.Id.ToString(), existCategory, nameof(existCategory.Id));
            return _mapper.Map<ResponseCategory>(existCategory);
        }

        public async Task<IEnumerable<ResponseCategory>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var allCategories = await _categoryRepository.ListAsync(cancellationToken);
            return allCategories.Select(category => _mapper.Map<ResponseCategory>(category));
        }
    }
}
