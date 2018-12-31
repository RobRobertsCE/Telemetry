using System;

namespace iRacing.Telemetry.Windows
{
    [Flags()]
    public enum AppState
    {
        Loading = 0x01,
        Ready = 0x02,
        ProjectLoaded = 0x04,
        SessionLoaded = 0x08
    }
}
