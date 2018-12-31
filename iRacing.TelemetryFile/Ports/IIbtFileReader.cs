using System.Threading.Tasks;

namespace iRacing.TelemetryFile.Ports
{
    public interface IIbtFileReader
    {
        Task<byte[]> ReadTelemetryDataAsync(string fullPath);
    }
}
