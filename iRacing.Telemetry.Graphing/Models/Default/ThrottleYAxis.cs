using System.Drawing;

namespace iRacing.Telemetry.Graphing.Models.Default
{
    public class ThrottleYAxis : LineGraphYAxis
    {
        #region ctor
        public ThrottleYAxis()
            : base()
        {
            SmallLabelFont = new Font(DefaultFontFamily, DefaultFontSize - 2);

            Format = ".00";

            LargeTickWidth = 3;
            SmallTickWidth = 2;

            SmallStep = .25F;
            LargeStep = .5F;
        }
        #endregion
    }
}
