using AutoMapper;
using FluentResults;
using MediatR;
using Vermilion.Application.Common.Exceptions;
using Vermilion.Application.Interfaces;
using Vermilion.Contracts.Responses.Reviews;
using Vermilion.Contracts.Users.Commands.AddReview;
using Vermilion.Contracts.Users.Commands.LoginUser;
using Vermilion.Contracts.Users.Commands.RegisterUser;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Interfaces;
using Vermilion.Domain.Repositories;
using Vermilion.Domain.Specifications.SpecsUser;
using Vermilion.Domain.ValueObjects;

namespace Vermilion.Application.Handlers.Users
{
    public class UserCommandHandler :
        IRequestHandler<RegisterUserCommand, Result>,
        IRequestHandler<LoginUserCommand, Result<string>>,
        IRequestHandler<AddReviewCommand, Result<ResponseReview>>
    {
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Catering> _cateringRepository;

        public UserCommandHandler(IMapper mapper, IRepository<User> userRepository, IRepository<Catering> cateringRepository, IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _cateringRepository = cateringRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
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

        public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySpecAsync(new UserByEmailSpec(request.Email));

            if (user is null)
                return Result.Fail(new ExceptionalError($"\"{nameof(User)}\" with Email: {request.Email} was not found", new NotFoundException()));

            var result = _passwordHasher.Verify(request.Password, user.PasswordHash);

            if (result == false)
                return Result.Fail($"Wrong credentials");

            var token = _jwtProvider.Generate(user);

            return Result.Ok(token);
        }

        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetBySpecAsync(new UserByEmailSpec(request.Email));

            var hashedPassword = _passwordHasher.Generate(request.Password);

            if (userExist is not null)
                return Result.Fail("User already registered");

            var user = User.Create(new FullName(request.Name, string.Empty, string.Empty), request.Email, null, hashedPassword).Value;

            await _userRepository.AddAsync(user);

            return Result.Ok();
        }
    }
}
