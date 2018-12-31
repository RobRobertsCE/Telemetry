using iRacing.Telemetry.Graphing.Internal;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace iRacing.Telemetry.Graphing.Models
{
    public class LineGraphYAxis : LineGraphAxis, ILineGraphYAxis
    {
        #region constants     
        /// <summary>
        /// Minimum horizontal distance between the vertical axis line and the edge of the graphics rectangle.
        /// </summary>
        public const int MinimumVerticalLineXOffset = 2;
        public const float AxisIndexOffsetAmount = 0;
        #endregion

        #region fields
        AxisPrintCoordinates _axisCoordinates = null;
        #endregion

        #region properties
        [JsonIgnore()]
        protected virtual bool HasSmallTicks
        {
            get
            {
                return SmallStep.HasValue;
            }
        }
        [JsonIgnore()]
        protected virtual bool HasLargeTicks
        {
            get
            {
                return LargeStep.HasValue;
            }
        }
        [JsonIgnore()]
        protected virtual bool HasTicks
        {
            get
            {
                return (HasSmallTicks || HasLargeTicks);
            }
        }

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

            if (!ShowLargeLabels && !ShowSmallLabels && !ShowTitle && !ShowLargeTicks && !ShowSmallTicks)
                return;
            try
            {

                if (_axisCoordinates == null || _axisCoordinates.offset != offset)
                    _axisCoordinates = GetPrintCoordinates(e.ClipRectangle.Size, offset);

                using (Brush axisBrush = new SolidBrush(AxisColor))
                {
                    using (Pen axisPen = new Pen(axisBrush, AxisBaseLineWidth))
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

                        if (ShowLargeTicks)
                        {
                            using (Pen tickPen = new Pen(axisBrush, LargeTickLineThickness))
                            {
                                foreach (var tick in _axisCoordinates.LargeTicks)
                                {
                                    e.Graphics.DrawLine(
                                       axisPen,
                                       new PointF(
                                          tick.X,
                                          tick.Y),
                                       new PointF(
                                           tick.X + tick.Width,
                                           tick.Y));
                                }
                            }
                            if (ShowLargeLabels)
                            {
                                using (Brush labelBrush = new SolidBrush(LargeLabelColor))
                                {
                                    foreach (var label in _axisCoordinates.LargeLabels)
                                    {
                                        e.Graphics.DrawString(label.Text,
                                            LargeLabelFont,
                                            labelBrush,
                                            new PointF(label.X, label.Y));
                                    }
                                }
                            }
                        }
                        if (ShowSmallTicks)
                        {
                            using (Pen tickPen = new Pen(axisBrush, SmallTickLineThickness))
                            {
                                foreach (var tick in _axisCoordinates.SmallTicks)
                                {
                                    e.Graphics.DrawLine(
                                       axisPen,
                                       new PointF(
                                          tick.X,
                                          tick.Y),
                                       new PointF(
                                           tick.X + tick.Width,
                                           tick.Y));
                                }
                            }
                            if (ShowSmallLabels)
                            {
                                using (Brush labelBrush = new SolidBrush(SmallLabelColor))
                                {
                                    foreach (var label in _axisCoordinates.SmallLabels)
                                    {
                                        e.Graphics.DrawString(label.Text,
                                            SmallLabelFont,
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
                                    float titleHeightInPixels = _axisCoordinates.TitleLabel.Text.Length * AxisFont.Size;
                                    float letterSpacing = 5F;
                                    float titleYPosition = _axisCoordinates.TitleLabel.Y - (titleHeightInPixels / 2) + (_axisCoordinates.TitleLabel.Text.Length * letterSpacing); ;
                                    for (int i = 0; i < Name.Length; i++)
                                    {
                                        e.Graphics.DrawString(
                                            _axisCoordinates.TitleLabel.Text[i].ToString(),
                                            AxisFont,
                                            axisBrush,
                                            new PointF(
                                                _axisCoordinates.TitleLabel.X - (TextRenderer.MeasureText(_axisCoordinates.TitleLabel.Text[i].ToString(), AxisFont).Width / 2),
                                                titleYPosition
                                                )
                                            );
                                        titleYPosition += AxisFont.Size + 5F;
                                    }
                                }
                                else
                                {
                                    Size titleSizeInPixels = TextRenderer.MeasureText(_axisCoordinates.TitleLabel.Text, AxisFont);
                                    float titleXPosition = _axisCoordinates.TitleLabel.X;
                                    float titleYPosition = _axisCoordinates.TitleLabel.Y - (titleSizeInPixels.Width / 2);

                                    StringFormat drawFormat = new StringFormat();
                                    drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                                    e.Graphics.DrawString(
                                        _axisCoordinates.TitleLabel.Text,
                                        AxisFont,
                                        axisBrush,
                                        titleXPosition,
                                        titleYPosition,
                                        drawFormat);
                                }
                            }
                            else
                            {
                                Size titleSizeInPixels = TextRenderer.MeasureText(_axisCoordinates.TitleLabel.Text, AxisFont);
                                float titleXPosition = _axisCoordinates.TitleLabel.X;
                                float titleYPosition = _axisCoordinates.TitleLabel.Y - (titleSizeInPixels.Height / 2);

                                e.Graphics.DrawString(_axisCoordinates.TitleLabel.Text, AxisFont, axisBrush, new PointF(titleXPosition, titleYPosition));
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
        //protected virtual float Scale(float rangeStart, float rangeEnd, float valuesStart, float valuesEnd, float value)
        //{
        //    float rangeSpan = rangeEnd - rangeStart;
        //    float valuesSpan = valuesEnd - valuesStart;
        //    float adjustedValue = (valuesStart != 0) ? value - valuesStart : value;
        //    float valueOffset = adjustedValue / valuesSpan;
        //    float rangeOffset = valueOffset * rangeSpan;

        //    return Math.Abs(rangeOffset + rangeStart);
        //}
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
            c.smallTickWidth = SmallTickWidth.HasValue ? SmallTickWidth.Value : DefaultSmallTickWidth;
            c.largeTickWidth = LargeTickWidth.HasValue ? LargeTickWidth.Value : DefaultLargeTickWidth;
            c.maximumTickWidth = (c.largeTickWidth > c.smallTickWidth) ? c.largeTickWidth : c.smallTickWidth;

            // outermost x coordinate (away from vertical axis line) for all ticks
            c.outermostTickX = (Position == YAxisPosition.Left) ?
                        c.axisVerticalLineX - c.maximumTickWidth :
                        c.axisVerticalLineX + c.maximumTickWidth;

            // actual tick X coordinates
            c.smallTickX = (Position == YAxisPosition.Left) ?
                        c.axisVerticalLineX - c.smallTickWidth :
                        c.axisVerticalLineX;

            c.largeTickX = (Position == YAxisPosition.Left) ?
                        c.axisVerticalLineX - c.largeTickWidth :
                        c.axisVerticalLineX;

            // horizontal margin between tick line and label
            c.tickLineToLabelMargin = -2F;

            c.smallLabelSize = TextRenderer.MeasureText((EffectiveMaximum).ToString(Format), SmallLabelFont);
            c.largeLabelSize = TextRenderer.MeasureText((EffectiveMaximum).ToString(Format), LargeLabelFont);

            c.maximumLablelWidth = (c.smallLabelSize.Width > c.largeLabelSize.Width) ?
                c.smallLabelSize.Width :
                c.largeLabelSize.Width;

            // all labels are aligned vertically on the same Y coordinate.
            c.labelX = (Position == YAxisPosition.Left) ?
                        c.outermostTickX - c.tickLineToLabelMargin - c.maximumLablelWidth :
                        c.outermostTickX + c.tickLineToLabelMargin;

            var actualTitle = string.IsNullOrEmpty(Unit) ? Name : $"{Name} ({Unit})";

            if (DrawTitleVertically)
            {
                Size horizontalSize = TextRenderer.MeasureText(actualTitle, AxisFont);
                // flip horizontal size to vertical
                c.titleSize = new Size(
                    horizontalSize.Height,
                    horizontalSize.Width);
            }
            else
            {
                c.titleSize = TextRenderer.MeasureText(actualTitle, AxisFont);
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

            float valueRange = Math.Abs(EffectiveMaximum - EffectiveMinimum);
            float largeStep = LargeStep.HasValue ? LargeStep.Value : (valueRange / 3);
            float smallStep = SmallStep.HasValue ? SmallStep.Value : (largeStep / 3);

            float startYPosition = InvertRange ? -EffectiveMaximum : EffectiveMinimum;
            float maxYPosition = InvertRange ? -EffectiveMinimum : EffectiveMaximum;
            float scalingRangeMinimum = InvertRange ? -c.maximumY : c.minimumY;
            float scalingRangeMaximum = InvertRange ? -c.minimumY : c.maximumY;
            float scalingValuesMinimum = InvertRange ? -EffectiveMinimum : EffectiveMinimum;
            float scalingValuesMaximum = InvertRange ? -EffectiveMaximum : EffectiveMaximum;

            for (float i = startYPosition; i < maxYPosition; i += largeStep)
            {
                var largeStepValue = i;
                var largeScaledY = LineGraphHelper.Scale(scalingRangeMinimum, scalingRangeMaximum,
                        scalingValuesMinimum, scalingValuesMaximum, largeStepValue);
                c.LargeTicks.Add(new Tick()
                {
                    X = c.largeTickX,
                    Y = largeScaledY,
                    Width = LargeTickWidth.GetValueOrDefault(8)
                });
                c.LargeLabels.Add(new TickLabel()
                {
                    X = c.labelX,
                    Y = largeScaledY - (LargeLabelFont.SizeInPoints),
                    Text = FormatLabel(Math.Abs(Math.Round(largeStepValue, Precision.GetValueOrDefault(2))))
                });

                for (float x = i + smallStep; x < i + largeStep; x += smallStep)
                {
                    var smallStepValue = x;
                    var smallScaledY = LineGraphHelper.Scale(scalingRangeMinimum, scalingRangeMaximum,
                        scalingValuesMinimum, scalingValuesMaximum, smallStepValue);

                    c.SmallTicks.Add(new Tick()
                    {
                        X = c.smallTickX,
                        Y = smallScaledY,
                        Width = SmallTickWidth.GetValueOrDefault(4)
                    });

                    c.SmallLabels.Add(new TickLabel()
                    {
                        X = c.labelX,
                        Y = smallScaledY - (SmallLabelFont.SizeInPoints),
                        Text = FormatLabel(Math.Abs(Math.Round(smallStepValue, Precision.GetValueOrDefault(2))))
                    });
                }
            }

            var lastScaledY = LineGraphHelper.Scale(scalingRangeMinimum, scalingRangeMaximum,
                    scalingValuesMinimum, scalingValuesMaximum, scalingValuesMaximum);

            c.LargeTicks.Add(new Tick()
            {
                X = c.largeTickX,
                Y = Math.Abs(InvertRange ? scalingRangeMinimum : scalingRangeMaximum),
                Width = LargeTickWidth.GetValueOrDefault(8)
            });
            c.LargeLabels.Add(new TickLabel()
            {
                X = c.labelX,
                Y = Math.Abs(InvertRange ? scalingRangeMinimum : scalingRangeMaximum) - (LargeLabelFont.SizeInPoints),
                Text = FormatLabel(Math.Abs(InvertRange ? scalingValuesMinimum : scalingValuesMaximum))
            });

            return c;
        }
        #endregion
    }
}
