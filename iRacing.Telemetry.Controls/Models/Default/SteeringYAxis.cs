using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class SteeringYAxis : LineGraphYAxis
    {
        #region ctor
        public SteeringYAxis()
            : base()
        {
            Format = "##0.#0";
            TickWidth = 8;
            TickStep = 60;
        }
        #endregion
    }
}
