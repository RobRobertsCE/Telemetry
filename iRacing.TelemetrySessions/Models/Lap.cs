namespace iRacing.TelemetrySessions.Models
{
    public class Lap
    {
        public int Index { get; set; }
        public decimal Time { get; set; }
        public decimal Speed { get; set; }
        public bool IsClean { get; set; }
    }
}
