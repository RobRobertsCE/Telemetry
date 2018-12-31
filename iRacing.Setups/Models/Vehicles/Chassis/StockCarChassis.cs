using iRacing.Setups.Models;

namespace iRacing.Setups.Vehicles.Chassis
{
    public class StockCarChassis : SetupBase
    {
        public int BallastForward { get; set; }
        public Alignment Alignment { get; set; }
        public RideHeights RideHeights { get; set; }
        public Weights Weights { get; set; }
        public Springs Springs { get; set; }
        public Shocks Shocks { get; set; }
        public Tires Tires { get; set; }
        public int SteeringRatio { get; set; }
        public int SteeringOffset { get; set; }
        public decimal BrakeBalance { get; set; }
        public AttachableSwayBar SwayBar { get; set; }
        public TrackBar TrackBar { get; set; }
        public decimal Tape { get; set; }
        public decimal RearGear { get; set; }
        public decimal Fuel { get; set; }
    }
}
