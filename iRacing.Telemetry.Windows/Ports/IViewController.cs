using iRacing.Telemetry.Windows.Models;
using iRacing.Common.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using iRacing.Common;

namespace iRacing.Telemetry.Windows.Ports
{
    public interface IViewController : INotifyPropertyChanged
    {
        IServiceProvider ServiceProvider { get; set; }

        ObservableCollection<IFieldDefinition> FieldDefinitions { get; set; }
        ObservableCollection<IMdiChildForm> MdiChildren { get; set; }
        IWin32Window Parent { get; }
        IProject Project { get; set; }
        ISession Session { get; set; }
        ILapInfo CurrentLap { get; set; }
        int CurrentLapNumber { get; set; }
        int CurrentFrameIndex { get; set; }
        AppState State { get; }

        event EventHandler<TelemetryAppStateChangedEventArgs> ControllerStateChanged;
        event EventHandler<MessageBoxRequestEventArgs> MessageBoxRequest;
        event EventHandler<FileDialogRequestEventArgs> FileDialogRequest;

        void SetParent(IWin32Window windowHandle);

        void NewProject();
        Task OpenProjectAsync();
        Task OpenProjectAsync(string fileName);
        void CloseProject();
        void SaveProject();
        void SaveProjectAs();

        Task OpenSessionAsync();
        Task OpenSessionAsync(string fileName);
        void CloseSession();
        void SaveSessionAs();
        Task LoadSavedSessionAsync();

        void LoadNewDisplay(DisplayTypes displayType);
        void OpenDisplay();
        void SaveDisplay();
    }
}
