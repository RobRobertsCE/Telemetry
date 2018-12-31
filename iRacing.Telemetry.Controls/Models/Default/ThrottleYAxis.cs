using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class ThrottleYAxis : LineGraphYAxis
    {
        #region ctor
        public ThrottleYAxis()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = .5F;
            Format = "#.#0";
            TickWidth = 8;
            TickStep = .5F;
            InvertRange = true;
        }
        #endregion
    }
}
