using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class RpmYAxis : LineGraphYAxis
    {
        #region ctor
        public RpmYAxis()
            : base()
        {
            RangeStart = 0.5F;
            RangeEnd = 1F;
            InvertRange = true;

            Font font = new Font(new FontFamily("Tahoma"), DefaultFontSize);

            ShowAxis = true;
            ShowTitle = true;
            DrawTitleVertically = true;
            DrawTitleLettersHorizontally = false;
            ShowTicks = true;
            ShowTickLabels = true;
            Precision = 2;
            Format = "###0.#0";
            TickWidth = 8;
            TickStep = 1000;

            Position = YAxisPosition.Left;
        }
        #endregion
    }
}
