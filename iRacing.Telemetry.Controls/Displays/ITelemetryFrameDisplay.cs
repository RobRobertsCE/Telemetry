using iRacing.Common.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace iRacing.Telemetry.Controls.Displays
{
    public interface ITelemetryFrameDisplay : ITelemetryDisplay, INotifyPropertyChanged
    {
        LineGraphDisplayInfo DisplayInfo { get; set; }
        IList<IFrame> Frames { get; set; }
        IFieldDefinition Field { get; set; }
        int? FrameIdx { get; }
        void SetFrameIdx(int? frameIdx);
    }
}
