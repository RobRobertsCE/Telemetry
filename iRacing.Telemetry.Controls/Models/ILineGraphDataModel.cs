using System.Collections.Generic;

namespace iRacing.Telemetry.Controls.Models
{
    public interface ILineGraphDataModel
    {
        bool HasValues { get; }
        int FieldCount { get; }
        int LapCount { get; }

        int GetLapFrameCount(int lapIdx);

        IEnumerable<TelemetryValues> GetLapValues(int lapIdx);
        IEnumerable<TelemetryValues> GetFrameValues(int frameIdx);
        IEnumerable<TelemetryValues> GetSessionFieldValues(int fieldIdx);
        IEnumerable<TelemetryValues> GetLapFieldValues(int lapIdx, int fieldIdx);

        float GetValue(int lapIdx, int frameIdx, int fieldIdx);
        void SetValue(int lapIdx, int frameIdx, int fieldIdx, float value);
    }
}
