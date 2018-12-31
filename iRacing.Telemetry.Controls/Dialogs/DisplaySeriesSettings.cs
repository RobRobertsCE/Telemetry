using iRacing.Telemetry.Controls.Displays;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Dialogs
{
    public partial class DisplaySeriesSettings : Form
    {
        public LineGraphDisplayInfo DisplayInfo { get; set; }

        public DisplaySeriesSettings()
        {
            InitializeComponent();
        }

        private void DisplaySeriesSettings_Load(object sender, EventArgs e)
        {
            if (DisplayInfo != null)
                ShowDisplayInfo();
        }

        protected virtual void ShowDisplayInfo()
        {
            txtAxisXExtent.Text = DisplayInfo.AxisXExtent.ToString();
            txtAxisYExtent.Text = DisplayInfo.AxisYExtent.ToString();
            txtX.Text = DisplayInfo.X.ToString();
            txtY.Text = DisplayInfo.Y.ToString();
            txtThickness.Text = DisplayInfo.Thickness.ToString();
        }

        protected virtual void UpdateDisplayInfo()
        {
            DisplayInfo.AxisXExtent = Int32.Parse(txtAxisXExtent.Text);
            DisplayInfo.AxisYExtent = Int32.Parse(txtAxisYExtent.Text);
            DisplayInfo.X = Int32.Parse(txtX.Text);
            DisplayInfo.Y = Int32.Parse(txtY.Text);
            DisplayInfo.Thickness = Int32.Parse(txtThickness.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayInfo = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DisplayInfo != null)
                UpdateDisplayInfo();
        }
    }
}
