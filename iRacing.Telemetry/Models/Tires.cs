namespace iRacing.Telemetry.Models
{
    public class Tires
    {
        #region properties
        public LeftFrontTire LeftFront { get; set; } = new LeftFrontTire();
        public LeftRearTire LeftRear { get; set; } = new LeftRearTire();
        public RightFrontTire RightFront { get; set; } = new RightFrontTire();
        public RightRearTire RightRear { get; set; } = new RightRearTire();
        #endregion

        #region ctor
        public Tires()
        {
        }
        #endregion
    }
}

