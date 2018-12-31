using iRacing.TelemetryFile.Ports;
using System.IO;
using System.Threading.Tasks;

namespace iRacing.TelemetryFile.Adapters
{
    internal class IbtFileReader : IIbtFileReader
    {
        public async Task<byte[]> ReadTelemetryDataAsync(string fullPath)
        {
            if (!File.Exists(fullPath))
                throw new FileNotFoundException("Telemetry file not found", fullPath);

            return await Task.Run(() => File.ReadAllBytes(fullPath));
        }
    }
}
