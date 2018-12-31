namespace iRacing.Common
{
    public class iRacingTelemetryOptions
    {
        #region properties
        public bool IsDebug { get; set; } = false;
        public string TelemetryDirectory { get; set; } = @"C:\Users\rroberts\Documents\iRacing\telemetry";
        public string AppDirectory { get; set; } = @"C:\Users\rroberts\Telemetry\iRacingTelemetry";
        public string FunctionsDirectory { get; set; } = @"C:\Users\rroberts\Telemetry\iRacingTelemetry\Functions";
        public string ProjectsDirectory { get; set; } = @"C:\Users\rroberts\Telemetry\iRacingTelemetry\Projects";
        public string TracksDirectory { get; set; } = @"C:\Users\rroberts\Telemetry\iRacingTelemetry\Tracks";
        public string DisplaysDirectory { get; set; } = @"C:\Users\rroberts\Telemetry\iRacingTelemetry\Displays";

        public string FieldDisplaysFileName { get; set; } = "DefaultDisplayInfo.json";
        public string FieldDefinitionsFileName { get; set; } = "FieldDefinitions.json";
        public string TelemetryFunctionsFileName { get; set; } = "Functions.json";
        public string UserDefinedFunctionsFileName { get; set; } = "UserDefinedFunctions.json";

        #endregion

        #region ctor
        public iRacingTelemetryOptions()
        {

        }
        #endregion
    }
}
