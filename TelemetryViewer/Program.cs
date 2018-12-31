using iRacing.Common;
using iRacing.Telemetry.Windows;
using iRacing.Telemetry.Windows.Ports;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Windows.Forms;

namespace TelemetryViewer
{
    static class Program
    {
        private static IServiceProvider _serviceProvider;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            log.Info("Hello logging world!");

            services.AddSingleton<ILog>(log);
            services.AddCommon();
            services.AddTelemetryViewer();

            _serviceProvider = services.BuildServiceProvider();

            IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor = _serviceProvider.GetRequiredService<IOptionsMonitor<iRacingTelemetryOptions>>();
            iRacingTelemetryOptions options = (optionsAccessor == null) ? throw new ArgumentNullException(nameof(optionsAccessor)) : optionsAccessor.CurrentValue;

            //ILoggerFactory loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
            //loggerFactory.AddConsole();
            //var logger = loggerFactory.CreateLogger<MainView>();

            var controller = _serviceProvider.GetRequiredService<IViewController>();

            Application.Run(new MainView(
                controller,
                _serviceProvider,
                log,
                options));
        }
    }
}
