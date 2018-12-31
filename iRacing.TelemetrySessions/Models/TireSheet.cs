namespace iRacing.TelemetrySessions.Models
{
    public class TireSheet
    {
        public TirePressures Pressures { get; set; }
        public TireTemperatures Temperatures { get; set; }
        public TireWear Wear { get; set; }

        public TireSheet()
        {
            Pressures = new TirePressures();
            Temperatures = new TireTemperatures();
            Wear = new TireWear();
        }
    }
}
