using iRacing.Telemetry.Controls.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Views
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
            nudMin.Value = (decimal)firstSeries.Minimum;
            nudMax.Value = (decimal)(txtUnit.Text.Trim() == "%" ? 1 : firstSeries.Maximum);

            numRangeStart.Value = (decimal)firstSeries.RangeStart;
            numRangeEnd.Value = (decimal)firstSeries.RangeEnd;
            munPrecision.Value = firstSeries.Precision;

            SetCheckBoxState(chkMinWarning, seriesList.Select(s => s.ShowMinimumWarning).ToList());
            numMinWarn.Value = (decimal)firstSeries.MinWarning;

            SetCheckBoxState(chkMaxWarning, seriesList.Select(s => s.ShowMaximumWarning).ToList());
            numMaxWarn.Value = (decimal)firstSeries.MaxWarning;

            numLargeStep.Value = (decimal)firstSeries.TickStep;

            SetCheckBoxState(chkShowAxis, seriesList.Select(s => s.ShowAxis).ToList());
            SetCheckBoxState(chkShowTitle, seriesList.Select(s => s.ShowTitle).ToList());

            SetCheckBoxState(chkShowLargeTicks, seriesList.Select(s => s.ShowTicks).ToList());
            SetCheckBoxState(chkShowLargeLabels, seriesList.Select(s => s.ShowTickLabels).ToList());

            SetCheckBoxState(chkInvertRange, seriesList.Select(s => s.InvertRange).ToList());

            lblAxisFont.Text = seriesList.FirstOrDefault().Font.ToString();
            lblAxisFont.Tag = seriesList.FirstOrDefault().Font;

            numTopMargin.Value = seriesList.FirstOrDefault().Margins.Top;
            numBottomMargin.Value = seriesList.FirstOrDefault().Margins.Bottom;
            numLeftMargin.Value = seriesList.FirstOrDefault().Margins.Left;
            numRightMargin.Value = seriesList.FirstOrDefault().Margins.Right;
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
                series.Format = txtFormat.Text.Trim();
                series.Unit = txtUnit.Text.Trim();
                series.LineThickness = (float)numLineThickness.Value;

                series.Maximum = (int)nudMax.Value;
                series.Minimum = (int)nudMin.Value;

                series.RangeStart = (float)numRangeStart.Value;
                series.RangeEnd = (float)numRangeEnd.Value;
                series.Precision = (int)munPrecision.Value;

                series.TickStep = (float)numLargeStep.Value;

                if (chkMinWarning.CheckState == CheckState.Unchecked)
                {
                    series.MinWarning = 0;
                }
                if (chkMinWarning.CheckState == CheckState.Checked)
                {
                    series.MinWarning = (float)numMinWarn.Value;
                }

                if (chkMaxWarning.CheckState == CheckState.Unchecked)
                {
                    series.MaxWarning = 0;
                }
                if (chkMaxWarning.CheckState == CheckState.Checked)
                {
                    series.MaxWarning = (float)numMaxWarn.Value;
                }

                result = GetValuesState(chkMinWarning);
                seriesList.ToList().ForEach(s => s.ShowMinimumWarning = result.HasValue ? result.Value : s.ShowMinimumWarning);

                result = GetValuesState(chkMaxWarning);
                seriesList.ToList().ForEach(s => s.ShowMaximumWarning = result.HasValue ? result.Value : s.ShowMaximumWarning);

                result = GetValuesState(chkShowAxis);
                seriesList.ToList().ForEach(s => s.ShowAxis = result.HasValue ? result.Value : s.ShowAxis);

                result = GetValuesState(chkShowTitle);
                seriesList.ToList().ForEach(s => s.ShowTitle = result.HasValue ? result.Value : s.ShowTitle);

                result = GetValuesState(chkShowLargeTicks);
                seriesList.ToList().ForEach(s => s.ShowTicks = result.HasValue ? result.Value : s.ShowTicks);

                result = GetValuesState(chkShowLargeLabels);
                seriesList.ToList().ForEach(s => s.ShowTickLabels = result.HasValue ? result.Value : s.ShowTickLabels);

                result = GetValuesState(chkInvertRange);
                seriesList.ToList().ForEach(s => s.InvertRange = result.HasValue ? result.Value : s.InvertRange);

                seriesList.ToList().ForEach(s => s.Margins.Top = (int)numTopMargin.Value);
                seriesList.ToList().ForEach(s => s.Margins.Bottom = (int)numBottomMargin.Value);
                seriesList.ToList().ForEach(s => s.Margins.Left = (int)numLeftMargin.Value);
                seriesList.ToList().ForEach(s => s.Margins.Right = (int)numRightMargin.Value);

                Font axisFont = (Font)lblAxisFont.Tag;
                seriesList.ToList().ForEach(s => s.Font = axisFont);
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
            dlgSeriesColor.AllowFullOpen = true;
            dlgSeriesColor.AnyColor = true;
            dlgSeriesColor.FullOpen = true;
            dlgSeriesColor.SolidColorOnly = false;

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

        private void btnSetAxisFont_Click(object sender, EventArgs e)
        {
            try
            {
                Font currentFont = (Font)lblAxisFont.Tag;

                Font newFont = SelectFont(currentFont);

                lblAxisFont.Text = newFont.ToString();
                lblAxisFont.Tag = newFont;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        protected virtual Font SelectFont(Font currentFont)
        {
            var dialog = new FontDialog()
            {
                Font = currentFont,
                FontMustExist = true
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                return dialog.Font;
            }
            else
            {
                return currentFont;
            }
        }
        #endregion
    }
}
