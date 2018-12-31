using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace iRacing.Telemetry.Controls.Models
{
    public class HistogramModel : INotifyPropertyChanged
    {
        #region constants
        public const int DefaultResolution = 40;
        #endregion

        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region properties
        public int MaxGroupCount { get; set; }
        public HistogramCorners Corner { get; set; }
        public string FieldName { get; set; }
        public IList<float> Values { get; set; }
        private IList<HistogramSpan> _map = null;
        public IList<HistogramSpan> Map
        {
            get
            {
                return _map;
            }
            set
            {
                _map = value;
                OnPropertyChanged(nameof(Map));
            }
        }
        #endregion

        #region ctor
        public HistogramModel(HistogramCorners corner, string fieldName)
            : this(corner)
        {
            FieldName = fieldName;
        }
        public HistogramModel(HistogramCorners corner)
        {
            Corner = corner;
            Map = new List<HistogramSpan>();
            Values = new List<float>();
        }
        #endregion

        #region public
        public int MapValues(int resolution)
        {
            _map = CreateMap(Values, resolution);
            return _map.Max(m => m.Count);
        }
        #endregion

        #region protected
        protected virtual IList<float> MetersPerSecondToMillimetersPerSecond(IList<float> values)
        {
            return values.Select(v => v * 1000).ToList();
        }

        protected virtual IList<HistogramSpan> CreateMap(IList<float> values, int resolution)
        {
            // value comes in a meters/second
            values = MetersPerSecondToMillimetersPerSecond(values);

            // < 5 mm/sec - suspension friction
            // 0 - +/-25 mm/s Inertial chassis motion, (roll, pitch, heave)
            // +/-25 mm/s - +/-200 mm/sec Road input (bumps)
            // > +/- 200 mm/sec Curbs

            var spanRanges = new List<HistogramSpan>();

            float spanIncrement = 5F;
            float spanStart = 0F;

            int halfSpanCount = 0;

            if (resolution % 2 == 0)
            {
                // even number
                halfSpanCount = (resolution / 2);
            }
            else
            {
                // odd number
                spanRanges.Add(new HistogramSpan()
                {
                    Min = -(spanIncrement / 2),
                    Max = spanIncrement / 2
                });
                spanStart = spanIncrement / 2;
                halfSpanCount = ((resolution - 1) / 2);
            }

            for (int i = 0; i < halfSpanCount; i++)
            {
                spanRanges.Add(new HistogramSpan()
                {
                    Min = -(spanStart + ((i + 1) * spanIncrement)),
                    Max = -(spanStart + (i * spanIncrement)),
                    BinsToZero = i
                });
                spanRanges.Add(new HistogramSpan()
                {
                    Min = spanStart + (i * spanIncrement),
                    Max = spanStart + ((i + 1) * spanIncrement),
                    BinsToZero = i
                });
            }

            IList<HistogramSpan> map = new List<HistogramSpan>();

            if (values.Count > 0)
            {

                foreach (HistogramSpan spanDefinition in spanRanges.OrderBy(s => s.Min))
                {
                    var spanItem = new HistogramSpan()
                    {
                        Min = spanDefinition.Min,
                        Max = spanDefinition.Max,
                        Count = values.Count(v => v >= spanDefinition.Min && v < spanDefinition.Max),
                        BinsToZero = spanDefinition.BinsToZero
                    };

                    map.Add(spanItem);
                }
            }

            return map;
        }
        #endregion

        #region classes
        public class HistogramSpan
        {
            public int BinsToZero { get; set; }
            public float Min { get; set; }
            public float Max { get; set; }
            public int Count { get; set; }
        }
        #endregion
    }
}
