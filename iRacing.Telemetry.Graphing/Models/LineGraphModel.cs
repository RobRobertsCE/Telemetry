using iRacing.Telemetry.Graphing.Internal;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Graphing.Models
{
    public class LineGraphModel : ILineGraphModel, INotifyPropertyChanged
    {
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
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }
        #endregion

        #region fields
        private int _seriesCount = 0;
        #endregion

        #region protected properties
        public virtual ILineGraphSeries[] SeriesList { get; set; }
        [JsonIgnore()]
        protected virtual ILineGraphValues Values { get; set; }
        #endregion

        #region public properties  
        [JsonIgnore()]
        public bool HasValues { get { return (Values != null && Values.GetLength(0) > 0); } }
        [JsonIgnore()]
        public int SeriesCount { get { return SeriesList.Length; } }
        [JsonIgnore()]
        public int LapCount { get { return Values.GetLength(ArrayIndex.Lap); } }
        [JsonIgnore()]
        public int FrameCount { get { return Values.GetLength(ArrayIndex.Frame); } }
        [JsonIgnore()]
        public int FieldCount { get { return Values.GetLength(ArrayIndex.Field); } }
        [JsonIgnore()]
        public SummaryColumnFlags SummaryFlags
        {
            get
            {
                var flags = new SummaryColumnFlags();

                flags = SummaryColumnFlags.Value;

                if (SeriesList.ToList().Any(s => s.ShowLapMinimum))
                    flags = flags | SummaryColumnFlags.LapMin;

                if (SeriesList.ToList().Any(s => s.ShowLapMaximum))
                    flags = flags | SummaryColumnFlags.LapMax;

                if (SeriesList.ToList().Any(s => s.ShowLapAverage))
                    flags = flags | SummaryColumnFlags.LapAvg;

                return flags;
            }
        }

        private string _name = "DefaultLineGraphModel";
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
        #endregion

        #region ctor
        private LineGraphModel()
        {

        }
        public LineGraphModel(int lapCount, int maxFrameCount, int fieldCount)
        {
            Values = new LineGraphValues(lapCount, maxFrameCount, fieldCount);
            SeriesList = new LineGraphSeries[fieldCount];
        }
        #endregion

        #region public
        public virtual void SetValue(int lapIdx, int frameIdx, int fieldIdx, float value)
        {
            try
            {
                Values.SetValue(lapIdx, frameIdx, fieldIdx, value);
            }
            catch (System.IndexOutOfRangeException ex)
            {
                throw new System.Exception("Internal arrays have not been initialized", ex);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public virtual float GetValue(int lapIdx, int frameIdx, int fieldIdx)
        {
            float? value = null;

            try
            {
                value = Values.GetValue(lapIdx, frameIdx, fieldIdx);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.Message);
            }

            return value.GetValueOrDefault();
        }
        public virtual float[] GetLapFieldValues(int lapIdx, int fieldIdx)
        {
            return Values.GetLapFieldValues(lapIdx, fieldIdx);
        }
        public virtual float[,] GetSessionFieldValue(int fieldIdx)
        {
            return Values.GetSessionFieldValues(fieldIdx);
        }
        public virtual float[] GetLapFrameValue(int lapIdx, int frameIdx)
        {
            return Values.GetLapFrameValue(lapIdx, frameIdx);
        }

        public virtual void UpdateSeries(ILineGraphSeries series)
        {
            if (SeriesList[series.FieldIndex] != null)
            {
                SeriesList[series.FieldIndex].PropertyChanged -= LineGraphSeries_PropertyChanged;
            }

            SeriesList[series.FieldIndex] = series;

            series.PropertyChanged += LineGraphSeries_PropertyChanged;

            OnPropertyChanged(nameof(SeriesList));
        }

        private void LineGraphSeries_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e);
        }

        public virtual int AddSeries(ILineGraphSeries series)
        {
            try
            {
                series.FieldIndex = _seriesCount++;

                SeriesList[series.FieldIndex] = series;

                series.PropertyChanged += LineGraphSeries_PropertyChanged;

                OnPropertyChanged(nameof(SeriesList));

                return series.FieldIndex;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception("Internal arrays have not been initialized", ex);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual ILineGraphSeries GetSeries(int fieldIdx)
        {
            return SeriesList[fieldIdx];
        }

        public void Save(string fileName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var json = JsonConvert.SerializeObject(this, settings);
            File.WriteAllText(fileName, json);
        }
        public static LineGraphModel Load(string fileName)
        {
            var json = File.ReadAllText(fileName);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            return JsonConvert.DeserializeObject<LineGraphModel>(json, settings);
        }
        #endregion
    }
}
