using iRacing.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.TelemetrySessions.Models
{
    public class TelemetrySession
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid UserId { get; set; }
        public Guid TrackId { get; set; }
        public Guid CarClassId { get; set; }
        public SessionType SessionType { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public SurfaceType Surface { get; set; }
        public IList<SessionRun> Runs { get; set; }
        public Lap BestLap
        {
            get
            {
                var bestLap = Runs.Select(r => new { r.Id, r.BestLap }).OrderBy(l => l.BestLap).FirstOrDefault();
                return bestLap.BestLap;
            }
        }
    }
}
