using iRacing.Telemetry.Controls.Converters;
using iRacing.Telemetry.Controls.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Models
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

        #region public properties
        private ObservableCollection<ILineGraphSeries> _seriesCollection = null;
        public ObservableCollection<ILineGraphSeries> SeriesCollection
        {
            get
            {
                return _seriesCollection;
            }
            protected set
            {
                if (_seriesCollection != null)
                {
                    _seriesCollection.CollectionChanged -= _seriesCollection_CollectionChanged;
                }

                _seriesCollection = new ObservableCollection<ILineGraphSeries>(value);

                if (_seriesCollection != null)
                {
                    _seriesCollection.CollectionChanged += _seriesCollection_CollectionChanged;
                }
            }
        }

        [JsonIgnore()]
        public SummaryColumnFlags SummaryFlags
        {
            get
            {
                var flags = new SummaryColumnFlags();

                flags = SummaryColumnFlags.Value | SummaryColumnFlags.Unit;

                Array summaryColumnEnumValues = Enum.GetValues(typeof(SummaryColumnFlags));

                for (int i = 1; i < summaryColumnEnumValues.GetLength(0) - 1; i++)
                {
                    SummaryColumnFlags summaryColumnEnumValue = (SummaryColumnFlags)summaryColumnEnumValues.GetValue(i);

                    if (SeriesCollection.Any(s => s.SummaryColumnFlags.HasFlag(summaryColumnEnumValue)))
                        flags = flags | summaryColumnEnumValue;
                }

                return flags;
            }
        }
        #endregion

        #region ctor
        public LineGraphModel()
        {
            SeriesCollection = new ObservableCollection<ILineGraphSeries>();
        }
        #endregion

        #region public
        public void Save(string fileName)
        {
            var json = Serialize();
            File.WriteAllText(fileName, json);
        }
        public string Serialize()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
            settings.Converters.Add(new ColorConverter());
            return JsonConvert.SerializeObject(this, settings);
        }
        public static LineGraphModel Load(string fileName)
        {
            if (!File.Exists(fileName))
            {
                var model = new LineGraphModel();
                model.Save(fileName);
                return model;
            }
            else
            {
                var json = File.ReadAllText(fileName);
                return Deserialize(json);
            }
        }
        public static LineGraphModel Deserialize(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
            settings.Converters.Add(new ColorConverter());
            return JsonConvert.DeserializeObject<LineGraphModel>(json, settings);
        }
        #endregion

        #region protected
        protected virtual void _seriesCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        SeriesAdded(e.NewItems);
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        SeriesRemoved(e.OldItems);
                        break;
                    }
                case NotifyCollectionChangedAction.Replace:
                    {
                        SeriesReplaced(e.NewItems, e.OldItems);
                        break;
                    }
                case NotifyCollectionChangedAction.Move:
                    {
                        SeriesMoved(e);
                        break;
                    }
                case NotifyCollectionChangedAction.Reset:
                    {
                        SeriesCollectionReset();
                        break;
                    }
            }

            OnPropertyChanged(nameof(SeriesCollection));
        }
        protected virtual void SeriesAdded(System.Collections.IList added)
        {
            foreach (ILineGraphSeries series in added)
            {
                series.PropertyChanged += LineGraphSeries_PropertyChanged;
            }

            ResetFieldIndexes();
        }
        protected virtual void SeriesRemoved(System.Collections.IList removed)
        {
            foreach (ILineGraphSeries series in removed)
            {
                series.PropertyChanged -= LineGraphSeries_PropertyChanged;
            }

            ResetFieldIndexes();
        }
        protected virtual void SeriesMoved(NotifyCollectionChangedEventArgs e)
        {
            ResetFieldIndexes();
        }
        protected virtual void SeriesReplaced(System.Collections.IList added, System.Collections.IList removed)
        {
            foreach (ILineGraphSeries series in removed)
            {
                series.PropertyChanged -= LineGraphSeries_PropertyChanged;
            }

            foreach (ILineGraphSeries series in added)
            {
                series.PropertyChanged += LineGraphSeries_PropertyChanged;
            }

            ResetFieldIndexes();
        }
        protected virtual void SeriesCollectionReset()
        {

        }
        protected virtual void ResetFieldIndexes()
        {
            foreach (ILineGraphSeries series in _seriesCollection)
            {
                series.FieldIndex = _seriesCollection.IndexOf(series);
            }
        }
        #endregion

        #region private
        private void LineGraphSeries_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e);
        }
        #endregion
    }
}
