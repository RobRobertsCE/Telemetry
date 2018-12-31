using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacing.TelemetrySessions.Models
{
    public class SessionRun
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid SetupId { get; set; }
        public TireSheet TireSheet { get; set; }
        public IList<Lap> Laps { get; set; }
        public Lap BestLap
        {
            get
            {
                return Laps.OrderBy(l => l.Time).FirstOrDefault();
            }
        }

        public SessionRun()
        {
            Laps = new List<Lap>();
        }
    }
}
