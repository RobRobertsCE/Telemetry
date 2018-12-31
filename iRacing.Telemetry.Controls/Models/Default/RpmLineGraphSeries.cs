using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class RpmLineGraphSeries : LineGraphSeries
    {
        public RpmLineGraphSeries()
            : base()
        {
            RangeStart = 0.5F;
            RangeEnd = 1F;

            Name = "RPM";
            Key = "Telemetry.RPM";
            Unit = "rpm";
            Color = Color.LightSteelBlue;
            Minimum = 0;
            Maximum = 7500;
            MinWarning = 0;
            MaxWarning = 6100;
            ShowMaximumWarning = true;
            Precision = 2;
            Format = "###0.#0";

            InvertRange = true;

            ShowAxis = true;
            ShowTitle = true;
            DrawTitleVertically = true;
            DrawTitleLettersHorizontally = false;
            ShowTicks = true;
            ShowTickLabels = true;
            TickStep = 1000;

            Position = YAxisPosition.Left;
        }
    }
}
