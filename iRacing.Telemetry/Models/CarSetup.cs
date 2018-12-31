namespace iRacing.Telemetry.Models
{
    public class CarSetup
    {
        #region properties
        public int UpdateCount { get; set; }
        public Tires Tires { get; set; } = new Tires();
        public Chassis Chassis { get; set; } = new Chassis();
        #endregion

        #region ctor
        public CarSetup()
        {
        }
        #endregion
    }
}

