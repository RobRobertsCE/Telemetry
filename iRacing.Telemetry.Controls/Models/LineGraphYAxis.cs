using iRacing.Telemetry.Controls.Internal;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Models
{
    public class LineGraphYAxis : LineGraphAxis, ILineGraphYAxis
    {
        #region constants     
        /// <summary>
        /// Minimum horizontal distance between the vertical axis line and the edge of the graphics rectangle.
        /// </summary>
        public const int MinimumVerticalLineXOffset = 2;
        public const float AxisIndexOffsetAmount = 2;
        #endregion

        #region fields
        private float _defaultTickWidth = 4F;
        AxisPrintCoordinates _axisCoordinates = null;
        #endregion

        #region properties
        private bool _drawTitleVertically = true;
        public bool DrawTitleVertically
        {
            get
            {
                return _drawTitleVertically;
            }
            set
            {
                _drawTitleVertically = value;
                OnPropertyChanged(nameof(DrawTitleVertically));
            }
        }

        private bool _drawTitleLettersHorizontally = false;
        public bool DrawTitleLettersHorizontally
        {
            get
            {
                return _drawTitleLettersHorizontally;
            }
            set
            {
                _drawTitleLettersHorizontally = value;
                OnPropertyChanged(nameof(DrawTitleLettersHorizontally));
            }
        }

        private YAxisPosition _yAxisPosition = YAxisPosition.Left;

        public YAxisPosition Position
        {
            get
            {
                return _yAxisPosition;
            }
            set
            {
                _yAxisPosition = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        #endregion

        #region ctor
        public LineGraphYAxis()
            : base()
        {

        }
        #endregion

        #region public
        public void ResetAxisCoordinates()
        {
            _axisCoordinates = null;
        }
        public float GetAxisDrawWidth()
        {
            _axisCoordinates = GetPrintCoordinates(new Size(100, 100), 0);

            var drawWidth = _axisCoordinates.GetPrintSizeF().Width;

            ResetAxisCoordinates();

            return drawWidth;
        }
        public override void PaintAxis(PaintEventArgs e, int offset)
        {
            if (!ShowAxis)
                return;

            if (!ShowTitle && !ShowTicks && !ShowTickLabels)
                return;
            try
            {

                if (_axisCoordinates == null || _axisCoordinates.offset != offset)
                    _axisCoordinates = GetPrintCoordinates(e.ClipRectangle.Size, offset);

                using (Brush axisBrush = new SolidBrush(Color))
                {
                    using (Pen axisPen = new Pen(axisBrush, AxisBaseLineThickness))
                    {
                        // Draw the vertical axis line
                        e.Graphics.DrawLine(
                            axisPen,
                            new PointF(
                                _axisCoordinates.axisVerticalLineX,
                                _axisCoordinates.minimumY),
                            new PointF(
                                _axisCoordinates.axisVerticalLineX,
                                _axisCoordinates.maximumY));

                        if (ShowTicks)
                        {
                            using (Pen tickPen = new Pen(axisBrush, TickLineThickness))
                            {
                                foreach (var tick in _axisCoordinates.Ticks)
                                {
                                    e.Graphics.DrawLine(
                                       axisPen,
                                       new PointF(
                                          tick.X,
                                          tick.Y),
                                       new PointF(
                                           tick.X + _defaultTickWidth,
                                           tick.Y));
                                }
                            }
                            if (ShowTickLabels)
                            {
                                using (Brush labelBrush = new SolidBrush(Color))
                                {
                                    foreach (var label in _axisCoordinates.TickLabels)
                                    {
                                        e.Graphics.DrawString(label.Text,
                                            Font,
                                            labelBrush,
                                            new PointF(label.X, label.Y));
                                    }
                                }
                            }
                        }

                        if (ShowTitle)
                        {
                            if (DrawTitleVertically)
                            {
                                if (DrawTitleLettersHorizontally)
                                {
                                    float titleHeightInPixels = _axisCoordinates.TitleLabel.Text.Length * Font.Size;
                                    float letterSpacing = 5F;
                                    float titleYPosition = _axisCoordinates.TitleLabel.Y - (titleHeightInPixels / 2) + (_axisCoordinates.TitleLabel.Text.Length * letterSpacing); ;
                                    for (int i = 0; i < Name.Length; i++)
                                    {
                                        e.Graphics.DrawString(
                                            _axisCoordinates.TitleLabel.Text[i].ToString(),
                                            Font,
                                            axisBrush,
                                            new PointF(
                                                _axisCoordinates.TitleLabel.X - (TextRenderer.MeasureText(_axisCoordinates.TitleLabel.Text[i].ToString(), Font).Width / 2),
                                                titleYPosition
                                                )
                                            );
                                        titleYPosition += Font.Size + 5F;
                                    }
                                }
                                else
                                {
                                    Size titleSizeInPixels = TextRenderer.MeasureText(_axisCoordinates.TitleLabel.Text, Font);
                                    float titleXPosition = _axisCoordinates.TitleLabel.X;
                                    float titleYPosition = _axisCoordinates.TitleLabel.Y - (titleSizeInPixels.Width / 2);

                                    StringFormat drawFormat = new StringFormat();
                                    drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                                    e.Graphics.DrawString(
                                        _axisCoordinates.TitleLabel.Text,
                                        Font,
                                        axisBrush,
                                        titleXPosition,
                                        titleYPosition,
                                        drawFormat);
                                }
                            }
                            else
                            {
                                Size titleSizeInPixels = TextRenderer.MeasureText(_axisCoordinates.TitleLabel.Text, Font);
                                float titleXPosition = _axisCoordinates.TitleLabel.X;
                                float titleYPosition = _axisCoordinates.TitleLabel.Y - (titleSizeInPixels.Height / 2);

                                e.Graphics.DrawString(_axisCoordinates.TitleLabel.Text, Font, axisBrush, new PointF(titleXPosition, titleYPosition));
                            } // if draw title vertically
                        } // if show title
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region protected
        protected virtual string FormatLabel(float value)
        {
            string formatString = $"{{0:{Format}}}";
            string result = String.Format(formatString, value);
            return result;
        }
        protected virtual string FormatLabel(double value)
        {
            string formatString = $"{{0:{Format}}}";
            string result = String.Format(formatString, value);
            return result;
        }
        protected virtual string FormatLabel(int value)
        {
            string formatString = $"{{0:{Format}}}";
            string result = String.Format(formatString, value).PadLeft(Format.Length, ' ');
            return result;
        }
        #endregion

        #region internal
        private AxisPrintCoordinates GetPrintCoordinates(Size printArea, int offset)
        {
            Size actualyPrintArea = new Size(printArea.Width - offset, printArea.Height);

            AxisPrintCoordinates c = new AxisPrintCoordinates();
            c.offset = offset;

            // minimum X coordinate (starts at zero)
            c.minimumX = Margins.Left;

            // maximum X coordinate
            c.maximumX = actualyPrintArea.Width - Margins.Right;

            // x range
            c.rangeX = c.maximumX - c.minimumX;

            // X offset from index
            c.indexOffsetX = AxisIndexOffsetAmount;

            // minimum Y coordinate
            c.minimumY = (base.RangeStart * actualyPrintArea.Height) + Margins.Top;

            // maximum Y coordinate
            c.maximumY = (base.RangeEnd * actualyPrintArea.Height) - Margins.Bottom;

            // y range
            c.rangeY = c.maximumY - c.minimumY;

            // X coordinate of the vertical axis line (all other y positions should be based off of this value)
            c.axisVerticalLineX = (Position == YAxisPosition.Left) ?
                        c.maximumX - c.indexOffsetX :
                        c.indexOffsetX;

            if (c.axisVerticalLineX < MinimumVerticalLineXOffset)
                c.axisVerticalLineX = MinimumVerticalLineXOffset;

            // effective tick widths
            c.tickWidth = TickWidth;

            // outermost x coordinate (away from vertical axis line) for all ticks
            c.outermostTickX = (Position == YAxisPosition.Left) ?
                        c.axisVerticalLineX - c.tickWidth :
                        c.axisVerticalLineX + c.tickWidth;

            // actual tick X coordinates

            c.tickX = (Position == YAxisPosition.Left) ?
                        c.axisVerticalLineX - c.tickWidth :
                        c.axisVerticalLineX;

            // horizontal margin between tick line and label
            c.tickLineToLabelMargin = -2F;

            c.labelSize = TextRenderer.MeasureText((Maximum).ToString(Format), Font);

            c.maximumLablelWidth = c.labelSize.Width;

            // all labels are aligned vertically on the same Y coordinate.
            c.labelX = (Position == YAxisPosition.Left) ?
                        c.outermostTickX - c.tickLineToLabelMargin - c.maximumLablelWidth :
                        c.outermostTickX + c.tickLineToLabelMargin;

            var actualTitle = string.IsNullOrEmpty(Unit) ? Name : $"{Name} ({Unit})";

            if (DrawTitleVertically)
            {
                Size horizontalSize = TextRenderer.MeasureText(actualTitle, Font);
                // flip horizontal size to vertical
                c.titleSize = new Size(
                    horizontalSize.Height,
                    horizontalSize.Width);
            }
            else
            {
                c.titleSize = TextRenderer.MeasureText(actualTitle, Font);
            }

            c.titleX = (Position == YAxisPosition.Left) ?
                        c.labelX - c.titleToLabelMargin - c.titleSize.Width :
                        c.labelX + c.titleToLabelMargin;

            c.titleY = c.minimumY + ((c.maximumY - c.minimumY) / 2);

            c.TitleLabel = new TitleLabel()
            {
                Text = actualTitle,
                X = c.titleX,
                Y = c.titleY
            };

            float valueRange = Math.Abs(Maximum - Minimum);
            float largeStep = TickStep;

            float startYPosition = InvertRange ? -Maximum : Minimum;
            float maxYPosition = InvertRange ? -Minimum : Maximum;
            float scalingRangeMinimum = InvertRange ? -c.maximumY : c.minimumY;
            float scalingRangeMaximum = InvertRange ? -c.minimumY : c.maximumY;
            float scalingValuesMinimum = InvertRange ? -Minimum : Minimum;
            float scalingValuesMaximum = InvertRange ? -Maximum : Maximum;

            for (float i = startYPosition; i < maxYPosition; i += largeStep)
            {
                var largeStepValue = i;
                var largeScaledY = LineGraphHelper.MapValueToExactCoordinate(scalingRangeMinimum, scalingRangeMaximum,
                        scalingValuesMinimum, scalingValuesMaximum, largeStepValue);
                c.Ticks.Add(new Tick()
                {
                    X = c.tickX,
                    Y = largeScaledY
                });
                c.TickLabels.Add(new TickLabel()
                {
                    X = c.labelX,
                    Y = largeScaledY - (Font.SizeInPoints),
                    Text = FormatLabel(Math.Abs(Math.Round(largeStepValue, Precision)))
                });
            }

            var lastScaledY = LineGraphHelper.MapValueToExactCoordinate(scalingRangeMinimum, scalingRangeMaximum,
                    scalingValuesMinimum, scalingValuesMaximum, scalingValuesMaximum);

            c.Ticks.Add(new Tick()
            {
                X = c.tickX,
                Y = Math.Abs(InvertRange ? scalingRangeMinimum : scalingRangeMaximum)
            });
            c.TickLabels.Add(new TickLabel()
            {
                X = c.labelX,
                Y = Math.Abs(InvertRange ? scalingRangeMinimum : scalingRangeMaximum) - (Font.SizeInPoints),
                Text = FormatLabel(Math.Abs(InvertRange ? scalingValuesMinimum : scalingValuesMaximum))
            });

            return c;
        }
        #endregion
    }
}
