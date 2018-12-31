using System;

namespace iRacing.Telemetry.Windows.Models
{
    public class TelemetryAppStateChangedEventArgs : EventArgs
    {
        public AppState OldState { get; set; }
        public AppState NewState { get; set; }

        public TelemetryAppStateChangedEventArgs()
        {

        }

        public TelemetryAppStateChangedEventArgs(AppState oldState, AppState newState)
        {
            OldState = oldState;
            NewState = newState;
        }
    }
}
