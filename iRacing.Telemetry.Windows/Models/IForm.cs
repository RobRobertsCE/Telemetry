using iRacing.Common.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Models
{
    public interface IForm
    {
        event EventHandler<LapNumberChangeRequestEventArgs> LapNumberChangeRequest;
        event EventHandler<FrameIndexChangeRequestEventArgs> FrameIndexChangeRequest;

        IServiceProvider ServiceProvider { get; set; }

        // Window state
        IWin32Window WindowHandle { get; set; }
        string Text { get; set; }
        Point Location { get; set; }
        Size Size { get; set; }
        FormWindowState WindowState { get; set; }
        Form MdiParent { get; set; }
        IFormDisplayInfo FormDisplayInfo { get; set; }

        // controller sets these properties
        AppState State { get; set; }
        int CurrentLapNumber { get; set; }
        int CurrentFrameIndex { get; set; }
        ILapInfo CurrentLap { get; set; }


        ISession Session { get; set; }

        IList<ILapInfo> Laps { get; set; }
        IList<IFieldDefinition> FieldDefinitions { get; set; }
        IList<IFieldDisplayInfo> FieldDisplayInfos { get; set; }




        void Show();
    }
}
