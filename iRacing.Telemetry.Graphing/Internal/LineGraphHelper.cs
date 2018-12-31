using System;

namespace iRacing.Telemetry.Graphing.Internal
{
    internal static class LineGraphHelper
    {
        internal static float Scale(float rangeStart, float rangeEnd, float valuesStart, float valuesEnd, float value)
        {
            float rangeSpan = rangeEnd - rangeStart;
            float valuesSpan = valuesEnd - valuesStart;
            float adjustedValue = (valuesStart != 0) ? value - valuesStart : value;
            float valueOffset = adjustedValue / valuesSpan;
            float rangeOffset = valueOffset * rangeSpan;

            return Math.Abs(rangeOffset + rangeStart);
        }
    }
}
