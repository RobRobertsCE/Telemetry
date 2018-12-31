using iRacing.Common.Models;
using System.ComponentModel;

namespace iRacing.Telemetry.Windows.Models
{
    public interface ISession : INotifyPropertyChanged
    {
        string Name { get; set; }
        string FileName { get; set; }
        string SessionFileName { get; set; }
        string Setup { get; set; }
        string Vehicle { get; set; }
        string Track { get; set; }
        int LapCount { get; set; }
        int FastestLap { get; set; }
        float FastestLapTime { get; set; }

        ISessionData TelemetrySessionData { get; set; }

        void Save();
        void SaveAs(string fileName);
    }
}
