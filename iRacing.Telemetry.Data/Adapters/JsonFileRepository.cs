using iRacing.Common;
using log4net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;

namespace iRacing.Telemetry.Data.Adapters
{
    internal class JsonFileRepository
    {
        #region fields
        protected readonly ILog _logger;
        protected readonly iRacingTelemetryOptions _options;
        protected readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        #endregion

        #region properties
        protected string DataFileName { get; set; }
        #endregion

        #region ctor
        protected JsonFileRepository(
              IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor,
              ILog log)
        {
            _options = (optionsAccessor == null) ? throw new ArgumentNullException(nameof(optionsAccessor)) : optionsAccessor.CurrentValue;
            _logger = (log == null) ? throw new ArgumentNullException(nameof(log)) : log;
        }
        #endregion

        #region protected
        protected virtual void ExceptionHandler(Exception ex)
        {
            ExceptionHandler(ex, $"Exception in {this.GetType().Name}");
        }
        protected virtual void ExceptionHandler(Exception ex, string message)
        {
            _logger.Error(message, ex);
        }

        protected string ReadFromFile(string directory, string fileName)
        {
            var content = String.Empty;
            var fullFilePath = Path.Combine(directory, fileName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                _logger.Info($"Created directory {directory}");
            }
            if (File.Exists(fullFilePath))
            {
                content = File.ReadAllText(fullFilePath);
            }
            else
            {
                _logger.Info($"File did not exist: {fullFilePath}");
            }
            return content;
        }
        protected void WriteToFile(string directory, string fileName, string content)
        {
            var fullFilePath = Path.Combine(directory, fileName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                _logger.Info($"Created directory {directory}");
            }
            if (File.Exists(fullFilePath))
            {
                _logger.Info($"Deleted file prior to save: {fullFilePath}");
                File.Delete(fullFilePath);
            }
            File.WriteAllText(fullFilePath, content);
        }
        #endregion
    }
}
