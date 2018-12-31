namespace iRacing.Telemetry.Models
{
    public class FrontChassis
    {
        #region properties
        public decimal BallastForward { get; set; }
        public decimal NoseWeight { get; set; }
        public decimal CrossWeight { get; set; }
        public int ToeIn { get; set; }
        // 12:1
        public string SteeringRatio { get; set; }
        public int SteeringOffset { get; set; }
        public int FrontBrakeBias { get; set; }
        public int SwayBarSize { get; set; }
        public int SwayBarArmLength { get; set; }
        public int LeftBarEndClearance { get; set; }
        public bool AttachLeftSide { get; set; }
        #endregion

        #region ctor
        public FrontChassis()
        {
        }
        #endregion
    }
}
