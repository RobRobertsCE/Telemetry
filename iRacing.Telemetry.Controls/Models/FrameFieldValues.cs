using System.Collections.Generic;

namespace iRacing.Telemetry.Controls.Models
{
    public struct FrameFieldValues
    {
        public bool HasValues;

        public float Value;

        public bool MinWarning;
        public bool MaxWarning;

        public IDictionary<SummaryColumnFlags, float> SummaryValues;

        public FrameFieldValues(bool hasValues)
        {
            HasValues = hasValues;
            Value = 0;
            MinWarning = false;
            MaxWarning = false;
            SummaryValues = new Dictionary<SummaryColumnFlags, float>();
        }
    }
}
