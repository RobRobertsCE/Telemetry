using iRacing.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace iRacing.Telemetry.Windows
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
            services.AddOptions();
            services.Configure<iRacingTelemetryOptions>(myOptions =>
            {
                myOptions.IsDebug = false;
            });

            return services;
        }
    }
}
