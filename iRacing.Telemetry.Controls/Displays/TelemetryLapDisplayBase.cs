using iRacing.Common.Models;
using System.Collections.Generic;

namespace iRacing.Telemetry.Controls.Displays
{
    public partial class TelemetryLapDisplayBase : DisplayBase, ITelemetryLapDisplay
    {
        #region properties
        public LapTimesDisplayInfo DisplayInfo { get; set; }

        private int? _lapNumber = null;
        public int? LapNumber
        {
            get
            {
                return _lapNumber;
            }
            private set
            {
                _lapNumber = value;
                OnPropertyChanged(nameof(LapNumber));
                DisplaySelectedLapIndicator();
            }
        }

        private IList<ILapInfo> _laps;
        public IList<ILapInfo> Laps
        {
            get
            {
                return _laps;
            }
            set
            {
                _laps = value;
                OnPropertyChanged(nameof(Laps));
                DisplayLaps();
            }
        }
        #endregion

        #region ctor
        public TelemetryLapDisplayBase(IList<ILapInfo> laps)
            : this()
        {
            Laps = laps;
        }

        public TelemetryLapDisplayBase()
            : base()
        {
            InitializeComponent();
            DisplayType = DisplayType.LapTimes;
        }
        #endregion

        #region public
        public void SetLapNumber(int? lapNumber)
        {
            _lapNumber = lapNumber;
            DisplaySelectedLapIndicator();
        }
        #endregion

        #region protected
        protected virtual void DisplayLaps()
        {
            ClearLapsDisplay();

            if (Laps == null || Laps.Count == 0)
                return;

            DisplaySelectedLapIndicator();
        }

        // Display the frame index vertical line
        protected virtual void DisplaySelectedLapIndicator()
        {

        }

        protected virtual void ClearLapsDisplay()
        {

        }
        #endregion
    }
}
