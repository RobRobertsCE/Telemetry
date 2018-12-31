using iRacing.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace iRacing.Telemetry.Windows.Models
{
    public class TelemetrySession : ISession
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region constants
        internal const string DefaultSessionName = "<New Session>";
        #endregion

        #region properties
        private string _name = string.Empty;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _fileName;
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        public string Setup { get; set; }
        public string Track { get; set; }
        public string Vehicle { get; set; }
        public int LapCount { get; set; }
        public int FastestLap { get; set; }
        public float FastestLapTime { get; set; }
        public string SessionFileName { get; set; }

        private ISessionData _telemetrySessionData;
        [JsonIgnore()]
        public ISessionData TelemetrySessionData
        {
            get
            {
                return _telemetrySessionData;
            }
            set
            {
                _telemetrySessionData = value;
                ParseTelemetrySessionData(_telemetrySessionData);
                OnPropertyChanged(nameof(TelemetrySessionData));
            }
        }

        [JsonIgnore()]
        internal string State { get; set; }
        [JsonIgnore()]
        public bool HasChanges
        {
            get
            {
                var currentState = Serialize(this);
                return (currentState == State);
            }
        }
        #endregion

        #region ctor
        public TelemetrySession()
        {

        }
        #endregion

        #region public
        public virtual void Save()
        {
            SaveAs(FileName);
        }
        public virtual void SaveAs(string fileName)
        {
            FileName = fileName;
            if (Name == DefaultSessionName)
            {
                Name = Path.GetFileNameWithoutExtension(fileName);
            }
            var json = Serialize(this);
            File.WriteAllText(fileName, json);
        }
        #endregion

        #region protected
        protected void ParseTelemetrySessionData(ISessionData session)
        {
            if (session == null)
            {
                Setup = String.Empty;
                Track = String.Empty;
                Vehicle = String.Empty;
                LapCount = -1;
                FastestLap = -1;
                FastestLapTime = -1;
            }
            else
            {
                var driverCarIdx = GetDriverCarIdx(session);

                Setup = GetSetupName(session);
                Track = GetTrackName(session);
                Vehicle = GetVehicleInfo(session, driverCarIdx);
                LapCount = TelemetrySessionData.Laps.Count;
                FastestLap = GetFastestLap(session, driverCarIdx);
                FastestLapTime = GetFastestLapTime(session, driverCarIdx);
            }
        }

        #region parse session info
        protected virtual int GetDriverCarIdx(ISessionData session)
        {
            return Int32.Parse(session.SessionInfo.driverInfo["DriverCarIdx"].ToString());
        }
        protected virtual string GetTrackInfo(ISessionData session)
        {
            var trackName = GetTrackName(session);
            var trackLength = session.SessionInfo.weekendInfo["TrackLength"].ToString();
            var trackType = session.SessionInfo.weekendInfo["TrackType"].ToString();
            var sessions = (IList<object>)session.SessionInfo.sessionInfo["Sessions"];
            var currentSession = (IDictionary<object, object>)sessions.LastOrDefault();
            var trackState = GetTrackState(session);
            return $"{trackName}\r\n{trackLength}\r\n{trackType}\r\n{trackState}";
        }
        protected virtual string GetTrackName(ISessionData session)
        {
            return session.SessionInfo.weekendInfo["TrackDisplayName"].ToString();
        }
        protected virtual string GetTrackState(ISessionData session)
        {
            var currentSession = GetCurrentSession(session);
            return currentSession["SessionTrackRubberState"].ToString();
        }
        protected virtual string GetWeather(ISessionData session)
        {
            return session.SessionInfo.weekendInfo["TrackSkies"].ToString();
        }
        protected virtual string GetAirTemp(ISessionData session)
        {
            return session.SessionInfo.weekendInfo["TrackAirTemp"].ToString();
        }
        protected virtual string GetTrackTemp(ISessionData session)
        {
            return session.SessionInfo.weekendInfo["TrackSurfaceTemp"].ToString();
        }
        protected virtual string GetTimeOfDay(ISessionData session)
        {
            var weekendOptions = (IDictionary<object, object>)session.SessionInfo.weekendInfo["WeekendOptions"];
            return weekendOptions["TimeOfDay"].ToString();
        }
        protected virtual IDictionary<object, object> GetCurrentSession(ISessionData session)
        {
            var sessions = (IList<object>)session.SessionInfo.sessionInfo["Sessions"];
            return (IDictionary<object, object>)sessions.LastOrDefault();
        }
        protected virtual string GetLapInfo(ISessionData session, int driverCarIdx)
        {
            string lapCount = "";
            string fastestLapNumber = "";
            string fastestLapTime = "";

            var sessions = (IList<object>)session.SessionInfo.sessionInfo["Sessions"];
            var currentSession = (IDictionary<object, object>)sessions.LastOrDefault();

            var sessionResults = (IList<object>)currentSession["ResultsPositions"];
            if (sessionResults == null)
            {
                return "0";
            }
            else
            {
                foreach (IDictionary<object, object> result in sessionResults)
                {
                    if (result["CarIdx"].ToString() == driverCarIdx.ToString())
                    {
                        lapCount = result["Lap"].ToString();
                        fastestLapNumber = result["FastestLap"].ToString();
                        fastestLapTime = result["FastestTime"].ToString();
                    }
                }

                return $"{lapCount}   Best Lap: {fastestLapNumber} [{fastestLapTime}]";
            }
        }
        protected virtual int GetFastestLap(ISessionData session, int driverCarIdx)
        {
            int fastestLapNumber = -1;
            string fastestLapTime = "";

            var sessions = (IList<object>)session.SessionInfo.sessionInfo["Sessions"];
            var currentSession = (IDictionary<object, object>)sessions.LastOrDefault();

            var sessionResults = (IList<object>)currentSession["ResultsPositions"];
            if (sessionResults == null)
            {
                return -1;
            }
            else
            {
                foreach (IDictionary<object, object> result in sessionResults)
                {
                    if (result["CarIdx"].ToString() == driverCarIdx.ToString())
                    {
                        fastestLapNumber = int.Parse(result["FastestLap"].ToString());
                    }
                }

                return fastestLapNumber;
            }
        }
        protected virtual float GetFastestLapTime(ISessionData session, int driverCarIdx)
        {
            float fastestLapTime = 0F;

            var sessions = (IList<object>)session.SessionInfo.sessionInfo["Sessions"];
            var currentSession = (IDictionary<object, object>)sessions.LastOrDefault();

            var sessionResults = (IList<object>)currentSession["ResultsPositions"];
            if (sessionResults == null)
            {
                return -1;
            }
            else
            {
                foreach (IDictionary<object, object> result in sessionResults)
                {
                    if (result["CarIdx"].ToString() == driverCarIdx.ToString())
                    {
                        fastestLapTime = float.Parse(result["FastestTime"].ToString());
                    }
                }

                return fastestLapTime;
            }
        }
        protected virtual string GetCurrentSessionInfo(ISessionData session)
        {
            var currentSession = GetCurrentSession(session);
            var sessionName = currentSession["SessionName"].ToString();
            return sessionName;
        }
        protected virtual IDictionary<object, object> GetDriver(ISessionData session, int driverCarIdx)
        {
            var driversList = (IList<object>)session.SessionInfo.driverInfo["Drivers"];
            var driver = (IDictionary<object, object>)driversList[driverCarIdx];
            return driver;
        }
        protected virtual string GetVehicleInfo(ISessionData session, int driverCarIdx)
        {
            var driver = GetDriver(session, driverCarIdx);
            var vehicle = driver["CarScreenName"].ToString();
            return vehicle;
        }
        protected virtual string GetDriverInfo(ISessionData session, int driverCarIdx)
        {
            var driver = GetDriver(session, driverCarIdx);
            var userName = driver["UserName"].ToString();
            return userName;
        }
        protected virtual string GetSetupName(ISessionData session)
        {
            var setupName = session.SessionInfo.driverInfo["DriverSetupName"].ToString();
            bool isModified = ("1" == session.SessionInfo.driverInfo["DriverSetupIsModified"].ToString());
            if (isModified)
            {
                var setupSection = session.SetupInfo;
                var modifiedCount = setupSection.updateCount;
                return $"{setupName} [{modifiedCount}]";
            }
            else
            {
                return setupName;
            }
        }
        #endregion
        #endregion

        #region internal
        internal static string Serialize(ISession session)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            return JsonConvert.SerializeObject(session, settings);
        }
        #endregion
    }
}
