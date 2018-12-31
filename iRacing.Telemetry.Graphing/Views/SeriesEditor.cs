using iRacing.Telemetry.Graphing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Graphing.Views
{
    public partial class SeriesEditor : Form
    {
        #region fields
        bool _applyToAxis = true;
        #endregion

        #region properties
        public IList<ILineGraphSeries> Series { get; set; }
        #endregion

        #region ctor / load
        public SeriesEditor()
        {
            InitializeComponent();
        }

        private void SeriesEditor_Load(object sender, EventArgs e)
        {
            try
            {
                DisplaySeries(Series);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region protected
        protected virtual void DisplaySeries(IList<ILineGraphSeries> seriesList)
        {
            if (Series?.Count == 0)
                return;

            lblSeriesName.Text = string.Join(", ", seriesList.Select(s => s.Name));

            var firstSeries = seriesList.FirstOrDefault();

            txtColor.BackColor = firstSeries.Color;
            txtFormat.Text = firstSeries.Format;
            txtUnit.Text = firstSeries.Unit.Trim();

            numLineThickness.Value = (decimal)firstSeries.LineThickness;
            nudMin.Value = firstSeries.Minimum;
            nudMax.Value = firstSeries.Maximum;

            numRangeStart.Value = (decimal)firstSeries.YAxis.RangeStart;
            numRangeEnd.Value = (decimal)firstSeries.YAxis.RangeEnd;
            munPrecision.Value = firstSeries.YAxis.Precision.GetValueOrDefault(0);

            SetCheckBoxState(chkMinWarning, seriesList.Select(s => s.ShowMinimumWarning).ToList());
            numMinWarn.Value = (decimal)firstSeries.MinWarning.GetValueOrDefault(0);

            SetCheckBoxState(chkMaxWarning, seriesList.Select(s => s.ShowMaximumWarning).ToList());
            numMaxWarn.Value = (decimal)firstSeries.MaxWarning.GetValueOrDefault(0);

            numLargeStep.Value = (decimal)firstSeries.YAxis.LargeStep.GetValueOrDefault(100);
            numSmallStep.Value = (decimal)firstSeries.YAxis.SmallStep.GetValueOrDefault(25);

            SetCheckBoxState(chkLapMin, seriesList.Select(s => s.ShowLapMinimum).ToList());
            SetCheckBoxState(chkLapMax, seriesList.Select(s => s.ShowLapMaximum).ToList());
            SetCheckBoxState(chkLapAvg, seriesList.Select(s => s.ShowLapAverage).ToList());

            SetCheckBoxState(chkShowAxis, seriesList.Select(s => s.YAxis.ShowAxis).ToList());
            SetCheckBoxState(chkShowTitle, seriesList.Select(s => s.YAxis.ShowTitle).ToList());

            SetCheckBoxState(chkShowLargeTicks, seriesList.Select(s => s.YAxis.ShowLargeTicks).ToList());
            SetCheckBoxState(chkShowLargeLabels, seriesList.Select(s => s.YAxis.ShowLargeLabels).ToList());

            SetCheckBoxState(chkShowSmallTicks, seriesList.Select(s => s.YAxis.ShowSmallTicks).ToList());
            SetCheckBoxState(chkShowSmallLabels, seriesList.Select(s => s.YAxis.ShowSmallLabels).ToList());
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

        protected virtual bool SaveChanges(IList<ILineGraphSeries> seriesList)
        {
            foreach (var series in seriesList)
            {
                bool? result;

                series.Color = txtColor.BackColor;
                if (_applyToAxis)
                {
                    series.YAxis.AxisColor = series.Color;
                    series.YAxis.LargeLabelColor = series.Color;
                    series.YAxis.SmallLabelColor = series.Color;
                }

                series.Format = txtFormat.Text.Trim();
                if (_applyToAxis)
                {
                    series.YAxis.Format = series.Format;
                }

                series.Unit = txtUnit.Text.Trim();

                series.LineThickness = (float)numLineThickness.Value;
                series.Maximum = (int)nudMax.Value;
                series.Minimum = (int)nudMin.Value;

                series.YAxis.RangeStart = (float)numRangeStart.Value;
                series.YAxis.RangeEnd = (float)numRangeEnd.Value;
                series.YAxis.Precision = (int)munPrecision.Value;

                series.YAxis.LargeStep = (float)numLargeStep.Value;
                series.YAxis.SmallStep = (float)numSmallStep.Value;

                if (chkMinWarning.CheckState == CheckState.Unchecked)
                {
                    series.MinWarning = null;
                }
                if (chkMinWarning.CheckState == CheckState.Checked)
                {
                    series.MinWarning = (float)numMinWarn.Value;
                }

                if (chkMaxWarning.CheckState == CheckState.Unchecked)
                {
                    series.MaxWarning = null;
                }
                if (chkMaxWarning.CheckState == CheckState.Checked)
                {
                    series.MaxWarning = (float)numMaxWarn.Value;
                }

                result = GetValuesState(chkMinWarning);
                seriesList.ToList().ForEach(s => s.ShowMinimumWarning = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkMaxWarning);
                seriesList.ToList().ForEach(s => s.ShowMaximumWarning = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkLapMin);
                seriesList.ToList().ForEach(s => s.ShowLapMinimum = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkLapMax);
                seriesList.ToList().ForEach(s => s.ShowLapMaximum = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkLapAvg);
                seriesList.ToList().ForEach(s => s.ShowLapAverage = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkShowAxis);
                seriesList.ToList().ForEach(s => s.YAxis.ShowAxis = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkShowTitle);
                seriesList.ToList().ForEach(s => s.YAxis.ShowTitle = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkShowLargeTicks);
                seriesList.ToList().ForEach(s => s.YAxis.ShowLargeTicks = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkShowLargeLabels);
                seriesList.ToList().ForEach(s => s.YAxis.ShowLargeLabels = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkShowSmallTicks);
                seriesList.ToList().ForEach(s => s.YAxis.ShowSmallTicks = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);

                result = GetValuesState(chkShowSmallLabels);
                seriesList.ToList().ForEach(s => s.YAxis.ShowSmallLabels = result.HasValue ? result.Value : s.YAxis.ShowSmallTicks);
            }

            return true;
        }
        #endregion

        #region private
        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            try
            {
                txtColor.BackColor = GetNewColor(Series.FirstOrDefault().Color);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void txtColor_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtColor.BackColor = GetNewColor(Series.FirstOrDefault().Color);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private Color GetNewColor(Color currentColor)
        {
            var result = dlgSeriesColor.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                return dlgSeriesColor.Color;
            }
            else
            {
                return currentColor;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveChanges(Series))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        private void chkMinWarning_CheckStateChanged(object sender, EventArgs e)
        {
            numMinWarn.Enabled = (chkMinWarning.CheckState != CheckState.Unchecked);
        }

        private void chkMaxWarning_CheckStateChanged(object sender, EventArgs e)
        {
            numMaxWarn.Enabled = (chkMaxWarning.CheckState != CheckState.Unchecked);
        }

        private void chkShowLargeTicks_CheckStateChanged(object sender, EventArgs e)
        {
            chkShowLargeLabels.Enabled = (chkShowLargeTicks.CheckState != CheckState.Unchecked);
        }

        private void chkShowSmallTicks_CheckStateChanged(object sender, EventArgs e)
        {
            chkShowSmallLabels.Enabled = (chkShowSmallTicks.CheckState != CheckState.Unchecked);
        }
    }
}
