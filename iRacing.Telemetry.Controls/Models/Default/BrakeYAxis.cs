using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class BrakeYAxis : LineGraphYAxis
    {
        #region ctor
        public BrakeYAxis()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = .5F;

            Format = "#.#0";

            TickWidth = 8;
            TickStep = .25F;

            InvertRange = true;
        }
        #endregion
    }
}
