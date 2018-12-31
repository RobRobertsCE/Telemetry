namespace iRacing.Telemetry.Models
{
    public class WeekendInfo
    {
        #region properties
        public string TrackName { get; set; }
        public int TrackID { get; set; }
        public decimal TrackLength { get; set; }
        public string TrackDisplayName { get; set; }
        public string TrackDisplayShortName { get; set; }
        public string TrackConfigName { get; set; }
        public string TrackCity { get; set; }
        public string TrackCountry { get; set; }
        public decimal TrackAltitude { get; set; }
        public decimal TrackLatitude { get; set; }
        public decimal TrackLongitude { get; set; }
        public decimal TrackNorthOffset { get; set; }
        public int TrackNumTurns { get; set; }
        public decimal TrackPitSpeedLimit { get; set; }
        /* TODO:
         *  
        public enum TrackType { get; set; }
        public enum TrackDirection { get; set; }
        public enum TrackWeatherType { get; set; }
        public enum TrackSkies { get; set; }
         */
        public string TrackType { get; set; }
        public string TrackDirection { get; set; }
        public string TrackWeatherType { get; set; }
        public string TrackSkies { get; set; }
        public decimal TrackSurfaceTemp { get; set; }
        public decimal TrackAirTemp { get; set; }
        public decimal TrackAirPressure { get; set; }
        public decimal TrackWindVel { get; set; }
        public decimal TrackWindDir { get; set; }
        public int TrackRelativeHumidity { get; set; }
        public int TrackFogLevel { get; set; }
        public bool TrackCleanup { get; set; }
        public bool TrackDynamicTrack { get; set; }
        public int SeriesID { get; set; }
        public int SeasonID { get; set; }
        public int SessionID { get; set; }
        public int SubSessionID { get; set; }
        public int LeagueID { get; set; }
        public bool Official { get; set; }
        public int RaceWeek { get; set; }
        // TODO: 
        //public enum EventType { get; set; }
        //public enum Category { get; set; }
        //public enum SimMode { get; set; }
        public string EventType { get; set; }
        public string Category { get; set; }
        public string SimMode { get; set; }
        public bool TeamRacing { get; set; }
        public int MinDrivers { get; set; }
        public int MaxDrivers { get; set; }
        // TODO: public enum DCRuleSet { get; set; }
        public string DCRuleSet { get; set; }
        public string QualifierMustStartRace { get; set; }
        public int NumCarClasses { get; set; }
        public int NumCarTypes { get; set; }
        public bool HeatRacing { get; set; }
        public WeekendOptions WeekendOptions { get; set; } = new WeekendOptions();
        #endregion

        #region ctor
        public WeekendInfo()
        {
        }
        #endregion
    }
}

