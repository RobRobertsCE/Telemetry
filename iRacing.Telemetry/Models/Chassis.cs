namespace iRacing.Telemetry.Models
{
    public class Chassis
    {
        #region properties
        public FrontChassis Front { get; set; } = new FrontChassis();
        public LeftFrontChassis LeftFront { get; set; } = new LeftFrontChassis();
        public LeftRearChassis LeftRear { get; set; } = new LeftRearChassis();
        public RightFrontChassis RightFront { get; set; } = new RightFrontChassis();
        public RightRearChassis RightRear { get; set; } = new RightRearChassis();
        public RearChassis Rear { get; set; } = new RearChassis();
        #endregion

        #region ctor
        public Chassis()
        {
        }
        #endregion
    }
}

