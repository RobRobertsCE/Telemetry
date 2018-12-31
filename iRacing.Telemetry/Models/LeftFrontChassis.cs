namespace iRacing.Telemetry.Models
{
    public class LeftFrontChassis
    {
        #region properties
        public int CornerWeight { get; set; }
        public int RideHeight { get; set; }
        public int ShockCollarOffset { get; set; }
        public int SpringRate { get; set; }
        public int BumpStiffness { get; set; }
        public int ReboundStiffness { get; set; }
        public decimal Camber { get; set; }
        public decimal Caster { get; set; }
        #endregion

        #region ctor
        public LeftFrontChassis()
        {
        }
        #endregion
    }
}

