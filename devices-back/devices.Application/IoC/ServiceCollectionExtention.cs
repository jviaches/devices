using devices.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace devices.Application.IoC
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDeviceService, DeviceService>();

            return services;
        }
    }
}
