using iRacing.Telemetry.Windows.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views.Displays
{
    public partial class DisplayForm : Form, INotifyPropertyChanged
    {
        #region events
      
        // do not override, use SessionChanged
        public virtual void SessionChangedHandler(object sender, ITelemetrySession session)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => { SessionChanged(session); }));
            }
            else
            {
                SessionChanged(session);

                Session = session;
            }
        }
        #endregion



        public DisplayForm()
            : base()
        {
            InitializeComponent();

            DisplayInfo = new TelemetryWindowDisplayInfo();
        }

     
        protected virtual void SessionChanged(ITelemetrySession session)
        {

        }

        //protected virtual void ExceptionHandler(Exception ex)
        //{
        //    Console.WriteLine(ex.ToString());
        //    MessageBox.Show(ex.Message);
        //}
    }
}
