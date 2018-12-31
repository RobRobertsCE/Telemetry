using iRacing.Common;
using iRacing.Common.Models;
using iRacing.Telemetry.Controls.Factories;
using iRacing.Telemetry.Controls.Models;
using iRacing.Telemetry.Data.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views.Displays
{
    public partial class WaveformDisplay : MdiChildForm
    {
        #region events
        protected override void ProtectedPropertyChangedHandlerAsync(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                Log.Info($"waveform prop change: {e.PropertyName}");
                switch (e.PropertyName)
                {
                    case nameof(CurrentLap):
                        {
                            if (CurrentLap != null)
                                Console.WriteLine();
                            else
                                Console.WriteLine();

                            break;
                        }
                    case nameof(CurrentLapNumber):
                        {
                            if (CurrentLap != null && CurrentLap.LapNumber != CurrentLapNumber)
                                SetCurrentLap(CurrentLap?.LapIndex);
                            break;
                        }
                    case nameof(CurrentLapIndex):
                        {
                            SetCurrentLap(CurrentLapIndex);
                            break;
                        }
                    case nameof(CurrentFrameIndex):
                        {
                            SetCurrentFrame(CurrentFrameIndex);
                            break;
                        }
                    case nameof(Session):
                        {
                            if (Session != null)
                            {
                                UpdateSessionData();
                                SetCurrentLap(CurrentLap?.LapIndex);
                            }
                            else
                            {
                                Console.WriteLine();
                            }

                            break;
                        }
                    case nameof(WindowState):
                        {
                            if (_graph != null)
                                _graph.RefreshGraphics();
                            break;
                        }
                    case nameof(FieldDisplayInfos):
                        {
                            break;
                        }
                    case nameof(FieldDefinitions):
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region properties
        public WaveformDisplayInfo WaveformDisplayInfo
        {
            get
            {
                return (WaveformDisplayInfo)base.FormDisplayInfo;
            }
            set
            {
                base.FormDisplayInfo = value;
                OnPropertyChanged(nameof(WaveformDisplayInfo));
            }
        }
        #endregion

        #region ctor/load
        public WaveformDisplay()
            : base()
        {
            InitializeComponent();

            FormDisplayInfo.DisplayType = DisplayTypes.Waveform;
        }

        public WaveformDisplay(
            IServiceProvider serviceProvider,
            log4net.ILog log,
            iRacingTelemetryOptions options)
          : base(
            serviceProvider,
            log,
            options,
            DisplayTypes.Waveform)
        {
            InitializeComponent();
        }

        public WaveformDisplay(
          IServiceProvider serviceProvider,
          log4net.ILog log,
          iRacingTelemetryOptions options,
          IFormDisplayInfo displayInfo)
        : this(
          serviceProvider,
          log,
          options)
        {
            this.FormDisplayInfo = displayInfo;
        }

        protected override void TelemetryForm_Load(object sender, EventArgs e)
        {
            base.TelemetryForm_Load(sender, e);

            _graph.PropertyChanged += _graph_PropertyChanged;
            _graph.SelectedFrameChangeRequest += _graph_SelectedFrameChangeRequest;

            if (WaveformDisplayInfo.Model != null)
            {
                _graph.Model = WaveformDisplayInfo.Model;
            }

            if (Session != null)
            {
                SetSessionData();
                _graph.RefreshGraphics();
            }
        }
        #endregion

        #region public
        public override void BeforeSave()
        {
            SaveModel();
        }
        #endregion

        #region protected
        protected virtual void SaveModel()
        {
            WaveformDisplayInfo.Model = _graph.Model;
        }
        protected virtual void SaveModel(string fileName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => { SaveModel(fileName); }));
            }
            else
            {
                try
                {
                    _graph.Model.Save(fileName);
                }
                catch (Exception ex)
                {
                    ExceptionHandler(ex);
                }
            }
        }
        protected virtual void SetModel(string fileName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => { SetModel(fileName); }));
            }
            else
            {
                try
                {
                    _graph.Model = LineGraphModel.Load(fileName);
                }
                catch (Exception ex)
                {
                    ExceptionHandler(ex);
                }
            }
        }
        protected virtual void ClearModel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => { ClearModel(); }));
            }
            else
            {
                try
                {
                    _graph.Model = null;
                }
                catch (Exception ex)
                {
                    ExceptionHandler(ex);
                }
            }
        }

        protected virtual void SetSessionData()
        {
            if (Session?.TelemetrySessionData == null)
                return;

            if (_graph.Model == null)
                return;

            _graph.ResetTelemetryData();

            for (int lapIdx = 0; lapIdx < Session.TelemetrySessionData.Laps.Count; lapIdx++)
            {
                var lap = Session.TelemetrySessionData.Laps[lapIdx];

                for (int frameIdx = 0; frameIdx < lap.LapFrames.Count; frameIdx++)
                {
                    var frame = lap.LapFrames[frameIdx];

                    foreach (ILineGraphSeries series in _graph.Model.SeriesCollection)
                    {
                        var lapFrameFieldValue = frame.GetTelemetryValue<float>(series.Name);

                        _graph.TelemetryData.SetValue(lapIdx, frameIdx, series.FieldIndex, lapFrameFieldValue);
                    }
                }
            }
        }
        protected void GetTypedValue()
        {
            //for (int fieldIdx = 0; fieldIdx < _graph.Model.SeriesCount; fieldIdx++)
            //{
            //    var series = _graph.Model.GetSeries(fieldIdx);

            //    var lapFrameFieldValue = frame.GetTelemetryValue<float>(series.Name);

            //    Model.SetValue(lapIdx, frameIdx, fieldIdx, lapFrameFieldValue);

            //    //switch (field.DataType)
            //    //{
            //    //    case (Common.irsdk_VarType.irsdk_float):
            //    //        {
            //    //            var frameValue = frame.GetTelemetryValue<float>(fieldDisplayInfo.Name);
            //    //            series.Points.Add(new DataPoint(frame.LapDistPct, frameValue));
            //    //            break;
            //    //        }
            //    //    case (Common.irsdk_VarType.irsdk_double):
            //    //        {
            //    //            var frameValue = frame.GetTelemetryValue<double>(fieldDisplayInfo.Name);
            //    //            series.Points.Add(new DataPoint(frame.LapDistPct, frameValue));
            //    //            break;
            //    //        }
            //    //    case (Common.irsdk_VarType.irsdk_int):
            //    //        {
            //    //            var frameValue = frame.GetTelemetryValue<int>(fieldDisplayInfo.Name);
            //    //            series.Points.Add(new DataPoint(frame.LapDistPct, frameValue));
            //    //            break;
            //    //        }
            //    //}
            //}
        }
        protected virtual void ClearSessionData()
        {
            _graph?.ResetTelemetryData();
        }
        protected virtual void UpdateSessionData()
        {
            ClearSessionData();
            SetSessionData();
        }

        protected virtual void ResetSeriesList()
        {
            try
            {
                _graph?.ResetTelemetryData();

                var displayFieldKeys = FormDisplayInfo.DisplayFields.Select(d => d.Key).ToList();

                var seriesKeys = _graph.Model.SeriesCollection.Select(s => s.Key).ToList();

                foreach (string removedKey in seriesKeys.Except(displayFieldKeys))
                {
                    RemoveSeries(removedKey);
                }

                foreach (string addedKey in displayFieldKeys.Except(seriesKeys))
                {
                    var addedDisplayInfo = FormDisplayInfo.DisplayFields.FirstOrDefault(d => d.Key == addedKey);
                    AddSeries(addedDisplayInfo);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        protected virtual void RemoveSeries(string key)
        {
            var seriesToRemove = _graph.Model.SeriesCollection.FirstOrDefault(d => d.Key == key);

            if (seriesToRemove != null)
                _graph.Model.SeriesCollection.Remove(seriesToRemove);
        }

        protected virtual void AddSeries(FieldDisplayInfo displayInfo)
        {
            ILineGraphSeries series = LineGraphSeriesFactory.GetSeries(displayInfo.Key);

            if (series == null)
            {
                series = LineGraphSeriesFactory.GetGenericSeries(
                                                    displayInfo.Key,
                                                    displayInfo.Name,
                                                    displayInfo.GetColor(),
                                                    displayInfo.Thickness,
                                                    displayInfo.Format,
                                                    displayInfo.GetUnit(),
                                                    (int)displayInfo.RangeMin,
                                                    (int)displayInfo.RangeMax);
            }

            series.SummaryColumnFlags = _graph.Model.SummaryFlags;

            _graph.DisplaySeriesEditor(series);

            _graph.Model.SeriesCollection.Add(series);
        }

        protected virtual void SetCurrentLap(int? idx)
        {
            if (idx.HasValue)
                _graph.SetCurrentLap(idx.Value);
        }
        protected virtual void SetCurrentLap(int idx)
        {
            _graph.SetCurrentLap(idx);
        }
        protected virtual void SetCurrentFrame(int? idx)
        {
            if (idx.HasValue)
                _graph.SetCurrentFrame(idx.Value);
        }
        protected virtual void SetCurrentFrame(int idx)
        {
            _graph.SetCurrentFrame(idx);
        }

        protected virtual string GetFullFilePath(string fileName)
        {
            return Path.Combine(Options.DisplaysDirectory, fileName);
        }

        protected virtual void DisplaySeriesSelection()
        {
            try
            {
                var dialog = new FieldDefinitionsView(ServiceProvider, true);

                //foreach (FieldDisplayInfo displayInfo in FormDisplayInfo.DisplayFields)
                //{
                //    dialog.SelectedFieldDefinitionKeys.Add(displayInfo.Key);
                //}

                foreach (ILineGraphSeries series in _graph.Model.SeriesCollection)
                {
                    dialog.SelectedFieldDefinitionKeys.Add(series.Key);
                }

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // remove unselected fields
                    foreach (FieldDisplayInfo existingField in FormDisplayInfo.DisplayFields.ToList())
                    {
                        if (!dialog.SelectedFieldDefinitionKeys.Contains(existingField.Key))
                        {
                            FormDisplayInfo.DisplayFields.Remove(existingField);
                        }
                    }

                    // add new fields
                    foreach (string key in dialog.SelectedFieldDefinitionKeys)
                    {
                        var existing = FormDisplayInfo.DisplayFields.FirstOrDefault(f => f.Key == key);
                        if (existing == null)
                        {
                            FormDisplayInfo.DisplayFields.Add((FieldDisplayInfo)dialog.DisplayInfos.FirstOrDefault(d => d.Key == key));
                        }
                    }

                    ResetSeriesList();

                    SaveModel();

                    UpdateSessionData();

                    SetCurrentLap(CurrentLap?.LapIndex);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region private
        private void _graph_SelectedFrameChangeRequest(object sender, int e)
        {
            base.OnFrameIndexChangeRequest(e);
        }

        private void _graph_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                switch (e.PropertyName)
                {
                    case nameof(_graph.CanShowGroupingMenu):
                        {
                            seriesGroupingToolStripMenuItem.Enabled = _graph.CanShowGroupingMenu;
                            break;
                        }
                    case nameof(_graph.CanShowSeriesEditorMenu):
                        {
                            editSelectedSeriesToolStripMenuItem.Enabled = _graph.CanShowSeriesEditorMenu;
                            break;
                        }
                    case nameof(_graph.CanShowMarginsEditorMenu):
                        {
                            editSelectedMarginsToolStripMenuItem.Enabled = _graph.CanShowMarginsEditorMenu;
                            break;
                        }
                    case nameof(_graph.Model):
                        {

                            break;
                        }
                    case nameof(_graph.TelemetryData):
                        {

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void addRemoveSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisplaySeriesSelection();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void editSelectedSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _graph.DisplaySeriesEditor();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void seriesGroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _graph.DisplayGroupSelectionEditor();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void summaryColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _graph.DisplaySummaryColumnEditor();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        private void editSelectedMarginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _graph.DisplayMarginEditor();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
    }
}
