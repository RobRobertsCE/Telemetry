using System;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Models
{
    public class MessageBoxRequestEventArgs : EventArgs
    {
        public DialogResult DialogResult { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public MessageBoxButtons Buttons { get; set; }
        public MessageBoxIcon Icon { get; set; }
    }
}
