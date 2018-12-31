using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using iRacing.Telemetry.Controls.Models;

namespace iRacing.Telemetry.Controls.Views
{
    public partial class MarginsEditor : Form
    {
        #region properties
        public IList<ILineGraphSeries> Series { get; set; }
        #endregion

        #region ctor/load

        public MarginsEditor()
        {
            InitializeComponent();
        }

        private void MarginsEditor_Load(object sender, EventArgs e)
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

        #region private
        protected virtual void DisplaySeries(IList<ILineGraphSeries> seriesList)
        {
            if (Series?.Count == 0)
                return;

            lblSeriesName.Text = string.Join(", ", seriesList.Select(s => s.Name));

            var firstSeries = seriesList.FirstOrDefault();

            numTopMargin.Value = firstSeries.Margins.Top;
            numBottomMargin.Value = firstSeries.Margins.Bottom;
            numLeftMargin.Value = firstSeries.Margins.Left;
            numRightMargin.Value = firstSeries.Margins.Right;
        }

        protected virtual bool SaveChanges(IList<ILineGraphSeries> seriesList)
        {
            foreach (var series in seriesList)
            {
                seriesList.ToList().ForEach(s => s.Margins.Top = (int)numTopMargin.Value);
                seriesList.ToList().ForEach(s => s.Margins.Bottom = (int)numBottomMargin.Value);
                seriesList.ToList().ForEach(s => s.Margins.Left = (int)numLeftMargin.Value);
                seriesList.ToList().ForEach(s => s.Margins.Right = (int)numRightMargin.Value);
            }

            return true;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region private
        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }
        #endregion
    }
}
