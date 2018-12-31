using iRacing.Telemetry.Windows.Models;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Windows.Ports
{
    public interface ISessionFactory
    {
        Task<ISession> LoadSavedSessionAsync(string jsonFileName);
        Task<ISession> LoadAtlasTelemetryAsync(string telemetryFileName);
        Task<ISession> LoadAtlasTelemetryAsync(byte[] telemetryBytes);
    }
}
