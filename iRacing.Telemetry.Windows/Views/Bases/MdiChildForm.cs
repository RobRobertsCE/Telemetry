using iRacing.Common;
using iRacing.Telemetry.Windows.Models;
using System;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views
{
    public partial class MdiChildForm : TelemetryForm, IMdiChildForm
    {
        #region events
        // Ask the controller to close this window.
        public event EventHandler CloseWindowRequest;
        protected virtual void OnCloseWindowRequest(IWin32Window windowHandle)
        {
            var handler = CloseWindowRequest;
            if (handler != null)
            {
                handler.Invoke(this, new CloseWindowRequestEventArgs(windowHandle));
            }
        }
        #endregion

        #region ctor
        public MdiChildForm()
            : base()
        {
            InitializeComponent();
        }

        public MdiChildForm(
            IServiceProvider serviceProvider,
            log4net.ILog log,
            iRacingTelemetryOptions options,
            DisplayTypes displayType)
           : base(serviceProvider,
                 log,
                 options,
                 displayType)
        {
            InitializeComponent();
        }
        #endregion

        #region public
        // controller calls this to close this window.
        public virtual void CloseWindow()
        {
            
            Close();
        }
        public virtual void BeforeSave()
        {

        }
        #endregion

        FormWindowState LastWindowState = FormWindowState.Minimized;
        private void MdiChildForm_Resize(object sender, EventArgs e)
        {
            // When window state changes
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;
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
