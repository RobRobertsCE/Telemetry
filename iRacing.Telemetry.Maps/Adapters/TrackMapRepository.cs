using iRacing.Common;
using iRacing.Telemetry.Maps.Internal;
using iRacing.Telemetry.Maps.Internal.Models;
using iRacing.Telemetry.Maps.Models;
using iRacing.Telemetry.Maps.Ports;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Maps.Adapters
{
    internal class TrackMapRepository : JsonFileRepository, ITrackMapRepository
    {
        #region fields
        private readonly IImageHelper _imageHelper;
        #endregion

        #region properties 
        private IList<TrackMapInfo> _trackMapInfos;
        protected IList<TrackMapInfo> TrackMapInfos
        {
            get
            {
                if (_trackMapInfos == null)
                {
                    _trackMapInfos = LoadFromFile();
                }
                return _trackMapInfos;
            }
            set
            {
                _trackMapInfos = value;
            }
        }

        public bool HasChanges
        {
            get
            {
                var currentState = Serialize(TrackMapInfos);

                return (State != currentState);
            }
        }
        protected string State { get; set; }
        #endregion

        #region ctor
        public TrackMapRepository(
                IImageHelper imageHelper,
                IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor,
                ILoggerFactory loggerFactory)
            : base(optionsAccessor, loggerFactory)
        {
            _imageHelper = (imageHelper == null) ? throw new ArgumentNullException(nameof(imageHelper)) : imageHelper;
            DataFileName = "TrackMapInfo.json";
        }
        #endregion

        #region public
        public async Task<IList<TrackMapInfo>> GetTrackMapInfosAsync()
        {
            return await Task.Run(() => GetTrackMapInfos());
        }
        public async Task<TrackMapInfo> GetTrackMapInfoAsync(string trackName)
        {
            return await Task.Run(() => GetTrackMapInfo(trackName));
        }
        public async Task<TrackMapInfo> GetTrackMapInfoAsync(int id)
        {
            return await Task.Run(() => GetTrackMapInfo(id));
        }

        public async Task<Image> GetTrackMapImageAsync(string trackName)
        {
            return await Task.Run(() => GetTrackMapImage(trackName));
        }
        public async Task<Image> GetTrackMapImageAsync(int id)
        {
            return await Task.Run(() => GetTrackMapImage(id));
        }

        public async Task<TrackMapInfo> SaveTrackMapInfoAsync(TrackMapInfo trackMapInfo)
        {
            return await Task.Run(() => SaveTrackMapInfo(trackMapInfo));
        }
        public async Task<bool> SaveTrackMapImageAsync(Image trackImage, int id)
        {
            return await Task.Run(() => SaveTrackMapImage(trackImage, id, ImageFormat.Png));
        }

        public async Task<bool> DeleteTrackMapInfoAsync(int id)
        {
            return await Task.Run(() => DeleteTrackMapInfo(id));
        }
        public async Task<bool> DeleteTrackMapImageAsync(int id)
        {
            return await Task.Run(() => DeleteTrackMapImage(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await Task.Run(() =>
            {
                return SaveToFile(TrackMapInfos);
            });
        }

        public async Task<bool> DiscardChangesAsync()
        {
            return await Task.Run(() =>
            {
                _trackMapInfos = null;
                State = String.Empty;
                return true;
            });
        }
        #endregion

        #region protected
        protected virtual IList<TrackMapInfo> GetTrackMapInfos()
        {
            return TrackMapInfos.ToList();
        }
        protected virtual TrackMapInfo GetTrackMapInfo(string trackName)
        {
            return TrackMapInfos.FirstOrDefault(t => t.TrackName == trackName);
        }
        protected virtual TrackMapInfo GetTrackMapInfo(int id)
        {
            return TrackMapInfos.FirstOrDefault(t => t.Id == id);
        }

        protected virtual Image GetTrackMapImage(string trackName)
        {
            Image trackImage = null;

            var existing = GetTrackMapInfo(trackName);

            if (existing != null)
            {
                trackImage = LoadImageFromFile(existing.ImageFile);
            }

            return trackImage;
        }
        protected virtual Image GetTrackMapImage(int id)
        {
            Image trackImage = null;

            var existing = GetTrackMapInfo(id);

            if (existing != null)
            {
                trackImage = LoadImageFromFile(existing.ImageFile);
            }

            return trackImage;
        }

        protected virtual TrackMapInfo SaveTrackMapInfo(TrackMapInfo trackMapInfo)
        {
            var existing = GetTrackMapInfo(trackMapInfo.Id);

            if (existing != null)
            {
                DeleteTrackMapInfo(existing);
            }
            else
            {
                if (trackMapInfo.Id <= 0)
                    trackMapInfo.Id = GetNextId();
            }

            TrackMapInfos.Add(trackMapInfo);

            return trackMapInfo;
        }
        protected virtual bool SaveTrackMapImage(Image trackMapImage, int id, ImageFormat format)
        {
            var existing = GetTrackMapInfo(id);

            if (existing != null)
            {
                var fileName = GetTrackMapImageFileName(existing);

                if (_imageHelper.SaveImageToFile(trackMapImage, fileName, format))
                {
                    existing.ImageFile = fileName;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        protected virtual bool DeleteTrackMapInfo(int id)
        {
            var existing = GetTrackMapInfo(id);

            if (existing != null)
            {
                DeleteTrackMapInfo(existing);
            }

            return true;
        }
        protected virtual bool DeleteTrackMapInfo(TrackMapInfo trackMapInfo)
        {
            TrackMapInfos.Remove(trackMapInfo);

            return true;
        }

        protected virtual bool DeleteTrackMapImage(int id)
        {
            var existing = GetTrackMapInfo(id);

            if (existing != null)
            {
                return DeleteTrackMapImage(existing.ImageFile);
            }
            else
                return false;
        }
        protected virtual bool DeleteTrackMapImage(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                return false;

            if (File.Exists(fileName))
                File.Delete(fileName);

            return true;
        }

        protected virtual int GetNextId()
        {
            if (TrackMapInfos.Count == 0)
                return 1;
            else
                return TrackMapInfos.Max(t => t.Id) + 1;
        }
        public string GetTrackMapImageFileName(TrackMapInfo trackMapInfo)
        {
            return Path.Combine(_options.TracksDirectory, $"{trackMapInfo.Id}-{trackMapInfo.TrackName}.png");
        }

        protected virtual Image LoadImageFromFile(string fileName)
        {
            return _imageHelper.LoadImageFromFile(fileName);
        }

        protected virtual IList<TrackMapInfo> LoadFromFile()
        {
            IList<TrackMapInfo> trackMapInfos = new List<TrackMapInfo>();

            var json = ReadFromFile(_options.TracksDirectory, DataFileName);

            if (!String.IsNullOrEmpty(json))
            {
                trackMapInfos = Deserialize(json);
                State = json;
            }

            return trackMapInfos;
        }
        protected virtual bool SaveToFile(IList<TrackMapInfo> trackMapInfos)
        {
            var json = Serialize(trackMapInfos);
            WriteToFile(_options.TracksDirectory, DataFileName, json);
            State = json;
            return true;
        }

        protected virtual string Serialize(IList<TrackMapInfo> trackMapInfos)
        {
            return JsonConvert.SerializeObject(trackMapInfos, _jsonSerializerSettings);
        }
        protected virtual IList<TrackMapInfo> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<IList<TrackMapInfo>>(json, _jsonSerializerSettings);
        }
        #endregion
    }
}
