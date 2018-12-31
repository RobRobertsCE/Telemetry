using System.Drawing;

namespace iRacing.Telemetry.Graphing.Models.Default
{
    public class RpmYAxis : LineGraphYAxis
    {
        #region ctor
        public RpmYAxis()
            : base()
        {
            RangeStart = 0.5F;
            RangeEnd = 1F;

            InvertRange = false;

            Font font = new Font(new FontFamily("Tahoma"), DefaultFontSize);

            ShowAxis = true;
            ShowTitle = true;
            DrawTitleVertically = true;
            DrawTitleLettersHorizontally = false;
            ShowLargeTicks = true;
            ShowLargeLabels = true;
            ShowSmallLabels = true;
            ShowSmallTicks = true;
            Precision = 0;
            Format = "0000";
            LargeTickWidth = 3;
            SmallTickWidth = 2;

            SmallStep = 500;
            LargeStep = 1000;

            Position = YAxisPosition.Left;
        }
        #endregion
    }
}
