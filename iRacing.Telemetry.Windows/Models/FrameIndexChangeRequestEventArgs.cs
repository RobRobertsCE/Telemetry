using System;

namespace iRacing.Telemetry.Windows.Models
{
    public class FrameIndexChangeRequestEventArgs : EventArgs
    {
        public int FrameIndex { get; set; }

        public FrameIndexChangeRequestEventArgs()
        {

        }
        public FrameIndexChangeRequestEventArgs(int frameIndex)
        {
            FrameIndex = frameIndex;
        }
    }
}
