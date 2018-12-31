using iRacing.Setups.Adapters;
using iRacing.Setups.Ports;
using iRacing.Setups.Vehicles.Chassis;
using Microsoft.Extensions.DependencyInjection;

namespace iRacing.Setups
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSetups(this IServiceCollection services)
        {
            services.AddTransient<ISetupFactory<StockCarChassis>, SetupFactory<StockCarChassis>>();
            services.AddTransient<ISetupRepository<StockCarChassis>, SetupRepository<StockCarChassis>>();

            return services;
        }
    }
}
