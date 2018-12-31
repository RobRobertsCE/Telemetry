using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Models
{
    public class FileDialogRequestEventArgs : EventArgs
    {
        public enum FileDialogTypes
        {
            Open,
            Save,
            SelectFolder
        }

        public FileDialogTypes FileDialogType { get; set; }
        public string InitialDirectory { get; set; }
        public string FileName { get; set; }
        public string Filter { get; set; }
        public int FilterIndex { get; set; }
        public DialogResult DialogResult { get; set; }
    }
}
