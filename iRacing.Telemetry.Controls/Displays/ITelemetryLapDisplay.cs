using iRacing.Common.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace iRacing.Telemetry.Controls.Displays
{
    public interface ITelemetryLapDisplay : ITelemetryDisplay, INotifyPropertyChanged
    {
        LapTimesDisplayInfo DisplayInfo { get; set; }
        IList<ILapInfo> Laps { get; set; }
        int? LapNumber { get; }
        void SetLapNumber(int? lapNumber);
    }
}
