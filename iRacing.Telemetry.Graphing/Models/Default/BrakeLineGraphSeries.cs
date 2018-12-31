using System.Drawing;

namespace iRacing.Telemetry.Graphing.Models.Default
{
    public class BrakeLineGraphSeries : LineGraphSeries
    {
        public BrakeLineGraphSeries()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = .5F;

            Name = "Brake";
            Key = "Brake";
            Color = Color.Red;
            Format = ".#0";
            Unit = "%";

            LineThickness = 1F;
        }
    }
}
