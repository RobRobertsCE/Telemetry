using System.Collections.Generic;
using System.Drawing;

namespace iRacing.Telemetry.Controls.Internal
{
    internal class AxisPrintCoordinates
    {
        // local
        public float tickLineToLabelMargin = -0.5F;
        public float titleToLabelMargin = 0F;

        // output
        public float minimumX;
        public float maximumX;
        public float rangeX;
        public float indexOffsetX;

        public float minimumY;
        public float maximumY;
        public float rangeY;
        public float axisVerticalLineX;
        public float tickWidth;
        public float outermostTickX;
        public float tickX;
        public Size labelSize = Size.Empty;

        public float maximumLablelWidth;
        public float labelX;
        public Size titleSize = Size.Empty;

        public float titleY;
        public float titleX;

        public int offset = 0;

        public List<Tick> Ticks { get; set; } = new List<Tick>();
        public List<TickLabel> TickLabels { get; set; } = new List<TickLabel>();
        public TitleLabel TitleLabel { get; set; }
        public AxisLine AxisLine { get; set; }

        public PointF GetPrintPointF()
        {
            return new PointF(minimumX, minimumY);
        }
        public SizeF GetPrintSizeF()
        {
            return new SizeF(maximumX - titleX, maximumY);
        }
        public RectangleF GetPrintRectangleF()
        {
            return new RectangleF(GetPrintPointF(), GetPrintSizeF());
        }
    }

    internal class AxisLine
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Thickness { get; set; }
        public Color Color { get; set; }
    }

    internal class Tick
    {
        public float X { get; set; }
        public float Y { get; set; }
        public TickLabel Label { get; set; }
    }

    internal class TickLabel
    {
        public float X { get; set; }
        public float Y { get; set; }
        public string Text { get; set; }
    }

    internal class TitleLabel
    {
        public float X { get; set; }
        public float Y { get; set; }
        public string Text { get; set; }
    }
}
