using iRacing.Telemetry.Windows.Ports;
using System;

namespace iRacing.Telemetry.Windows.Models
{
    public interface IMdiParentForm : ITelemetryForm
    {
        event EventHandler<NewChildWindowRequestEventArgs> NewChildWindowRequest;
        event EventHandler<CloseWindowRequestEventArgs> CloseChildWindowRequest;

        IViewController Controller { get; set; }
    }
}
