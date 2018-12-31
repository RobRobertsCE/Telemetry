namespace iRacing.Telemetry.Maps.Models
{
    public class TrackCoordinate : Coordinate
    {
        /// <summary>
        /// Throttle telemetry value
        /// </summary>
        /// <remarks>Should be between 0 and 1</remarks>
        public float Throttle { get; set; }
        /// <summary>
        /// Brake telemetry value
        /// </summary>
        /// <remarks>Should be between 0 and 1</remarks>
        public float Brake { get; set; }
    }
}
