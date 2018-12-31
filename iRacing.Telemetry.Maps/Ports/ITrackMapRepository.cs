using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using iRacing.Telemetry.Maps.Models;

namespace iRacing.Telemetry.Maps.Ports
{
    public interface ITrackMapRepository
    {
        bool HasChanges { get; }
        string GetTrackMapImageFileName(TrackMapInfo trackMapInfo);
        Task<IList<TrackMapInfo>> GetTrackMapInfosAsync();
        Task<bool> DeleteTrackMapImageAsync(int id);
        Task<bool> DeleteTrackMapInfoAsync(int id);
        Task<bool> DiscardChangesAsync();
        Task<Image> GetTrackMapImageAsync(int id);
        Task<Image> GetTrackMapImageAsync(string trackName);
        Task<TrackMapInfo> GetTrackMapInfoAsync(int id);
        Task<TrackMapInfo> GetTrackMapInfoAsync(string trackName);
        Task<bool> SaveChangesAsync();
        Task<bool> SaveTrackMapImageAsync(Image trackImage, int id);
        Task<TrackMapInfo> SaveTrackMapInfoAsync(TrackMapInfo trackMapInfo);
    }
}