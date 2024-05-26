using MassTransit;
using Microsoft.Extensions.Logging;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.Reviews
{
    public sealed class ReviewCreatedEventConsumer : IConsumer<ReviewCreatedEvent>
    {
        private readonly IRepository<Catering> _cateringRepository;
        private readonly ILogger<ReviewCreatedEvent> _logger;

        public ReviewCreatedEventConsumer(IRepository<Catering> cateringRepository, ILogger<ReviewCreatedEvent> logger)
        {
            _cateringRepository = cateringRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ReviewCreatedEvent> context)
        {
            var catering = await _cateringRepository.GetByIdAsync(context.Message.CateringId);
            catering.UpdateAverageRating(context.Message.Rating);
            await _cateringRepository.UpdateAsync(catering);

            _logger.LogInformation($"Review with ID {context.Message.ReviewId} with rating {context.Message.Rating} was added to Catering with ID {context.Message.CateringId}");
        }
    }
}
