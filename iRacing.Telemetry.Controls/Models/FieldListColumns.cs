using iRacing.Telemetry.Controls.Attributes;
using System.ComponentModel;

namespace iRacing.Telemetry.Controls.Models
{
    public enum FieldListColumns
    {
        [Description("")]
        FieldName = 0,
        [Description("")]
        [SummaryFieldColumn(SummaryColumnFlags.Value)]
        Value,
        [Description("LMin")]
        [SummaryFieldColumn(SummaryColumnFlags.LapMin)]
        LapMin,
        [Description("LMax")]
        [SummaryFieldColumn(SummaryColumnFlags.LapMax)]
        LapMax,
        [Description("LDelta")]
        [SummaryFieldColumn(SummaryColumnFlags.LapDelta)]
        LapDelta,
        [Description("LMode")]
        [SummaryFieldColumn(SummaryColumnFlags.LapMode)]
        LapMode,
        [Description("LAvg")]
        [SummaryFieldColumn(SummaryColumnFlags.LapAvg)]
        LapAvg,
        [Description("LStdDev")]
        [SummaryFieldColumn(SummaryColumnFlags.LapStdDev)]
        LapStdDev,
        [Description("SMin")]
        [SummaryFieldColumn(SummaryColumnFlags.SessionMin)]
        SessionMin,
        [Description("SMAx")]
        [SummaryFieldColumn(SummaryColumnFlags.SessionMax)]
        SessionMax,
        [Description("SDelta")]
        [SummaryFieldColumn(SummaryColumnFlags.SessionDelta)]
        SessionDelta,
        [Description("SMode")]
        [SummaryFieldColumn(SummaryColumnFlags.SessionMode)]
        SessionMode,
        [Description("SAvg")]
        [SummaryFieldColumn(SummaryColumnFlags.SessionAvg)]
        SessionAvg,
        [Description("SStdDev")]
        [SummaryFieldColumn(SummaryColumnFlags.SessionStdDev)]
        SessionStdDev,
        [SummaryFieldColumn(SummaryColumnFlags.Unit)]
        [Description("Unit")]
        Unit
    }
}
