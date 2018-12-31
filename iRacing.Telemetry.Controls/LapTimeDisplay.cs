using iRacing.Telemetry.Controls.Displays;
using iRacing.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.Telemetry.Controls
{
    public partial class LapTimeDisplay : TelemetryLapDisplayBase
    {
        #region fields
        private IList<LapTimeView> _lapTimeViews = new List<LapTimeView>();
        #endregion

        #region ctor
        public LapTimeDisplay()
        {
            InitializeComponent();
        }
        #endregion

        #region public
        public override void ClearDisplay()
        {
            ClearLapsDisplay();
        }
        #endregion

        #region protected
        protected override void DisplayLaps()
        {
            try
            {
                lstLapTimes.SuspendLayout();

                ClearLapsDisplay();

                if (Laps == null || Laps.Count == 0)
                    return;

                _lapTimeViews = new List<LapTimeView>();

                foreach (ILapInfo lap in Laps)
                {
                    _lapTimeViews.Add(new LapTimeView() { Lap = lap });
                }

                lstLapTimes.DisplayMember = "DisplayText";
                lstLapTimes.DataSource = _lapTimeViews;

                DisplaySelectedLapIndicator();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                lstLapTimes.ResumeLayout();
            }
        }

        // Display the frame index vertical line
        protected override void DisplaySelectedLapIndicator()
        {
            lstLapTimes.SelectedItems.Clear();
            if (LapNumber.HasValue)
            {
                var selectedLap = _lapTimeViews.FirstOrDefault(l => l.Lap.LapNumber == LapNumber);
                if (selectedLap != null)
                    lstLapTimes.SelectedIndex = selectedLap.Lap.LapIndex;
            }
        }

        protected override void ClearLapsDisplay()
        {
            lstLapTimes.DataSource = null;
            lstLapTimes.Items.Clear();
        }
        #endregion

        #region private
        private void LapTimeDisplay_Load(object sender, EventArgs e)
        {
            ClearLapsDisplay();
        }
        #endregion

        #region private classes
        private class LapTimeView
        {
            public ILapInfo Lap { get; set; }
            public string DisplayText
            {
                get { return $"{Lap.LapNumber} {Lap.LapTime}"; }
            }
        }
        #endregion
    }
}
