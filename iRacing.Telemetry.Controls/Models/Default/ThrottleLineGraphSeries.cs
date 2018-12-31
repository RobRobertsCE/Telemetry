using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class ThrottleLineGraphSeries : LineGraphSeries
    {
        public ThrottleLineGraphSeries()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = .5F;
            Name = "Throttle";
            Key = "Telemetry.Throttle";
            Unit = "%";
            Color = Color.LimeGreen;
            Format = "#.#0";

            LineThickness = 1F;

            TickStep = .5F;

            InvertRange = true;
        }
    }
}
