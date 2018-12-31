using iRacing.Telemetry.Windows.Adapters;
using iRacing.Telemetry.Windows.Ports;
using iRacing.TelemetryFile;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace iRacing.Telemetry.Windows
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelemetryWindows(this IServiceCollection services)
        {
            services.AddCommon();
            services.AddTelemetry();
            services.AddTelemetryFile();
            services.AddTelemetryData();
            services.AddMaps();

            services.TryAddTransient<IViewController, ViewController>();
            services.TryAddTransient<ISessionFactory, SessionFactory>();
            services.TryAddTransient<IProjectFactory, ProjectFactory>();
            services.TryAddTransient<IDisplayInfoService, DisplayInfoService>();

            return services;
        }
    }
}
