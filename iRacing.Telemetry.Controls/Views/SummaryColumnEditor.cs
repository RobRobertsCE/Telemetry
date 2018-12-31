using iRacing.Telemetry.Controls.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Views
{
    public partial class SummaryColumnEditor : Form
    {
        #region fields
        private IList<CheckBox> _checkBoxes;
        private bool _maunalUpdate = false;
        private bool _maunalUpdateAll = false;
        #endregion

        #region properties
        public IList<ILineGraphSeries> SeriesList { get; set; }
        #endregion

        #region ctor
        public SummaryColumnEditor()
        {
            InitializeComponent();

            _checkBoxes = new List<CheckBox>()
            {
                chkLapMin,
                chkLapMax,
                chkLapDelta,
                chkLapMode,
                chkLapAvg,
                chkLapStdDev,
                chkSessionMin,
                chkSessionDelta,
                chkSessionMode,
                chkSessionMax,
                chkSessionAvg,
                chkSessionStdDev
            };
        }
        #endregion

        #region private
        private void SummaryColumnEditor_Load(object sender, EventArgs e)
        {
            if (SeriesList != null)
            {
                lblSeriesName.Text = string.Join(", ", SeriesList.Select(s => s.Name));

                _maunalUpdate = true;
                _maunalUpdateAll = true;

                SetCheckBoxState(chkLapMin, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.LapMin)).ToList());
                SetCheckBoxState(chkLapMax, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.LapMax)).ToList());
                SetCheckBoxState(chkLapDelta, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.LapDelta)).ToList());
                SetCheckBoxState(chkLapMode, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.LapMode)).ToList());
                SetCheckBoxState(chkLapAvg, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.LapAvg)).ToList());
                SetCheckBoxState(chkLapStdDev, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.LapStdDev)).ToList());

                SetCheckBoxState(chkSessionMin, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.SessionMin)).ToList());
                SetCheckBoxState(chkSessionMax, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.SessionMax)).ToList());
                SetCheckBoxState(chkSessionDelta, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.SessionDelta)).ToList());
                SetCheckBoxState(chkSessionMode, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.SessionMode)).ToList());
                SetCheckBoxState(chkSessionAvg, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.SessionAvg)).ToList());
                SetCheckBoxState(chkSessionStdDev, SeriesList.Select(s => s.SummaryColumnFlags.HasFlag(SummaryColumnFlags.SessionStdDev)).ToList());

                _maunalUpdate = false;
                _maunalUpdateAll = false;

                UpdateAllCheckboxState();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_maunalUpdate) return;

            if (chkAll.CheckState != CheckState.Indeterminate)
            {
                _maunalUpdateAll = true;

                _checkBoxes.ToList().ForEach(c => c.Checked = chkAll.Checked);

                _maunalUpdateAll = false;
            }
        }

        private void UpdateAllCheckboxState()
        {
            if (_maunalUpdateAll) return;

            _maunalUpdate = true;

            if (_checkBoxes.All(c => c.Checked))
            {
                chkAll.CheckState = CheckState.Checked;
            }
            else if (_checkBoxes.All(c => !c.Checked))
            {
                chkAll.CheckState = CheckState.Unchecked;
            }
            else
            {
                chkAll.CheckState = CheckState.Indeterminate;
            }

            _maunalUpdate = false;
        }

        private void chkSummaryColumn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAllCheckboxState();
        }

        private void SetCheckBoxState(CheckBox control, IList<bool> values)
        {
            if (values.Distinct().Count() > 1)
            {
                control.CheckState = CheckState.Indeterminate;
            }
            else if (values.All(s => s == true))
            {
                control.CheckState = CheckState.Checked;
            }
            else if (values.All(s => s == false))
            {
                control.CheckState = CheckState.Unchecked;
            }
        }

        private bool? GetValuesState(CheckBox control)
        {
            bool? result = null;

            if (control.CheckState == CheckState.Checked)
            {
                result = true;
            }
            else if (control.CheckState == CheckState.Indeterminate)
            {
                // do nothing
            }
            else if (control.CheckState == CheckState.Unchecked)
            {
                result = false;
            }

            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveChanges(SeriesList))
                DialogResult = DialogResult.OK;
        }

        protected virtual bool SaveChanges(IList<ILineGraphSeries> seriesList)
        {
            foreach (var series in seriesList)
            {
                bool? result;

                result = GetValuesState(chkLapMin);
                if (result.HasValue)
                {
                    if (result.Value==true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.LapMin;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.LapMin;
                }
                result = GetValuesState(chkLapMax);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.LapMax;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.LapMax;
                }
                result = GetValuesState(chkLapDelta);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.LapDelta;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.LapDelta;
                }
                result = GetValuesState(chkLapMode);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.LapMode;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.LapMode;
                }
                result = GetValuesState(chkLapAvg);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.LapAvg;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.LapAvg;
                }
                result = GetValuesState(chkLapStdDev);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.LapStdDev;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.LapStdDev;
                }

                result = GetValuesState(chkSessionMin);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.SessionMin;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.SessionMin;
                }
                result = GetValuesState(chkSessionMax);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.SessionMax;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.SessionMax;
                }
                result = GetValuesState(chkSessionDelta);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.SessionDelta;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.SessionDelta;
                }
                result = GetValuesState(chkSessionMode);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.SessionMode;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.SessionMode;
                }
                result = GetValuesState(chkSessionAvg);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.SessionAvg;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.SessionAvg;
                }
                result = GetValuesState(chkSessionStdDev);
                if (result.HasValue)
                {
                    if (result.Value == true)
                        series.SummaryColumnFlags |= SummaryColumnFlags.SessionStdDev;
                    else
                        series.SummaryColumnFlags &= ~SummaryColumnFlags.SessionStdDev;
                }
            }

            return true;
        }
        #endregion

    }
}
