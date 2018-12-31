using iRacing.Telemetry.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace TelemetryViewer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelemetryViewer(this IServiceCollection services)
        {
            services.AddCommon();
            services.AddTelemetryWindows();

            return services;
        }
    }
}
