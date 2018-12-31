using System.Drawing;

namespace iRacing.Telemetry.Controls.Models.Default
{
    public class GenericLineGraphSeries : LineGraphSeries
    {
        #region constants
        public const string DefaultFormat = "####.##";
        public const string DefaultUnit = "";
        public const int DefaultMinValue = 0;
        public const int DefaultMaxValue = 100;
        public const int DefaultLargeStepCount = 2;
        public const int DefaultSmallStepCount = 2;
        #endregion

        #region fields
        public static Color DefaultColor = Color.White;
        #endregion

        #region ctor
        public GenericLineGraphSeries()
            : base()
        {

            ShowAxis = true;
            ShowTitle = true;
            DrawTitleVertically = true;
            DrawTitleLettersHorizontally = false;
            ShowTicks = true;
            ShowTickLabels = true;
            Precision = 2;
            TickStep = 10;

            Position = YAxisPosition.Left;
        }
        public GenericLineGraphSeries(string key, string displayName)
            : this(key, displayName, DefaultColor, DefaultLineThickness, DefaultFormat, DefaultUnit, DefaultMinValue, DefaultMaxValue)
        {
        }

        public GenericLineGraphSeries(string key, string displayName, int maxValue)
            : this(key, displayName, DefaultColor, DefaultLineThickness, DefaultFormat, DefaultUnit, DefaultMinValue, maxValue)
        {
        }

        public GenericLineGraphSeries(string key, string displayName, string format, string unit, int minValue, int maxValue)
            : this(key, displayName, DefaultColor, DefaultLineThickness, format, unit, minValue, maxValue)
        {
        }
        public GenericLineGraphSeries(
                       string key,
                       string displayName,
                       Color color,
                       float lineThickness,
                       string format,
                       string unit,
                       int minValue,
                       int maxValue)
            : base()
        {
            Key = key;
            Name = displayName;
            Color = color;
            LineThickness = lineThickness;
            Format = format;
            Unit = unit;
            Minimum = minValue;
            Maximum = maxValue;
            Precision = DefaultPrecision;
            InvertRange = false;
        }
        #endregion
    }
}
