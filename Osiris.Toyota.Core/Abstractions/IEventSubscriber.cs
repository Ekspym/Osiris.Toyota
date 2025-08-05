using Osiris.Toyota.Core.Entities;


namespace Osiris.Toyota.Core.Abstractions
{
    public interface IEventSubscriber
    {
        Task SubscribeAsync(Subscription subscription);
        Task UnsubscribeAsync(string subscriptionId);
        Task NotifyAsync(NotificationEvent @event);
    }
}
