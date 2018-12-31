using Infragistics.UltraChart.Shared.Styles;
using iRacing.Common.Models;
using iRacing.Telemetry.Controls.Displays;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls
{
    public partial class LineGraph : UserControl//, ITelemetryFrameDisplay
    {
        public int FrameIdx { get; set; } = -1;
        public int LapIdx { get; set; } = 1;
        public LineGraphDisplayInfo DisplayInfo { get; set; }
        public IList<float> xAxisRange { get; set; }
        public IDictionary<string, decimal> yAxisData { get; set; }
        public IList<IFrame> Frames { get; set; }
        public IList<ILapInfo> Laps { get; set; }
        public IFieldDefinition Field { get; set; }
        public object SelectedValue { get; private set; }

        public LineGraph()
        {
            InitializeComponent();

            var defaultData = new List<int>() { 1, 5, 7, 3, 4 };

            ultraChart1.ChartType = ChartType.LineChart;
            ultraChart1.Data.DataSource = defaultData;
            ultraChart1.Data.DataBind();
            ultraChart1.Data.SwapRowsAndColumns = true;
        }

        public void UpdateDisplayInfo(LineGraphDisplayInfo displayInfo)
        {
            DisplayInfo = displayInfo;
            DisplayData();
        }

        public void DisplayData()
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Value", typeof(double));

            //int frameIdx = 0;
            //foreach (ITelemetryFrame frame in Frames)
            //{
            //    //dt.Rows.Add(new object[] { frameIdx, Frames[frameIdx].GetTelemetryValue<double>(Field.Name) });
            //    dt.Rows.Add(new object[] { Frames[frameIdx].GetTelemetryValue<double>(DisplayInfo.DisplaySeries.FirstOrDefault().FieldName) });
            //    frameIdx++;
            //}

            //ultraChart1.ChartType = ChartType.LineChart;
            //ultraChart1.Data.DataSource = dt;
            //ultraChart1.Data.DataBind();
            ultraChart1.Data.DataSource = null;

            ultraChart1.LineChart.DrawStyle = DisplayInfo.DrawStyle;
            ultraChart1.LineChart.StartStyle = DisplayInfo.StartStyle;
            ultraChart1.LineChart.EndStyle = DisplayInfo.EndStyle;
            ultraChart1.LineChart.HighLightLines = DisplayInfo.HighLightLines;
            ultraChart1.LineChart.MidPointAnchors = DisplayInfo.MidPointAnchors;
            ultraChart1.LineChart.NullHandling = DisplayInfo.NullHandling;
            ultraChart1.LineChart.Thickness = DisplayInfo.Thickness;

            ultraChart1.Series.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("Label", typeof(string));
            for (int i = 0; i < DisplayInfo.DisplaySeries.Count; i++)
            {
                dt.Columns.Add($"Series{i.ToString()}", typeof(float));
            }
            foreach (DisplaySeries series in DisplayInfo.DisplaySeries)
            {
                ultraChart1.Axis.Y.RangeMin = series.MinValue;
                ultraChart1.Axis.Y.RangeMax = series.MaxValue;
                ultraChart1.Axis.Y.RangeType = AxisRangeType.Custom;

                int frameIdx = 0;
                foreach (IFrame frame in Frames)
                {
                    var frameValue = frame.GetTelemetryValue<float>(series.FieldName);
                    //numericSeries.Points.Add(new NumericDataPoint(frameValue, frameIdx, false));
                    dt.Rows.Add("frame" + frameIdx.ToString(), frameValue);
                    frameIdx++;
                }

                ultraChart1.Data.DataSource = dt;
                ultraChart1.Data.DataBind();
            }

            //ultraChart1.Data.SwapRowsAndColumns = true;

            SetFrameIdx(0);
        }
        public void SetLapNumber(int? lapNumber)
        {
            // lap number has changed.
            SetFrameIdx(0);
        }

        public void SetFrameIdx(int idx)
        {
            try
            {
                FrameIdx = idx;

                lblFrameCount.Text = Frames.Count.ToString();
                lblFrameIdx.Text = FrameIdx.ToString();
                var fieldName = DisplayInfo.DisplaySeries.FirstOrDefault()?.FieldName;
                lblField.Text = fieldName;
                lblValue.Text = Frames[FrameIdx].GetTelemetryValue<float>(fieldName).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        public void IncrementFrameIdx(int delta)
        {
            var newFrameIdx = FrameIdx + delta;

            if (newFrameIdx < 0)
                newFrameIdx = 0;
            else if (newFrameIdx > (Frames.Count - 1))
                newFrameIdx = (Frames.Count - 1);

            SetFrameIdx(newFrameIdx);
        }

        private class DataViewItem
        {
            public string Name { get; set; }
            public Decimal Value { get; set; }
        }
    }
}
