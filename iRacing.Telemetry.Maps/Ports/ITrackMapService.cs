using iRacing.Telemetry.Maps.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Maps.Ports
{
    public interface ITrackMapService
    {
        Image GetImageFromBytes(byte[] byteArray);
        string GetMapUri(float latitude, float longitude, int zoom);
        Task<byte[]> GetMapAsync(float latitude, float longitude);
        Task<byte[]> GetMapAsync(float latitude, float longitude, IList<TrackCoordinate> trackCoordinates);
        Task<byte[]> GetMapAsync(float latitude, float longitude, int zoom);
        Task<byte[]> GetMapAsync(float latitude, float longitude, int zoom, IList<TrackCoordinate> trackCoordinates);
        Task<byte[]> GetMapAsync(float latitude, float longitude, int zoom, int scale);
        Task<byte[]> GetMapAsync(float latitude, float longitude, int zoom, int scale, int width, int height);
    }
}
