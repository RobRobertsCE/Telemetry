using iRacing.Telemetry.Controls.Internal;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Models
{
    public class LineGraphSeries : ILineGraphSeries, ILineGraphYAxis
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (
                propertyName == nameof(RangeStart) ||
                propertyName == nameof(RangeEnd) ||
                propertyName == nameof(Minimum) ||
                propertyName == nameof(Maximum) ||
                propertyName == nameof(Margins)
                )
            {
                _seriesMapper = null;
            }
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region axis constants
        public const int DefaultFontSize = 8;
        public const string DefaultFontFamily = "Tahoma";
        public const float DefaultLineThickness = 1F;
        public const int DefaultTickLineThickness = 1;
        public const int DefaultTickWidth = 8;
        public const float DefaultRangeStart = 0F;
        public const float DefaultRangeEnd = 1F;
        public const int DefaultPrecision = 2;
        public const float DefaultMinimum = 0;
        public const float DefaultMaximum = 1000;
        #endregion

        #region y axis constants     
        /// <summary>
        /// Minimum horizontal distance between the vertical axis line and the edge of the graphics rectangle.
        /// </summary>
        public const int MinimumVerticalLineXOffset = 2;
        public const float AxisIndexOffsetAmount = 2;
        #endregion

        public static Margins DefaultMargins = new Margins(0, 0, 10, 10);

        #region y axis fields
        private float _defaultTickWidth = 4F;
        AxisPrintCoordinates _axisCoordinates = null;
        #endregion

        #region properties     
        private string _name = String.Empty;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _key = String.Empty;
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        private Color _color = Color.Black;
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        private string _format = String.Empty;
        public string Format
        {
            get
            {
                return _format;
            }
            set
            {
                _format = value;
                OnPropertyChanged(nameof(Format));
            }
        }

        private string _unit = String.Empty;
        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        private int _fieldIndex = 0;
        public int FieldIndex
        {
            get
            {
                return _fieldIndex;
            }
            set
            {
                _fieldIndex = value;
                OnPropertyChanged(nameof(FieldIndex));
            }
        }

        private float _minimum = 0F;
        public float Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                _minimum = value;
                OnPropertyChanged(nameof(Minimum));
            }
        }

        private float _maximum = 1F;
        public float Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
                OnPropertyChanged(nameof(Maximum));
            }
        }

        private int _precision = 3;
        public int Precision
        {
            get
            {
                return _precision;
            }
            set
            {
                _precision = value;
                OnPropertyChanged(nameof(Precision));
            }
        }

        private float _maxWarning = 0F;
        public float MaxWarning
        {
            get
            {
                return _maxWarning;
            }
            set
            {
                _maxWarning = value;
                OnPropertyChanged(nameof(MaxWarning));
            }
        }

        private float _minWarning = 0F;
        public float MinWarning
        {
            get
            {
                return _minWarning;
            }
            set
            {
                _minWarning = value;
                OnPropertyChanged(nameof(MinWarning));
            }
        }

        private float _rangeStart = 0F;
        /// <summary>
        ///  Offsets and scales the part of graph that the series uses.
        /// </summary>
        /// <remarks>Valid values between 0.0F and 1.0F.
        /// ex: start=0, end =.5 means the series uses the bottom half of the graph for the Y axis.</remarks>
        public float RangeStart
        {
            get
            {
                return _rangeStart;
            }
            set
            {
                _rangeStart = value;
                OnPropertyChanged(nameof(RangeStart));
            }
        }

        private float _rangeEnd = 1F;
        /// <summary>
        ///  Offsets and scales the part of graph that the series uses.
        /// </summary>
        /// <remarks>Valid values between 0.0F and 1.0F.
        /// ex: start=0, end =.5 means the series uses the bottom half of the graph for the Y axis.</remarks>
        public float RangeEnd
        {
            get
            {
                return _rangeEnd;
            }
            set
            {
                _rangeEnd = value;
                OnPropertyChanged(nameof(RangeEnd));
            }
        }

        private bool _showMaximumWarning = false;
        public bool ShowMaximumWarning
        {
            get
            {
                return _showMaximumWarning;
            }
            set
            {
                _showMaximumWarning = value;
                OnPropertyChanged(nameof(ShowMaximumWarning));
            }
        }

        private bool _showMinimumWarning = false;
        public bool ShowMinimumWarning
        {
            get
            {
                return _showMinimumWarning;
            }
            set
            {
                _showMinimumWarning = value;
                OnPropertyChanged(nameof(ShowMinimumWarning));
            }
        }

        private SummaryColumnFlags _summaryColumnFlags;
        public SummaryColumnFlags SummaryColumnFlags
        {
            get
            {
                return _summaryColumnFlags;
            }
            set
            {
                _summaryColumnFlags = value;
                OnPropertyChanged(nameof(SummaryColumnFlags));
            }
        }

        private float _lineThickness = 0;
        public float LineThickness
        {
            get
            {
                return _lineThickness;
            }
            set
            {
                _lineThickness = value;
                OnPropertyChanged(nameof(LineThickness));
            }
        }
        #endregion

        #region axis properties
        private float _axisBaseLineThickness = DefaultLineThickness;
        public float AxisBaseLineThickness
        {
            get
            {
                return _axisBaseLineThickness;
            }
            set
            {
                _axisBaseLineThickness = value;
                OnPropertyChanged(nameof(AxisBaseLineThickness));
            }
        }
        private int _index;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                OnPropertyChanged(nameof(Index));
            }
        }
        private Margins _margins = DefaultMargins;
        public Margins Margins
        {
            get
            {
                return _margins;
            }
            set
            {
                _margins = value;
                OnPropertyChanged(nameof(Margins));
            }
        }

        private Font _axisFont;
        public Font Font
        {
            get
            {
                return _axisFont;
            }
            set
            {
                _axisFont = value;
                OnPropertyChanged(nameof(Font));
            }
        }

        private bool _showAxis = true;
        public bool ShowAxis
        {
            get
            {
                return _showAxis;
            }
            set
            {
                _showAxis = value;
                OnPropertyChanged(nameof(ShowAxis));
            }
        }
        private bool _showTitle = true;
        public bool ShowTitle
        {
            get
            {
                return _showTitle;
            }
            set
            {
                _showTitle = value;
                OnPropertyChanged(nameof(ShowTitle));
            }
        }
        private bool _showTickLabels = true;
        public bool ShowTickLabels
        {
            get
            {
                return _showTickLabels;
            }
            set
            {
                _showTickLabels = value;
                OnPropertyChanged(nameof(ShowTickLabels));
            }
        }
        private bool _showTicks = true;
        public bool ShowTicks
        {
            get
            {
                return _showTicks;
            }
            set
            {
                _showTicks = value;
                OnPropertyChanged(nameof(ShowTicks));
            }
        }

        private bool _invertRange;
        public bool InvertRange
        {
            get
            {
                return _invertRange;
            }
            set
            {
                _invertRange = value;
                OnPropertyChanged(nameof(InvertRange));
            }
        }

        private float _tickStep = 0F;
        public float TickStep
        {
            get
            {
                if (_tickStep == 0)
                    _tickStep = Maximum / 4;

                return _tickStep;
            }
            set
            {
                _tickStep = value;
                OnPropertyChanged(nameof(TickStep));
            }
        }
        #endregion

        #region y axis properties
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

        private SeriesMapper _seriesMapper = null;
        public SeriesMapper SeriesMapper
        {
            get
            {
                if (_seriesMapper == null)
                {
                    _seriesMapper = new SeriesMapper(
                         RangeStart,
                         RangeEnd,
                         Minimum,
                         Maximum,
                         Margins);
                }
                return _seriesMapper;
            }
        }
        #endregion

        #region ctor
        public LineGraphSeries()
        {
            Font = new Font(new FontFamily(DefaultFontFamily), DefaultFontSize);
        }
        #endregion

        #region public     
        public void Save(string fileName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
            var json = JsonConvert.SerializeObject(this, settings);
            File.WriteAllText(fileName, json);
        }
        public static LineGraphSeries Load(string fileName)
        {
            var json = File.ReadAllText(fileName);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
            return JsonConvert.DeserializeObject<LineGraphSeries>(json, settings);
        }
        public void PaintAxis(PaintEventArgs e, int offset)
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
                            using (Pen tickPen = new Pen(axisBrush, DefaultTickLineThickness))
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

        #region private
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
            c.minimumY = (RangeStart * actualyPrintArea.Height) + Margins.Top;

            // maximum Y coordinate
            c.maximumY = (RangeEnd * actualyPrintArea.Height) - Margins.Bottom;

            // y range
            c.rangeY = c.maximumY - c.minimumY;

            // X coordinate of the vertical axis line (all other y positions should be based off of this value)
            c.axisVerticalLineX = (Position == YAxisPosition.Left) ?
                        c.maximumX - c.indexOffsetX :
                        c.indexOffsetX;

            if (c.axisVerticalLineX < MinimumVerticalLineXOffset)
                c.axisVerticalLineX = MinimumVerticalLineXOffset;

            // effective tick widths
            c.tickWidth = DefaultTickWidth;

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
            float largeStep = TickStep == 0 ? Maximum / 4 : TickStep;

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

        #region y axis

        #region public
        public void ResetAxisCoordinates()
        {
            _axisCoordinates = null;
        }
        private static Bitmap _sizingBitmap = new Bitmap(1, 1);
        public float GetAxisDrawWidth()
        {
            using (Graphics g = Graphics.FromImage(_sizingBitmap))
            {
                SizeF labelSize = g.MeasureString(Maximum.ToString(Format), Font);
                var axisWidth = DefaultTickWidth + (int)labelSize.Width;
                return axisWidth;
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
        #endregion
        #endregion
    }
}