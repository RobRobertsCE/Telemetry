using iRacing.Common;
using iRacing.Telemetry.Windows.Models;
using iRacing.Telemetry.Windows.Ports;
using log4net;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views
{
    public partial class MdiParentForm : TelemetryForm, IMdiParentForm
    {
        #region events
        public event EventHandler<NewChildWindowRequestEventArgs> NewChildWindowRequest;
        protected virtual void OnNewChildWindowRequest()
        {
            var handler = NewChildWindowRequest;
            if (handler != null)
            {
                handler.Invoke(this, new NewChildWindowRequestEventArgs());
            }
        }
        public event EventHandler<CloseWindowRequestEventArgs> CloseChildWindowRequest;
        protected virtual void OnCloseChildWindowRequest(IWin32Window windowHandle)
        {
            var handler = CloseChildWindowRequest;
            if (handler != null)
            {
                handler.Invoke(this, new CloseWindowRequestEventArgs(windowHandle));
            }
        }
        #endregion

        private MruMenu _projectMru;
        private MruMenu _sessionMru;

        #region properties
        IViewController _controller = null;
        public virtual IViewController Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                _controller = value;
                _controller.PropertyChanged += _controller_PropertyChanged;
                _controller.ControllerStateChanged += _controller_StateChanged;
                _controller.MessageBoxRequest += _controller_MessageBoxRequest;
                _controller.FileDialogRequest += _controller_FileDialogRequest;
            }
        }
        #endregion

        #region ctor / load / closing
        public MdiParentForm()
            : base()
        {

        }

        public MdiParentForm(
            IViewController controller,
            IServiceProvider serviceProvider,
            ILog log,
            iRacingTelemetryOptions options)
          : base(
            serviceProvider,
            log,
            options,
            DisplayTypes.MdiParent)
        {
            InitializeComponent();

            Controller = controller;

            Controller.SetParent(this.WindowHandle);
        }

        private void MdiParentForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            var projectMruPlaceholder = new MruPlaceholderToolStripMenuItem() { Text = "<mru>" };
            fileToolStripMenuItem.DropDownItems.Insert(10, projectMruPlaceholder);

            var sessionMruPlaceholder = new MruPlaceholderToolStripMenuItem() { Text = "<mru>" };
            sessionToolStripMenuItem.DropDownItems.Insert(7, sessionMruPlaceholder);

            var projectMruFile = Path.Combine(Options.AppDirectory, "projectsMru.json");
            _projectMru = MruMenu.Load(projectMruFile);
            _projectMru.MruItemSelected += _projectMru_MruItemSelected;
            fileToolStripMenuItem.DropDownOpening += FileToolStripMenuItem_DropDownOpening;

            var sessionMruFile = Path.Combine(Options.AppDirectory, "sessionsMru.json");
            _sessionMru = MruMenu.Load(sessionMruFile);
            _sessionMru.MruItemSelected += _sessionMru_MruItemSelected;
            sessionToolStripMenuItem.DropDownOpening += SessionToolStripMenuItem_DropDownOpening;

            _sessionMru.SetMenuItemState(false);
        }

        private async void _sessionMru_MruItemSelected(object sender, MruMenuItem e)
        {
            await Controller.OpenSessionAsync(e.FileName);
        }

        private async void _projectMru_MruItemSelected(object sender, MruMenuItem e)
        {
            await Controller.OpenProjectAsync(e.FileName);
        }

        private void SessionToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            _sessionMru.LoadParentMenu(sessionToolStripMenuItem);
        }

        private void FileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            _projectMru.LoadParentMenu(fileToolStripMenuItem);
        }

        private void MdiParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormDisplayInfo.Title = this.Text;
            FormDisplayInfo.Height = Height;
            FormDisplayInfo.Width = Width;
            FormDisplayInfo.X = Location.X < 0 ? 0 : Location.X;
            FormDisplayInfo.Y = Location.Y < 0 ? 0 : Location.Y;
            FormDisplayInfo.WindowState = WindowState;
        }
        #endregion

        #region protected
        protected virtual void ControllerStateChanged(TelemetryAppStateChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => { ControllerStateChanged(e); }));
            }
            else
            {
                mnuMainViewMenu.Enabled = e.NewState.HasFlag(AppState.Ready);
                tlsMainViewToolStrip.Enabled = e.NewState.HasFlag(AppState.Ready);
                tlsSessionToolStrip.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);

                openProjectToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.Ready);
                newProjectToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.Ready);
                closeProjectToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                saveProjectAsToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                saveProjectToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);

                btnOpenProject.Enabled = e.NewState.HasFlag(AppState.Ready);
                btnNewProject.Enabled = e.NewState.HasFlag(AppState.Ready);
                btnCloseProject.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                btnSaveProject.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                btnSaveProjectAs.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);

                openToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                closeSessionToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                loadSavedSessionToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                saveSessionToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                saveSessionToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                btnOpenSession.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                btnCloseSession.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                _sessionMru?.SetMenuItemState(e.NewState.HasFlag(AppState.ProjectLoaded));

                btnNewHistogramDisplay.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                btnNewLapTimesDisplay.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                btnNewWaveformDisplay.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                btnNewTrackMapDisplay.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                btnSetupDisplay.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                btnSessionDetailsDisplay.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);

                histogramToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                lapTimesToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                waveformToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                trackMapToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                setupToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                sessionDetailsToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);

                btnFirstLap.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                btnNextLap.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                btnPreviousLap.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                btnLastLap.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                btnFastestLap.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);

                btnResetZoom.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                btnZoomIn.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);
                btnZoomOut.Enabled = e.NewState.HasFlag(AppState.SessionLoaded);

                copyToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;

                btnCut.Enabled = false;
                btnCopy.Enabled = false;
                btnPaste.Enabled = false;
                btnDelete.Enabled = false;

                fieldDefinitionsToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.Ready);
                btnFieldDefinitions.Enabled = e.NewState.HasFlag(AppState.Ready);
                functionEditorToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.Ready);
                btnFunctionEditor.Enabled = e.NewState.HasFlag(AppState.Ready);
                trackMapBuilderToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.Ready);
                btnTrackMapBuilder.Enabled = e.NewState.HasFlag(AppState.Ready);
                optionsToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.Ready);
                btnOptions.Enabled = e.NewState.HasFlag(AppState.Ready);

                btnSaveDisplay.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                saveDisplayToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                saveDisplayToolStripMenuItem1.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                loadDisplayToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);

                openDisplayToolStripMenuItem.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);
                btnOpenDisplay.Enabled = e.NewState.HasFlag(AppState.ProjectLoaded);

                Console.WriteLine($"Old State: {e.OldState.ToString()}   New State: {e.NewState.ToString()}");

                UpdateProject(Controller?.Project);
                UpdateSession(Controller?.Session);
            }
        }
        protected virtual void ControllerPropertyChanged(PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case ("Project"):
                    {
                        UpdateProject(Controller?.Project);
                        UpdateSessionName(Controller?.Session);
                        UpdateSetupName(Controller?.Session);
                        UpdateVehicleName(Controller?.Session);
                        UpdateSessionLaps();
                        break;
                    }
                case ("Project.Name"):
                    {
                        UpdateProject(Controller?.Project);
                        break;
                    }
                case ("Project.FileName"):
                    {
                        UpdateProjectMruMenu(Controller?.Project);
                        break;
                    }
                case ("Session.Name"):
                    {
                        UpdateSessionName(Controller?.Session);
                        break;
                    }
                case ("Session.FileName"):
                    {
                        UpdateSessionMruMenu(Controller?.Session);
                        break;
                    }
                case ("MdiChildren"):
                    {
                        break;
                    }
                case ("FieldDefinitions"):
                    {
                        break;
                    }
                case ("FieldDisplayInfos"):
                    {
                        break;
                    }
                case ("CurrentLap"):
                    {
                        UpdateSessionLaps();
                        break;
                    }
                case ("CurrentLapNumber"):
                    {
                        UpdateSessionLaps();
                        break;
                    }
                case ("CurrentFrameIndex"):
                    {
                        UpdateSessionLaps();
                        break;
                    }
            }
        }
        protected virtual DialogResult ControllerDisplayMessageBox(IWin32Window owner, MessageBoxRequestEventArgs e)
        {
            if (this.InvokeRequired)
            {
                e.DialogResult = (DialogResult)Invoke(new Func<DialogResult>(
                             () => { return MessageBox.Show(this, e.Prompt, e.Title, e.Buttons, e.Icon); }));
            }
            else
            {
                e.DialogResult = MessageBox.Show(this, e.Prompt, e.Title, e.Buttons, e.Icon);
            }

            return e.DialogResult;
        }
        protected virtual DialogResult ControllerDisplaySaveFileDialog(IWin32Window owner, FileDialogRequestEventArgs e)
        {
            if (this.InvokeRequired)
            {
                e.DialogResult = (DialogResult)Invoke(new Func<DialogResult>(
                             () =>
                             {
                                 var dialog = new SaveFileDialog()
                                 {
                                     InitialDirectory = e.InitialDirectory,
                                     Filter = e.Filter,
                                     FilterIndex = e.FilterIndex,
                                     FileName = e.FileName
                                 };

                                 e.DialogResult = dialog.ShowDialog(owner);

                                 if (e.DialogResult == DialogResult.OK)
                                 {
                                     e.FileName = dialog.FileName;
                                 }

                                 return e.DialogResult;
                             }));
            }
            else
            {
                var dialog = new SaveFileDialog()
                {
                    InitialDirectory = e.InitialDirectory,
                    Filter = e.Filter,
                    FilterIndex = e.FilterIndex,
                    FileName = Path.GetFileName(e.FileName)
                };

                e.DialogResult = dialog.ShowDialog(this);

                if (e.DialogResult == DialogResult.OK)
                {
                    e.FileName = dialog.FileName;
                }
            }

            return e.DialogResult;
        }
        protected virtual DialogResult ControllerDisplayOpenFileDialog(IWin32Window owner, FileDialogRequestEventArgs e)
        {
            if (this.InvokeRequired)
            {
                e.DialogResult = (DialogResult)Invoke(new Func<DialogResult>(
                             () =>
                             {
                                 var dialog = new OpenFileDialog()
                                 {
                                     InitialDirectory = e.InitialDirectory,
                                     Filter = e.Filter,
                                     FilterIndex = e.FilterIndex,
                                     FileName = e.FileName
                                 };

                                 e.DialogResult = dialog.ShowDialog(owner);

                                 if (e.DialogResult == DialogResult.OK)
                                 {
                                     e.FileName = dialog.FileName;
                                 }

                                 return e.DialogResult;
                             }));
            }
            else
            {
                var dialog = new OpenFileDialog()
                {
                    InitialDirectory = e.InitialDirectory,
                    Filter = e.Filter,
                    FilterIndex = e.FilterIndex,
                    FileName = e.FileName
                };

                e.DialogResult = dialog.ShowDialog(this);

                if (e.DialogResult == DialogResult.OK)
                {
                    e.FileName = dialog.FileName;
                }
            }

            return e.DialogResult;
        }

        protected virtual void UpdateProject(IProject project)
        {
            UpdateProjectMruMenu(project);

            if (project == null)
            {
                lblProjectName.Text = "No project";
            }
            else
            {
                lblProjectName.Text = project.Name;
            }
        }
        protected virtual void UpdateProjectMruMenu(IProject project)
        {
            if (project != null)
                _projectMru.AddItem(project.FileName);
        }

        protected virtual void UpdateSession(ISession session)
        {
            UpdateSessionName(session);
            UpdateSessionMruMenu(session);
            UpdateSetupName(session);
            UpdateVehicleName(session);
            UpdateTrackName(session);
            UpdateSessionMruMenu(session);
        }
        protected virtual void UpdateSessionMruMenu(ISession session)
        {
            if (session != null)
                _sessionMru.AddItem(session.FileName);
        }
        protected virtual void UpdateSessionName(ISession session)
        {
            if (session == null)
            {
                lblSession.Text = "No session";
            }
            else
            {
                lblSession.Text = Path.GetFileNameWithoutExtension(session.SessionFileName);
            }
        }
        protected virtual void UpdateSetupName(ISession session)
        {
            if (session == null)
            {
                lblSetup.Text = "No setup";
            }
            else
            {
                lblSetup.Text = session.Setup;
            }
        }
        protected virtual void UpdateVehicleName(ISession session)
        {
            if (session == null)
            {
                lblVehicle.Text = "No vehicle";
            }
            else
            {
                lblVehicle.Text = session.Vehicle;
            }
        }
        protected virtual void UpdateTrackName(ISession session)
        {
            if (session == null)
            {
                lblTrack.Text = "No track";
            }
            else
            {
                lblTrack.Text = session.Track;
            }
        }

        protected virtual void UpdateSessionLaps()
        {
            if (Controller.Session == null)
            {
                lblSessionLaps.Text = "0 of 0 laps";
            }
            else
            {
                var startLap = Controller.Session.TelemetrySessionData.Laps.Min(l => l.LapNumber);
                var endLap = Controller.Session.TelemetrySessionData.Laps.Max(l => l.LapNumber);
                lblSessionLaps.Text = $"{Controller.CurrentLapNumber} of Laps {startLap} to {endLap} [{Controller.CurrentFrameIndex}]";
            }
        }

        protected virtual void NewProject()
        {
            Controller.NewProject();
        }
        protected virtual async Task OpenProjectAsync()
        {
            await Controller.OpenProjectAsync();
        }
        protected virtual void CloseProject()
        {
            Controller.CloseProject();
        }
        protected virtual void SaveProject()
        {
            Controller.SaveProject();
        }
        protected virtual void SaveProjectAs()
        {
            Controller.SaveProjectAs();
        }

        protected virtual async Task OpenSessionAsync()
        {
            await Controller.OpenSessionAsync();
        }
        protected virtual void CloseSession()
        {
            Controller.CloseSession();
        }
        protected virtual void NewDisplayAsync(DisplayTypes displayType)
        {
            Controller.LoadNewDisplay(displayType);
        }
        protected virtual void DisplayFieldDefinitionsView()
        {
            var dialog = new FieldDefinitionsView(Controller.ServiceProvider);

            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                // do whatever...
            }
        }
        protected virtual void DisplayFunctionEditorView()
        {
            var dialog = new FunctionsView();

            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                // do whatever...
            }
        }
        protected virtual void DisplayOptionsView()
        {
            var dialog = new OptionsView();

            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                // do whatever...
            }
        }
        protected virtual void DisplayTrackMapBuilderView()
        {
            var dialog = new TrackMapBuilderView();

            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                // do whatever...
            }
        }

        protected virtual void OpenDisplay()
        {
            try
            {
                _controller.OpenDisplay();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        protected virtual void SaveDisplay()
        {
            try
            {
                _controller.SaveDisplay();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        protected virtual async Task PerformCutAsync()
        {
            await Task.Run(() => { Console.WriteLine("PerformCutAsync"); });
        }
        protected virtual async Task PerformCopyAsync()
        {
            await Task.Run(() => { Console.WriteLine("PerformCopyAsync"); });
        }
        protected virtual async Task PerformPasteAsync()
        {
            await Task.Run(() => { Console.WriteLine("PerformPasteAsync"); });
        }
        protected virtual async Task PerformDeleteAsync()
        {
            await Task.Run(() => { Console.WriteLine("PerformDeleteAsync"); });
        }

        protected virtual async Task FirstLapAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("FirstLapAsync");

                var lap = Controller?.Session?.TelemetrySessionData?.Laps?.FirstOrDefault();
                if (lap != null)
                    Controller.CurrentLapNumber = lap.LapNumber;
            });
        }
        protected virtual async Task PreviousLapAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("PreviousLapAsync");

                var lap = Controller?.Session?.TelemetrySessionData?.Laps?.LastOrDefault(l => l.LapNumber < Controller.CurrentLapNumber);
                if (lap != null)
                    Controller.CurrentLapNumber = lap.LapNumber;
            });
        }
        protected virtual async Task NextLapAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("NextLapAsync");

                var lap = Controller?.Session?.TelemetrySessionData?.Laps?.FirstOrDefault(l => l.LapNumber > Controller.CurrentLapNumber);
                if (lap != null)
                    Controller.CurrentLapNumber = lap.LapNumber;
            });
        }
        protected virtual async Task LastLapAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("LastLapAsync");

                var lap = Controller?.Session?.TelemetrySessionData?.Laps?.LastOrDefault();
                if (lap != null)
                    Controller.CurrentLapNumber = lap.LapNumber;
            });
        }
        protected virtual async Task FastestLapAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("FastestLapAsync");

                var lap = Controller?.
                        Session?.
                        TelemetrySessionData?.
                        Laps?.
                        Where(l => l.LapTime > 0).
                        OrderBy(l => l.LapTime).
                        FirstOrDefault();
                if (lap != null)
                    Controller.CurrentLapNumber = lap.LapNumber;
            });
        }

        protected virtual async Task ZoomInAsync()
        {
            await Task.Run(() => { Console.WriteLine("ZoomInAsync"); });
        }
        protected virtual async Task ZoomOutAsync()
        {
            await Task.Run(() => { Console.WriteLine("ZoomOutAsync"); });
        }
        protected virtual async Task ResetZoomAsync()
        {
            await Task.Run(() => { Console.WriteLine("ResetZoomAsync"); });
        }
        #endregion

        #region private
        private void _controller_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                ControllerPropertyChanged(e);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void _controller_StateChanged(object sender, TelemetryAppStateChangedEventArgs e)
        {
            try
            {
                ControllerStateChanged(e);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void _controller_MessageBoxRequest(object sender, MessageBoxRequestEventArgs e)
        {
            try
            {
                e.DialogResult = ControllerDisplayMessageBox(this, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void _controller_FileDialogRequest(object sender, FileDialogRequestEventArgs e)
        {
            try
            {
                if (e.FileDialogType == FileDialogRequestEventArgs.FileDialogTypes.Open)
                {
                    e.DialogResult = ControllerDisplayOpenFileDialog(this, e);
                }
                else if (e.FileDialogType == FileDialogRequestEventArgs.FileDialogTypes.Save)
                {
                    e.DialogResult = ControllerDisplaySaveFileDialog(this, e);
                }
                else if (e.FileDialogType == FileDialogRequestEventArgs.FileDialogTypes.SelectFolder)
                {
                    throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnSaveDisplay_Click(object sender, EventArgs e)
        {
            SaveDisplay();
        }

        private void saveDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDisplay();
        }


        private void loadDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDisplay();
        }

        private void saveDisplayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveDisplay();
        }
        private void openDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDisplay();
        }

        private void btnOpenDisplay_Click(object sender, EventArgs e)
        {
            OpenDisplay();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewProject();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void btnNewProject_Click(object sender, EventArgs e)
        {
            try
            {
                NewProject();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void btnOpenProject_Click(object sender, EventArgs e)
        {
            try
            {
                await OpenProjectAsync();
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
                await OpenProjectAsync();
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
                CloseProject();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void btnCloseProject_Click(object sender, EventArgs e)
        {
            try
            {
                CloseProject();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            try
            {
                SaveProject();
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
                SaveProject();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveProjectAs();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void btnSaveProjectAs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveProjectAs();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                await OpenSessionAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnOpenSession_Click(object sender, EventArgs e)
        {
            try
            {
                await OpenSessionAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void closeSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseSession();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void btnCloseSession_Click(object sender, EventArgs e)
        {
            try
            {
                CloseSession();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void lapTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.LapTimes);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void btnNewLapTimesDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.LapTimes);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void waveformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.Waveform);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void btnNewWaveformDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.Waveform);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.Histogram);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void btnNewHistogramDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.Histogram);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnNewTrackMapDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.TrackMap);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void trackMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.TrackMap);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.Setup);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void btnSetupDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.Setup);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnSessionDetailsDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.SessionDetails);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void sessionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewDisplayAsync(DisplayTypes.SessionDetails);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void fieldDefinitionsItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayFieldDefinitionsView();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void functionEditorItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayFunctionEditorView();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void optionsItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayOptionsView();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void trackMapBuilderItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayTrackMapBuilderView();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                await PerformCutAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnCut_Click(object sender, EventArgs e)
        {
            try
            {
                await PerformCutAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                await PerformCopyAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                await PerformCopyAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                await PerformPasteAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnPaste_Click(object sender, EventArgs e)
        {
            try
            {
                await PerformPasteAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                await PerformDeleteAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                await PerformDeleteAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void btnZoomIn_Click(object sender, EventArgs e)
        {
            try
            {
                await ZoomInAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnResetZoom_Click(object sender, EventArgs e)
        {
            try
            {
                await ZoomOutAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnZoomOut_Click(object sender, EventArgs e)
        {
            try
            {
                await ResetZoomAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private async void btnFirstLap_Click(object sender, EventArgs e)
        {
            try
            {
                await FirstLapAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnPreviousLap_Click(object sender, EventArgs e)
        {
            try
            {
                await PreviousLapAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnNextLap_Click(object sender, EventArgs e)
        {
            try
            {
                await NextLapAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnLastLap_Click(object sender, EventArgs e)
        {
            try
            {
                await LastLapAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnFastestLap_Click(object sender, EventArgs e)
        {
            try
            {
                await FastestLapAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }
        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }
        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }
        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }
        #endregion

    }
}
