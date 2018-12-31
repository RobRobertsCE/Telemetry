using iRacing.TelemetrySessions.Adapters;
using iRacing.TelemetrySessions.Ports;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace iRacing.TelemetryFile
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelemetrySessions(this IServiceCollection services)
        {
            //services.AddLogging();
            //services.AddOptions();

            services.AddTelemetryFile();

            services.TryAddTransient<ITelemetryDataRepository, TelemetryDataRepository>();
            services.TryAddTransient<ITelemetrySessionRepository, TelemetrySessionRepository>();

            return services;
        }
    }
}
