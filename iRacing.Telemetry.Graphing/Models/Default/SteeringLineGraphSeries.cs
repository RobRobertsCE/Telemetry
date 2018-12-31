using System.Drawing;

namespace iRacing.Telemetry.Graphing.Models.Default
{
    public class SteeringLineGraphSeries : LineGraphSeries
    {
        public SteeringLineGraphSeries()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = .5F;

            Name = "Steering Angle";
            Key = "Steering";
            Color = Color.Yellow;
            Format = "##0";
            Unit = "degrees";
            Minimum = 0;
            Maximum = 360;
        }
    }
}
