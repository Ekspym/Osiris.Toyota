using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Infrastructure.Connectors;
using Osiris.Toyota.Infrastructure.Services;


namespace Osiris.Toyota.Infrastructure.Extensions
{
    public static class IocExtensions
    {
        public static void InstallToyotaServices(this IServiceCollection services)
        {
            services.AddScoped<IDataProtector>();
            services.AddScoped<ILoadService, LoadService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();
            services.AddScoped<ITransportService, TransportService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        public static void InstallTOneConnector(this IServiceCollection services)
        {
            services.AddTransient<IExternalSystemConnector, TOneConnector>();
        }

    }
}
