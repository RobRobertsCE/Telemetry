using iRacing.Common.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Displays
{
    public partial class DisplayBase : Form, ITelemetryDisplay
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event EventHandler CloseDisplayRequest;
        protected virtual void OnCloseDisplayRequest()
        {
            var handler = this.CloseDisplayRequest;

            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }


        public Guid Id { get; private set; }

        public virtual DisplayType DisplayType { get; set; }

        public DisplayBase()
        {
            InitializeComponent();

            Id = Guid.NewGuid();
        }

        public virtual void ClearDisplay()
        {

        }

        public virtual void SessionChanged(ISessionData session)
        {

        }

        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }
    }
}
