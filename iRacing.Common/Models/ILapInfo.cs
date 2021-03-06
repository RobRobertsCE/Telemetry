﻿using System.Collections.Generic;

namespace iRacing.Common.Models
{
    public interface ILapInfo
    {
        int FrameIndex { get; set; }
        IList<IFrame> LapFrames { get; set; }
        int LapIndex { get; set; }
        int LapNumber { get; set; }
        float LapSpeed { get; set; }
        float LapTime { get; set; }
        irsdk_SessionState SessionState { get; set; }
    }
}