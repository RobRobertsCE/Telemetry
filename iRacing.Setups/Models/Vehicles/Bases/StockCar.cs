using iRacing.Setups.Models.Base;

namespace iRacing.Setups.Models.Vehicles.Bases
{
    public class StockCar : Chassis
    {

        protected StockCar()
        {
            Tires = new Tires();
            Weights = new Weights();
        }
    }
}
