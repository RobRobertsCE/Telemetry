using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class SpeedLineGraphSeries : LineGraphSeries
    {
        public SpeedLineGraphSeries()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = 1F;

            Name = "Speed";
            Key = "Telemetry.Speed";
            Unit = "f/s";
            Color = Color.Cyan;
            Minimum = 0;
            Maximum = 200;
            Precision = 3;
            MinWarning = 0;
            MaxWarning = 120;
            ShowMaximumWarning = true;
            Format = "##0.##0";
            TickStep = 50;

            Position = YAxisPosition.Left;
        }
    }
}
