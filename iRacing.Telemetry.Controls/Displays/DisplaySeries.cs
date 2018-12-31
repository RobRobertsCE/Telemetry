using iRacing.Common;
using iRacing.Common.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Controls.Displays
{
    public class DisplaySeries
    {
        public int Idx { get; set; }
        public string FieldName { get; set; }
        public irsdk_VarType DataType { get; set; }
        public string Unit { get; set; }
        public string Format { get; set; }

        public DisplaySeriesLine DisplaySeriesLine { get; set; }

        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public bool DisplayAxisLegend { get; set; }
        public bool DisplayMajorGridlines { get; set; }
        public bool DisplayMinorGridlines { get; set; }

        public DisplaySeries()
        {
        }
    }
}
