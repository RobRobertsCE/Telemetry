using iRacing.Telemetry.Controls.Models;
using System;

namespace iRacing.Telemetry.Controls.Attributes
{
    public class SummaryFieldColumnAttribute : Attribute
    {
        public SummaryColumnFlags SummaryColumnFlags { get; set; }

        public SummaryFieldColumnAttribute(SummaryColumnFlags value)
        {
            SummaryColumnFlags = value;
        }
    }
}
