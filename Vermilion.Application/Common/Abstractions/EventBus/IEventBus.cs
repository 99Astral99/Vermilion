namespace Vermilion.Application.Common.Abstractions.EventBus
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T message, CancellationToken cancellationToken = default);
    }
}
