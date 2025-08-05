using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;


namespace Osiris.Toyota.Infrastructure.Extensions
{
    public static class IocExtensions
    {
        public static void InstallToyotaServices(this IServiceCollection services)
        {
            services.AddScoped<IDataProtector>();
        }

    }
}
