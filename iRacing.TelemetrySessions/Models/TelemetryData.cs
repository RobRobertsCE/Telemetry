using System;

namespace iRacing.TelemetrySessions.Models
{
    public class TelemetryData
    {
        public Guid Id { get; set; }
        public byte[] Data { get; set; }
    }
}
