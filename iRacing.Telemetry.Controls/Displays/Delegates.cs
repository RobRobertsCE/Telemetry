using System;

namespace iRacing.Telemetry.Controls.Displays
{
    public delegate void FrameChangedEventHandler(object sender, FrameChangedEventArgs e);
    public class FrameChangedEventArgs : EventArgs
    {
        public int NewFrameIdx { get; set; }

        public FrameChangedEventArgs()
        {

        }

        public FrameChangedEventArgs(int newFrameIdx)
        {
            NewFrameIdx = newFrameIdx;
        }
    }

    public delegate void ActiveDisplayChangedEventHandler(object sender, ActiveDisplayChangedEventArgs e);
    public class ActiveDisplayChangedEventArgs : EventArgs
    {
        public ITelemetryDisplay ActiveDisplay { get; set; }

        public ActiveDisplayChangedEventArgs()
        {

        }

        public ActiveDisplayChangedEventArgs(ITelemetryDisplay activeDisplay)
        {
            ActiveDisplay = activeDisplay;
        }
    }

    public delegate void DisplayAddedEventHandler(object sender, DisplayAddedEventArgs e);
    public class DisplayAddedEventArgs : EventArgs
    {
        public ITelemetryDisplay DisplayAdded { get; set; }

        public DisplayAddedEventArgs()
        {

        }

        public DisplayAddedEventArgs(ITelemetryDisplay displayAdded)
        {
            DisplayAdded = displayAdded;
        }
    }

    public delegate void DisplayRemovedEventHandler(object sender, DisplayRemovedEventArgs e);
    public class DisplayRemovedEventArgs : EventArgs
    {
        public ITelemetryDisplay DisplayRemoved { get; set; }

        public DisplayRemovedEventArgs()
        {

        }

        public DisplayRemovedEventArgs(ITelemetryDisplay displayRemoved)
        {
            DisplayRemoved = displayRemoved;
        }
    }
}
