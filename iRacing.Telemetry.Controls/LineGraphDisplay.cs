using iRacing.Common.Models;
using iRacing.Telemetry.Controls.Dialogs;
using iRacing.Telemetry.Controls.Displays;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls
{
    public partial class LineGraphDisplay : TelemetryFrameDisplayBase
    {
        public LineGraphDisplay(LineGraphDisplayInfo displayInfo)
            : this()
        {
            DisplayInfo = displayInfo;
            lineGraph1.DisplayInfo = DisplayInfo;
        }
        public LineGraphDisplay()
        {
            InitializeComponent();

            if (DisplayInfo != null)
                lineGraph1.DisplayInfo = DisplayInfo;
        }

        public LineGraphDisplay(IFieldDefinition field)
            : this()
        {
            Field = field;
            lineGraph1.Field = Field;
        }

        #region protected
        protected override void DisplayFrames()
        {
            ClearFramesDisplay();

            if (Frames == null || Frames.Count == 0)
                return;

            if (Field == null)
                return;

            this.lineGraph1.Frames = this.Frames;
            lineGraph1.DisplayData();

            DisplaySelectedFrameIdx();
        }

        // Display the frame index vertical line
        protected override void DisplaySelectedFrameIdx()
        {

        }

        protected override void ClearFramesDisplay()
        {

        }
        #endregion

        private void LineGraphDisplay_Load(object sender, EventArgs e)
        {
            this.lineGraph1.Frames = this.Frames;
            lineGraph1.DisplayData();
        }

        private void displayInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new DisplaySeriesSettings()
                {
                    DisplayInfo = this.DisplayInfo
                };

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.DisplayInfo = dialog.DisplayInfo;
                    UpdateDisplay();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDisplay()
        {
            this.Location = new Point(DisplayInfo.X, DisplayInfo.Y);

            lineGraph1.UpdateDisplayInfo(DisplayInfo);
        }
    }
}
