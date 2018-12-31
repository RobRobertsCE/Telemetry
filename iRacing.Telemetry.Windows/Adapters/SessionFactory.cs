using iRacing.Telemetry.Windows.Models;
using iRacing.Telemetry.Windows.Ports;
using iRacing.TelemetryFile;
using iRacing.TelemetryFile.Ports;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Windows.Adapters
{
    internal class SessionFactory : ISessionFactory
    {
        #region fields
        private IIbtFileParser _telemetryFileParser;
        private IIbtSessionParser _telemetrySessionParser;
        private IIbtFileReader _telemetryFileReader;
        #endregion

        #region ctor
        public SessionFactory(
            IIbtFileParser telemetryFileParser,
            IIbtSessionParser telemetrySessionParser,
            IIbtFileReader telemetryFileReader)
        {
            _telemetryFileParser = (telemetryFileParser == null) ? throw new ArgumentNullException(nameof(telemetryFileParser)) : telemetryFileParser;
            _telemetrySessionParser = (telemetrySessionParser == null) ? throw new ArgumentNullException(nameof(telemetrySessionParser)) : telemetrySessionParser;
            _telemetryFileReader = (telemetryFileReader == null) ? throw new ArgumentNullException(nameof(telemetryFileReader)) : telemetryFileReader;
        }
        #endregion

        #region public
        public async Task<ISession> LoadSavedSessionAsync(string jsonFileName)
        {
            var json = File.ReadAllText(jsonFileName);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var session = JsonConvert.DeserializeObject<TelemetrySession>(json, settings);
            session.FileName = jsonFileName;
            session.State = TelemetrySession.Serialize(session);

            if (!String.IsNullOrEmpty(session.SessionFileName))
            {
                var telemetry = await _telemetryFileParser.ParseTelemetryFileAsync(session.SessionFileName, IbtParseOptions.All);
                session.TelemetrySessionData = telemetry.SessionData;
            }

            return session;
        }

        public async Task<ISession> LoadAtlasTelemetryAsync(string telemetryFileName)
        {
            var telemetry = await _telemetryFileParser.ParseTelemetryFileAsync(telemetryFileName, IbtParseOptions.All);

            ISession session = new TelemetrySession()
            {
                FileName = String.Empty,
                SessionFileName = telemetryFileName,
                Name = Path.GetFileNameWithoutExtension(telemetry.FileName),
                TelemetrySessionData = telemetry.SessionData
            };

            return session;
        }

        public async Task<ISession> LoadAtlasTelemetryAsync(byte[] telemetryBytes)
        {
            ISession session = new TelemetrySession()
            {
                TelemetrySessionData = await _telemetrySessionParser.ParseTelemetrySessionAsync(telemetryBytes)
            };

            return session;
        }
        #endregion
    }
}
