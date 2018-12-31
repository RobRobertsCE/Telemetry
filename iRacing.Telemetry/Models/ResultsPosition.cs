namespace iRacing.Telemetry.Models
{
    public class ResultsPosition
    {
        #region properties
        public int Position { get; set; }
        public int ClassPosition { get; set; }
        public int CarIdx { get; set; }
        public int Lap { get; set; }
        public decimal Time { get; set; }
        public int FastestLap { get; set; }
        public decimal FastestTime { get; set; }
        public decimal LastTime { get; set; }
        public int LapsLed { get; set; }
        public int LapsComplete { get; set; }
        public int JokerLapsComplete { get; set; }
        public decimal LapsDriven { get; set; }
        public int Incidents { get; set; }
        public int ReasonOutId { get; set; }
        public string ReasonOutStr { get; set; }
        // TODO: public enum ReasonOutStr { get; set; } Running
        #endregion

        #region ctor
        public ResultsPosition()
        {
        }
        #endregion
    }
}

