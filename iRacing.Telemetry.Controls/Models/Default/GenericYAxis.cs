using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class GenericYAxis : LineGraphYAxis
    {
        #region ctor
        public GenericYAxis()
            :base()
        {

        }
        public GenericYAxis(string format)
            : base()
        {
            Font font = new Font(new FontFamily("Tahoma"), DefaultFontSize);

            ShowAxis = true;
            ShowTitle = true;
            DrawTitleVertically = true;
            DrawTitleLettersHorizontally = false;
            ShowTicks = true;
            ShowTickLabels = true;
            Precision = 2;
            Format = format;
            TickStep = 10;
            TickWidth = 8;

            Position = YAxisPosition.Left;

            InheritValuesFromSeries = true;
        }
        #endregion
    }
}
