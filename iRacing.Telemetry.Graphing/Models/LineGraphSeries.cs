using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace iRacing.Telemetry.Graphing.Models
{
    public class LineGraphSeries : ILineGraphSeries
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region properties
        private LineGraphYAxis _yAxis = null;
        public LineGraphYAxis YAxis
        {
            get
            {
                return _yAxis;
            }
            set
            {
                if (_yAxis != null)
                {
                    _yAxis.PropertyChanged -= _yAxisProperty_PropertyChanged;
                }
                _yAxis = value;
                SetYAxis(_yAxis);
                OnPropertyChanged(nameof(YAxis));
            }
        }

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

        private int _minimum = 0;
        public int Minimum
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

        private int _maximum = 1;
        public int Maximum
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

        private int? _precision = 2;
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

        private float? _maxWarning = .9F;
        public float? MaxWarning
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

        private float? _minWarning = .9F;
        public float? MinWarning
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

        private bool _showMajorGridlines = false;
        public bool ShowMajorGridlines
        {
            get
            {
                return _showMajorGridlines;
            }
            set
            {
                _showMajorGridlines = value;
                OnPropertyChanged(nameof(ShowMajorGridlines));
            }
        }

        private bool _showMinorGridlines = false;
        public bool ShowMinorGridlines
        {
            get
            {
                return _showMinorGridlines;
            }
            set
            {
                _showMinorGridlines = value;
                OnPropertyChanged(nameof(ShowMinorGridlines));
            }
        }

        private bool _showLapMinimum = false;
        public bool ShowLapMinimum
        {
            get
            {
                return _showLapMinimum;
            }
            set
            {
                _showLapMinimum = value;
                OnPropertyChanged(nameof(ShowLapMinimum));
            }
        }

        private bool _showLapMaximum = false;
        public bool ShowLapMaximum
        {
            get
            {
                return _showLapMaximum;
            }
            set
            {
                _showLapMaximum = value;
                OnPropertyChanged(nameof(ShowLapMaximum));
            }
        }

        private bool _showLapAverage = false;
        public bool ShowLapAverage
        {
            get
            {
                return _showLapAverage;
            }
            set
            {
                _showLapAverage = value;
                OnPropertyChanged(nameof(ShowLapAverage));
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

        #region ctor
        public LineGraphSeries()
        {

        }
        #endregion

        #region public
        public virtual void SetYAxis(LineGraphYAxis yAxis)
        {
            if (yAxis.AxisColor == Color.Empty)
                yAxis.AxisColor = Color;

            if (yAxis.SmallLabelColor == Color.Empty)
                yAxis.SmallLabelColor = Color;

            if (yAxis.LargeLabelColor == Color.Empty)
                yAxis.LargeLabelColor = Color;

            if (String.IsNullOrEmpty(yAxis.Name))
                yAxis.Name = Name;

            if (String.IsNullOrEmpty(yAxis.Unit))
                yAxis.Unit = Unit;

            if (String.IsNullOrEmpty(yAxis.Format))
                yAxis.Format = Format;

            yAxis.Precision = Precision;

            yAxis.Minimum = Minimum;

            yAxis.Maximum = Maximum;

            yAxis.RangeStart = RangeStart;

            yAxis.RangeEnd = RangeEnd;

            _yAxis.PropertyChanged += _yAxisProperty_PropertyChanged;
        }

        public void Save(string fileName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var json = JsonConvert.SerializeObject(this, settings);
            File.WriteAllText(fileName, json);
        }
        public static LineGraphSeries Load(string fileName)
        {
            var json = File.ReadAllText(fileName);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            return JsonConvert.DeserializeObject<LineGraphSeries>(json, settings);
        }
        #endregion

        #region private
        private void _yAxisProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged($"YAxis.{e.PropertyName }");
        }
        #endregion
    }
}