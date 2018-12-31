using iRacing.Telemetry.Maps.Adapters;
using iRacing.Telemetry.Maps.Internal;
using iRacing.Telemetry.Maps.Ports;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace iRacing.Telemetry.Windows
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMaps(this IServiceCollection services)
        {
            services.TryAddTransient<IImageHelper, ImageHelper>();
            services.TryAddTransient<ITrackMapService, GoogleTrackMapService>();
            services.TryAddTransient<ITrackMapRepository, TrackMapRepository>();

            return services;
        }
    }
}
