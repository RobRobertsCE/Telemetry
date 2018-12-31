namespace iRacing.Setups.Models
{
    public class Tires : CornerValues<Tire>
    {
        public decimal FrontStagger { get; set; }
        public decimal RearStagger { get; set; }
    }
}
