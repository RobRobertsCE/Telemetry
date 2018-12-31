using iRacing.Common;
using iRacing.Telemetry.Windows.Ports;
using log4net;
using Microsoft.Extensions.Logging;
using System;

namespace TelemetryViewer
{
    public partial class MainView
    {
        public MainView()
            : base()
        {
            InitializeComponent();
        }
        public MainView(
                IViewController controller,
                IServiceProvider serviceProvider,
                ILog log,
                iRacingTelemetryOptions options)
          : base(
                controller,
                serviceProvider,
                log,
                options)
        {
            InitializeComponent();
        }
    }
}
