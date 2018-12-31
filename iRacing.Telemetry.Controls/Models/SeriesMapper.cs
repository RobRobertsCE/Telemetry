using iRacing.Telemetry.Controls.Internal;
using System.Drawing;
using System.Drawing.Printing;

namespace iRacing.Telemetry.Controls.Models
{
    public class SeriesMapper
    {
        public Size GraphicsSize { get; set; }
        public Margins Margins { get; set; }
        public float RangeStart { get; set; }
        public float RangeEnd { get; set; }
        public float ValueStart { get; set; }
        public float ValueEnd { get; set; }

        public SeriesMapper()
        {

        }

        public SeriesMapper(
            float rangeStart,
            float rangeEnd,
            float valueStart,
            float valueEnd,
            Margins margins)
        {
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
            ValueStart = valueStart;
            ValueEnd = valueEnd;
            Margins = margins;
        }

        // vert axis line is drawn topy to bottomy.

        public float MapValueInverted(float value)
        {
            var topY = (GraphicsSize.Height * RangeStart) + Margins.Top;
            var bottomY = (GraphicsSize.Height * RangeEnd) - Margins.Bottom;
            var verticalRange = bottomY - topY;
            var valueRange = ValueStart - ValueEnd;

            float coordinate = LineGraphHelper.MapValueToExactCoordinate(
                   topY,
                   bottomY,
                   ValueStart,
                   ValueEnd,
                   value);

            return coordinate;
        }

        public float MapValue(float value)
        {
            var topY = (GraphicsSize.Height * RangeStart) + Margins.Top;
            var bottomY = (GraphicsSize.Height * RangeEnd) - Margins.Bottom;
            var verticalRange = bottomY - topY;
            var valueRange = ValueStart - ValueEnd;
            float invertedTickStartY = topY + bottomY;

            float coordinate = LineGraphHelper.MapValueToExactCoordinate(
                   topY,
                   bottomY,
                   ValueStart,
                   ValueEnd,
                   value);

            return invertedTickStartY - coordinate;
        }
    }
}
