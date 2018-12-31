using System.Collections.Generic;

namespace iRacing.Telemetry.Models
{
    public class Session
    {
        #region properties
        public int SessionNum { get; set; }
        public string SessionLaps { get; set; }
        // TODO: public enum SessionLaps { get; set; } unlimited
        public string SessionTime { get; set; }
        // TODO: public enum SessionTime { get; set; } unlimited
        public int SessionNumLapsToAvg { get; set; }
        // TODO: public enum SessionType { get; set; } Offline Testing
        // TODO: public enum SessionTrackRubberState { get; set; } moderate usage
        // TODO: public enum SessionName { get; set; } TESTING
        public string SessionType { get; set; }
        public string SessionTrackRubberState { get; set; }
        public string SessionName { get; set; }
        public string SessionSubType { get; set; }
        public bool SessionSkipped { get; set; }
        public int SessionRunGroupsUsed { get; set; }
        public IList<ResultsPosition> ResultsPositions { get; set; } = new List<ResultsPosition>();
        public IList<ResultsFastestLap> ResultsFastestLap { get; set; } = new List<ResultsFastestLap>();
        public decimal ResultsAverageLapTime { get; set; }
        public int ResultsNumCautionFlags { get; set; }
        public int ResultsNumCautionLaps { get; set; }
        public int ResultsNumLeadChanges { get; set; }
        public int ResultsLapsComplete { get; set; }
        public bool ResultsOfficial { get; set; }
        #endregion

        #region ctor
        public Session()
        {
        }
        #endregion
    }
}

