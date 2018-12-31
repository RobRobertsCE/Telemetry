using System;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Models
{
    public interface IMdiChildForm : ITelemetryForm, IDisposable
    {
        // events send requests to controller
        event EventHandler CloseWindowRequest;
        event FormClosingEventHandler FormClosing;

        bool IsLoading { get; set; }

        void BeforeSave();
        void CloseWindow();
    }
}
