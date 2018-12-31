using iRacing.Common.Models;
using System;
using System.Drawing;

namespace iRacing.Telemetry.Controls.Displays
{
    public interface ITelemetryDisplay : IDisposable
    {
        event EventHandler CloseDisplayRequest;

        Guid Id { get; }
        DisplayType DisplayType { get; set; }
        Point Location { get; set; }
        Size Size { get; set; }

        void BringToFront();
        bool Focus();
        void ClearDisplay();
        void SessionChanged(ISessionData session);
    }
}
