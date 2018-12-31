using iRacing.Telemetry.Data.Adapters;
using iRacing.Telemetry.Data.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace iRacing.Telemetry
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelemetryData(this IServiceCollection services)
        {
            services.AddTransient<IFieldDefinitionRepository, FieldDefinitionFileRepository>();
            services.AddTransient<IFieldDisplayInfoRepository, FieldDisplayInfoFileFileRepository>();
            services.AddTransient<IFunctionRepository, FunctionFileRepository>();
            services.AddTransient<IUserDefinedFunctionRepository, UserDefinedFunctionRepository>();
                        
            return services;
        }
    }
}
