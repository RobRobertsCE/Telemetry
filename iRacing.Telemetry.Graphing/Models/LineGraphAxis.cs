using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace iRacing.Telemetry.Graphing.Models
{
    public abstract class LineGraphAxis
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, e);
        }
        #endregion

        #region constants
        public const int DefaultFontSize = 8;
        public const string DefaultFontFamily = "Tahoma";
        public const float DefaultLineThickness = 1F;
        public const float DefaultLargeTickThickness = 1F;
        public const float DefaultSmallTickThickness = .5F;
        public const float DefaultLargeTickWidth = 8F;
        public const float DefaultSmallTickWidth = 4F;
        public const float DefaultRangeStart = 0F;
        public const float DefaultRangeEnd = 1F;
        public const int DefaultPrecision = 2;
        public const float DefaultMinimum = 0;
        public const float DefaultMaximum = 1000;
        #endregion

        #region properties
        private string _name;
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
        private string _unit;
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
        private string _format;
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
        private int? _precision;
        public int? Precision
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
        private float _axisBaseLineWidth = DefaultLineThickness;
        public float AxisBaseLineWidth
        {
            get
            {
                return _axisBaseLineWidth;
            }
            set
            {
                _axisBaseLineWidth = value;
                OnPropertyChanged(nameof(AxisBaseLineWidth));
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
        private Margins _margins = new Margins(0, 0, 2, 2);
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

        private Color _axisColor;
        public Color AxisColor
        {
            get
            {
                return _axisColor;
            }
            set
            {
                _axisColor = value;
                OnPropertyChanged(nameof(AxisColor));
            }
        }
        private Color _largeLabelColor;
        public Color LargeLabelColor
        {
            get
            {
                return _largeLabelColor;
            }
            set
            {
                _largeLabelColor = value;
                OnPropertyChanged(nameof(LargeLabelColor));
            }
        }
        private Color _smallLabelColor;
        public Color SmallLabelColor
        {
            get
            {
                return _smallLabelColor;
            }
            set
            {
                _smallLabelColor = value;
                OnPropertyChanged(nameof(SmallLabelColor));
            }
        }

        private Font _axisFont;
        public Font AxisFont
        {
            get
            {
                return _axisFont;
            }
            set
            {
                _axisFont = value;
                OnPropertyChanged(nameof(AxisFont));
            }
        }
        private Font _largeLabelFont;
        public Font LargeLabelFont
        {
            get
            {
                return _largeLabelFont;
            }
            set
            {
                _largeLabelFont = value;
                OnPropertyChanged(nameof(LargeLabelFont));
            }
        }
        private Font _smallLabelFont;
        public Font SmallLabelFont
        {
            get
            {
                return _smallLabelFont;
            }
            set
            {
                _smallLabelFont = value;
                OnPropertyChanged(nameof(SmallLabelFont));
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
        private bool _showLargeLabels = true;
        public bool ShowLargeLabels
        {
            get
            {
                return _showLargeLabels;
            }
            set
            {
                _showLargeLabels = value;
                OnPropertyChanged(nameof(ShowLargeLabels));
            }
        }
        private bool _showSmallLabels = true;
        public bool ShowSmallLabels
        {
            get
            {
                return _showSmallLabels;
            }
            set
            {
                _showSmallLabels = value;
                OnPropertyChanged(nameof(ShowSmallLabels));
            }
        }
        private bool _showLargeTicks = true;
        public bool ShowLargeTicks
        {
            get
            {
                return _showLargeTicks;
            }
            set
            {
                _showLargeTicks = value;
                OnPropertyChanged(nameof(ShowLargeTicks));
            }
        }
        private bool _showSmallTicks = true;
        public bool ShowSmallTicks
        {
            get
            {
                return _showSmallTicks;
            }
            set
            {
                _showSmallTicks = value;
                OnPropertyChanged(nameof(ShowSmallTicks));
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

        private float? _largeStep;
        public float? LargeStep
        {
            get
            {
                return _largeStep;
            }
            set
            {
                _largeStep = value;
                OnPropertyChanged(nameof(LargeStep));
            }
        }
        private float? _smallStep;
        public float? SmallStep
        {
            get
            {
                return _smallStep;
            }
            set
            {
                _smallStep = value;
                OnPropertyChanged(nameof(SmallStep));
            }
        }

        private float? _largeTickWidth;
        public float? LargeTickWidth
        {
            get
            {
                return _largeTickWidth;
            }
            set
            {
                _largeTickWidth = value;
                OnPropertyChanged(nameof(LargeTickWidth));
            }
        }
        private float? _smallTickWidth;
        public float? SmallTickWidth
        {
            get
            {
                return _smallTickWidth;
            }
            set
            {
                _smallTickWidth = value;
                OnPropertyChanged(nameof(SmallTickWidth));
            }
        }

        private float _smallTickLineThickness = DefaultSmallTickThickness;
        public float SmallTickLineThickness
        {
            get
            {
                return _smallTickLineThickness;
            }
            set
            {
                _smallTickLineThickness = value;
                OnPropertyChanged(nameof(SmallTickLineThickness));
            }
        }
        private float _largeTickLineThickness = DefaultLargeTickThickness;
        public float LargeTickLineThickness
        {
            get
            {
                return _largeTickLineThickness;
            }
            set
            {
                _largeTickLineThickness = value;
                OnPropertyChanged(nameof(LargeTickLineThickness));
            }
        }

        private float? _minimum;
        public float? Minimum
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
        private float? _maximum;
        public float? Maximum
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

        private float _rangeStart = DefaultRangeStart;
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
        private float _rangeEnd = DefaultRangeEnd;
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

        [JsonIgnore()]
        public virtual float EffectiveMinimum { get { return Minimum.HasValue ? Minimum.Value : DefaultMinimum; } }
        [JsonIgnore()]
        public virtual float EffectiveMaximum { get { return Maximum.HasValue ? Maximum.Value : DefaultMaximum; } }
        #endregion

        #region ctor
        public LineGraphAxis()
        {
            Font font = new Font(new FontFamily(DefaultFontFamily), DefaultFontSize);
            AxisFont = font;
            LargeLabelFont = font;
            SmallLabelFont = font;
        }
        #endregion

        #region public
        public abstract void PaintAxis(PaintEventArgs e, int offset);
        #endregion
    }
}
