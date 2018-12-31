using iRacing.Telemetry.Controls.Internal;
using iRacing.Telemetry.Controls.Models;
using iRacing.Telemetry.Controls.Extensions;
using iRacing.Telemetry.Controls.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace iRacing.Telemetry.Controls
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

        public event EventHandler<int> SelectedFrameChangeRequest;
        protected virtual void OnSelectedFrameChangeRequest(int frameidx)
        {
            var handler = SelectedFrameChangeRequest;
            if (handler != null)
                handler.Invoke(this, frameidx);
        }
        #endregion

        #region consts
        private static string MissingSummaryValueDisplay = String.Empty;
        private const int DefaultSummaryColumnWidth = 40;
        private const int MinWarningImageIndex = 0;
        private const int MaxWarningImageIndex = 1;
        private const int NoWarningImageIndex = -1;
        private const int DefaultTickWidth = 8;
        private const string DefaultKey = "TelemetryLineGraph";
        #endregion

        #region fields
        float _selectedFramePercent = 0F;
        int _selectedFrameX = 0;
        int _selectedFrameIdx = 0;
        int _selectedLapIdx = 0;
        int[] _maxFieldSizes;

        private bool _resizing = false;

        Bitmap _axisBitmap = null;
        Bitmap _graphBitmap = null;
        Bitmap _graphBackgroundBitmap = null;

        int _graphTimebaseGridSize = 50;
        int _gridColorRGB = 245;
        int _gridColorAlpha = 64;

        int _topMargin = 2;
        int _bottomMargin = 24;
        int _innerMargin = 0;
        int _outerMargin = 1;

        PixelFormat pixelFormat = PixelFormat.Format32bppPArgb;
        SmoothingMode smoothingMode = SmoothingMode.HighQuality;
        #endregion

        #region properties
        private ILineGraphModel _model = new LineGraphModel();
        public ILineGraphModel Model
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

                if (_model != null)
                {
                    _model.PropertyChanged += _model_PropertyChanged;

                    SeriesCollectionChanged();
                }

                OnPropertyChanged(nameof(Model));
            }
        }

        private ILineGraphDataModel _telemetryData = null;
        public ILineGraphDataModel TelemetryData
        {
            get
            {
                return _telemetryData;
            }
            set
            {
                _telemetryData = value;
                OnPropertyChanged(nameof(TelemetryData));
            }
        }

        private bool _canShowGroupingMenu = false;
        public bool CanShowGroupingMenu
        {
            get
            {
                return _canShowGroupingMenu;
            }
            set
            {
                _canShowGroupingMenu = value;
                OnPropertyChanged(nameof(CanShowGroupingMenu));
            }
        }

        private bool _canShowSeriesEditorMenu = false;
        public bool CanShowSeriesEditorMenu
        {
            get
            {
                return _canShowSeriesEditorMenu;
            }
            set
            {
                _canShowSeriesEditorMenu = value;
                OnPropertyChanged(nameof(CanShowSeriesEditorMenu));
            }
        }

        private bool _canShowMarginsEditorMenu = false;
        public bool CanShowMarginsEditorMenu
        {
            get
            {
                return _canShowMarginsEditorMenu;
            }
            set
            {
                _canShowMarginsEditorMenu = value;
                OnPropertyChanged(nameof(CanShowMarginsEditorMenu));
            }
        }
        #endregion

        #region ctor/load
        public TelemetryLineGraph()
        {
            InitializeComponent();

            InitializeSeriesListView();
        }

        private void LineGraph_Load(object sender, EventArgs e)
        {
            try
            {
                ((Form)Parent).ResizeBegin += TelemetryLineGraph_ResizeBegin;
                ((Form)Parent).ResizeEnd += TelemetryLineGraph_ResizeEnd;

                graphPanel.MouseDown += GraphPanel_MouseDown;

                this.DoubleBuffered = true;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void InitializeSeriesListView()
        {
            lvFieldList.Columns.Clear();

            foreach (FieldListColumns seriesColumn in Enum.GetValues(typeof(FieldListColumns)))
            {
                var columnHeader = new ColumnHeader()
                {
                    Text = seriesColumn.GetDescription()
                };

                switch (seriesColumn)
                {
                    case FieldListColumns.FieldName:
                        {
                            columnHeader.Width = 100;
                            break;
                        }
                    case FieldListColumns.Unit:
                        {
                            columnHeader.Width = 40;
                            break;
                        }
                    default:
                        {
                            columnHeader.Width = 60;
                            break;
                        }
                }

                lvFieldList.Columns.Add(columnHeader);
            }

            lvFieldList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            _maxFieldSizes = new int[lvFieldList.Columns.Count];
        }
        #endregion

        #region public
        public void SetCurrentLap(int lapIndex)
        {
            if (lapIndex < 0 || lapIndex > TelemetryData.LapCount)
                return;

            if (_selectedLapIdx == lapIndex)
                return;

            _selectedLapIdx = lapIndex;

            int framesInCurrentLap = TelemetryData.GetLapFrameCount(_selectedLapIdx);

            int newFrameIdx = framesInCurrentLap < _selectedFrameIdx ? framesInCurrentLap : _selectedFrameIdx;

            _selectedFrameIdx = -1;

            ResetGraphGraphics();

            SetCurrentFrame(newFrameIdx);
        }

        public void SetCurrentFrame(int frameIdx)
        {
            if (_selectedFrameIdx != frameIdx)
            {
                var frameCountForLap = TelemetryData.GetLapFrameCount(_selectedLapIdx);
                _selectedFramePercent = (float)frameIdx / (float)frameCountForLap;
                _selectedFrameX = (int)(graphPanel.Width * _selectedFramePercent);

                UpdateSeriesListValues(frameIdx);

                _selectedFrameIdx = frameIdx;

                // to refresh the selected frame indicator
                RedrawGraph();
            }
        }

        public void ResetTelemetryData()
        {
            TelemetryData = new LineGraphDataModel();
            graphPanel.Refresh();
            graphYAxisPanel.Refresh();
        }

        public void DisplaySeriesEditor(ILineGraphSeries series)
        {
            if (EditSeries(new List<ILineGraphSeries>() { series }))
            {
                SeriesCollectionChanged();
            }
        }
        public void DisplaySeriesEditor(IList<ILineGraphSeries> seriesList)
        {
            if (EditSeries(seriesList))
            {
                SeriesCollectionChanged();
            }
        }
        public void DisplaySeriesEditor()
        {
            if (EditSelectedSeries())
            {
                SeriesCollectionChanged();
            }
        }

        public void DisplayMarginEditor(ILineGraphSeries series)
        {
            if (EditMargins(new List<ILineGraphSeries>() { series }))
            {
                SeriesCollectionChanged();
            }
        }
        public void DisplayMarginEditor(IList<ILineGraphSeries> seriesList)
        {
            if (EditMargins(seriesList))
            {
                SeriesCollectionChanged();
            }
        }
        public void DisplayMarginEditor()
        {
            if (EditSelectedMargins())
            {
                SeriesCollectionChanged();
            }
        }

        public void DisplayGroupSelectionEditor()
        {
            if (GroupSelectedSeries())
            {
                SeriesCollectionChanged();
            }
        }

        public void DisplaySummaryColumnEditor()
        {
            if (SetAllSummaryColumns())
            {
                SeriesCollectionChanged();
            }
        }

        public void RefreshGraphics()
        {
            ResetGraphics();
            RedrawGraphics();
        }
        #endregion

        #region protected
        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }
        #endregion

        #region private
        private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case ("SeriesList"):
                    {
                        throw new NotImplementedException();
                    }
                case nameof(Model.SeriesCollection):
                    {
                        SeriesCollectionChanged();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        #region series list
        /* parent methods - use these */
        /// <summary>
        /// A series was added to or removed from the series list
        /// </summary>
        private void SeriesCollectionChanged()
        {
            try
            {
                SuspendLayout();

                InitializeSeriesList();

                UpdateVisibleColumns(Model.SummaryFlags);

                UpdateSeriesListValues(_selectedFrameIdx);

                UpdateAxisPanelSize();

                ResetGraphics();

                _selectedLapIdx = -1;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                ResumeLayout(true);
            }
        }

        /// <summary>
        /// A series in the series list fired a property changed event
        /// </summary>
        /// <param name="series">The series that changed</param>
        private void SeriesChanged(ILineGraphSeries series)
        {
            try
            {
                SuspendLayout();

                UpdateVisibleColumns(Model.SummaryFlags);

                UpdateSeriesListValues(_selectedFrameIdx);

                UpdateAxisPanelSize();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                ResumeLayout(true);
            }
        }
        /* end parent methods */

        /// <summary>
        /// Clears all the series from the listview and adds them from the model's series list.
        /// </summary>
        private void InitializeSeriesList()
        {
            lvFieldList.Items.Clear();

            foreach (ILineGraphSeries series in Model.SeriesCollection)
            {
                AddSeriesToList(series);
            }
        }

        /// <summary>
        /// Adds a single series to the list view
        /// </summary>
        /// <param name="series">The ILineGraphSeries to add</param>
        private void AddSeriesToList(ILineGraphSeries series)
        {
            var lvi = new ListViewItem(series.Name)
            {
                BackColor = Color.Black,
                ForeColor = Color.White,
                Tag = series
            };

            lvi.UseItemStyleForSubItems = false;

            var enumValues = Enum.GetValues(typeof(FieldListColumns));
            var enumLength = enumValues.GetLength(0);
            for (int i = 1; i < enumLength - 1; i++)
            {
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "", series.Color, Color.Black, lvi.Font));
            }

            // units in white
            var unitsSubItem = lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, series.Unit, Color.White, Color.Black, lvi.Font));

            lvFieldList.Items.Add(lvi);
        }

        /// <summary>
        /// Sets the individual listView column widths based on the visibleColumns settings.
        /// </summary>
        /// <param name="visibleColumns">SummaryColumnFlags</param>
        private void UpdateVisibleColumns(SummaryColumnFlags visibleColumns)
        {
            Array fieldColumns = Enum.GetValues(typeof(FieldListColumns));

            // skip first two (Field Name, Value) and last (Unit). These columns are always displayed.
            for (int i = 1; i < fieldColumns.GetLength(0) - 1; i++)
            {
                FieldListColumns fieldColumnsEnumValue = (FieldListColumns)fieldColumns.GetValue(i);
                SummaryColumnFlags summaryColumnFlagValue = fieldColumnsEnumValue.GetSummaryFieldColumn();

                lvFieldList.Columns[(int)fieldColumnsEnumValue].Width =
                    (visibleColumns.HasFlag(summaryColumnFlagValue) ?
                    DefaultSummaryColumnWidth :
                    0);
            }
        }

        /// <summary>
        /// Calculates the width of each Y axis, and sizes the control accordingly.
        /// </summary>
        private void UpdateAxisPanelSize()
        {
            int runningOffset = 0;

            foreach (ILineGraphSeries series in Model.SeriesCollection)
            {
                if ((series.ShowAxis))
                {
                    runningOffset += (int)series.GetAxisDrawWidth();
                }
            }

            graphLayoutTable.ColumnStyles[0].Width = runningOffset;
        }

        /// <summary>
        /// Updates the value columns in the listview from the selected frame data.
        /// </summary>
        /// <param name="frameIdx"></param>
        private void UpdateSeriesListValues(int frameIdx)
        {
            if (!(TelemetryData?.HasValues).GetValueOrDefault(false))
            {
                // default settings - clear out all columns except field name and unit
                foreach (ILineGraphSeries series in Model.SeriesCollection)
                {
                    ListViewItem listItem = lvFieldList.Items[series.FieldIndex];

                    for (int i = 1; i < lvFieldList.Columns.Count - 1; i++)
                    {
                        listItem.SubItems[i].Text = String.Empty;
                    }
                }
            }
            else
            {
                // display telemetry values
                foreach (ILineGraphSeries series in Model.SeriesCollection)
                {
                    ListViewItem listItem = lvFieldList.Items[series.FieldIndex];

                    float minWarning = series.ShowMinimumWarning ?
                            series.MinWarning
                            : 0;

                    float maxWarning = series.ShowMaximumWarning ?
                            series.MaxWarning
                            : 0;

                    FrameFieldValues frameFieldValues = GetFrameFieldValues(
                        series.SummaryColumnFlags,
                        _selectedLapIdx,
                        frameIdx,
                        series.FieldIndex,
                        minWarning,
                        maxWarning);

                    if (frameFieldValues.HasValues)
                    {

                        listItem.SubItems[(int)FieldListColumns.Value].Text = frameFieldValues.Value.ToString(series.Format);

                        if (frameFieldValues.MinWarning)
                        {
                            listItem.ImageIndex = MinWarningImageIndex;
                        }
                        else if (frameFieldValues.MaxWarning)
                        {
                            listItem.ImageIndex = MaxWarningImageIndex;
                        }
                        else
                        {
                            listItem.ImageIndex = NoWarningImageIndex;
                        }

                        Array fieldColumns = Enum.GetValues(typeof(FieldListColumns));

                        for (int i = 2; i < fieldColumns.GetLength(0) - 1; i++)
                        {
                            FieldListColumns fieldColumnsEnumValue = (FieldListColumns)fieldColumns.GetValue(i);
                            SummaryColumnFlags summaryColumnFlagValue = fieldColumnsEnumValue.GetSummaryFieldColumn();

                            listItem.SubItems[(int)fieldColumnsEnumValue].Text =
                             series.SummaryColumnFlags.HasFlag(summaryColumnFlagValue) ? frameFieldValues.SummaryValues[summaryColumnFlagValue].ToString(series.Format) : MissingSummaryValueDisplay;
                        }

                    }
                }
            }

            ResizeSeriesListColumns();
        }

        private FrameFieldValues GetFrameFieldValues(SummaryColumnFlags flags, int lapIdx, int frameIdx, int fieldIdx, float? minWarning, float? maxWarning)
        {
            IEnumerable<TelemetryValues> lapFieldValues = TelemetryData.GetLapFieldValues(lapIdx, fieldIdx).ToList();

            FrameFieldValues ffv;

            if (lapFieldValues.Count() == 0)
            {
                ffv = new FrameFieldValues(false);
            }
            else
            {
                ffv = new FrameFieldValues(true);

                ffv.Value = lapFieldValues.FirstOrDefault(v => v.FrameIdx == frameIdx).Value.GetValueOrDefault();

                IEnumerable<float> lapValues = lapFieldValues.Select(v => v.Value.GetValueOrDefault());

                var lapMin = lapValues.Min();
                var lapMax = lapValues.Max();

                if (flags.HasFlag(SummaryColumnFlags.LapMin))
                    ffv.SummaryValues.Add(SummaryColumnFlags.LapMin, lapMin);

                if (flags.HasFlag(SummaryColumnFlags.LapMax))
                    ffv.SummaryValues.Add(SummaryColumnFlags.LapMax, lapMax);

                if (flags.HasFlag(SummaryColumnFlags.LapDelta))
                    ffv.SummaryValues.Add(SummaryColumnFlags.LapDelta, lapMax - lapMin);

                if (flags.HasFlag(SummaryColumnFlags.LapMode))
                    ffv.SummaryValues.Add(SummaryColumnFlags.LapMode, lapValues.Mode());

                if (flags.HasFlag(SummaryColumnFlags.LapAvg))
                    ffv.SummaryValues.Add(SummaryColumnFlags.LapAvg, lapValues.Average());

                if (flags.HasFlag(SummaryColumnFlags.LapStdDev))
                    ffv.SummaryValues.Add(SummaryColumnFlags.LapStdDev, lapValues.StandardDeviation());

                IEnumerable<TelemetryValues> sessionFieldValues = TelemetryData.GetSessionFieldValues(fieldIdx);

                IEnumerable<float> sessionValues = sessionFieldValues.Select(v => v.Value.GetValueOrDefault());

                var sessionMin = sessionValues.Min();
                var sessionMax = sessionValues.Max();

                if (flags.HasFlag(SummaryColumnFlags.SessionMin))
                    ffv.SummaryValues.Add(SummaryColumnFlags.SessionMin, sessionMin);

                if (flags.HasFlag(SummaryColumnFlags.SessionMax))
                    ffv.SummaryValues.Add(SummaryColumnFlags.SessionMax, sessionMax);

                if (flags.HasFlag(SummaryColumnFlags.SessionDelta))
                    ffv.SummaryValues.Add(SummaryColumnFlags.SessionDelta, sessionMax - sessionMin);

                if (flags.HasFlag(SummaryColumnFlags.SessionMode))
                    ffv.SummaryValues.Add(SummaryColumnFlags.SessionMode, sessionValues.Mode());

                if (flags.HasFlag(SummaryColumnFlags.SessionAvg))
                    ffv.SummaryValues.Add(SummaryColumnFlags.SessionAvg, sessionValues.Average());

                if (flags.HasFlag(SummaryColumnFlags.SessionStdDev))
                    ffv.SummaryValues.Add(SummaryColumnFlags.SessionStdDev, sessionValues.StandardDeviation());

                if (maxWarning.HasValue)
                    ffv.MaxWarning = ffv.Value >= maxWarning.Value;

                if (minWarning.HasValue)
                    ffv.MinWarning = ffv.Value <= minWarning.Value;

            }

            return ffv;
        }

        private int GetMaxWidthForColumn(ListViewItem lvi, int columnIdx, int defaultMaxWidth)
        {
            int maxHeaderOrFieldWidth = lvFieldList.Columns[columnIdx].Text.Length > lvi.SubItems[columnIdx].Text.Length ?
                   lvFieldList.Columns[columnIdx].Text.Length :
                   lvi.SubItems[columnIdx].Text.Length;

            int maxWidthForColumn = defaultMaxWidth > maxHeaderOrFieldWidth ? defaultMaxWidth : maxHeaderOrFieldWidth;

            return maxWidthForColumn;
        }

        private void ResizeSeriesListColumns()
        {
            int characterWidth = (int)(lvFieldList.Font.Size * 1.5);
            Size startingListViewSize = lvFieldList.Size;
            int[] maxFieldSizes = new int[lvFieldList.Columns.Count];
            int totalVisibleColumnWidth = 0;
            float widthDelta = 0F;

            foreach (ListViewItem lvi in lvFieldList.Items)
            {
                Array fieldColumns = Enum.GetValues(typeof(FieldListColumns));

                /* These three columns have minimum sizes, and are never hidden */
                int fieldNameColumnIdx = 0;
                int fieldColumnMinimumCharacters = 5; // Allow room for the warning image
                int valueColumnIdx = 1;
                int valueColumnMinimumCharacters = 6; // No header text in this column
                int unitColumnIdx = lvFieldList.Columns.Count - 1;
                int unitColumnMinimumCharacters = 5; // Allow room for the warning image

                maxFieldSizes[fieldNameColumnIdx] = GetMaxWidthForColumn(lvi, fieldNameColumnIdx, fieldColumnMinimumCharacters);
                maxFieldSizes[valueColumnIdx] = GetMaxWidthForColumn(lvi, valueColumnIdx, valueColumnMinimumCharacters);
                maxFieldSizes[unitColumnIdx] = GetMaxWidthForColumn(lvi, unitColumnIdx, unitColumnMinimumCharacters);

                // skip first two (Field Name, Value) and last (Unit). These columns are always displayed.
                for (int i = 2; i < fieldColumns.GetLength(0) - 1; i++)
                {
                    FieldListColumns fieldColumnsEnumValue = (FieldListColumns)fieldColumns.GetValue(i);
                    SummaryColumnFlags summaryColumnFlagValue = fieldColumnsEnumValue.GetSummaryFieldColumn();

                    if (lvFieldList.Columns[(int)fieldColumnsEnumValue].Width > 0)
                    {
                        maxFieldSizes[(int)fieldColumnsEnumValue] = GetMaxWidthForColumn(lvi, (int)fieldColumnsEnumValue, _maxFieldSizes[(int)fieldColumnsEnumValue]);
                    }
                }
            }

            for (int i = 0; i < maxFieldSizes.Length; i++)
            {
                if (maxFieldSizes[i] > _maxFieldSizes[i] || lvFieldList.Columns[i].Width != (int)(maxFieldSizes[i] * characterWidth))
                {
                    widthDelta += (_maxFieldSizes[i] - maxFieldSizes[i]) * characterWidth;

                    _maxFieldSizes[i] = maxFieldSizes[i];

                    lvFieldList.Columns[i].Width = (int)(maxFieldSizes[i] * characterWidth);
                }

                totalVisibleColumnWidth += lvFieldList.Columns[i].Width;
            }

            if (widthDelta != 0)
            {
                int scrollBarMargin = 5; // to get rid of scroll bar at bottom of ListView

                Size newListViewSize = new Size(totalVisibleColumnWidth + scrollBarMargin, lvFieldList.Height);

                int listViewSizeDelta = newListViewSize.Width - startingListViewSize.Width;

                splitContainer1.SplitterDistance = totalVisibleColumnWidth + scrollBarMargin;

                lvFieldList.Size = newListViewSize;

                if (Parent != null)
                    Parent.Size = new Size(Parent.Width + listViewSizeDelta, Parent.Height);
            }
        }
        #endregion

        #region frame selection
        private void GraphPanel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button.HasFlag(MouseButtons.Left))
                {
                    SelectFrameFromMouseClick(e);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void SelectFrameFromMouseClick(MouseEventArgs e)
        {
            float selectedFramePercent = (float)e.X / (float)graphPanel.Width;

            int selectedFrameIdx = (int)(TelemetryData.GetLapFrameCount(_selectedLapIdx) * selectedFramePercent);

            OnSelectedFrameChangeRequest(selectedFrameIdx);
        }
        #endregion

        #region editors
        private void lvFieldList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CanShowSeriesEditorMenu = (lvFieldList.SelectedItems.Count > 0);
            CanShowGroupingMenu = (lvFieldList.SelectedItems.Count > 0);
            CanShowMarginsEditorMenu = (lvFieldList.SelectedItems.Count > 0);
        }

        private bool EditSelectedSeries()
        {
            if (lvFieldList.SelectedItems.Count == 0)
                return false;

            return EditSeries(new List<ILineGraphSeries>() { (ILineGraphSeries)lvFieldList.SelectedItems[0].Tag });
        }
        private bool EditSeries(IList<ILineGraphSeries> seriesList)
        {
            SeriesEditor dialog = new SeriesEditor()
            {
                Series = seriesList
            };

            DialogResult seriesEditorResult = dialog.ShowDialog(this);

            bool changesMade = (seriesEditorResult == DialogResult.OK);

            return changesMade;
        }

        private bool EditSelectedMargins()
        {
            if (lvFieldList.SelectedItems.Count == 0)
                return false;

            IList<ILineGraphSeries> selectedSeries = new List<ILineGraphSeries>();

            foreach (ListViewItem seriesItem in lvFieldList.SelectedItems)
            {
                selectedSeries.Add((ILineGraphSeries)seriesItem.Tag);
            }

            return EditMargins(selectedSeries);
        }
        private bool EditMargins(IList<ILineGraphSeries> seriesList)
        {
            MarginsEditor dialog = new MarginsEditor()
            {
                Series = seriesList
            };

            DialogResult seriesEditorResult = dialog.ShowDialog(this);

            bool changesMade = (seriesEditorResult == DialogResult.OK);

            return changesMade;
        }

        private bool GroupSelectedSeries()
        {
            if (lvFieldList.SelectedItems.Count == 0)
                return false;

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

            return changesMade;
        }
        private bool SetAllSummaryColumns()
        {
            IList<ILineGraphSeries> seriesList = new List<ILineGraphSeries>();

            foreach (ListViewItem seriesItem in lvFieldList.Items)
            {
                seriesList.Add((ILineGraphSeries)seriesItem.Tag);
            }

            SummaryColumnEditor dialog = new SummaryColumnEditor()
            {
                SeriesList = seriesList
            };

            DialogResult seriesEditorResult = dialog.ShowDialog(this);

            bool changesMade = (seriesEditorResult == DialogResult.OK);

            return changesMade;
        }
        #endregion
        #endregion

        #region paint events
        // TODO: Axis on left or right
        // TODO: print states invalid at times
        #region axis

        private Size GetYAxisSize()
        {
            int width = graphYAxisPanel.Width - (_innerMargin + _outerMargin);
            int height = graphYAxisPanel.Height - (_topMargin + _bottomMargin);

            if (width < 1)
                width = 1;

            if (height < 1)
                height = 1;

            return new Size(width, height);
        }
        private Size GetGraphSize()
        {
            int width = graphPanel.Width - (_innerMargin + _outerMargin);
            int height = graphPanel.Height - (_topMargin + _bottomMargin);

            if (width < 1)
                width = 1;

            if (height < 1)
                height = 1;

            Size size = new Size(width, height);

            return size;
        }
        private Point GetYAxisLocation()
        {
            int x = _innerMargin;
            int y = _topMargin;

            if (x < 1)
                x = 1;

            if (y < 1)
                y = 1;

            return new Point(x, y);
        }
        private Point GetGraphLocation()
        {
            int x = _innerMargin;
            int y = _topMargin;

            if (x < 1)
                x = 1;

            if (y < 1)
                y = 1;

            Point point = new Point(x, y);

            return point;
        }
        private Point GetFrameIndicatorStartLocation()
        {
            return new Point(_selectedFrameX + _innerMargin, _topMargin);
        }
        private Point GetFrameIndicatorEndLocation()
        {
            return new Point(_selectedFrameX + _innerMargin, graphPanel.Height - _bottomMargin - _topMargin);
        }
        private Rectangle GetYAxisRectangle()
        {
            return new Rectangle(GetYAxisLocation(), GetYAxisSize());
        }
        private Rectangle GetGraphRectangle()
        {
            return new Rectangle(GetGraphLocation(), GetGraphSize());
        }

        private void TelemetryLineGraph_ResizeBegin(object sender, EventArgs e)
        {
            Console.WriteLine("TelemetryLineGraph_ResizeBegin");
            _resizing = true;
            ResetGraphics();
        }
        private void TelemetryLineGraph_ResizeEnd(object sender, EventArgs e)
        {
            Console.WriteLine("TelemetryLineGraph_ResizeEnd");
            _resizing = false;
            RedrawGraphics();
        }
        private void TelemetryLineGraph_SizeChanged(object sender, EventArgs e)
        {
            if (!_resizing)
            {
                ResetGraphics();
                RedrawGraphics();
            }
        }

        private void ResetGraphics()
        {
            ResetAxisGraphics();
            ResetGraphGraphics();
        }
        private void ResetAxisGraphics()
        {
            _axisBitmap = null;
        }
        private void ResetGraphGraphics()
        {
            _graphBitmap = null;
            _graphBackgroundBitmap = null;
        }

        private void RedrawGraphics()
        {
            RedrawAxis();
            RedrawGraph();
        }
        private void RedrawAxis()
        {
            graphPanel.Refresh();
            graphYAxisPanel.Refresh();
        }
        private void RedrawGraph()
        {
            graphPanel.Refresh();
        }

        private Bitmap GetYAxisBitmap()
        {
            if (_axisBitmap != null)
                return _axisBitmap;

            Bitmap bitmap = _axisBitmap;

            Size size = GetYAxisSize();

            bitmap = new Bitmap(
                size.Width,
                size.Height,
                pixelFormat);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = smoothingMode;

                g.Clear(Color.Black);

                int runningOffset = 0;

                foreach (ILineGraphSeries series in Model.SeriesCollection)
                {
                    if (series.ShowAxis)
                    {
                        var axisWidth = PaintAxis(g, size, series, runningOffset);

                        runningOffset += (series.Position == YAxisPosition.Left ? -axisWidth : axisWidth);
                    }
                }

                graphLayoutTable.ColumnStyles[0].Width = graphYAxisPanel.Width;
            }

            _axisBitmap = bitmap;

            return bitmap;
        }
        private int PaintAxis(Graphics g, Size size, ILineGraphSeries series, int offset)
        {
            int axisWidth = 0;
            int axisMargin = 2;
            try
            {
                g.SmoothingMode = smoothingMode;

                var topY = (size.Height * series.RangeStart) + series.Margins.Top;
                var bottomY = (size.Height * series.RangeEnd) - series.Margins.Bottom;
                var verticalRange = bottomY - topY;
                var valueRange = series.Maximum - series.Minimum;
                var verticalAxisLineX = offset + (series.Position == YAxisPosition.Left ? size.Width - 2 : 0);

                using (Pen axisPen = new Pen(series.Color, series.AxisBaseLineThickness))
                {
                    var axisBaseLineStartPoint = new PointF(verticalAxisLineX, topY);
                    var axisBaseLineEndPoint = new PointF(verticalAxisLineX, bottomY);

                    g.DrawLine(
                        axisPen,
                        axisBaseLineStartPoint,
                        axisBaseLineEndPoint);

                    // Get the label formatting info
                    SizeF labelSize = g.MeasureString(series.Maximum.ToString(series.Format), series.Font);
                    StringFormat labelFormat = new StringFormat() { Alignment = StringAlignment.Far };

                    axisWidth = DefaultTickWidth + (int)labelSize.Width;

                    int labelHorizontalOffset = (int)(series.Position == YAxisPosition.Left ?
                       -(DefaultTickWidth + labelSize.Width) :
                        DefaultTickWidth + labelSize.Width);

                    var ticks = LineGraphHelper.MapTicks(series, verticalAxisLineX, topY, bottomY);

                    if (series.InvertRange)
                    {
                        foreach (Tick tick in ticks.AllTicks)
                        {
                            var startX = series.Position == YAxisPosition.Left ? verticalAxisLineX - DefaultTickWidth : verticalAxisLineX;
                            var endX = series.Position == YAxisPosition.Left ? verticalAxisLineX : verticalAxisLineX + DefaultTickWidth;

                            g.DrawLine(axisPen, new PointF(startX, tick.Y), new PointF(endX, tick.Y));

                            if (tick.Label != null)
                            {
                                using (Brush labelBrush = new SolidBrush(series.Color))
                                {
                                    RectangleF labelRectangle = new RectangleF(
                                        tick.Label.X + labelHorizontalOffset,
                                        tick.Label.Y - (labelSize.Height / 2),
                                        labelSize.Width,
                                        labelSize.Height);

                                    g.DrawString(
                                        tick.Label.Text,
                                        series.Font,
                                        labelBrush,
                                        labelRectangle,
                                        labelFormat);
                                }
                            }
                        }
                    }
                    else
                    {
                        float invertedTickStartY = topY + bottomY;
                        foreach (Tick tick in ticks.AllTicks)
                        {
                            var startX = series.Position == YAxisPosition.Left ? verticalAxisLineX - DefaultTickWidth : verticalAxisLineX;
                            var endX = series.Position == YAxisPosition.Left ? verticalAxisLineX : verticalAxisLineX + DefaultTickWidth;

                            PointF tickStartPoint = new PointF(startX, invertedTickStartY - tick.Y);
                            PointF tickEndPoint = new PointF(endX, invertedTickStartY - tick.Y);

                            g.DrawLine(
                                axisPen,
                                tickStartPoint,
                                tickEndPoint);

                            if (tick.Label != null)
                            {
                                using (Brush labelBrush = new SolidBrush(series.Color))
                                {
                                    RectangleF labelRectangle = new RectangleF(
                                       tick.Label.X + labelHorizontalOffset,
                                       invertedTickStartY - tick.Label.Y - (labelSize.Height / 2),
                                       labelSize.Width,
                                       labelSize.Height);

                                    g.DrawString(
                                        tick.Label.Text,
                                        series.Font,
                                        labelBrush,
                                        labelRectangle,
                                        labelFormat);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            return axisWidth + axisMargin;
        }

        private Bitmap GetGraphBackgroundBitmap()
        {
            Bitmap bitmap = _graphBackgroundBitmap;

            if (bitmap != null)
                return bitmap;

            Size size = GetGraphSize();

            bitmap = new Bitmap(
                size.Width,
                size.Height,
                pixelFormat);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = smoothingMode;

                g.Clear(Color.Black);

                Color gridColor = Color.FromArgb(_gridColorAlpha, _gridColorRGB, _gridColorRGB, _gridColorRGB);
                using (Pen gridPen = new Pen(gridColor, 1F))
                {
                    for (int x = 1; x < bitmap.Width; x += _graphTimebaseGridSize)
                    {
                        g.DrawLine(gridPen, new PointF(x, 0), new PointF(x, bitmap.Height));
                    }

                    for (int y = bitmap.Height - 1; y > 0; y -= _graphTimebaseGridSize)
                    {
                        g.DrawLine(gridPen, new PointF(0, y), new PointF(bitmap.Width, y));
                    }
                }
            }

            return bitmap;
        }
        private Bitmap GetGraphBitmap()
        {
            Bitmap bitmap = _graphBitmap;

            try
            {
                Size size = GetGraphSize();

                if (bitmap != null && bitmap.Size == size)
                {
                    return bitmap;
                }

                bitmap = new Bitmap(
                    size.Width,
                    size.Height,
                    pixelFormat);

                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = smoothingMode;

                    g.Clear(Color.Black);

                    Bitmap backgroundBitmap = GetGraphBackgroundBitmap();

                    g.DrawImage(backgroundBitmap, 0, 0);

                    int frameCount = TelemetryData.GetLapFrameCount(_selectedLapIdx);

                    if (frameCount > 0)
                    {
                        float frameSpacing = (float)graphPanel.Width / (float)frameCount;

                        int seriesCount = Model.SeriesCollection.Count();

                        ILineGraphSeries[] seriesArray = new ILineGraphSeries[seriesCount];
                        IEnumerable<TelemetryValues>[] telemetryValuesArray = new IEnumerable<TelemetryValues>[seriesCount];
                        Pen[] seriesPens = new Pen[seriesCount];
                        PointF[] seriesLastPoint = new PointF[seriesCount];
                        GraphicsPath[] graphicsPaths = new GraphicsPath[seriesCount];
                        float[][] fieldLapValues = new float[seriesCount][];

                        for (int s = 0; s < seriesCount; s++)
                        {
                            var lapFieldValues = TelemetryData.GetLapFieldValues(_selectedLapIdx, s);
                            telemetryValuesArray[s] = lapFieldValues;

                            fieldLapValues[s] = lapFieldValues.Select(v => v.Value.Value).ToArray();

                            ILineGraphSeries series = Model.SeriesCollection.ToArray()[s];
                            series.SeriesMapper.GraphicsSize = size;
                            seriesArray[s] = series;

                            Pen seriesPen = new Pen(series.Color, series.AxisBaseLineThickness);
                            seriesPens[s] = seriesPen;

                            seriesLastPoint[s] = PointF.Empty;

                            graphicsPaths[s] = new GraphicsPath();
                        }

                        for (int x = 0; x < frameCount; x++)
                        {
                            float frameX = x * frameSpacing;

                            float frameY = 0;

                            for (int s = 0; s < seriesCount; s++)
                            {
                                float seriesFrameValue = fieldLapValues[s][x];

                                if (seriesArray[s].InvertRange)
                                    frameY = seriesArray[s].SeriesMapper.MapValueInverted(seriesFrameValue);
                                else
                                    frameY = seriesArray[s].SeriesMapper.MapValue(seriesFrameValue);

                                if (seriesLastPoint[s] == PointF.Empty)
                                {
                                    seriesLastPoint[s] = new PointF(frameX, frameY);
                                }

                                graphicsPaths[s].AddLine(seriesLastPoint[s], new PointF(frameX, frameY));

                                seriesLastPoint[s] = new PointF(frameX, frameY);

                            } // for (int s = 0; s < Model.SeriesCollection.Count(); s++)

                        } // for (int x = 0; x < frameCount; x++)

                        for (int s = 0; s < seriesCount; s++)
                        {
                            g.DrawPath(seriesPens[s], graphicsPaths[s]);

                            if (seriesArray[s].ShowMinimumWarning)
                            {
                                float minWarningY = 0F;
                                if (seriesArray[s].InvertRange)
                                    minWarningY = seriesArray[s].SeriesMapper.MapValueInverted(seriesArray[s].MinWarning);
                                else
                                    minWarningY = seriesArray[s].SeriesMapper.MapValue(seriesArray[s].MinWarning);

                                seriesPens[s].DashStyle = DashStyle.DashDotDot;
                                g.DrawLine(seriesPens[s], new PointF(0, minWarningY), new PointF(graphPanel.Width, minWarningY));
                            }
                            if (seriesArray[s].ShowMaximumWarning)
                            {
                                float maxWarningY = 0F;
                                if (seriesArray[s].InvertRange)
                                    maxWarningY = seriesArray[s].SeriesMapper.MapValueInverted(seriesArray[s].MaxWarning);
                                else
                                    maxWarningY = seriesArray[s].SeriesMapper.MapValue(seriesArray[s].MaxWarning);

                                seriesPens[s].DashStyle = DashStyle.Dash;
                                g.DrawLine(seriesPens[s], new PointF(0, maxWarningY), new PointF(graphPanel.Width, maxWarningY));
                            }
                        }

                        for (int p = 0; p < seriesPens.Length; p++)
                        {
                            seriesPens[p].Dispose();
                        }

                    } // if (frameCount > 0)

                } // using (Graphics g = Graphics.FromImage(bitmap))

            } // try
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }

            _graphBitmap = bitmap;

            return bitmap;
        }

        private void graphYAxisPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_resizing == true)
                return;

            Bitmap bitmap = GetYAxisBitmap();
            Point location = GetYAxisLocation();

            e.Graphics.SmoothingMode = smoothingMode;

            e.Graphics.DrawImage(bitmap, location.X, location.Y);
        }
        #endregion

        #region graph
        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (!_resizing)
                {
                    e.Graphics.SmoothingMode = smoothingMode;

                    Bitmap graphBitmap = _graphBitmap == null ? GetGraphBitmap() : _graphBitmap;

                    Point graphLocation = GetGraphLocation();

                    e.Graphics.DrawImage(graphBitmap, graphLocation.X, graphLocation.Y);

                    // draw the frame indicator
                    Point frameStartIndicatorLocation = GetFrameIndicatorStartLocation();
                    Point frameIndicatorEndLocation = GetFrameIndicatorEndLocation();
                    using (Pen seriesPen = new Pen(Color.WhiteSmoke, .5F))
                    {
                        e.Graphics.DrawLine(seriesPen, frameStartIndicatorLocation, frameIndicatorEndLocation);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
        #endregion
    }
}