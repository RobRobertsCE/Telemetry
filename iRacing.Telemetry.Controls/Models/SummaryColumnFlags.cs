using System;

namespace iRacing.Telemetry.Controls.Models
{
    [Flags]
    public enum SummaryColumnFlags
    {
        Value = (1 << 0),
        LapMin = (1 << 1),
        LapMax = (1 << 2),
        LapAvg = (1 << 3),
        LapDelta = (1 << 4),
        LapMode = (1 << 5),
        LapStdDev = (1 << 6),
        SessionMin = (1 << 7),
        SessionMax = (1 << 8),
        SessionDelta = (1 << 9),
        SessionMode = (1 << 10),
        SessionAvg = (1 << 11),
        SessionStdDev = (1 << 12),
        Unit = (1 << 13),
        All = Value | LapMin | LapMax | LapDelta | LapMode | LapAvg | LapStdDev | SessionMin | SessionMax | SessionDelta | SessionMode | SessionAvg | SessionStdDev | Unit
    }
}
