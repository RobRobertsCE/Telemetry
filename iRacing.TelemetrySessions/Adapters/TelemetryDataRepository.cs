using iRacing.TelemetrySessions.Models;
using iRacing.TelemetrySessions.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.TelemetrySessions.Adapters
{
    internal class TelemetryDataRepository : ITelemetryDataRepository
    {
        public Task GetTelemetryDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetTelemetryDataAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveTelemetryDataAsync(TelemetryData data)
        {
            throw new NotImplementedException();
        }
    }
}
