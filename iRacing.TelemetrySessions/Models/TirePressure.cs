namespace iRacing.TelemetrySessions.Models
{
    public class TirePressure
    {
        public decimal ColdPressure { get; set; }
        public decimal LastHotPressure { get; set; }
        public decimal Delta { get { return LastHotPressure - ColdPressure; } }
    }
}
