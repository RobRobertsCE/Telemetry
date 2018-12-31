using iRacing.Telemetry.Graphing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Graphing.Views
{
    public partial class GroupingEditor : Form
    {
        #region properties
        public IList<ILineGraphSeries> Series { get; set; }
        #endregion

        #region ctor / load
        public GroupingEditor()
        {
            InitializeComponent();
        }
        
        private void GroupingEditor_Load(object sender, EventArgs e)
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

            numRangeStart.Value = (decimal)firstSeries.YAxis.RangeStart;
            numRangeEnd.Value = (decimal)firstSeries.YAxis.RangeEnd;
        }
        protected virtual bool SaveChanges(IList<ILineGraphSeries> seriesList)
        {
            foreach (var series in seriesList)
            {
                series.YAxis.RangeStart = (float)numRangeStart.Value;
                series.YAxis.RangeEnd = (float)numRangeEnd.Value;
            }

            return true;
        }
        #endregion

        #region private [event handlers]
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

        #region private
        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }
        #endregion
    }
}
