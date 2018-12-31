using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class BrakeLineGraphSeries : LineGraphSeries
    {
        public BrakeLineGraphSeries()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = .5F;

            Name = "Brake";
            Key = "Telemetry.Brake";
            Color = Color.Red;
            Format = "#.#0";
            Unit = "%";
            
            TickStep = .25F;

            InvertRange = true;
        }
    }
}
