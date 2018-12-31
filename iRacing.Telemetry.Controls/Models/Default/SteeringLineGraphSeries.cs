using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class SteeringLineGraphSeries : LineGraphSeries
    {
        public SteeringLineGraphSeries()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = .5F;

            Name = "Steering Angle";
            Key = "Telemetry.SteeringWheelAngle";
            Color = Color.Yellow;
            Format = "##0.#0";
            Unit = "degrees";
            Minimum = 0;
            Maximum = 360;

            TickStep = 60;
        }
    }
}
