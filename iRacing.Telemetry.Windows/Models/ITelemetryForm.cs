using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using iRacing.Common;
using iRacing.Common.Models;
using log4net;
using Microsoft.Extensions.Logging;

namespace iRacing.Telemetry.Windows.Models
{
    public interface ITelemetryForm
    {
        string Text { get; set; }
        Point Location { get; set; }
        Size Size { get; set; }
        FormWindowState WindowState { get; set; }
        Form MdiParent { get; set; }
        int CurrentFrameIndex { get; set; }
        ILapInfo CurrentLap { get; set; }
        int CurrentLapIndex { get; set; }
        int CurrentLapNumber { get; set; }
        IList<IFieldDefinition> FieldDefinitions { get; set; }
        IList<IFieldDisplayInfo> FieldDisplayInfos { get; set; }
        IFormDisplayInfo FormDisplayInfo { get; set; }
        IList<ILapInfo> Laps { get; set; }
        ILog Log { get; set; }
        iRacingTelemetryOptions Options { get; set; }
        IServiceProvider ServiceProvider { get; set; }
        ISession Session { get; set; }
        AppState State { get; set; }
        IWin32Window WindowHandle { get; set; }

        event EventHandler<FrameIndexChangeRequestEventArgs> FrameIndexChangeRequest;
        event EventHandler<LapNumberChangeRequestEventArgs> LapNumberChangeRequest;
        event PropertyChangedEventHandler PropertyChanged;

        void Show();
    }
}