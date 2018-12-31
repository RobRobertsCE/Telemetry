using iRacing.Telemetry.Graphing.Controls;
using iRacing.Telemetry.Graphing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.Graphing
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.telemetryLineGraph1.Model.Save(Path.Combine(@"C:\Users\rroberts\Telemetry\iRacingTelemetry\Series", $"{telemetryLineGraph1.Model.Name}.json"));
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.telemetryLineGraph1.Model = LineGraphModel.Load(Path.Combine(@"C:\Users\rroberts\Telemetry\iRacingTelemetry\Series", $"DefaultLineGraphModel.json"));
        }
    }
}
