using iRacing.Common;
using iRacing.Common.Models;
using iRacing.Telemetry.Controls.Models;
using iRacing.Telemetry.Data.Ports;
using iRacing.Telemetry.Windows.Models;
using iRacing.Telemetry.Windows.Ports;
using iRacing.Telemetry.Windows.Views.Displays;
using iRacing.TelemetryFile;
using iRacing.TelemetryFile.Ports;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iRacing.Telemetry.Windows.Models.FileDialogRequestEventArgs;

namespace iRacing.Telemetry.Windows.Adapters
{
    public class ViewController : IViewController, INotifyPropertyChanged
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event EventHandler<IProject> ProjectClosing;
        protected virtual void OnProjectClosing()
        {
            var handler = ProjectClosing;
            if (handler != null)
            {
                handler.Invoke(this, Project);
            }
        }

        public event EventHandler ProjectClosed;
        protected virtual void OnProjectClosed()
        {
            var handler = ProjectClosed;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler<ISession> ControllerSessionChanged;
        protected virtual void OnControllerSessionChanged(ISession session)
        {
            var handler = ControllerSessionChanged;
            if (handler != null)
            {
                handler.Invoke(this, session);
            }
        }

        public event EventHandler<TelemetryAppStateChangedEventArgs> ControllerStateChanged;
        protected virtual void OnControllerStateChanged(AppState oldState, AppState newState)
        {
            var handler = ControllerStateChanged;
            if (handler != null)
            {
                handler.Invoke(this, new TelemetryAppStateChangedEventArgs(oldState, newState));
            }
        }

        public event EventHandler<MessageBoxRequestEventArgs> MessageBoxRequest;
        protected virtual DialogResult OnMessageBoxRequest(string prompt, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            var handler = MessageBoxRequest;
            if (handler != null)
            {
                var e = new MessageBoxRequestEventArgs()
                {
                    Prompt = prompt,
                    Title = title,
                    Buttons = buttons,
                    Icon = icon
                };

                handler.Invoke(this, e);

                return e.DialogResult;
            }
            return DialogResult.None;
        }

        public event EventHandler<FileDialogRequestEventArgs> FileDialogRequest;
        protected virtual string OnFileDialogRequest(FileDialogTypes dialogType, string initialDirectory, string fileName, string filter, int filterIndex)
        {
            var handler = FileDialogRequest;

            if (handler != null)
            {
                var e = new FileDialogRequestEventArgs()
                {
                    FileDialogType = dialogType,
                    InitialDirectory = initialDirectory,
                    FileName = fileName,
                    Filter = filter,
                    FilterIndex = filterIndex
                };

                handler.Invoke(this, e);

                if (e.DialogResult == DialogResult.OK)
                    return e.FileName;
            }

            return String.Empty;
        }
        #endregion

        #region fields
        protected readonly ISessionFactory _sessionFactory;
        protected readonly IProjectFactory _projectFactory;
        protected readonly IIbtFileParser _telemetryFileParser;
        protected readonly IDisplayInfoService _displayInfoService;
        #endregion

        #region properties
        private IServiceProvider _serviceProvider = null;
        public virtual IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                {
                    var services = new ServiceCollection();

                    services.AddTelemetrySessions();

                    _serviceProvider = services.BuildServiceProvider();
                }
                return _serviceProvider;
            }
            set
            {
                _serviceProvider = value;
            }
        }

        private iRacingTelemetryOptions _options;
        protected virtual iRacingTelemetryOptions Options
        {
            get
            {
                return _options;
            }
            set
            {
                _options = value;
                OnPropertyChanged(nameof(Options));
            }
        }

        public ILog Log { get; set; }

        private ObservableCollection<IMdiChildForm> _mdiChildren = null;
        public ObservableCollection<IMdiChildForm> MdiChildren
        {
            get
            {
                return _mdiChildren;
            }
            set
            {
                _mdiChildren = value;
                OnPropertyChanged(nameof(MdiChildren));
            }
        }

        private ObservableCollection<IFieldDefinition> _fieldDefinitions = null;
        public ObservableCollection<IFieldDefinition> FieldDefinitions
        {
            get
            {
                return _fieldDefinitions;
            }
            set
            {
                _fieldDefinitions = value;
                OnPropertyChanged(nameof(FieldDefinitions));
            }
        }

        private ObservableCollection<IFieldDisplayInfo> _fieldDisplayInfos = null;
        public ObservableCollection<IFieldDisplayInfo> FieldDisplayInfos
        {
            get
            {
                return _fieldDisplayInfos;
            }
            set
            {
                _fieldDisplayInfos = value;
                OnPropertyChanged(nameof(FieldDisplayInfos));
            }
        }

        private IProject _project = null;
        public IProject Project
        {
            get
            {
                return _project;
            }
            set
            {
                if (value == null && _project != null)
                {
                    OnProjectClosing();
                    _project.PropertyChanged -= Project_PropertyChanged;
                }

                _project = value;

                OnPropertyChanged(nameof(Project));

                if (_project != null)
                {
                    _project.PropertyChanged += Project_PropertyChanged;
                }
            }
        }

        private ISession _session = null;
        public ISession Session
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
                OnPropertyChanged(nameof(Session));
                if (_session == null)

                    State &= ~AppState.SessionLoaded;
                else
                    State = State | AppState.SessionLoaded;
            }
        }

        private AppState _state = AppState.Loading;
        public AppState State
        {
            get
            {
                return _state;
            }
            set
            {
                OnControllerStateChanged(_state, value);
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        public IWin32Window Parent { get; set; }

        private int _currentLapNumber = -1;
        public int CurrentLapNumber
        {
            get
            {
                return _currentLapNumber;
            }
            set
            {
                _currentLapNumber = value;
                OnPropertyChanged(nameof(CurrentLapNumber));
            }
        }

        private int _currentFrameIndex = 0;
        public int CurrentFrameIndex
        {
            get
            {
                return _currentFrameIndex;
            }
            set
            {
                _currentFrameIndex = value;
                OnPropertyChanged(nameof(CurrentFrameIndex));
            }
        }

        private ILapInfo _currentlap = null;
        public ILapInfo CurrentLap
        {
            get
            {
                return _currentlap;
            }
            set
            {
                _currentlap = value;
                OnPropertyChanged(nameof(CurrentLap));
            }
        }
        #endregion

        #region ctor
        public ViewController(
            ISessionFactory sessionFactory,
            IProjectFactory projectFactory,
            IIbtFileParser telemetryFileParser,
            IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor,
            ILog log,
            IServiceProvider serviceProvider,
            IDisplayInfoService displayInfoService)
        {
            _serviceProvider = serviceProvider;

            _sessionFactory = (sessionFactory == null) ? throw new ArgumentNullException(nameof(sessionFactory)) : sessionFactory;
            _projectFactory = (projectFactory == null) ? throw new ArgumentNullException(nameof(projectFactory)) : projectFactory;
            _displayInfoService = (displayInfoService == null) ? throw new ArgumentNullException(nameof(displayInfoService)) : displayInfoService;
            _telemetryFileParser = (telemetryFileParser == null) ? throw new ArgumentNullException(nameof(telemetryFileParser)) : telemetryFileParser;

            _options = (optionsAccessor == null) ? throw new ArgumentNullException(nameof(optionsAccessor)) : optionsAccessor.CurrentValue;
            Log = (log == null) ? throw new ArgumentNullException(nameof(log)) : log;

            MdiChildren = new ObservableCollection<IMdiChildForm>();
            MdiChildren.CollectionChanged += MdiChildren_CollectionChanged;

            PropertyChanged += TelemetryViewController_PropertyChanged;
            ProjectClosing += TelemetryViewController_ProjectClosing;

            Task.Run(async () =>
            {
                await LoadFieldDefinitionsAsync();
                FieldDefinitions.CollectionChanged += FieldDefinitions_CollectionChanged;

                await LoadFieldDisplayInfos();
                FieldDisplayInfos.CollectionChanged += FieldDisplayInfos_CollectionChanged;
            });
        }
        #endregion

        #region public (IViewController implementation)
        public void SetParent(IWin32Window windowHandle)
        {
            Parent = windowHandle;
            State = State | AppState.Ready;
        }

        #region project
        public virtual void NewProject()
        {
            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            Project = new Project();
        }
        public virtual async Task OpenProjectAsync()
        {
            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            var fileName = SelectOpenProjectFile();

            if (!String.IsNullOrEmpty(fileName))
            {
                Project = await _projectFactory.OpenTelemetryProject(fileName);
            }
        }
        public virtual async Task OpenProjectAsync(string fileName)
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                Project = await _projectFactory.OpenTelemetryProject(fileName);
            }
        }
        public virtual void CloseProject()
        {
            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.ProjectLoaded))
            {
                throw new InvalidOperationException("No project open");
            }

            Project = null;
        }
        public virtual void SaveProject()
        {
            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.ProjectLoaded) && Project == null)
            {
                throw new InvalidOperationException("No project open");
            }

            NotifyBeforeSave();

            if (string.IsNullOrEmpty(Project.FileName) || Project.Name == Models.Project.DefaultProjectName)
            {
                SaveProjectAs();
            }
            else
            {
                UpdateProjectDisplays(Project);

                SaveProject(Project);
            }
        }
        public virtual void SaveProjectAs()
        {
            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.ProjectLoaded) || Project == null)
            {
                throw new InvalidOperationException("No project open");
            }

            var fileName = SelectSaveProjectPath(Project);

            if (!String.IsNullOrEmpty(fileName))
            {
                Project.FileName = fileName;

                UpdateProjectDisplays(Project);

                SaveProject(Project);
            }
        }
        #endregion

        #region session
        public virtual async Task OpenSessionAsync()
        {
            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.ProjectLoaded))
            {
                throw new InvalidOperationException("No project open");
            }

            var fileName = SelectOpenSessionTelemetryFile();

            if (!String.IsNullOrEmpty(fileName))
            {
                var session = await _sessionFactory.LoadAtlasTelemetryAsync(fileName);
                session.FileName = fileName;
                SetSessionReference(session);
            }
        }
        public virtual async Task OpenSessionAsync(string fileName)
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                var session = await _sessionFactory.LoadAtlasTelemetryAsync(fileName);
                SetSessionReference(session);
            }
        }
        public virtual async Task LoadSavedSessionAsync()
        {
            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.ProjectLoaded))
            {
                throw new InvalidOperationException("No project open");
            }

            var fileName = SelectOpenSessionFile();

            if (!String.IsNullOrEmpty(fileName))
            {
                var session = await _sessionFactory.LoadAtlasTelemetryAsync(fileName);

                SetSessionReference(session);
            }
        }
        public virtual void SaveSessionAs()
        {
            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.SessionLoaded))
            {
                throw new InvalidOperationException("No session open");
            }

            var sessionFileName = SelectSaveSessionPath(Session);

            if (!String.IsNullOrEmpty(sessionFileName))
            {
                Session.SaveAs(sessionFileName);

                DisplaySavedSessionMessage(Session.Name);
            }
        }
        public virtual void CloseSession()
        {
            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.SessionLoaded))
            {
                throw new InvalidOperationException("No session open");
            }

            DereferenceSession();
        }
        #endregion

        #region display
        public virtual void LoadNewDisplay(DisplayTypes displayType)
        {
            Trace("LoadNewDisplay");

            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.ProjectLoaded))
            {
                throw new InvalidOperationException("No project open");
            }

            LoadNewProjectDisplay(displayType);
        }
        public virtual void OpenDisplay()
        {
            Trace("OpenDisplay");

            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.ProjectLoaded))
            {
                throw new InvalidOperationException("No project open");
            }

            OpenDisplayFromFile();
        }
        public virtual void SaveDisplay()
        {
            Trace("SaveDisplay");

            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.ProjectLoaded))
            {
                throw new InvalidOperationException("No project open");
            }

            SaveDisplayToFile();
        }
        #endregion
        #endregion

        #region protected
        protected virtual void ExceptionHandler(Exception ex)
        {
            Log.Error(ex.Message, ex);
            MessageBox.Show(ex.Message);
        }
        protected virtual void Trace(string message)
        {
            Log.Info(message);
        }

        #region internal property changed handler (controller->controller)
        protected virtual async void TelemetryViewController_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                Trace($"Controller.TelemetryViewController_PropertyChanged {e.PropertyName}");
                switch (e.PropertyName)
                {
                    case nameof(Project):
                        {
                            await HandleProjectChangedAsync();
                            break;
                        }
                    case nameof(FieldDefinitions):
                        {
                            await HandleFieldDefinitionsChangedAsync();
                            break;
                        }
                    case nameof(CurrentLapNumber):
                        {
                            await HandleCurrentLapNumberChangedAsync();
                            break;
                        }
                    case nameof(CurrentFrameIndex):
                        {
                            await HandleCurrentFrameIndexChangedAsync();
                            break;
                        }
                    case nameof(CurrentLap):
                        {
                            await HandleCurrentLapChangedAsync();
                            break;
                        }
                    case nameof(Session):
                        {
                            await HandleSessionChangedAsync();
                            break;
                        }
                    case nameof(State):
                        {
                            await HandleAppStateChangedAsync();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region field definitions
        protected virtual async Task LoadFieldDefinitionsAsync()
        {
            var fieldDefinitionRepository = ServiceProvider.GetRequiredService<IFieldDefinitionRepository>();
            var fieldDefinitions = await fieldDefinitionRepository.GetFieldDefinitionsAsync();
            FieldDefinitions = new ObservableCollection<IFieldDefinition>(fieldDefinitions);
        }
        // field definition collection event (controller->controller)
        protected virtual async void FieldDefinitions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Trace("FieldDefinitions_CollectionChanged");
            await HandleFieldDefinitionsChangedAsync();
        }
        protected virtual async Task HandleFieldDefinitionsChangedAsync()
        {
            await NotifyFieldDefinitionsChangedAsync();
        }
        protected virtual async Task NotifyFieldDefinitionsChangedAsync()
        {
            Trace("NotifyFieldDefinitionsChangedAsync");

            await Task.Run(() =>
            {
                foreach (IMdiChildForm mdiChild in MdiChildren)
                {
                    mdiChild.FieldDefinitions = FieldDefinitions;
                }
            });
        }

        protected virtual void NotifyBeforeSave()
        {
            foreach (IMdiChildForm mdiChild in MdiChildren)
            {
                mdiChild.BeforeSave();
            }
        }
        #endregion

        #region field display infos
        protected virtual async Task LoadFieldDisplayInfos()
        {
            var displayFieldRepository = ServiceProvider.GetRequiredService<IFieldDisplayInfoRepository>();
            var displayInfos = await displayFieldRepository.GetDisplayFieldsAsync();
            FieldDisplayInfos = new ObservableCollection<IFieldDisplayInfo>(displayInfos);
        }
        // field definition collection event (controller->controller)
        protected virtual async void FieldDisplayInfos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Trace("FieldDisplayInfos_CollectionChanged");
            await HandleFieldDisplayInfosChangedAsync();
        }
        protected virtual async Task HandleFieldDisplayInfosChangedAsync()
        {
            await NotifyFieldDisplayInfosChangedAsync();
        }
        protected virtual async Task NotifyFieldDisplayInfosChangedAsync()
        {
            Trace("NotifyFieldDisplayInfosChangedAsync");

            await Task.Run(() =>
            {
                foreach (IMdiChildForm mdiChild in MdiChildren)
                {
                    mdiChild.FieldDisplayInfos = FieldDisplayInfos;
                }
            });
        }
        #endregion

        #region project
        /// <summary>
        /// Project property changed event (project->controller)
        /// </summary>
        /// <param name="sender">ITelemetryProject Project</param>
        /// <param name="e">PropertyChangedEventArgs</param>
        /// /// <remarks>A property on the project changed.</remarks>
        protected virtual void Project_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Trace($"Controller.Project_PropertyChanged {e.PropertyName}");
            switch (e.PropertyName)
            {
                case ("Name"):
                    {
                        OnPropertyChanged("Project.Name");
                        break;
                    }
                case ("FileName"):
                    {
                        OnPropertyChanged("Project.FileName");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        protected virtual void SaveProject(IProject project)
        {
            project.Save();

            DisplaySavedProjectMessage(project.Name);
        }
        protected virtual async Task HandleProjectChangedAsync()
        {
            if (Project != null)
            {
                LoadProjectDisplays(Project);

                State = State | AppState.ProjectLoaded;

                if (!String.IsNullOrEmpty(Project.SessionFileName) && File.Exists(Project.SessionFileName))
                {
                    var loadedSession = await _sessionFactory.LoadAtlasTelemetryAsync(Project.SessionFileName);

                    if (loadedSession != null)
                    {
                        SetSessionReference(loadedSession);
                    }
                }
            }
            else
            {
                State &= ~AppState.ProjectLoaded;
            }
        }

        protected virtual void TelemetryViewController_ProjectClosing(object sender, IProject e)
        {
            HandleProjectClosing(e);
        }
        protected virtual void HandleProjectClosing(IProject project)
        {
            UpdateProjectDisplays(project);

            if (project.HasChanges)
            {
                var result = PromptToSaveChanges("project");

                if (result == DialogResult.Yes)
                {
                    var fileName = SelectSaveProjectPath(project);

                    if (!String.IsNullOrEmpty(fileName))
                    {
                        project.FileName = fileName;

                        SaveProject(project);
                    }
                }
            }

            CloseAllDisplays();

            DereferenceSession();
        }
        #endregion

        #region session
        /// <summary>
        /// Session property changed event (project.session -> controller) 
        /// </summary>
        /// <param name="sender">ITelemetrySession Project.Session</param>
        /// <param name="e">PropertyChangedEventArgs</param>
        /// /// <remarks>A property on the project session changed.</remarks>
        protected virtual void Session_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Trace($"Controller.Session_PropertyChanged {e.PropertyName}");

            switch (e.PropertyName)
            {
                case ("Name"):
                    {
                        OnPropertyChanged("Session.Name");
                        break;
                    }
                case ("FileName"):
                    {
                        OnPropertyChanged("Session.FileName");
                        break;
                    }
                case ("TelemetrySessionData"):
                    {
                        OnPropertyChanged("Session.TelemetrySessionData");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        protected virtual async Task HandleSessionChangedAsync()
        {
            CurrentFrameIndex = 0;

            if (Session != null)
            {
                var startLap = Session?.TelemetrySessionData?.Laps.Min(l => l.LapNumber); ;
                CurrentLapNumber = startLap.HasValue ? startLap.Value : 0;
                CurrentLap = Session?.TelemetrySessionData?.Laps.FirstOrDefault();
            }

            await NotifySessionChangedAsync();
        }
        protected virtual async Task NotifySessionChangedAsync()
        {
            Trace("NotifySessionChangedAsync");

            await Task.Run(() =>
            {
                try
                {
                    foreach (IMdiChildForm mdiChild in MdiChildren)
                    {
                        mdiChild.Session = Session;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler(ex);
                }

            });
        }
        #endregion

        #region current lap
        protected virtual async Task HandleCurrentLapChangedAsync()
        {
            await NotifyCurrentLapChangedAsync();
        }
        protected virtual async Task NotifyCurrentLapChangedAsync()
        {
            Trace("NotifyCurrentLapChangedAsync");

            await Task.Run(() =>
            {
                foreach (IMdiChildForm mdiChild in MdiChildren)
                {
                    if (mdiChild.CurrentLap != CurrentLap)
                        mdiChild.CurrentLap = CurrentLap;
                }
            });
        }
        #endregion

        #region lap number
        protected virtual async Task HandleCurrentLapNumberChangedAsync()
        {
            if (Session != null)
            {
                CurrentLap = Session.TelemetrySessionData?.Laps.FirstOrDefault(l => l.LapNumber == CurrentLapNumber);
            }
            else
                CurrentLap = null;

            await NotifyCurrentLapNumberChangedAsync();
        }
        protected virtual async Task NotifyCurrentLapNumberChangedAsync()
        {
            Trace("NotifyCurrentLapNumberChangedAsync");

            await Task.Run(() =>
            {
                foreach (IMdiChildForm mdiChild in MdiChildren)
                {
                    if (mdiChild.CurrentLapNumber != CurrentLapNumber)
                        mdiChild.CurrentLapNumber = CurrentLapNumber;
                }
            });
        }
        #endregion

        #region frame index
        protected virtual async Task HandleCurrentFrameIndexChangedAsync()
        {
            await NotifyFrameIndexChangedAsync();
        }
        protected virtual async Task NotifyFrameIndexChangedAsync()
        {
            Trace("NotifyFrameIndexChanged");

            await Task.Run(() =>
            {
                foreach (IMdiChildForm mdiChild in MdiChildren)
                {
                    if (mdiChild.CurrentFrameIndex != CurrentFrameIndex)
                        mdiChild.CurrentFrameIndex = CurrentFrameIndex;
                }
            });
        }
        #endregion

        #region state
        protected virtual async Task HandleAppStateChangedAsync()
        {
            await NotifyAppStateChangedAsync();
        }
        protected virtual async Task NotifyAppStateChangedAsync()
        {
            Trace("NotifyFrameIndexChanged");

            await Task.Run(() =>
            {
                foreach (IMdiChildForm mdiChild in MdiChildren)
                {
                    if (mdiChild.State != State)
                        mdiChild.State = State;
                }
            });
        }
        #endregion

        #region mdi child form events
        // mdi child collection events (controller->controller)
        protected virtual void MdiChildren_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Trace("MdiChildren_CollectionChanged");

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (IMdiChildForm mdiChild in e.NewItems)
                        {
                            mdiChild.IsLoading = true;

                            mdiChild.Session = Session;
                            mdiChild.CurrentLap = CurrentLap;
                            mdiChild.CurrentLapNumber = CurrentLapNumber;
                            mdiChild.CurrentFrameIndex = CurrentFrameIndex;
                            mdiChild.FieldDefinitions = FieldDefinitions;
                            mdiChild.FieldDisplayInfos = FieldDisplayInfos;

                            mdiChild.CloseWindowRequest += MdiChild_CloseWindowRequest;
                            mdiChild.FrameIndexChangeRequest += MdiChild_FrameIndexChangeRequest;
                            mdiChild.LapNumberChangeRequest += MdiChild_LapNumberChangeRequest;
                            mdiChild.FormClosing += MdiChild_FormClosing;

                            mdiChild.IsLoading = false;

                            mdiChild.State = State;
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Move:
                    {

                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (IMdiChildForm mdiChild in e.OldItems)
                        {
                            mdiChild.CloseWindowRequest -= MdiChild_CloseWindowRequest;
                            mdiChild.FrameIndexChangeRequest -= MdiChild_FrameIndexChangeRequest;
                            mdiChild.LapNumberChangeRequest -= MdiChild_LapNumberChangeRequest;
                            mdiChild.FormClosing -= MdiChild_FormClosing;
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Replace:
                    {

                        break;
                    }
                case NotifyCollectionChangedAction.Reset:
                    {

                        break;
                    }
                default:
                    {

                        break;
                    }
            }
            OnPropertyChanged("MdiChildren");
        }

        // mdi child event handlers (child window->controller)
        private void MdiChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            MdiChildren.Remove((IMdiChildForm)sender);
        }
        protected virtual void MdiChild_LapNumberChangeRequest(object sender, LapNumberChangeRequestEventArgs e)
        {
            Trace("MdiChild_LapNumberChangeRequest");

            CurrentLapNumber = e.LapNumber;
        }
        protected virtual void MdiChild_FrameIndexChangeRequest(object sender, FrameIndexChangeRequestEventArgs e)
        {
            Trace("MdiChild_FrameIndexChangeRequest");

            CurrentFrameIndex = e.FrameIndex;
        }
        protected virtual async Task CloseChildWindowAsync(IWin32Window windowHandle)
        {
            await Task.Run(() =>
            {

                IMdiChildForm mdiChildToClose = null;

                foreach (IMdiChildForm mdiChild in MdiChildren)
                {
                    if (mdiChild.WindowHandle == windowHandle)
                    {
                        mdiChildToClose = mdiChild;
                        break;
                    }
                }

                if (mdiChildToClose != null)
                {
                    MdiChildren.Remove(mdiChildToClose);

                    mdiChildToClose.CloseWindow();

                    mdiChildToClose.Dispose();
                }

            });
        }
        protected virtual async void MdiChild_CloseWindowRequest(object sender, EventArgs e)
        {
            Trace("MdiChild_CloseWindowRequest");

            await CloseChildWindowAsync(((IMdiChildForm)sender).WindowHandle);
        }
        #endregion

        #region displays
        protected virtual void LoadProjectDisplays(IProject project)
        {
            foreach (IFormDisplayInfo displayInfo in project.Displays)
            {
                LoadDisplay(displayInfo);
            }
        }
        protected virtual void UpdateProjectDisplays(IProject project)
        {
            project.Displays.Clear();

            foreach (ITelemetryForm displayForm in ((Form)Parent).MdiChildren.ToList().OfType<ITelemetryForm>())
            {
                project.Displays.Add(displayForm.FormDisplayInfo);
            }

            project.SessionFileName = Session?.SessionFileName;
        }
        protected virtual void LoadNewProjectDisplay(DisplayTypes displayType)
        {
            Trace("LoadNewProjectDisplay");

            if (!State.HasFlag(AppState.Ready))
            {
                throw new InvalidOperationException("App busy");
            }

            if (!State.HasFlag(AppState.ProjectLoaded))
            {
                throw new InvalidOperationException("No project open");
            }

            IFormDisplayInfo displayInfo = new FormDisplayInfo()
            {
                X = 100,
                Y = 100,
                Width = 300,
                Height = 600,
                DisplayType = displayType,
                WindowState = FormWindowState.Normal
            };

            // set any displaytype-specific properties here, (fields, etc...)
            switch (displayType)
            {
                case (DisplayTypes.LapTimes):
                    {
                        displayInfo.Width = 300;
                        displayInfo.Height = 600;

                        break;
                    }
                case (DisplayTypes.Waveform):
                    {
                        displayInfo = new WaveformDisplayInfo()
                        {
                            X = 10,
                            Y = 10,
                            Width = 800,
                            Height = 600,
                            DisplayType = displayType,
                            WindowState = FormWindowState.Normal
                        };

                        break;
                    }

                case (DisplayTypes.Histogram):
                    {
                        displayInfo.Width = 800;
                        displayInfo.Height = 600;
                        break;
                    }

                case (DisplayTypes.TrackMap):
                    {
                        displayInfo.Width = 640;
                        displayInfo.Height = 400;

                        break;
                    }

                case (DisplayTypes.Setup):
                    {
                        break;
                    }

                case (DisplayTypes.SessionDetails):
                    {
                        break;
                    }
            }

            LoadDisplay(displayInfo);
        }
        protected virtual void LoadDisplay(IFormDisplayInfo displayInfo)
        {
            try
            {
                ((Form)Parent).SuspendLayout();

                ITelemetryForm displayForm = null;

                switch (displayInfo.DisplayType)
                {
                    case (DisplayTypes.MdiParent):
                        {
                            return;
                        }
                    case (DisplayTypes.LapTimes):
                        {
                            displayForm = new LapTimesDisplay(
                                    ServiceProvider,
                                    Log,
                                    Options);

                            break;
                        }
                    case (DisplayTypes.Waveform):
                        {
                            displayForm = new WaveformDisplay(
                                    ServiceProvider,
                                    Log,
                                    Options,
                                    displayInfo);
                            break;
                        }

                    case (DisplayTypes.Histogram):
                        {
                            displayForm = new HistogramDisplay(
                                    ServiceProvider,
                                    Log,
                                    Options);
                            break;
                        }

                    case (DisplayTypes.TrackMap):
                        {
                            displayForm = new TrackMapDisplay(
                                    ServiceProvider,
                                    Log,
                                    Options);
                            break;
                        }

                    case (DisplayTypes.Setup):
                        {
                            displayForm = new SetupDisplay(
                                    ServiceProvider,
                                    Log,
                                    Options);
                            break;
                        }

                    case (DisplayTypes.SessionDetails):
                        {
                            displayForm = new SessionDetailsDisplay(
                                    ServiceProvider,
                                    Log,
                                    Options);
                            break;
                        }
                }

                displayForm.FormDisplayInfo = displayInfo;

                displayForm.Text = String.IsNullOrEmpty(displayInfo.Title) ? displayInfo.DisplayType.ToString() : displayInfo.Title;
                displayForm.MdiParent = (Form)Parent;

                displayForm.Location = new System.Drawing.Point(displayInfo.X, displayInfo.Y);
                displayForm.Size = new System.Drawing.Size(displayInfo.Width, displayInfo.Height);
                displayForm.WindowState = displayInfo.WindowState;

                displayForm.Show();

                MdiChildren.Add((IMdiChildForm)displayForm);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                ((Form)Parent).ResumeLayout(true);
            }
        }
        protected virtual void OpenDisplayFromFile()
        {
            var fileName = SelectOpenDisplayFile();

            if (!String.IsNullOrEmpty(fileName))
            {
                var displayInfo = _displayInfoService.LoadFormDisplayInfo(fileName);

                LoadDisplay(displayInfo);
            }
        }
        protected virtual void SaveDisplayToFile()
        {
            var fileName = SelectSaveDisplayFile();
            var displayInfo = GetActiveDisplayInfo();

            if (_displayInfoService.SaveFormDisplayInfo(displayInfo, fileName))
                DisplaySavedDisplayMessage(displayInfo.Name);
        }
        protected virtual IFormDisplayInfo GetActiveDisplayInfo()
        {
            var activeMdiChild = ((Form)Parent).ActiveMdiChild;
            if (activeMdiChild != null)
            {
                return ((ITelemetryForm)activeMdiChild).FormDisplayInfo;
            }
            else
                return null;
        }
        protected virtual void CloseAllDisplays()
        {
            foreach (IMdiChildForm childForm in MdiChildren.ToList())
            {
                ((Form)childForm).Close();
                MdiChildren.Remove(childForm);
                ((Form)Parent).Controls.Remove((Form)childForm);
                childForm.Dispose();
            }
        }
        #endregion
        #endregion

        #region private
        private void DisplaySavedSessionMessage(string name)
        {
            DisplaySaveCompleteMessage("Session", name);
        }
        private void DisplaySavedProjectMessage(string name)
        {
            DisplaySaveCompleteMessage("Project", name);
        }
        private void DisplaySavedDisplayMessage(string name)
        {
            DisplaySaveCompleteMessage("Display", name);
        }
        private void DisplaySaveCompleteMessage(string saveType, string name)
        {
            OnMessageBoxRequest($"{saveType} '{name}' saved", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private DialogResult PromptToSaveChanges(string objectName)
        {
            return OnMessageBoxRequest($"Save changes to {objectName}?", "Save Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private string GetDefaultProjectFileName(IProject project)
        {
            var projectName = (project.Name == Models.Project.DefaultProjectName) ? "New Project" : project.Name;
            return Path.Combine(Options.ProjectsDirectory, $"{projectName}.json");
        }
        private string SelectOpenProjectFile()
        {
            return OnFileDialogRequest(FileDialogTypes.Open, Options.ProjectsDirectory, String.Empty, "Project Files (*.json)|*.json|All Files (*.*)|*.*", 1);
        }
        private string SelectOpenDisplayFile()
        {
            return OnFileDialogRequest(FileDialogTypes.Open, Options.DisplaysDirectory, String.Empty, "Display Files (*.json)|*.json|All Files (*.*)|*.*", 1);
        }
        private string SelectSaveDisplayFile()
        {
            return OnFileDialogRequest(FileDialogTypes.Save, Options.DisplaysDirectory, String.Empty, "Display Files (*.json)|*.json|All Files (*.*)|*.*", 1);
        }
        private string SelectSaveProjectPath(IProject project)
        {
            var projectFileName = String.IsNullOrEmpty(project.FileName) ? GetDefaultProjectFileName(project) : project.FileName;

            string saveFilePath = OnFileDialogRequest(FileDialogTypes.Save, Options.ProjectsDirectory, projectFileName, "Project Files (*.json)|*.json|All Files (*.*)|*.*", 1);

            project.Name = Path.GetFileNameWithoutExtension(saveFilePath);

            return saveFilePath;
        }

        private string GetDefaultSessionFileName(ISession session)
        {
            var sessionName = (session.Name == TelemetrySession.DefaultSessionName) ? "New Session" : session.Name;
            return Path.Combine(Options.TelemetryDirectory, $"{sessionName}.json");
        }
        private string SelectOpenSessionFile()
        {
            return OnFileDialogRequest(FileDialogTypes.Open, Options.TelemetryDirectory, String.Empty, "Session Files (*.json)|*.json|All Files (*.*)|*.*", 1);
        }
        private string SelectOpenSessionTelemetryFile()
        {
            return OnFileDialogRequest(FileDialogTypes.Open, Options.TelemetryDirectory, String.Empty, "Atlas Telemetry Files(*.ibt) | *.ibt|All Files (*.*)|*.*", 1);
        }
        private string SelectSaveSessionPath(ISession session)
        {
            string sessionFileName = String.IsNullOrEmpty(session.FileName) ? GetDefaultSessionFileName(session) : session.FileName;

            return OnFileDialogRequest(FileDialogTypes.Save, Options.TelemetryDirectory, sessionFileName, "Telemetry session Files (*.json)|*.json|All Files (*.*)|*.*", 1);
        }

        private void SetSessionReference(ISession session)
        {
            if (Session != null)
            {
                CloseSession();
            }

            Session = session;
            Session.PropertyChanged += Session_PropertyChanged;
        }
        private void DereferenceSession()
        {
            if (Session != null)
            {
                Session.PropertyChanged -= Session_PropertyChanged;
                Session = null;
            }
        }
        #endregion
    }
}
