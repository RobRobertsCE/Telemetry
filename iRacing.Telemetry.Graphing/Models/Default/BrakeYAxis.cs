using System.Drawing;

namespace iRacing.Telemetry.Graphing.Models.Default
{
    public class BrakeYAxis : LineGraphYAxis
    {
        #region ctor
        public BrakeYAxis()
            : base()
        {
            SmallLabelFont = new Font(new FontFamily(DefaultFontFamily), DefaultFontSize - 1);

            Format = ".#0";

            LargeTickWidth = 3;
            SmallTickWidth = 2;

            SmallStep = .10F;
            LargeStep = .5F;
        }
        #endregion
    }
}
