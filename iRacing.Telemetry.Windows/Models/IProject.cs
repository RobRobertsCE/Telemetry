using iRacing.Common.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace iRacing.Telemetry.Windows.Models
{
    public interface IProject : INotifyPropertyChanged
    {
        string Name { get; set; }
        string FileName { get; set; }
        string SessionFileName { get; set; }
        IList<IFormDisplayInfo> Displays { get; set; }
        bool HasChanges { get; }

        void Save();
        void SaveAs(string fileName);
    }
}