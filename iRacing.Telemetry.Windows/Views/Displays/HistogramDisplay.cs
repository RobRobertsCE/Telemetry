using iRacing.Common;
using iRacing.Common.Models;
using iRacing.Telemetry.Controls;
using iRacing.Telemetry.Controls.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace iRacing.Telemetry.Windows.Views.Displays
{
    public partial class HistogramDisplay : MdiChildForm
    {
        #region events
        protected override void ProtectedPropertyChangedHandlerAsync(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                Log.Info($"histogram prop change: {e.PropertyName}");

                switch (e.PropertyName)
                {
                    case nameof(State):
                        {
                            if (State.HasFlag(AppState.SessionLoaded))
                            {
                                UpdateHistogramDisplay();
                            }
                            else
                            {
                                ClearDisplays();
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region fields
        int _maxGroupCount = 0;
        IList<HistogramGraph> _graphs;
        #endregion

        #region properties
        protected int _resolution = HistogramModel.DefaultResolution;
        public int Resolution
        {
            get
            {
                return _resolution;
            }
            set
            {
                _resolution = value;
                lblResolution.Text = _resolution.ToString();

                UpdateHistogramDisplay();
            }
        }
        #endregion

        #region ctor
        public HistogramDisplay()
            : base()
        {
            InitializeComponent();

            FormDisplayInfo.DisplayType = DisplayTypes.Histogram;
        }

        public HistogramDisplay(
            IServiceProvider serviceProvider,
            log4net.ILog log,
            iRacingTelemetryOptions options)
         : base(
            serviceProvider,
            log,
            options,
            DisplayTypes.Histogram)
        {
            InitializeComponent();
        }
        #endregion

        #region protected
        protected override void TelemetryForm_Load(object sender, EventArgs e)
        {
            base.TelemetryForm_Load(sender, e);

            try
            {
                hstLF.Model = new HistogramModel(HistogramCorners.LF, "Left Front Shock Velocity");
                hstRF.Model = new HistogramModel(HistogramCorners.RF, "Right Front Shock Velocity");
                hstLR.Model = new HistogramModel(HistogramCorners.LR, "Left Rear Shock Velocity");
                hstRR.Model = new HistogramModel(HistogramCorners.RR, "Right Rear Shock Velocity");

                _graphs = new List<HistogramGraph>() { hstLF, hstLR, hstRF, hstRR };

                Resolution = HistogramModel.DefaultResolution;

                if (Session != null)
                {
                    UpdateHistogramDisplay();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        protected virtual void UpdateHistogramDisplay()
        {
            if (CurrentLap == null)
                return;

            PopulateTelemetryValues();

            _maxGroupCount = GenerateHistogramMap(Resolution);

            DisplayHistograms(_maxGroupCount);
        }

        protected virtual void ClearDisplays()
        {
            foreach (HistogramGraph graph in _graphs)
            {
                graph.Model.Values.Clear();
            }
        }

        protected virtual void PopulateTelemetryValues()
        {
            ClearDisplays();

            var lfValues = _graphs.FirstOrDefault(g => g.Corner == HistogramCorners.LF).Model.Values;
            var rfValues = _graphs.FirstOrDefault(g => g.Corner == HistogramCorners.RF).Model.Values;
            var lrValues = _graphs.FirstOrDefault(g => g.Corner == HistogramCorners.LR).Model.Values;
            var rrValues = _graphs.FirstOrDefault(g => g.Corner == HistogramCorners.RR).Model.Values;

            foreach (IFrame frame in CurrentLap.LapFrames)
            {
                lfValues.Add(frame.LFshockVel);
                rfValues.Add(frame.RFshockVel);
                lrValues.Add(frame.LRshockVel);
                rrValues.Add(frame.RRshockVel);
            }
        }

        protected int GenerateHistogramMap(int resolution)
        {
            foreach (HistogramGraph graph in _graphs)
            {
                graph.GenerateHistogramMap(resolution);
            }

            return _graphs.Max(g => g.MaxCount);
        }

        protected void DisplayHistograms(int maxGroupCount)
        {
            foreach (HistogramGraph graph in _graphs)
            {
                graph.DisplayMap(maxGroupCount);
            }
        }
        #endregion

        #region private
        private void btnDecreaseResolution_Click(object sender, EventArgs e)
        {
            if (_resolution > 3)
                Resolution -= 1;
        }

        private void btnIncreaseResolution_Click(object sender, EventArgs e)
        {
            if (_resolution < 100)
                Resolution += 1;
        }
        #endregion
    }
}
