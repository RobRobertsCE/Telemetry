using System;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Models
{
    public class CloseWindowRequestEventArgs : EventArgs
    {
        public IWin32Window WindowHandle { get; set; }

        public CloseWindowRequestEventArgs()
        {

        }
        public CloseWindowRequestEventArgs(IWin32Window windowHandleToClose)
        {
            WindowHandle = windowHandleToClose;
        }
    }
}
