using iRacing.Telemetry.Windows.Models;
using iRacing.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using iRacing.Common;

namespace iRacing.Telemetry.Windows.Views.Displays
{
    public partial class LapTimesDisplay : MdiChildForm
    {
        #region events
        protected override void ProtectedPropertyChangedHandlerAsync(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(CurrentLapNumber):
                    {
                        SetSelectedLap(CurrentLapNumber);
                        break;
                    }
                case nameof(Laps):
                    {
                        DisplayLaps(Laps);
                        break;
                    }
                case "Session":
                    {
                        DisplayLaps(Laps);
                        break;
                    }
            }
        }
        #endregion

        #region fields
        private bool _suppressUpdate = false;
        #endregion

        #region ctor/load
        public LapTimesDisplay()
            : base()
        {
            InitializeComponent();

            FormDisplayInfo.DisplayType = DisplayTypes.LapTimes;
        }

        public LapTimesDisplay(
            IServiceProvider serviceProvider,
            log4net.ILog log,
            iRacingTelemetryOptions options)
          : base(
            serviceProvider,
            log,
            options,
            DisplayTypes.LapTimes)
        {
            InitializeComponent();
        }
        protected override void TelemetryForm_Load(object sender, EventArgs e)
        {
            base.TelemetryForm_Load(sender, e);

            //DisplayLaps(Laps);
        }
        #endregion

        #region protected      
        protected virtual void SessionChanged(ISession session)
        {
            Laps = session?.TelemetrySessionData?.Laps;
        }

        protected virtual void DisplayLaps(IList<ILapInfo> laps)
        {
            try
            {
                lvLapTimes.SuspendLayout();

                ClearLapsDisplay();

                if (Laps == null || Laps.Count == 0)
                    return;

                var fastestLap = laps.Where(l => l.LapTime > -1).OrderBy(l => l.LapTime).FirstOrDefault();

                foreach (ILapInfo lap in laps)
                {
                    var lvi = new ListViewItem(lap.LapIndex.ToString());
                    lvi.SubItems.Add(lap.LapNumber.ToString());
                    lvi.SubItems.Add(lap.LapTime.ToString());
                    lvi.SubItems.Add(lap.LapSpeed.ToString());
                    lvi.Tag = lap;

                    if (fastestLap != null && lap.LapNumber == fastestLap.LapNumber)
                    {
                        lvi.BackColor = Color.LimeGreen;
                    }

                    lvLapTimes.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                lvLapTimes.ResumeLayout();
            }
        }

        protected virtual void ClearLapsDisplay()
        {
            lvLapTimes.Items.Clear();
        }
        #endregion

        private void lvLapTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressUpdate)
                return;

            if (lvLapTimes.SelectedItems.Count > 0)
            {
                ILapInfo selectedLap = (ILapInfo)lvLapTimes.SelectedItems[0].Tag;
                OnLapNumberChangeRequest(selectedLap.LapNumber);
            }
        }

        private void SetSelectedLap(int lapNumber)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => { SetSelectedLap(lapNumber); }));
            }
            else
            {
                _suppressUpdate = true;
                foreach (ListViewItem item in lvLapTimes.Items)
                {
                    ILapInfo lapInfo = (ILapInfo)item.Tag;
                    item.Selected = (lapInfo.LapNumber == lapNumber);
                }
                _suppressUpdate = false;
            }
        }
    }
}
