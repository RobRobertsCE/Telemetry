using iRacing.TelemetrySessions.Models;
using System;
using System.Threading.Tasks;

namespace iRacing.TelemetrySessions.Ports
{
    public interface ITelemetryDataRepository
    {
        Task GetTelemetryDataAsync();
        Task GetTelemetryDataAsync(Guid id);
        Task SaveTelemetryDataAsync(TelemetryData data);
    }
}
