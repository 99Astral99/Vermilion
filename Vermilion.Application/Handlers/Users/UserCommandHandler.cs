using AutoMapper;
using FluentResults;
using MediatR;
using Vermilion.Application.Common.Abstractions.EventBus;
using Vermilion.Application.Common.Exceptions;
using Vermilion.Contracts.Responses.Reviews;
using Vermilion.Contracts.Users.Commands.AddReview;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.Users
{
    public class UserCommandHandler :
        IRequestHandler<AddReviewCommand, Result<ResponseReview>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Catering> _cateringRepository;

        public UserCommandHandler(IMapper mapper, IRepository<User> userRepository, IRepository<Catering> cateringRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _cateringRepository = cateringRepository;
        }

        public async Task<Result<ResponseReview>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (user is null)
                return Result.Fail(new ExceptionalError($"\"{nameof(User)}\" with ID: {request.UserId.Value} was not found", new NotFoundException()));

            var catering = await _cateringRepository.GetByIdAsync(request.CateringId);

            if (catering is null)
                return Result.Fail(new ExceptionalError($"\"{nameof(Catering)}\" with ID: {request.CateringId.Value} was not found", new NotFoundException()));

            var review = Review.Create(request.CateringId, request.UserId, request.UserName, request.Comment, request.Rating).Value;
            user.AddReview(review);
            await _userRepository.UpdateAsync(user);

            return Result.Ok(_mapper.Map<ResponseReview>(review));
        }
    }
}
