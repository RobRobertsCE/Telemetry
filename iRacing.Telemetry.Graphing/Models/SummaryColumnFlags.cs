using System;

namespace iRacing.Telemetry.Graphing.Models
{
    [Flags]
    public enum SummaryColumnFlags
    {
        Value = 0x01,
        LapMin = 0x02,
        LapMax = 0x04,
        LapAvg = 0x08,
        All = Value | LapMin | LapMax | LapAvg
    }
}
