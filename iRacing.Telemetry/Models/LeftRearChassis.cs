namespace iRacing.Telemetry.Models
{
    public class LeftRearChassis
    {
        #region properties
        public int CornerWeight { get; set; }
        public int RideHeight { get; set; }
        public int ShockCollarOffset { get; set; }
        public int SpringRate { get; set; }
        public int BumpStiffness { get; set; }
        public int ReboundStiffness { get; set; }
        #endregion

        #region ctor
        public LeftRearChassis()
        {
        }
        #endregion
    }
}
