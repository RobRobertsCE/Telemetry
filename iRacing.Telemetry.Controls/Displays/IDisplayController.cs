using iRacing.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Displays
{
    public interface IDisplayController : INotifyPropertyChanged
    {
        event EventHandler<ActiveDisplayChangedEventArgs> ActiveDisplayChanged;
        event EventHandler<DisplayAddedEventArgs> DisplayAdded;
        event EventHandler<DisplayRemovedEventArgs> DisplayRemoved;

        Form Owner { get; set; }
        ISessionData Session { get; set; }
        IList<ITelemetryDisplay> Displays { get; set; }

        int? LapNumber { get; set; }
        int? FrameIdx { get; set; }

        int? MinLapNumber { get; }
        int? MaxLapNumber { get; }
        int? MinFrameIdx { get; }
        int? MaxFrameIdx { get; }
        int? MinLapFrameIdx { get; }
        int? MaxLapFrameIdx { get; }

        int? NextLap();
        int? PreviousLap();
        int? FirstLap();
        int? LastLap();
        //int? SetLapNumber(int newLapNumber);
        int? NextFrame();
        int? PreviousFrame();
        int? FirstFrame();
        int? LastFrame();
        //int? SetFrameIdx(int newFrameIdx);

        void ActivateDisplay(ITelemetryDisplay display);
        void AddDisplay(ITelemetryDisplay display);
        void RemoveDisplay(ITelemetryDisplay display);
        void RemoveAllDisplays();
        void ClearAllDisplays();
    }
}