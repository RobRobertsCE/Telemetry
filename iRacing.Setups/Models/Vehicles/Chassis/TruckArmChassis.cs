using iRacing.Setups.Models;

namespace iRacing.Setups.Vehicles.Chassis
{
    public class TruckArmChassis : StockCarChassis
    {
        public TruckArmMountPositions LeftMountPosition { get; set; }
        public TruckArmMountPositions RightMountPosition { get; set; }
        public decimal Preload { get; set; }
    }
}
