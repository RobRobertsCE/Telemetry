using iRacing.Common;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Windows.Views.Displays
{
    public partial class SessionDetailsDisplay : MdiChildForm
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
                        break;
                    }
            }
        }
        #endregion


        public SessionDetailsDisplay()
            : base()
        {
            InitializeComponent();

            FormDisplayInfo.DisplayType = DisplayTypes.SessionDetails;
        }

        public SessionDetailsDisplay(
            IServiceProvider serviceProvider,
            log4net.ILog log,
            iRacingTelemetryOptions options)
          : base(
            serviceProvider,
            log,
            options,
            DisplayTypes.SessionDetails)
        {
            InitializeComponent();
        }

        protected override void TelemetryForm_Load(object sender, EventArgs e)
        {
            base.TelemetryForm_Load(sender, e);
        }

        protected virtual void DisplaySessionDetails()
        {

        }
    }
}
