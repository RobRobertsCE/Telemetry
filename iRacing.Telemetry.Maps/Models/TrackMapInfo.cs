using System.Drawing;

namespace iRacing.Telemetry.Maps.Models
{
    public class TrackMapInfo
    {
        #region properties
        public int Id { get; set; }
        public string TrackName { get; set; }
        public string Url { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Zoom { get; set; }
        public Size Size { get; set; }
        public string ImageFile { get; set; }
        #endregion

        public override string ToString()
        {
            return TrackName;
        }
    }
}
