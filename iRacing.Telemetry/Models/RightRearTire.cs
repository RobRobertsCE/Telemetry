namespace iRacing.Telemetry.Models
{
    public class RightRearTire
    {
        #region properties
        public int ColdPressure { get; set; }
        public int LastHotPressure { get; set; }
        public int[] LastTempsIMO { get; set; }
        public int[] TreadRemaining { get; set; }
        #endregion

        #region ctor
        public RightRearTire()
        {
        }
        #endregion
    }
}
