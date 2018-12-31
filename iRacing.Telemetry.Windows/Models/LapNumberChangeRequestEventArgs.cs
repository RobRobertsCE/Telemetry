using System;

namespace iRacing.Telemetry.Windows.Models
{
    public class LapNumberChangeRequestEventArgs : EventArgs
    {
        public int LapNumber { get; set; }

        public LapNumberChangeRequestEventArgs()
        {

        }
        public LapNumberChangeRequestEventArgs(int lapNumber)
        {
            LapNumber = lapNumber;
        }
    }
}
