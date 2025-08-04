using Osiris.Toyota.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Core.Abstractions
{
    public interface IEventSubscriber
    {
        Task SubscribeAsync(Subscription subscription);
        Task UnsubscribeAsync(string subscriptionId);
        Task NotifyAsync(NotificationEvent @event);
    }
}
