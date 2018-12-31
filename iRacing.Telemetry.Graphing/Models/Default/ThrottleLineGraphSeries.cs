using System.Drawing;

namespace iRacing.Telemetry.Graphing.Models.Default
{
    public class ThrottleLineGraphSeries : LineGraphSeries
    {
        public ThrottleLineGraphSeries()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = .5F;

            Name = "Throttle";
            Key = "Throttle";
            Unit = "%";
            Color = Color.LimeGreen;
            Format = ".#0";

            LineThickness = .5F;
        }
    }
}
