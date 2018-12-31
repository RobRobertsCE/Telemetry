using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class SpeedYAxis : LineGraphYAxis
    {
        #region ctor
        public SpeedYAxis()
            : base()
        {
            RangeStart = 0F;
            RangeEnd = 1F;
            
            ShowAxis = true;
            ShowTitle = true;
            DrawTitleVertically = true;
            DrawTitleLettersHorizontally = false;
            ShowTicks = true;
            ShowTickLabels = true;
            Precision = 3;
            Format = "##0.##0";
            TickWidth = 8;
            TickStep = 50;

            Position = YAxisPosition.Left;
        }
        #endregion
    }
}
