namespace iRacing.Telemetry.Models
{
    public class TelemetrySet
    {
        public WeekendInfo WeekendInfo { get; set; } = new WeekendInfo();
        public SessionInfo SessionInfo { get; set; } = new SessionInfo();
        public CameraInfo CameraInfo { get; set; } = new CameraInfo();
        public RadioInfo RadioInfo { get; set; } = new RadioInfo();
        public DriverInfo DriverInfo { get; set; } = new DriverInfo();
        public SplitTimeInfo SplitTimeInfo { get; set; } = new SplitTimeInfo();
        public CarSetup CarSetup { get; set; } = new CarSetup();
    }
}
