using iRacing.TelemetryFile.Adapters;
using iRacing.TelemetryFile.Ports;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace iRacing.TelemetryFile
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelemetryFile(this IServiceCollection services)
        {
            //services.AddLogging();
            //services.AddOptions();

            services.TryAddTransient<IIbtFileParser, IbtFileParser>();
            services.TryAddTransient<IIbtSessionParser, IbtSessionParser>();
            services.TryAddTransient<IIbtFileReader, IbtFileReader>();

            return services;
        }
    }
}
