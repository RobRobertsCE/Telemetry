using iRacing.Common.Models;

namespace iRacing.Telemetry.Data.Models
{
    public class TelemetryFunction : IFunction
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
    }
}
