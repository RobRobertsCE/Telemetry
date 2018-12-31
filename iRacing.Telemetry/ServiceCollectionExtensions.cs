using iRacing.Telemetry.Adapters;
using iRacing.Telemetry.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace iRacing.Telemetry
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelemetry(this IServiceCollection services)
        {
            services.AddTransient<ISessionParser, SessionParser>();

            return services;
        }
    }
}
