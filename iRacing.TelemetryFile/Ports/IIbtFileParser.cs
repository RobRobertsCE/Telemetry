using iRacing.Common.Models;
using System.Threading.Tasks;

namespace iRacing.TelemetryFile.Ports
{
    public interface IIbtFileParser
    {
        Task<IbtTelemetryFile> ParseTelemetryFileAsync(string fullPath, IbtParseOptions options);
    }
}
