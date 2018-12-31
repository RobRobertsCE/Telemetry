namespace iRacing.Telemetry.Models
{
    public class RightFrontTire
    {
        #region properties
        public int ColdPressure { get; set; }
        public int LastHotPressure { get; set; }
        public int[] LastTempsIMO { get; set; }
        public int[] TreadRemaining { get; set; }
        public int Stagger { get; set; }
        #endregion

        #region ctor
        public RightFrontTire()
        {
        }
        #endregion
    }
}
