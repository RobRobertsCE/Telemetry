using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Models
{
    public abstract class LineGraphAxis : ILineGraphAxis
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
        public const float DefaultLargeTickWidth = 8F;
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
        private int _precision;
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
        private Margins _margins = new Margins(0, 0, 4, 4);
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
        public Color Color
        {
            get
            {
                return _axisColor;
            }
            set
            {
                _axisColor = value;
                OnPropertyChanged(nameof(Color));
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

        private float _tickStep;
        public float TickStep
        {
            get
            {
                return _tickStep;
            }
            set
            {
                _tickStep = value;
                OnPropertyChanged(nameof(TickStep));
            }
        }

        private float _tickWidth;
        public float TickWidth
        {
            get
            {
                return _tickWidth;
            }
            set
            {
                _tickWidth = value;
                OnPropertyChanged(nameof(TickWidth));
            }
        }
        private float _tickLineThickness = DefaultLargeTickThickness;
        public float TickLineThickness
        {
            get
            {
                return _tickLineThickness;
            }
            set
            {
                _tickLineThickness = value;
                OnPropertyChanged(nameof(TickLineThickness));
            }
        }

        private float _minimum;
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
        private float _maximum;
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

        private bool _inheritValuesFromSeries = true;
        public bool InheritValuesFromSeries
        {
            get
            {
                return _inheritValuesFromSeries;
            }
            set
            {
                _inheritValuesFromSeries = value;
                OnPropertyChanged(nameof(InheritValuesFromSeries));
            }
        }

        private ILineGraphSeries _lineGraphSeries;
        public ILineGraphSeries Parent
        {
            get
            {
                return _lineGraphSeries;
            }
            set
            {
                _lineGraphSeries = value;
                OnPropertyChanged(nameof(Parent));
            }
        }
        #endregion

        #region ctor
        public LineGraphAxis()
        {
            Font = new Font(new FontFamily(DefaultFontFamily), DefaultFontSize);
        }
        #endregion

        #region public
        public abstract void PaintAxis(PaintEventArgs e, int offset);
        #endregion
    }
}
