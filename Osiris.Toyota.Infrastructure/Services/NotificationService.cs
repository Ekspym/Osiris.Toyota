using Microsoft.Extensions.Logging;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Entities;
using Osiris.Toyota.Infrastructure.Connectors;
using Osiris.Toyota.Infrastructure.DTOs;
using System.Net.Http;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.Services
{
    public interface INotificationService
    {
        Task SubscribeToEvents(EventSubscriptionRequest request);
        Task HandleNotification(NotificationEvent notification);
    }

    public class NotificationService : INotificationService
    {
        private readonly TOneConnector _connector;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(
            TOneConnector connector,
            IEventDispatcher eventDispatcher,
            ILogger<NotificationService> logger)
        {
            _connector = connector;
            _eventDispatcher = eventDispatcher;
            _logger = logger;
        }

        public async Task SubscribeToEvents(EventSubscriptionRequest request)
        {
            try
            {
                await _connector.SendRequestAsync<object>(
                    HttpMethod.Post,
                    "/api/v1/event-subscriptions",
                    request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to subscribe to events");
                throw;
            }
        }

        public async Task HandleNotification(NotificationEvent notification)
        {
            try
            {
                _logger.LogInformation("Handling notification: {EventData}, Type: {Type}", notification.EventData, notification.EventType);
                await _eventDispatcher.Dispatch(notification);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to handle notification event: {EventData}", notification.EventData);
                throw;
            }
        }
    }
}
