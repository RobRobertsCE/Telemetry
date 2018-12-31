namespace iRacing.Telemetry.Models
{
    public class ResultsFastestLap
    {
        #region properties
        public int CarIdx { get; set; }
        public int FastestLap { get; set; }
        public decimal FastestTime { get; set; }
        #endregion

        #region ctor
        public ResultsFastestLap()
        {
        }
        #endregion
    }
}

