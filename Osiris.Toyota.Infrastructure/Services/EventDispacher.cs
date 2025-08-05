using Microsoft.Extensions.Logging;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.Services
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly ILogger<EventDispatcher> _logger;

        public EventDispatcher(ILogger<EventDispatcher> logger)
        {
            _logger = logger;
        }

        public Task Dispatch(NotificationEvent notification)
        {
            _logger.LogInformation("Received notification event: {EventData}, Type: {Type}", notification.EventData, notification.EventType);
            return Task.CompletedTask;
        }
    }
}
