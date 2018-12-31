using System.Drawing;

namespace iRacing.Telemetry.Graphing.Models.Default
{
    public class RpmLineGraphSeries : LineGraphSeries
    {
        public RpmLineGraphSeries()
            : base()
        {
            RangeStart = 0.5F;
            RangeEnd = 1F;

            Name = "RPM";
            Key = "RPM";
            Unit = "rpm";
            Color = Color.SteelBlue;
            Minimum = 0;
            Maximum = 7500;
            MinWarning = null;
            MaxWarning = 6100;
            ShowMaximumWarning = true;
            Format = "###0";

            LineThickness = .2F;
        }
    }
}
