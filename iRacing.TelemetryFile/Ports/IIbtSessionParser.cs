using iRacing.Common.Models;
using System.Threading.Tasks;

namespace iRacing.TelemetryFile.Ports
{
    public interface IIbtSessionParser
    {
        Task<ISessionData> ParseTelemetrySessionAsync(byte[] telemetryBytes);
        Task<ISessionData> ParseTelemetrySessionAsync(byte[] telemetryBytes, IbtParseOptions options);
    }
}