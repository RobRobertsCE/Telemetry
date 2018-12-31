using iRacing.Telemetry.Graphing.Internal;
using iRacing.Telemetry.Graphing.Models;
using iRacing.Telemetry.Graphing.Models.Default;
using iRacing.Telemetry.Graphing.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Graphing.Controls
{
    public partial class TelemetryLineGraph : UserControl, INotifyPropertyChanged
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

        #region structs
        private struct FrameFieldValues
        {
            public float Value;
            public float LapMin;
            public float LapMax;
            public float LapAvg;
            public bool MinWarning;
            public bool MaxWarning;
        }
        #endregion

        #region enums
        private enum FieldListColumns
        {
            Warning = 1,
            Value,
            LapMin,
            LapMax,
            LapAvg
        }
        #endregion

        #region consts
        private const int DefaultSummaryColumnWidth = 60;
        #endregion

        #region fields
        float _selectedFramePercent = 0F;
        int _selectedFrame = 0;
        int _selectedLap = 0;
        #endregion

        #region properties
        private LineGraphModel _model = null;
        public LineGraphModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model != null)
                    _model.PropertyChanged -= _model_PropertyChanged;

                _model = value;

                _model.PropertyChanged += _model_PropertyChanged;

                OnPropertyChanged(nameof(Model));

                for (int i = 0; i < Model.SeriesCount; i++)
                {
                    AddSeries(Model.GetSeries(i));
                }

                UpdateSeriesListDisplay();
            }
        }
        #endregion

        #region ctor/load
        public TelemetryLineGraph()
        {
            InitializeComponent();

            this.Load += LineGraph_Load;
        }

        private void LineGraph_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Model == null)
                //{
                //    Model = BuildTestModel();

                //    for (int i = 0; i < Model.SeriesCount; i++)
                //    {
                //        AddSeries(Model.GetSeries(i));
                //    }

                //    SetCurrentLap(0);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region public
        public void AddSeries(ILineGraphSeries series)
        {
            AddSeriesToList(series);
            UpdateSeriesListDisplay();
        }

        public void SetCurrentLap(int lapIndex)
        {
            if (lapIndex < 0 || lapIndex > Model.LapCount)
                return;

            _selectedLap = lapIndex;

            graphPanel.Refresh();
            graphYAxisPanel.Refresh();
        }

        public void SetCurrentFrame(int frameIdx)
        {
            UpdateSeriesListValues(frameIdx);
        }
        #endregion

        #region private
        private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case ("Series"):
                    {
                        UpdateSeriesListValues(_selectedFrame);
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"OnPropertyChanged from {sender.GetType().ToString()}:{e.PropertyName}");
                        break;
                    }
            }
        }

        #region paint events
        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (Model == null)
                    return;

                using (Graphics g = e.Graphics)
                {
                    for (int fieldIdx = 0; fieldIdx < Model.FieldCount; fieldIdx++)
                    {
                        var field = Model.GetSeries(fieldIdx);

                        float minimumY = (field.YAxis.RangeStart * e.ClipRectangle.Height) + field.YAxis.Margins.Top;
                        float maximumY = (field.YAxis.RangeEnd * e.ClipRectangle.Height) - field.YAxis.Margins.Bottom;
                        float rangeY = maximumY - minimumY;
                        float startYPosition = field.YAxis.InvertRange ? -field.YAxis.EffectiveMaximum : field.YAxis.EffectiveMinimum;
                        float maxYPosition = field.YAxis.InvertRange ? -field.YAxis.EffectiveMinimum : field.YAxis.EffectiveMaximum;
                        float scalingRangeMinimum = field.YAxis.InvertRange ? -maximumY : minimumY;
                        float scalingRangeMaximum = field.YAxis.InvertRange ? -minimumY : maximumY;
                        float scalingValuesMinimum = field.YAxis.InvertRange ? -field.YAxis.EffectiveMinimum : field.YAxis.EffectiveMinimum;
                        float scalingValuesMaximum = field.YAxis.InvertRange ? -field.YAxis.EffectiveMaximum : field.YAxis.EffectiveMaximum;

                        if (field.ShowMaximumWarning)
                        {
                            using (Pen maxWarningPen = new Pen(field.Color, field.LineThickness) { DashPattern = new float[] { 4.0F, 2.0F } })
                            {
                                var maxWarningY = LineGraphHelper.Scale(scalingRangeMinimum, scalingRangeMaximum,
                                        scalingValuesMinimum, scalingValuesMaximum, field.MaxWarning.GetValueOrDefault(0));
                                g.DrawLine(maxWarningPen, 0, maxWarningY, graphPanel.Width, maxWarningY);
                            }
                        }
                        if (field.ShowMinimumWarning)
                        {
                            using (Pen minWarningPen = new Pen(field.Color, field.LineThickness) { DashPattern = new float[] { 4.0F, 2.0F } })
                            {
                                var minWarningY = LineGraphHelper.Scale(scalingRangeMinimum, scalingRangeMaximum,
                                         scalingValuesMinimum, scalingValuesMaximum, field.MinWarning.GetValueOrDefault(1));
                                g.DrawLine(minWarningPen, 0, minWarningY, graphPanel.Width, minWarningY);
                            }
                        }

                        using (Pen pen = new Pen(field.Color, field.LineThickness))
                        {
                            float xScale = (float)Model.FrameCount / (float)graphPanel.Width;

                            float newX = 0;
                            float val = Model.GetValue(_selectedLap, 0, fieldIdx);
                            float newY = LineGraphHelper.Scale(scalingRangeMinimum, scalingRangeMaximum,
                                        scalingValuesMinimum, scalingValuesMaximum, val);


                            float lastPointX = newX;
                            float lastPointY = newY;

                            for (int frameidx = 1; frameidx < Model.FrameCount; frameidx++)
                            {
                                newX = xScale * frameidx;

                                val = Model.GetValue(_selectedLap, frameidx, fieldIdx);
                                newY = LineGraphHelper.Scale(scalingRangeMinimum, scalingRangeMaximum,
                                       scalingValuesMinimum, scalingValuesMaximum, val);

                                g.DrawLine(pen, lastPointX, lastPointY, newX, newY);

                                lastPointX = newX;
                                lastPointY = newY;
                            }
                        }
                    }

                    using (Pen selectedFramePen = new Pen(Color.Gray, 1F))
                    {
                        float selectedFrameX = graphPanel.Width * _selectedFramePercent;
                        g.DrawLine(selectedFramePen, selectedFrameX, 0, selectedFrameX, graphPanel.Height);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void graphYAxisPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Model == null)
                return;

            int runningOffset = 0;

            for (int i = 0; i < Model.SeriesCount; i++)
            {
                var axis = Model.GetSeries(i).YAxis;
                if (axis.ShowAxis)
                {
                    Model.GetSeries(i).YAxis.PaintAxis(e, runningOffset);

                    runningOffset += (int)axis.GetAxisDrawWidth();
                }
            }
            this.graphLayoutTable.ColumnStyles[0].Width = runningOffset;
        }
        #endregion

        #region series list
        private void AddSeriesToList(ILineGraphSeries series)
        {
            var lvi = new ListViewItem(series.Key)
            {
                BackColor = Color.Black,
                ForeColor = series.Color,
                Tag = series
            };

            lvi.UseItemStyleForSubItems = false;

            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "", lvi.ForeColor, lvi.BackColor, lvi.Font)); // value
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "", lvi.ForeColor, lvi.BackColor, lvi.Font)); // warning
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "", lvi.ForeColor, lvi.BackColor, lvi.Font)); // lap min
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "", lvi.ForeColor, lvi.BackColor, lvi.Font)); // lap max
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "", lvi.ForeColor, lvi.BackColor, lvi.Font)); // lap avg

            lvFieldList.Items.Add(lvi);
        }

        private void UpdateSeriesListColors()
        {
            foreach (ListViewItem seriesItem in lvFieldList.Items)
            {
                ILineGraphSeries series = (ILineGraphSeries)seriesItem.Tag;
                seriesItem.ForeColor = series.Color;
            }
        }

        private void UpdateVisibleColumns(SummaryColumnFlags visibleColumns)
        {
            lvFieldList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvFieldList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvFieldList.Columns[(int)FieldListColumns.Value].Width =
                (visibleColumns.HasFlag(SummaryColumnFlags.Value) ? DefaultSummaryColumnWidth : 0);
            lvFieldList.Columns[(int)FieldListColumns.LapMin].Width =
                (visibleColumns.HasFlag(SummaryColumnFlags.LapMin) ? DefaultSummaryColumnWidth : 0);
            lvFieldList.Columns[(int)FieldListColumns.LapMax].Width =
                (visibleColumns.HasFlag(SummaryColumnFlags.LapMax) ? DefaultSummaryColumnWidth : 0);
            lvFieldList.Columns[(int)FieldListColumns.LapAvg].Width =
                (visibleColumns.HasFlag(SummaryColumnFlags.LapAvg) ? DefaultSummaryColumnWidth : 0);

            int totalVisibleColumnWidth = 0;
            foreach (ColumnHeader column in lvFieldList.Columns)
            {
                totalVisibleColumnWidth += column.Width;
            }
            Console.WriteLine($"ListView width: {lvFieldList.Width} totalVisibleColumnWidth: {totalVisibleColumnWidth}");

            int scrollBarMargin = 5; // to get rid of scroll bar at bottom of ListView
            lvFieldList.Size = new Size(totalVisibleColumnWidth + scrollBarMargin, lvFieldList.Height);
            splitContainer1.SplitterDistance = totalVisibleColumnWidth + scrollBarMargin;
        }

        private void UpdateAxisPanelSize()
        {
            int runningOffset = 0;

            for (int i = 0; i < Model.SeriesCount; i++)
            {
                var axis = Model.GetSeries(i).YAxis;
                if (axis.ShowAxis)
                {
                    runningOffset += (int)axis.GetAxisDrawWidth();
                }
            }
            this.graphLayoutTable.ColumnStyles[0].Width = runningOffset;
        }

        private void UpdateSeriesListDisplay()
        {
            UpdateVisibleColumns(Model.SummaryFlags);
            UpdateAxisPanelSize();
            UpdateSeriesListValues(_selectedFrame);
        }

        private void UpdateSeriesListValues(int frameIdx)
        {
            if (Model == null)
                return;

            if (!Model.HasValues)
                return;

            if (frameIdx < 0 || frameIdx > Model.FrameCount)
                return;

            for (int i = 0; i < Model.SeriesCount; i++)
            {
                var value = Model.GetValue(_selectedLap, frameIdx, i);
                lvFieldList.Items[i].SubItems[(int)FieldListColumns.Value].Text = value.ToString(Model.GetSeries(i).Format);

                FrameFieldValues ffv = GetFrameFieldValues(_selectedLap, frameIdx, i);

                lvFieldList.Items[i].SubItems[(int)FieldListColumns.Value].Text = ffv.Value.ToString(Model.GetSeries(i).Format);

                if (ffv.MinWarning)
                {
                    lvFieldList.Items[i].SubItems[(int)FieldListColumns.Warning].BackColor = Color.Orange;
                }
                else if (ffv.MaxWarning)
                {
                    lvFieldList.Items[i].SubItems[(int)FieldListColumns.Warning].BackColor = Color.Red;
                }
                else
                {
                    lvFieldList.Items[i].SubItems[(int)FieldListColumns.Warning].BackColor = Color.Black;
                }

                lvFieldList.Items[i].SubItems[(int)FieldListColumns.LapMin].Text =
                    Model.GetSeries(i).ShowLapMinimum ? ffv.Value.ToString(Model.GetSeries(i).Format) : String.Empty;

                lvFieldList.Items[i].SubItems[(int)FieldListColumns.LapMax].Text =
                    Model.GetSeries(i).ShowLapMaximum ? ffv.Value.ToString(Model.GetSeries(i).Format) : String.Empty;

                lvFieldList.Items[i].SubItems[(int)FieldListColumns.LapAvg].Text =
                    Model.GetSeries(i).ShowLapAverage ? ffv.Value.ToString(Model.GetSeries(i).Format) : String.Empty;
            }

            _selectedFrame = frameIdx;

            this.Refresh();
        }

        #endregion

        #region frame selection
        private void graphPanel_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button.HasFlag(MouseButtons.Left))
                {
                    _selectedFramePercent = (float)e.X / (float)graphPanel.Width;

                    var targetFrame = (int)(Model.FrameCount * _selectedFramePercent);

                    UpdateSeriesListValues(targetFrame);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private FrameFieldValues GetFrameFieldValues(int lapIdx, int frameIdx, int fieldIdx)
        {
            FrameFieldValues ffv = new FrameFieldValues();

            var lapValues = Model.GetLapFieldValues(lapIdx, fieldIdx).ToList();

            ffv.Value = lapValues[frameIdx];
            ffv.LapMin = lapValues.Min();
            ffv.LapMax = lapValues.Max();
            ffv.LapAvg = lapValues.Average();

            var series = Model.GetSeries(fieldIdx);

            if (series.ShowMaximumWarning && series.MaxWarning.HasValue)
                ffv.MaxWarning = ffv.Value >= series.MaxWarning.Value;

            if (series.ShowMinimumWarning && series.MinWarning.HasValue)
                ffv.MinWarning = ffv.Value <= series.MinWarning.Value;

            return ffv;
        }
        #endregion

        #region editors
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (EditSelectedSeries())
                {
                    UpdateVisibleColumns(Model.SummaryFlags);
                    UpdateSeriesListColors();
                    UpdateSeriesListValues(_selectedFrame);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private bool EditSelectedSeries()
        {
            IList<ILineGraphSeries> selectedSeries = new List<ILineGraphSeries>();

            foreach (ListViewItem seriesItem in lvFieldList.SelectedItems)
            {
                selectedSeries.Add((ILineGraphSeries)seriesItem.Tag);
            }

            SeriesEditor dialog = new SeriesEditor()
            {
                Series = selectedSeries
            };

            DialogResult seriesEditorResult = dialog.ShowDialog(this);

            bool changesMade = (seriesEditorResult == DialogResult.OK);

            if (changesMade)
            {
                foreach (ILineGraphSeries series in dialog.Series)
                {
                    Model.UpdateSeries(series);
                }
            }

            return changesMade;
        }

        private void groupSelectedSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (GroupSelectedSeries())
                {
                    UpdateVisibleColumns(Model.SummaryFlags);
                    UpdateSeriesListColors();
                    UpdateSeriesListValues(_selectedFrame);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private bool GroupSelectedSeries()
        {
            IList<ILineGraphSeries> selectedSeries = new List<ILineGraphSeries>();

            foreach (ListViewItem seriesItem in lvFieldList.SelectedItems)
            {
                selectedSeries.Add((ILineGraphSeries)seriesItem.Tag);
            }

            GroupingEditor dialog = new GroupingEditor()
            {
                Series = selectedSeries
            };

            DialogResult seriesEditorResult = dialog.ShowDialog(this);

            bool changesMade = (seriesEditorResult == DialogResult.OK);

            if (changesMade)
            {
                foreach (ILineGraphSeries series in dialog.Series)
                {
                    Model.UpdateSeries(series);
                }
            }

            return changesMade;
        }
        #endregion

        #region sample data
        private Random _randomValueGenerator = new Random();

        private LineGraphModel BuildTestModel()
        {
            int lapCount = 10;
            int maxFrameCount = 1000;

            var series = new List<LineGraphSeries>();

            var rpmSeries = new RpmLineGraphSeries()
            {
                YAxis = new RpmYAxis()
            };
            series.Add(rpmSeries);

            var steeringSeries = new SteeringLineGraphSeries()
            {
                YAxis = new SteeringYAxis()
            };
            series.Add(steeringSeries);

            var throttleSeries = new ThrottleLineGraphSeries()
            {
                YAxis = new ThrottleYAxis()
            };
            series.Add(throttleSeries);

            var brakeSeries = new BrakeLineGraphSeries()
            {
                YAxis = new BrakeYAxis()
            };
            series.Add(brakeSeries);

            var model = new LineGraphModel(lapCount, maxFrameCount, series.Count);

            model.AddSeries(rpmSeries);
            model.AddSeries(steeringSeries);
            model.AddSeries(throttleSeries);
            model.AddSeries(brakeSeries);

            PopulateSampleData(model, lapCount, maxFrameCount, rpmSeries, 100);
            PopulateSampleData(model, lapCount, maxFrameCount, steeringSeries, 3);
            PopulateSampleData(model, lapCount, maxFrameCount, throttleSeries, .1F);
            PopulateSampleData(model, lapCount, maxFrameCount, brakeSeries, .1F);

            return model;
        }

        private void PopulateSampleData(LineGraphModel model, int lapCount, int maxFrameCount, LineGraphSeries series, float scale)
        {
            float lastValue = series.Minimum + ((series.Maximum - series.Minimum) / 2);

            for (int lapIdx = 0; lapIdx < lapCount; lapIdx++)
            {
                model.SetValue(lapIdx, 0, series.FieldIndex, lastValue);

                for (int frameIdx = 1; frameIdx < maxFrameCount; frameIdx++)
                {
                    float valueDelta = (float)((_randomValueGenerator.NextDouble() - .5F) * scale);
                    float newValue = lastValue + valueDelta;

                    if (newValue > series.Maximum)
                        newValue = series.Maximum;

                    if (newValue < series.Minimum)
                        newValue = series.Minimum;

                    model.SetValue(lapIdx, frameIdx, series.FieldIndex, newValue);

                    lastValue = newValue;
                }
            }
        }
        #endregion
        #endregion
    }
}
