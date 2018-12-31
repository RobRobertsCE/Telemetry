using iRacing.Telemetry.Maps.Models;
using System.Collections.Generic;

namespace iRacing.Telemetry.Maps.Internal.Models
{
    internal class LapSegment
    {
        public string Header { get; set; }
        public IList<Coordinate> Points { get; set; } = new List<Coordinate>();
        public string EncodedToken { get; set; }
    }
}
