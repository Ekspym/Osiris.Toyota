using Osiris.Toyota.Core.Entities;

namespace Osiris.Toyota.Core.Abstractions
{
    public interface IEventDispatcher
    {
        Task Dispatch(NotificationEvent notification);
    }
}
