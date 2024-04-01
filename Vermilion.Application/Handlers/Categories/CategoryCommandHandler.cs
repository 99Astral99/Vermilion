using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Vermilion.Contracts.Categories.Commands.CreateCategory;
using Vermilion.Contracts.Categories.Commands.DeleteCategory;
using Vermilion.Contracts.Categories.Commands.UpdateCategory;
using Vermilion.Contracts.Responses;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.Categories
{
    public class CategoryCommandHandler :
        IRequestHandler<CreateCategoryCommand, ResponseCategory>,
        IRequestHandler<UpdateCategoryCommand, ResponseCategory>,
        IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryCommandHandler(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseCategory> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToCreate = Category.Create(request.Name).Value;
            var createdCategory = await _categoryRepository.AddAsync(categoryToCreate);

            return _mapper.Map<ResponseCategory>(createdCategory);
        }

        public async Task<ResponseCategory> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            Guard.Against.NotFound(request.Id.ToString(), existCategory, nameof(existCategory.Id));

            existCategory.SetName(request.Name);
            await _categoryRepository.UpdateAsync(existCategory);

            var updatedCategory = await _categoryRepository.GetByIdAsync(existCategory.Id, cancellationToken);
            return _mapper.Map<ResponseCategory>(updatedCategory);
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            Guard.Against.NotFound(request.Id.ToString(), existCategory, nameof(existCategory.Id));

            await _categoryRepository.DeleteAsync(existCategory, cancellationToken);
        }
    }
}
