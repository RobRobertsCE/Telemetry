namespace iRacing.Telemetry.Models
{
    public class WeekendOptions
    {
        #region properties
        public int NumStarters { get; set; }
        public bool StandingStart { get; set; }
        //public enum StartingGrid { get; set; } single file
        //public enum QualifyScoring { get; set; } best lap
        //public enum CourseCautions { get; set; } off
        //public enum Restarts { get; set; } single file
        //public enum WeatherType { get; set; } Specified / Dynamic Sky
        //public enum Skies { get; set; } Partly Cloudy
        //public enum WindDirection { get; set; } N
        public string StartingGrid { get; set; } 
        public string QualifyScoring { get; set; }
        public string CourseCautions { get; set; }
        public string Restarts { get; set; }
        public string WeatherType { get; set; }
        public string Skies { get; set; }
        public string WindDirection { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal WeatherTemp { get; set; }
        public decimal RelativeHumidity { get; set; }
        public int FogLevel { get; set; }
        // TODO: public enum TimeOfDay { get; set; } variable
        public string TimeOfDay { get; set; }
        public bool Unofficial { get; set; }
        //public enum CommercialMode { get; set; } consumer
        //public enum NightMode { get; set; } variable
        public string CommercialMode { get; set; }
        public string NightMode { get; set; }
        public bool IsFixedSetup { get; set; }
        // TODO: public enum StrictLapsChecking { get; set; } default
        public string StrictLapsChecking { get; set; }
        public bool HasOpenRegistration { get; set; }
        public int HardcoreLevel { get; set; }
        public int NumJokerLaps { get; set; }
        // TODO: public enum IncidentLimit { get; set; } unlimited
        public string IncidentLimit { get; set; }
        #endregion

        #region ctor
        public WeekendOptions()
        {
        }
        #endregion
    }
}

