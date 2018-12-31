using iRacing.Common;
using iRacing.Telemetry.Maps.Internal;
using iRacing.Telemetry.Maps.Internal.Models;
using iRacing.Telemetry.Maps.Models;
using iRacing.Telemetry.Maps.Ports;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Maps.Adapters
{
    public class GoogleTrackMapService : ITrackMapService
    {
        #region fields
        private GoogleMapType _googleMapType = GoogleMapType.Satellite;
        private GoogleImageFormat _googleImageFormat = GoogleImageFormat.PNG32;
        private int _googleMapZoom = 18;
        private int _googleMapScale = 1;
        private int _googleMapSizeX = 640;
        private int _googleMapSizeY = 640;
        private int _resolutionModifierStep = 1; // 1 = all, 2 = every other, 3 = every 3rd, etc.
        private int _maxResolutionModifierStep = 8;
        protected readonly ILogger<GoogleTrackMapService> _logger;
        protected readonly iRacingTelemetryOptions _options;
        protected readonly IImageHelper _imageHelper;
        #endregion

        #region ctor
        public GoogleTrackMapService(
                IImageHelper imageHelper,
                IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor,
                ILoggerFactory loggerFactory)
        {
            _imageHelper = (imageHelper == null) ? throw new ArgumentNullException(nameof(imageHelper)) : imageHelper;
            _options = (optionsAccessor == null) ? throw new ArgumentNullException(nameof(optionsAccessor)) : optionsAccessor.CurrentValue;
            var localLoggerFactory = (loggerFactory == null) ? throw new ArgumentNullException(nameof(loggerFactory)) : loggerFactory;
            localLoggerFactory.AddConsole((category, logLevel) => logLevel >= LogLevel.Trace);
            _logger = localLoggerFactory.CreateLogger<GoogleTrackMapService>();
        }
        #endregion

        #region public
        public Image GetImageFromBytes(byte[] byteArray)
        {
            return _imageHelper.GetImageFromByteArray(byteArray);
        }
        public string GetMapUri(float latitude, float longitude, int zoom)
        {
            return string.Format(
                       "https://maps.googleapis.com/maps/api/staticmap?center={0}&zoom={1}&size={2}&maptype={3}&format={4}&key={5}",
                       $"{latitude},{longitude}",
                       zoom,
                       "640x640",
                       GoogleMapHelper.GetGoogleMapTypeString(GoogleMapType.Satellite),
                       GoogleMapHelper.GetGoogleFormatString(GoogleImageFormat.PNG32),
                       GoogleMapHelper.ApiKey);
        }
        public string GetMapUri(float latitude, float longitude, int zoom, int scale, int width, int height, GoogleMapType mapType, GoogleImageFormat format)
        {
            return GetMapUri(latitude, longitude, zoom, scale, width, height, mapType, format, null);
        }
        public string GetMapUri(float latitude, float longitude, int zoom, int scale, int width, int height, GoogleMapType mapType, GoogleImageFormat format, IList<TrackCoordinate> trackCoordinates)
        {
            var requestUri = string.Empty;

            for (int i = _resolutionModifierStep; i <= _maxResolutionModifierStep; i++)
            {
                if (i > _resolutionModifierStep)
                {
                    _logger.LogTrace($"Attempting to build Track Map requestUri at resolution of {i}");
                }
                string pathParameter = BuildMapPath(trackCoordinates, i);

                requestUri = string.Format(
                   "https://maps.googleapis.com/maps/api/staticmap?center={0}&zoom={1}&size={2}&maptype={3}&format={4}{5}&key={6}",
                   $"{latitude},{longitude}",
                   zoom,
                   $"{width}x{height}",
                   GoogleMapHelper.GetGoogleMapTypeString(mapType),
                   GoogleMapHelper.GetGoogleFormatString(format),
                   pathParameter,
                   GoogleMapHelper.ApiKey);

                if (requestUri.Length < 8192)
                {
                    break;
                }
                else if (requestUri.Length > 8192 && i >= _maxResolutionModifierStep)
                {
                    throw new InvalidOperationException($"requestUri too long: {requestUri.Length}");
                }
            }

            return requestUri;
        }
        public async Task<byte[]> GetMapAsync(float latitude, float longitude)
        {
            return await GetMapAsync(latitude, longitude, _googleMapZoom, _googleMapScale, _googleMapSizeX, _googleMapSizeY, _googleMapType, _googleImageFormat, null);
        }
        public async Task<byte[]> GetMapAsync(float latitude, float longitude, IList<TrackCoordinate> trackCoordinates)
        {
            return await GetMapAsync(latitude, longitude, _googleMapZoom, _googleMapScale, _googleMapSizeX, _googleMapSizeY, _googleMapType, _googleImageFormat, trackCoordinates);
        }
        public async Task<byte[]> GetMapAsync(float latitude, float longitude, int zoom)
        {
            return await GetMapAsync(latitude, longitude, zoom, _googleMapScale, _googleMapSizeX, _googleMapSizeY, _googleMapType, _googleImageFormat, null);
        }
        public async Task<byte[]> GetMapAsync(float latitude, float longitude, int zoom, IList<TrackCoordinate> trackCoordinates)
        {
            return await GetMapAsync(latitude, longitude, zoom, _googleMapScale, _googleMapSizeX, _googleMapSizeY, _googleMapType, _googleImageFormat, trackCoordinates);
        }
        public async Task<byte[]> GetMapAsync(float latitude, float longitude, int zoom, int scale)
        {
            return await GetMapAsync(latitude, longitude, zoom, scale, _googleMapSizeX, _googleMapSizeY, _googleMapType, _googleImageFormat, null);
        }
        public async Task<byte[]> GetMapAsync(float latitude, float longitude, int zoom, int scale, int width, int height)
        {
            return await GetMapAsync(latitude, longitude, zoom, scale, width, height, _googleMapType, _googleImageFormat, null);
        }
        public async Task<byte[]> GetMapAsync(float latitude, float longitude, int zoom, int scale, int width, int height, GoogleMapType mapType, GoogleImageFormat format, IList<TrackCoordinate> trackCoordinates)
        {
            byte[] bitmap = null;

            try
            {
                var requestUri = string.Empty;

                for (int i = _resolutionModifierStep; i <= _maxResolutionModifierStep; i++)
                {
                    if (i > _resolutionModifierStep)
                    {
                        _logger.LogTrace($"Attempting to build Track Map requestUri at resolution of {i}");
                    }
                    string pathParameter = BuildMapPath(trackCoordinates, i);

                    requestUri = string.Format(
                      "https://maps.googleapis.com/maps/api/staticmap?&scale=1center={0}&zoom={1}&size={2}&maptype={3}&format={4}&key={5}{6}",
                      $"{latitude},{longitude}",
                      zoom,
                      $"{width}x{height}",
                      GoogleMapHelper.GetGoogleMapTypeString(mapType),
                      GoogleMapHelper.GetGoogleFormatString(format),
                      GoogleMapHelper.ApiKey,
                      pathParameter);

                    if (requestUri.Length < 8192)
                    {
                        break;
                    }
                    else if (requestUri.Length > 8192 && i >= _maxResolutionModifierStep)
                    {
                        throw new InvalidOperationException($"requestUri too long: {requestUri.Length}");
                    }
                }
                _logger.LogTrace($"Google Maps requestUri: {requestUri}");

                using (WebClient wc = new WebClient())
                {
                    bitmap = await wc.DownloadDataTaskAsync(new Uri(requestUri));
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetMapAsync");
                throw;
            }

            return bitmap;
        }
        #endregion

        #region protected
        protected virtual string BuildMapPath(IList<TrackCoordinate> trackCoordinates)
        {
            return BuildMapPath(trackCoordinates, _resolutionModifierStep);
        }
        protected virtual string BuildMapPath(IList<TrackCoordinate> trackCoordinates, int resolution)
        {
            string pathParameter = String.Empty;

            if (trackCoordinates != null && trackCoordinates.Count > 0)
            {
                LapSegment lapSegment = null;
                IList<LapSegment> lapSegments = new List<LapSegment>();

                string throttlePathHeader = "&path=color:green|weight:2";
                string brakePathHeader = "&path=color:red|weight:2";
                string coastPathHeader = "&path=color:yellow|weight:2";
                string currentState = "";

                var firsttrackCoordinate = trackCoordinates.FirstOrDefault();
                lapSegment = new LapSegment();

                if (firsttrackCoordinate.Throttle > 0 && firsttrackCoordinate.Throttle > firsttrackCoordinate.Brake)
                {
                    currentState = "Throttle";
                    lapSegment.Header = throttlePathHeader;
                }
                else if (firsttrackCoordinate.Brake > 0 && firsttrackCoordinate.Brake > firsttrackCoordinate.Throttle)
                {
                    currentState = "Brake";
                    lapSegment.Header = brakePathHeader;
                }
                else
                {
                    currentState = "Coast";
                    lapSegment.Header = coastPathHeader;
                }

                foreach (TrackCoordinate trackCoordinate in trackCoordinates.Where((x, i) => i % resolution == 0))
                {
                    lapSegment.Points.Add(trackCoordinate);

                    if (trackCoordinate.Throttle > 0 && trackCoordinate.Throttle > trackCoordinate.Brake)
                    {
                        if (currentState != "Throttle")
                        {
                            lapSegment.EncodedToken = GoogleMapHelper.EncodeCoordinates(lapSegment.Points);
                            lapSegments.Add(lapSegment);
                            lapSegment = new LapSegment() { Header = throttlePathHeader };
                            lapSegment.Points.Add(trackCoordinate);
                            currentState = "Throttle";
                        }
                    }
                    else if (trackCoordinate.Brake > 0 && trackCoordinate.Brake > trackCoordinate.Throttle)
                    {
                        if (currentState != "Brake")
                        {
                            lapSegment.EncodedToken = GoogleMapHelper.EncodeCoordinates(lapSegment.Points);
                            lapSegments.Add(lapSegment);
                            lapSegment = new LapSegment() { Header = brakePathHeader };
                            lapSegment.Points.Add(trackCoordinate);
                            currentState = "Brake";
                        }
                    }
                    else
                    {
                        if (currentState != "Coast")
                        {
                            lapSegment.EncodedToken = GoogleMapHelper.EncodeCoordinates(lapSegment.Points);
                            lapSegments.Add(lapSegment);
                            lapSegment = new LapSegment() { Header = coastPathHeader };
                            lapSegment.Points.Add(trackCoordinate);
                            currentState = "Coast";
                        }
                    }
                }
                // add the last segment
                lapSegment.EncodedToken = GoogleMapHelper.EncodeCoordinates(lapSegment.Points);
                lapSegments.Add(lapSegment);

                StringBuilder sb = new StringBuilder();

                foreach (LapSegment encodedLapSegment in lapSegments)
                {
                    sb.Append(encodedLapSegment.Header);
                    sb.Append("|enc:");
                    sb.Append(encodedLapSegment.EncodedToken);
                }

                pathParameter = sb.ToString();
            }

            return pathParameter;
        }
        #endregion
    }
}
