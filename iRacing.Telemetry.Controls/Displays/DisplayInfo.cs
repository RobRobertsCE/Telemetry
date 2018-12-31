using Infragistics.UltraChart.Shared.Styles;
using iRacing.Common;
using System.Collections.Generic;
using System.Drawing;

namespace iRacing.Telemetry.Controls.Displays
{
    public abstract class DisplayInfo
    {
        public DisplayType DisplayType { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ZOrder { get; set; }


        // Positions chart grid within UltraChart control.
        // ultraChart1.Axis.X.Extent = 40;
        public int AxisXExtent { get; set; }
        public int AxisYExtent { get; set; }

        public DisplayInfo()
        {

        }
        protected DisplayInfo(DisplayType displayType)
            : this()
        {
            DisplayType = displayType;
        }
    }

    public class LapTimesDisplayInfo : DisplayInfo
    {
        public LapTimesDisplayInfo()
            : base(DisplayType.LapTimes)
        {
        }
    }

    public class LineGraphDisplayInfo : DisplayInfo
    {
        public IList<DisplaySeries> DisplaySeries { get; set; }
        // LineChart properties
        public int Thickness { get; set; }
        public LineDrawStyle DrawStyle { get; set; }
        public LineCapStyle StartStyle { get; set; }
        public LineCapStyle EndStyle { get; set; }
        public bool HighLightLines { get; set; }
        public bool MidPointAnchors { get; set; }
        public NullHandling NullHandling { get; set; }

        public LineGraphDisplayInfo()
            : base(DisplayType.LineGraph)
        {
            DisplaySeries = new List<DisplaySeries>();
        }
    }

    public class DefaultDisplaySeriesLine : DisplaySeriesLine
    {
        public DefaultDisplaySeriesLine()
        {
            InitializeDefaultValues();
        }

        void InitializeDefaultValues()
        {
            ColorArgb = Color.Red.ToArgb();
        }
    }

    public class DefaultDisplaySeriesRPM : DisplaySeries
    {
        public DefaultDisplaySeriesRPM()
        {
            InitializeDefaultValues();
        }

        void InitializeDefaultValues()
        {
            Idx = 0;
            FieldName = "RPM";
            DataType = irsdk_VarType.irsdk_float;
            Unit = "RPM";
            Format = "#####.0";
            MinValue = 0;
            MaxValue = 10000;
            DisplayAxisLegend = false;
            DisplayMajorGridlines = true;
            DisplayMinorGridlines = false;
            DisplaySeriesLine = new DefaultDisplaySeriesLine();
        }
    }

    public class DefaultLineChartRpmDisplayInfo : LineGraphDisplayInfo
    {
        public DefaultLineChartRpmDisplayInfo()
            : base()
        {
            InitializeDefaultValues();
        }

        void InitializeDefaultValues()
        {
            X = 250;
            Y = 250;
            Width = 600;
            Height = 400;
            ZOrder = 0;

            Thickness = 2;
            DrawStyle = LineDrawStyle.Dash;
            StartStyle = LineCapStyle.DiamondAnchor;
            EndStyle = LineCapStyle.Triangle;
            HighLightLines = true;
            NullHandling = NullHandling.DontPlot;
            AxisXExtent = 5;
            AxisYExtent = 5;

            DisplaySeries.Add(new DefaultDisplaySeriesRPM());
        }
    }

    public class DefaultLapTimesDisplayInfo : LapTimesDisplayInfo
    {

        public DefaultLapTimesDisplayInfo()
            : base()
        {
            X = 0;
            Y = 0;
            Width = 250;
            Height = 600;
            ZOrder = 0;
        }
    }

}
