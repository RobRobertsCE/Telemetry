using System.Drawing;

namespace iRacing.Telemetry.Graphing.Models.Default
{
    public class SteeringYAxis : LineGraphYAxis
    {
        #region ctor
        public SteeringYAxis()
            : base()
        {
            SmallLabelFont = new Font(DefaultFontFamily, DefaultFontSize - 2);

            Format = "##0";

            LargeTickWidth = 3;
            SmallTickWidth = 2;

            SmallStep = 40;
            LargeStep = 120;
        }
        #endregion
    }
}
