using System;

namespace iRacing.Telemetry.Windows.Models
{
    internal class LapView
    {
        public int Index { get; set; }
        public int LapNumber { get; set; }
        public float LapTime { get; set; }
        public bool IsFastest { get; set; }

        string _displayTitle = String.Empty;
        public string DisplayTitle
        {
            get
            {
                if (String.IsNullOrEmpty(_displayTitle))
                {
                    var isFastestToken = IsFastest ? "*" : "";
                    _displayTitle = $"{LapNumber,5}{isFastestToken,3} {LapTime}";
                }
                return _displayTitle;
            }
            set
            {
                _displayTitle = value;
            }
        }
    }
}
