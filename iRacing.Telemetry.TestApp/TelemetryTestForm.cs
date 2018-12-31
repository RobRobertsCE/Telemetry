using iRacing.Telemetry.Controls;
using iRacing.Telemetry.Controls.Dialogs;
using iRacing.Telemetry.Controls.Displays;
using iRacing.Telemetry.TestApp.Project;
using iRacing.TelemetryFile;
using iRacing.Common.Models;
using iRacing.TelemetryFile.Ports;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.TestApp
{
    public partial class TelemetryTestForm
    {
        #region constants
        private const string TelemetryFolder = @"C:\Users\rroberts\Documents\iRacing\telemetry";
        private const string ProjectsFolder = @"C:\Users\rroberts\Documents\iRacing\telemetry\iRacingTelemetry\Projects";
        private const string DisplaysFolder = @"C:\Users\rroberts\Documents\iRacing\telemetry\iRacingTelemetry\Displays";
        #endregion

        #region enums
        [Flags()]
        protected enum FormStates
        {
            Loading = 0x01,
            Ready = 0x02,
            ProjectOpen = 0x04,
            SessionOpen = 0x08
        }
        #endregion

        #region events
        protected virtual async void OnSessionChanged(ITelemetrySessionData session)
        {
            _displayController.Session = _session;

            ClearSession();

            if (session != null)
            {
                await DisplaySessionAsync(session);
                SetSessionOpenFormState();
            }
            else
            {
                SetSessionClosedFormState();
            }
        }

        protected virtual void OnFormStateChanged(FormStates state)
        {
            exitToolStripMenuItem.Enabled = state.HasFlag(FormStates.Loading);

            mnuMainMenu.Enabled = state.HasFlag(FormStates.Ready);
            tlsMainToolStrip.Enabled = state.HasFlag(FormStates.Ready);
            newProjectToolStripMenuItem.Enabled = state.HasFlag(FormStates.Ready);
            openProjectToolStripMenuItem.Enabled = state.HasFlag(FormStates.Ready);

            closeProjectToolStripMenuItem.Enabled = state.HasFlag(FormStates.ProjectOpen);
            saveProjectToolStripMenuItem.Enabled = state.HasFlag(FormStates.ProjectOpen);
            saveProjectAsToolStripMenuItem.Enabled = state.HasFlag(FormStates.ProjectOpen);
            displayToolStripMenuItem.Enabled = state.HasFlag(FormStates.ProjectOpen);
            windowToolStripMenuItem.Enabled = state.HasFlag(FormStates.ProjectOpen);

            sessionToolStripMenuItem.Enabled = state.HasFlag(FormStates.ProjectOpen);
            openToolStripMenuItem1.Enabled = state.HasFlag(FormStates.ProjectOpen);
            closeToolStripMenuItem1.Enabled = state.HasFlag(FormStates.SessionOpen);
            saveFieldListToolStripMenuItem.Enabled = state.HasFlag(FormStates.SessionOpen);

            Console.WriteLine($"New form state: {state.ToString()}");
        }

        protected virtual void OnProjectChanged(TelemetryProject project)
        {
            if (project != null)
            {
                SetProjectOpenFormState();
            }
            else
            {
                SetProjectClosedFormState();
            }
        }
        #endregion

        #region fields
        private string _sessionFileName;
        private IDisplayController _displayController;
        #endregion

        #region properties
        private IServiceProvider _serviceProvider = null;
        protected virtual IServiceProvider ServiceProvider
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
        }

        private ITelemetrySessionData _session = null;
        protected virtual ITelemetrySessionData Session
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;

                OnSessionChanged(_session);
            }
        }

        private TelemetryProject _project = null;
        protected virtual TelemetryProject Project
        {
            get
            {
                return _project;
            }
            set
            {
                _project = value;

                OnProjectChanged(_project);
            }
        }

        private FormStates _formState = FormStates.Loading;
        protected virtual FormStates FormState
        {
            get
            {
                return _formState;
            }
            set
            {
                _formState = value;
                OnFormStateChanged(_formState);
            }
        }
        #endregion

        #region ctor / load
        public TelemetryTestForm()
        {
            InitializeComponent();
        }
        private void TelemetryTestForm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLoadingFormState();

                _displayController = new DisplayController(this);
                _displayController.PropertyChanged += _displayController_PropertyChanged;
                _displayController.ActiveDisplayChanged += _displayController_ActiveDisplayChanged;
                _displayController.DisplayAdded += _displayController_DisplayAdded;
                _displayController.DisplayRemoved += _displayController_DisplayRemoved;

                ClearSession();

                SetReadyFormState();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region exception handlers
        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }
        private void ExceptionHandler(KeyNotFoundException ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }
        #endregion

        #region form state
        public void SetLoadingFormState()
        {
            FormState = FormStates.Loading;
        }
        public void SetReadyFormState()
        {
            FormState = FormStates.Loading | FormStates.Ready;
        }
        private void SetProjectOpenFormState()
        {
            FormState = FormState | FormStates.ProjectOpen;
        }
        private void SetProjectClosedFormState()
        {
            FormState &= ~FormStates.ProjectOpen;
        }
        private void SetSessionOpenFormState()
        {
            FormState = FormState | FormStates.SessionOpen;
        }
        private void SetSessionClosedFormState()
        {
            FormState &= ~FormStates.SessionOpen;
        }
        #endregion

        #region display session     
        protected virtual void ClearSession()
        {
            _sessionFileName = String.Empty;
            ClearSessionName();
            ClearSetupName();
            ClearSessionInfo();

            closeToolStripMenuItem1.Enabled = false;
        }
        protected virtual async Task DisplaySessionAsync(ITelemetrySessionData session)
        {
            DisplaySessionName();
            await DisplaySessionInfoAsync(session);

            closeToolStripMenuItem1.Enabled = true;
        }

        protected virtual void DisplaySessionName()
        {
            if (!String.IsNullOrEmpty(_sessionFileName))
            {
                lblSession.Text = $"Session: {Path.GetFileNameWithoutExtension(_sessionFileName)}";
            }
            else
            {
                ClearSessionName();
            }
        }
        protected virtual void ClearSessionName()
        {
            lblSession.Text = "Session:";
        }

        protected virtual void DisplaySetupName(string setupName)
        {
            lblSetupName.Text = $"Setup: {setupName}";
        }
        protected virtual void ClearSetupName()
        {
            lblSetupName.Text = "Setup:";
        }

        #region session info
        protected virtual void ClearSessionInfo()
        {
            // status bar
            lblVehicleName.Text = "Vehicle:";
            lblTrackName.Text = "Track:";
            lblWeather.Text = "Weather:";
            lblTrackState.Text = "Track State:";
            lblTimeOfDay.Text = "Time of Day:";
            lblSessionTypeName.Text = "Session Type:";
            lblAirTemp.Text = "Air Temp:";
            lblTrackTemp.Text = "Track Temp:";
        }
        protected virtual async Task DisplaySessionInfoAsync(ITelemetrySessionData session)
        {
            string sessionName = "";
            string vehicle = "";
            string setupName = "";

            string trackName = "";
            string weather = "";
            string trackState = "";
            string timeOfDay = "";
            string airTemp = "";
            string trackTemp = "";

            await Task.Run(() =>
            {
                try
                {
                    var driverCarIdx = GetDriverCarIdx(session);

                    sessionName = GetCurrentSessionInfo(session);
                    setupName = GetSetupName(session);
                    vehicle = GetVehicleInfo(session, driverCarIdx);

                    trackName = GetTrackName(session);
                    trackState = GetTrackState(session);
                    weather = GetWeather(session);
                    timeOfDay = GetTimeOfDay(session);
                    airTemp = GetAirTemp(session);
                    trackTemp = GetTrackTemp(session);
                }
                catch (KeyNotFoundException ex)
                {
                    ExceptionHandler(ex);
                }
                catch (Exception ex)
                {
                    ExceptionHandler(ex);
                }
            });

            DisplaySetupName(setupName);

            lblVehicleName.Text = $"Vehicle: {vehicle}";
            lblTrackName.Text = $"Track: {trackName}";
            lblWeather.Text = $"Weather: {weather}";
            lblTrackState.Text = $"Track State: {trackState}";
            lblTimeOfDay.Text = $"Time of Day: {timeOfDay}";
            lblSessionTypeName.Text = $"Session Type: {sessionName}";
            lblAirTemp.Text = $"Air Temp: {airTemp}";
            lblTrackTemp.Text = $"Track Temp: {trackTemp}";
        }
        protected virtual int GetDriverCarIdx(ITelemetrySessionData session)
        {
            return Int32.Parse(session.SessionInfo.driverInfo["DriverCarIdx"].ToString());
        }
        protected virtual string GetTrackInfo(ITelemetrySessionData session)
        {
            var trackName = GetTrackName(session);
            var trackLength = session.SessionInfo.weekendInfo["TrackLength"].ToString();
            var trackType = session.SessionInfo.weekendInfo["TrackType"].ToString();
            var sessions = (IList<object>)session.SessionInfo.sessionInfo["Sessions"];
            var currentSession = (IDictionary<object, object>)sessions.LastOrDefault();
            var trackState = GetTrackState(session);
            return $"{trackName}\r\n{trackLength}\r\n{trackType}\r\n{trackState}";
        }
        protected virtual string GetTrackName(ITelemetrySessionData session)
        {
            return session.SessionInfo.weekendInfo["TrackDisplayName"].ToString();
        }
        protected virtual string GetTrackState(ITelemetrySessionData session)
        {
            var currentSession = GetCurrentSession(session);
            return currentSession["SessionTrackRubberState"].ToString();
        }
        protected virtual string GetWeather(ITelemetrySessionData session)
        {
            return session.SessionInfo.weekendInfo["TrackSkies"].ToString();
        }
        protected virtual string GetAirTemp(ITelemetrySessionData session)
        {
            return session.SessionInfo.weekendInfo["TrackAirTemp"].ToString();
        }
        protected virtual string GetTrackTemp(ITelemetrySessionData session)
        {
            return session.SessionInfo.weekendInfo["TrackSurfaceTemp"].ToString();
        }
        protected virtual string GetTimeOfDay(ITelemetrySessionData session)
        {
            var weekendOptions = (IDictionary<object, object>)session.SessionInfo.weekendInfo["WeekendOptions"];
            return weekendOptions["TimeOfDay"].ToString();
        }
        protected virtual IDictionary<object, object> GetCurrentSession(ITelemetrySessionData session)
        {
            var sessions = (IList<object>)session.SessionInfo.sessionInfo["Sessions"];
            return (IDictionary<object, object>)sessions.LastOrDefault();
        }
        protected virtual string GetLapInfo(ITelemetrySessionData session, int driverCarIdx)
        {
            string lapCount = "";
            string fastestLapNumber = "";
            string fastestLapTime = "";

            var sessions = (IList<object>)session.SessionInfo.sessionInfo["Sessions"];
            var currentSession = (IDictionary<object, object>)sessions.LastOrDefault();

            var sessionResults = (IList<object>)currentSession["ResultsPositions"];
            if (sessionResults == null)
            {
                return "0";
            }
            else
            {
                foreach (IDictionary<object, object> result in sessionResults)
                {
                    if (result["CarIdx"].ToString() == driverCarIdx.ToString())
                    {
                        lapCount = result["Lap"].ToString();
                        fastestLapNumber = result["FastestLap"].ToString();
                        fastestLapTime = result["FastestTime"].ToString();
                    }
                }

                return $"{lapCount}   Best Lap: {fastestLapNumber} [{fastestLapTime}]";
            }
        }
        protected virtual string GetCurrentSessionInfo(ITelemetrySessionData session)
        {
            var currentSession = GetCurrentSession(session);
            var sessionName = currentSession["SessionName"].ToString();
            return sessionName;
        }
        protected virtual IDictionary<object, object> GetDriver(ITelemetrySessionData session, int driverCarIdx)
        {
            var driversList = (IList<object>)session.SessionInfo.driverInfo["Drivers"];
            var driver = (IDictionary<object, object>)driversList[driverCarIdx];
            return driver;
        }
        protected virtual string GetVehicleInfo(ITelemetrySessionData session, int driverCarIdx)
        {
            var driver = GetDriver(session, driverCarIdx);
            var vehicle = driver["CarScreenName"].ToString();
            return vehicle;
        }
        protected virtual string GetDriverInfo(ITelemetrySessionData session, int driverCarIdx)
        {
            var driver = GetDriver(session, driverCarIdx);
            var userName = driver["UserName"].ToString();
            return userName;
        }
        protected virtual string GetSetupName(ITelemetrySessionData session)
        {
            var setupName = session.SessionInfo.driverInfo["DriverSetupName"].ToString();
            bool isModified = ("1" == session.SessionInfo.driverInfo["DriverSetupIsModified"].ToString());
            if (isModified)
            {
                var setupSection = session.SetupInfo;
                var modifiedCount = setupSection.updateCount;
                return $"{setupName} [{modifiedCount}]";
            }
            else
            {
                return setupName;
            }
        }
        #endregion
        #endregion

        #region close app/telemetry navigation/child windows
        private void TelemetryTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CloseApp(true);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseApp();
        }
        private bool CloseApp()
        {
            return CloseApp(false);
        }
        private bool CloseApp(bool formEvent)
        {
            var cancel = false;

            if (Project != null)
            {
                cancel = CloseProject(Project);
            }

            if (!formEvent && !cancel)
                this.Close();

            return cancel;
        }

        // Lap/frame navigation menu items
        private void btnFrameBack_Click(object sender, EventArgs e)
        {
            _displayController.PreviousFrame();
        }
        private void btnFrameForward_Click(object sender, EventArgs e)
        {
            _displayController.NextFrame();
        }
        private void btnLapBack_Click(object sender, EventArgs e)
        {
            _displayController.PreviousLap();
        }
        private void btnLapForward_Click(object sender, EventArgs e)
        {
            _displayController.NextLap();
        }

        // MDI child window menu items
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        #endregion

        #region display controller events
        private void _displayController_DisplayRemoved(object sender, DisplayRemovedEventArgs e)
        {
            Console.WriteLine("_displayController_DisplayRemoved");
        }
        private void _displayController_DisplayAdded(object sender, DisplayAddedEventArgs e)
        {
            Console.WriteLine("_displayController_DisplayAdded");
        }
        private void _displayController_ActiveDisplayChanged(object sender, ActiveDisplayChangedEventArgs e)
        {
            Console.WriteLine("_displayController_ActiveDisplayChanged");
        }
        private void _displayController_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Session":
                    {
                        if (_displayController.MaxLapNumber.HasValue)
                            tslMaxLaps.Text = $"MaxLap: {_displayController.MaxLapNumber.ToString()}";
                        else
                            tslMaxLaps.Text = "MaxLap:";

                        if (_displayController.MinLapNumber.HasValue)
                            tslMinLaps.Text = $"MinLap: {_displayController.MinLapNumber.ToString()}";
                        else
                            tslMinLaps.Text = "MinLap:";

                        if (_displayController.LapNumber.HasValue)
                            tslLap.Text = $"Lap: {_displayController.LapNumber.ToString()}";
                        else
                            tslLap.Text = "Lap:";

                        if (_displayController.FrameIdx.HasValue)
                            tslFrame.Text = $"FrameIdx: {_displayController.FrameIdx.ToString()}";
                        else
                            tslFrame.Text = "FrameIdx:";

                        break;
                    }
                case "FrameIdx":
                    {
                        if (_displayController.FrameIdx.HasValue)
                            tslFrame.Text = $"FrameIdx: {_displayController.FrameIdx.ToString()}";
                        else
                            tslFrame.Text = "FrameIdx:";

                        break;
                    }
                case "LapNumber":
                    {
                        if (_displayController.LapNumber.HasValue)
                            tslLap.Text = $"Lap: {_displayController.LapNumber.ToString()}";
                        else
                            tslLap.Text = "Lap:";

                        break;
                    }
                default:
                    {

                        break;
                    }
            }
        }
        #endregion

        #region field definitions
        private IFieldDefinition SelectFieldDefinition()
        {
            var fieldDefinitions = GetFieldDefinitions();

            if (fieldDefinitions == null)
            {
                MessageBox.Show("No field definitions available");
                return null;
            }

            var dialog = new FieldSelectionDialog()
            {
                Fields = fieldDefinitions
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
                return dialog.Field;
            else
                return null;
        }
        private IFieldDefinition GetFieldDefinition(string fieldName)
        {
            var fieldDefinitions = GetFieldDefinitions();
            return fieldDefinitions.FirstOrDefault(f => f.Name == fieldName);
        }
        private void saveFieldListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session == null)
            {
                MessageBox.Show("No session loaded");
                return;
            }

            SaveFieldDefinitionFile(Session);
        }
        private void SaveFieldDefinitionFile(ITelemetrySessionData session)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var json = JsonConvert.SerializeObject(session.Fields, settings);
            var fieldListFile = Path.Combine(DisplaysFolder, "FieldDefinitions.json");
            File.WriteAllText(fieldListFile, json);
            MessageBox.Show("Field definition list saved");
        }
        private IList<IFieldDefinition> LoadFieldDefinitionFile()
        {
            IList<IFieldDefinition> fieldDefinitions = null;

            var fieldListFile = Path.Combine(DisplaysFolder, "FieldDefinitions.json");
            if (File.Exists(fieldListFile))
            {
                var json = File.ReadAllText(fieldListFile);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                fieldDefinitions = JsonConvert.DeserializeObject<IList<IFieldDefinition>>(json, settings);
            }
            return fieldDefinitions;
        }
        private IList<IFieldDefinition> GetFieldDefinitions()
        {
            if (Session != null)
            {
                return Session.Fields;
            }
            else
            {
                return LoadFieldDefinitionFile();
            }
        }
        #endregion

        #region displays
        private void lapTimesDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewLapTimesDisplay();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void lineGraphDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewLineGraphDisplay();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void NewLapTimesDisplay()
        {
            var displayInfo = new DefaultLapTimesDisplayInfo();

            NewLapTimesDisplay(displayInfo);
        }
        private void NewLapTimesDisplay(LapTimesDisplayInfo displayInfo)
        {
            ITelemetryDisplay display = new LapTimeDisplay()
            {
                Size = new System.Drawing.Size(displayInfo.Width, displayInfo.Height),
                Location = new System.Drawing.Point(displayInfo.X, displayInfo.Y),
                DisplayInfo = displayInfo
            };

            _displayController.AddDisplay(display);
        }
        private void NewLineGraphDisplay()
        {
            var displayInfo = new DefaultLineChartRpmDisplayInfo();

            NewLineGraphDisplay(displayInfo);
        }
        private void NewLineGraphDisplay(LineGraphDisplayInfo displayInfo)
        {
            ITelemetryDisplay display = new LineGraphDisplay(displayInfo)
            {
                Size = new System.Drawing.Size(displayInfo.Width, displayInfo.Height),
                Location = new System.Drawing.Point(displayInfo.X, displayInfo.Y)
            };

            if (displayInfo.DisplaySeries.Count > 0)
            {
                foreach (DisplaySeries series in displayInfo.DisplaySeries)
                {
                    var fieldDefinition = GetFieldDefinition(series.FieldName);
                    if (fieldDefinition != null)
                        ((ITelemetryFrameDisplay)display).Field = fieldDefinition;
                    else
                        MessageBox.Show($"Could not find field definition named {series.FieldName}");
                }
            }

            _displayController.AddDisplay(display);
        }
        #endregion

        #region sessions
        private async void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            await OpenSessionAsync();
        }
        private async Task OpenSessionAsync()
        {
            try
            {
                var session = await LoadTelemetryFileSessionAsync();

                if (session != null)
                    Session = session;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseSession();
        }
        private void CloseSession()
        {
            Session = null;
        }
        private async Task<ITelemetrySessionData> LoadTelemetryFileSessionAsync()
        {
            ITelemetrySessionData session = null;

            _sessionFileName = SelectSessionFile();

            if (!String.IsNullOrEmpty(_sessionFileName))
            {
                session = await LoadTelemetryFileSessionAsync(_sessionFileName);
            }

            return session;
        }

        private async Task<ITelemetrySessionData> LoadTelemetryFileSessionAsync(string sessionFileName)
        {
            Session = null;

            var telemetrySessionFile = await OpenSessionFileAsync(sessionFileName);

            if (Project != null)
                Project.SessionName = sessionFileName;

            return telemetrySessionFile.TelemetrySessionData;
        }

        private string SelectSessionFile()
        {
            var fileName = String.Empty;

            var dialog = new OpenFileDialog()
            {
                InitialDirectory = TelemetryFolder,
                Filter = "Atlas Files (*.ibt)|*.ibt|All Files (*.*)|*.*",
                FilterIndex = 1
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }

            return fileName;
        }

        private async Task<IbtTelemetryFile> OpenSessionFileAsync(string fileName)
        {
            var parser = ServiceProvider.GetRequiredService<IIbtTelemetryFileParser>();

            return await parser.ParseTelemetryFileAsync(fileName, ParseOptions.All);
        }

        private async Task<ITelemetrySessionData> ParseSessionFileAsync(byte[] telemetryBytes)
        {
            var parser = ServiceProvider.GetRequiredService<IIbtTelemetrySessionParser>();

            return await parser.ParseTelemetrySessionAsync(telemetryBytes);
        }
        #endregion

        #region projects
        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadNewProject();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var openedProject = await SelectProject();

                if (openedProject != null)
                    Project = openedProject;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseProject(Project);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Project != null)
                    SaveProjectAs(Project, GetProjectFileName(Project));
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject(Project);
        }
        private string GetProjectName(string projectName)
        {
            if (String.IsNullOrEmpty(projectName))
                projectName = "<Project Name>";

            var dialog = new InputDialog("New Project Name", projectName);

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                projectName = dialog.Response;
            }
            else
            {
                projectName = String.Empty;
            }

            return projectName;
        }
        private string GetProjectFileName(TelemetryProject project)
        {
            return Path.Combine(ProjectsFolder, $"{Project.Name}.json");
        }
        private void LoadNewProject()
        {
            var cancel = false;
            if (Project != null)
            {
                cancel = CloseProject(Project);
            }

            if (!cancel)
            {
                var projectName = GetProjectName("");

                Project = new TelemetryProject() { Name = projectName };

                DisplayProject(Project);
            }
        }
        private async Task<TelemetryProject> OpenProject(string fileName)
        {
            var project = TelemetryProject.Load(fileName);

            if (project != null)
            {
                if (Session == null)
                {
                    if (!String.IsNullOrEmpty(project.SessionName))
                        Session = await LoadTelemetryFileSessionAsync(project.SessionName);
                }
                else
                    project.SessionName = _sessionFileName;

                DisplayProject(project);
            }

            return project;
        }
        private async Task<TelemetryProject> SelectProject()
        {
            var dialog = new OpenFileDialog()
            {
                InitialDirectory = ProjectsFolder,
                Filter = "Project Files (*.json)|*.json|All Files (*.*)|*.*",
                FilterIndex = 1
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                return await OpenProject(dialog.FileName);
            }
            else
                return null;
        }
        private bool CloseProject(TelemetryProject project)
        {
            var cancel = false;

            if (project != null && ProjectHasChanges(project))
            {
                cancel = PromptToSaveChanges(project);
            }

            if (!cancel)
            {
                ClearProjectDisplay();

                Project = null;
            }

            return cancel;
        }
        private bool PromptToSaveChanges(TelemetryProject project)
        {
            var cancel = false;

            var promptResponse = MessageBox.Show(this, "Save changes to the project?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (promptResponse == DialogResult.Cancel)
            {
                cancel = true;
            }
            else if (promptResponse == DialogResult.Yes)
            {
                SaveProject(project);
            }

            return cancel;
        }
        private bool ProjectHasChanges(TelemetryProject project)
        {
            var newState = TelemetryProject.SerializeProject(project);
            return (project.State != newState);
        }
        private void UpdateProjectState(TelemetryProject project)
        {
            project.SessionName = _sessionFileName;

            project.Displays.Clear();

            foreach (ITelemetryDisplay display in _displayController.Displays)
            {
                if (display is ITelemetryFrameDisplay)
                {
                    project.Displays.Add(((ITelemetryFrameDisplay)display).DisplayInfo);
                }
                else if (display is ITelemetryLapDisplay)
                {
                    project.Displays.Add(((ITelemetryLapDisplay)display).DisplayInfo);
                }
            }
        }

        private void SaveProject(TelemetryProject project)
        {
            var dialog = new SaveFileDialog()
            {
                InitialDirectory = ProjectsFolder,
                Filter = "Project Files (*.json)|*.json|All Files (*.*)|*.*",
                FilterIndex = 1,
                FileName = Path.GetFileName(GetProjectFileName(project))
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                var nameToSaveAs = Path.GetFileNameWithoutExtension(dialog.FileName);
                if (nameToSaveAs != project.Name)
                {
                    project.Name = nameToSaveAs;
                }

                SaveProjectAs(project, dialog.FileName);

                Project = project;
            }
        }
        private void SaveProjectAs(TelemetryProject project, string fileName)
        {
            UpdateProjectState(project);

            project.Save(fileName);

            MessageBox.Show($"Project {project.Name} saved");

            DisplayProjectName(project);
        }

        private void DisplayProject(TelemetryProject project)
        {
            ClearProjectDisplay();

            DisplayProjectName(project);

            foreach (DisplayInfo displayInfo in project.Displays)
            {
                if (displayInfo is LapTimesDisplayInfo)
                {
                    NewLapTimesDisplay((LapTimesDisplayInfo)displayInfo);
                }
                if (displayInfo is LineGraphDisplayInfo)
                {
                    NewLineGraphDisplay((LineGraphDisplayInfo)displayInfo);
                }
            }
        }
        private void DisplayProjectName(TelemetryProject project)
        {

            lblProject.Text = $"Project: [{project.Name}]";

        }
        private void ClearProjectDisplay()
        {
            _displayController.RemoveAllDisplays();

            lblProject.Text = "Project:";
        }
        #endregion
    }
}
