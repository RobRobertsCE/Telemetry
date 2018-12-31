using iRacing.Common;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;

namespace iRacing.Telemetry.Windows.Views.Displays
{
    public partial class SetupDisplay : MdiChildForm
    {
        #region events     
        protected override void ProtectedPropertyChangedHandlerAsync(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(CurrentLapNumber):
                    {
                      
                        break;
                    }
                case nameof(CurrentFrameIndex):
                    {

                        break;
                    }
                case nameof(Laps):
                    {
                        break;
                    }
                case ("Session"):
                    {
                        // ParseTelemetrySession(Session);
                        break;
                    }
            }
        }
        #endregion

        #region ctor/load
        public SetupDisplay()
            :base()
        {
            InitializeComponent();

            FormDisplayInfo.DisplayType = DisplayTypes.Setup;
        }

        public SetupDisplay(
            IServiceProvider serviceProvider,
            log4net.ILog log,
            iRacingTelemetryOptions options)
          : base(
            serviceProvider,
            log,
            options,
            DisplayTypes.Setup)
        {
            InitializeComponent();
        }

        protected override void TelemetryForm_Load(object sender, EventArgs e)
        {
            base.TelemetryForm_Load(sender, e);
        }
        #endregion
    }
}
