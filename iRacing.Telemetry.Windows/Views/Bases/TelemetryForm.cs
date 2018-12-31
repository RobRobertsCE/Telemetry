using iRacing.Common;
using iRacing.Common.Models;
using iRacing.Telemetry.Data.Ports;
using iRacing.Telemetry.Windows.Models;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views
{
    public partial class TelemetryForm : Form, INotifyPropertyChanged, ITelemetryForm
    {
        #region events        
        private readonly object padlock = new object();
        private event PropertyChangedEventHandler _propertyChanged;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                lock (padlock)
                {
                    _propertyChanged += value;
                }
            }
            remove
            {
                lock (padlock)
                {
                    _propertyChanged -= value;
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (IsLoading) return;

            var handler = _propertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raises LapNumberChangeRequest event to be caught by controller
        /// </summary>
        public event EventHandler<LapNumberChangeRequestEventArgs> LapNumberChangeRequest;
        protected virtual void OnLapNumberChangeRequest(int lapNumber)
        {
            var handler = LapNumberChangeRequest;
            if (handler != null)
            {
                handler.Invoke(this, new LapNumberChangeRequestEventArgs(lapNumber));
            }
        }

        /// <summary>
        /// Raises FrameIndexChangeRequest event to be caught by controller
        /// </summary>
        public event EventHandler<FrameIndexChangeRequestEventArgs> FrameIndexChangeRequest;
        protected virtual void OnFrameIndexChangeRequest(int frameIndex)
        {
            var handler = FrameIndexChangeRequest;
            if (handler != null)
            {
                handler.Invoke(this, new FrameIndexChangeRequestEventArgs(frameIndex));
            }
        }
        #endregion

        #region fields
        private IFieldDefinitionRepository _fieldDefinitionRepository;
        private IFieldDisplayInfoRepository _displayFieldRepository;
        private FormWindowState _lastWindowState = FormWindowState.Minimized;
        #endregion

        #region properties
        public bool IsLoading { get; set; }

        public IWin32Window WindowHandle { get; set; }

        private IServiceProvider _serviceProvider = null;
        public virtual IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                {
                    var services = new ServiceCollection();

                    services.AddTelemetryWindows();

                    _serviceProvider = services.BuildServiceProvider();
                }
                return _serviceProvider;
            }
            set
            {
                _serviceProvider = value;
            }
        }

        IList<IFieldDefinition> _fieldDefinitions = new List<IFieldDefinition>();
        public IList<IFieldDefinition> FieldDefinitions
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

        private IList<IFieldDisplayInfo> _displayInfos = new List<IFieldDisplayInfo>();
        public IList<IFieldDisplayInfo> FieldDisplayInfos
        {
            get
            {
                return _displayInfos;
            }
            set
            {
                _displayInfos = value;
                OnPropertyChanged(nameof(FieldDisplayInfos));
            }
        }

        public ILog Log { get; set; }

        public virtual iRacingTelemetryOptions Options { get; set; }

        private int _currentLapNumber = 0;
        public int CurrentLapNumber
        {
            get
            {
                return _currentLapNumber;
            }
            set
            {
                if (_currentLapNumber != value)
                {
                    _currentLapNumber = value;
                    OnPropertyChanged(nameof(CurrentLapNumber));
                }
            }
        }

        private int _currentLapIndex = 0;
        public int CurrentLapIndex
        {
            get
            {
                return _currentLapIndex;
            }
            set
            {
                if (_currentLapIndex != value)
                {
                    _currentLapIndex = value;
                    OnPropertyChanged(nameof(CurrentLapIndex));
                }
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

        private IList<ILapInfo> _laps = new List<ILapInfo>();
        public virtual IList<ILapInfo> Laps
        {
            get
            {
                return _laps;
            }
            set
            {
                _laps = value;
                HandleLapsChanged();
            }
        }

        private ILapInfo _currentLap = null;
        public virtual ILapInfo CurrentLap
        {
            get
            {
                _currentLap = Session?.TelemetrySessionData?.Laps.FirstOrDefault(l => l.LapNumber == CurrentLapNumber);
                return _currentLap;
            }
            set
            {
                _currentLap = value;
                //OnPropertyChanged(nameof(CurrentLap));
                if (CurrentLap != null)
                {
                    _currentLapNumber = CurrentLap.LapNumber;
                    _currentLapIndex = CurrentLap.LapIndex;
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
            }
        }

        private IFormDisplayInfo _formDisplayInfo = new FormDisplayInfo();
        public IFormDisplayInfo FormDisplayInfo
        {
            get
            {
                return _formDisplayInfo;
            }
            set
            {
                _formDisplayInfo = value;
                OnPropertyChanged(nameof(FormDisplayInfo));
            }
        }

        private AppState _state;
        public AppState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }
        #endregion

        #region ctor/load
        public TelemetryForm()
            : base()
        {
            InitializeComponent();

            WindowHandle = this;
        }

        public TelemetryForm(
            IServiceProvider serviceProvider,
            ILog log,
            iRacingTelemetryOptions options,
            DisplayTypes displayType)
            : this()
        {
            FormDisplayInfo.DisplayType = displayType;
            FormDisplayInfo.Name = displayType.ToString();
            _serviceProvider = (serviceProvider == null) ? throw new ArgumentNullException(nameof(serviceProvider)) : serviceProvider;
            Log = (log == null) ? throw new ArgumentNullException(nameof(log)) : log;
            Options = (options == null) ? throw new ArgumentNullException(nameof(options)) : options;
        }

        ~TelemetryForm()
        {
            PropertyChanged -= this.InternalPropertyChangedAsync;
        }
        #endregion

        #region form events
        protected virtual void TelemetryForm_Load(object sender, EventArgs e)
        {
            try
            {
                _fieldDefinitionRepository = ServiceProvider.GetRequiredService<IFieldDefinitionRepository>();
                _displayFieldRepository = ServiceProvider.GetRequiredService<IFieldDisplayInfoRepository>();

                PropertyChanged += this.InternalPropertyChangedAsync;

                if (!String.IsNullOrEmpty(FormDisplayInfo.Name))
                {
                    this.Text = FormDisplayInfo.Name;
                }

                WindowState = FormDisplayInfo.WindowState;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void TelemetryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormDisplayInfo.Title = this.Text;
            FormDisplayInfo.Height = Height;
            FormDisplayInfo.Width = Width;
            FormDisplayInfo.X = Location.X < 0 ? 0 : Location.X;
            FormDisplayInfo.Y = Location.Y < 0 ? 0 : Location.Y;
            FormDisplayInfo.WindowState = WindowState;
        }
        #endregion

        #region internal property changed handlers
        internal virtual void InternalPropertyChangedAsync(object sender, PropertyChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => { InternalPropertyChangedAsync(this, e); }));
            }
            else
            {
                switch (e.PropertyName)
                {
                    case nameof(Session):
                        {
                            _currentLap = Session?.TelemetrySessionData?.Laps?.FirstOrDefault();
                            int? lapNumber = Session?.TelemetrySessionData?.Laps?.FirstOrDefault().LapNumber;
                            _currentLapNumber = lapNumber.HasValue ? lapNumber.Value : -1;
                            _currentFrameIndex = 0;
                            _laps = Session?.TelemetrySessionData?.Laps;
                            break;
                        }
                    case nameof(FormDisplayInfo):
                        {
                            Text = FormDisplayInfo.Name;
                            break;
                        }
                }

                ProtectedPropertyChangedHandlerAsync(this, e);
            }
        }

        protected virtual void ProtectedPropertyChangedHandlerAsync(object sender, PropertyChangedEventArgs e)
        {

        }

        private void HandleLapsChanged()
        {
            OnPropertyChanged(nameof(Laps));
        }
        #endregion

        #region protected      
        protected virtual void ExceptionHandler(Exception ex)
        {
            if (Log != null)
                Log.Error(ex.Message, ex);
            else
                Console.WriteLine(ex.ToString());

            MessageBox.Show(ex.Message);
        }
        #endregion


        private void TelemetryForm_Resize(object sender, EventArgs e)
        {
            // When window state changes
            if (WindowState != _lastWindowState)
            {
                _lastWindowState = WindowState;
                if (WindowState == FormWindowState.Maximized)
                {
                    // Maximized!
                }
                if (WindowState == FormWindowState.Normal)
                {
                    // Restored!
                }
                OnPropertyChanged(nameof(WindowState));
            }
        }
    }
}
