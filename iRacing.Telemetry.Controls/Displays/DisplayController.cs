using iRacing.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Displays
{
    public class DisplayController : IDisplayController
    {
        #region events
        public event EventHandler<ActiveDisplayChangedEventArgs> ActiveDisplayChanged;
        protected virtual void OnActiveDisplayChanged(ITelemetryDisplay activeDisplay)
        {
            var handler = this.ActiveDisplayChanged;

            if (handler != null)
            {
                handler.Invoke(this, new ActiveDisplayChangedEventArgs(activeDisplay));
            }
        }

        public event EventHandler<DisplayAddedEventArgs> DisplayAdded;
        protected virtual void OnDisplayAdded(ITelemetryDisplay displayAdded)
        {
            var handler = this.DisplayAdded;

            if (handler != null)
            {
                handler.Invoke(this, new DisplayAddedEventArgs(displayAdded));
            }
        }

        public event EventHandler<DisplayRemovedEventArgs> DisplayRemoved;
        protected virtual void OnDisplayRemoved(ITelemetryDisplay displayRemoved)
        {
            var handler = this.DisplayRemoved;

            if (handler != null)
            {
                handler.Invoke(this, new DisplayRemovedEventArgs(displayRemoved));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region properties
        public Form Owner { get; set; }
        public Control LastActiveDisplay { get; private set; }

        public IList<ITelemetryDisplay> Displays { get; set; } = new List<ITelemetryDisplay>();

        private ISessionData _session = null;
        public virtual ISessionData Session
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
                if (_session != null)
                {
                    _lapNumber = _session.Laps.FirstOrDefault().LapNumber;
                    _frameIdx = 0;
                }
                else
                {
                    _lapNumber = null;
                    _frameIdx = null;
                }

                OnPropertyChanged(nameof(Session));
                NotifySessionChanged(_session);
            }
        }

        public virtual ILapInfo CurrentLap
        {
            get
            {
                if (Session == null)
                    return null;

                return Session.Laps.FirstOrDefault(l => l.LapNumber == LapNumber);
            }
        }

        public virtual IList<IFrame> CurrentFrames
        {
            get
            {
                if (Session == null)
                    return null;

                return CurrentLap.LapFrames;
            }
        }

        private int? _frameIdx = null;
        public int? FrameIdx
        {
            get
            {
                return _frameIdx;
            }
            set
            {
                if (_frameIdx == value)
                    return;

                var newFrameIdx = SetFrameIdx(value.Value);

                if (newFrameIdx != null)
                {
                    _frameIdx = newFrameIdx;
                    OnPropertyChanged(nameof(FrameIdx));
                    NotifyFrameIdxChanged(_frameIdx.Value);
                }
            }
        }

        private int? _lapNumber = null;
        public int? LapNumber
        {
            get
            {
                return _lapNumber;
            }
            set
            {
                if (_lapNumber == value)
                    return;

                var newLapNumber = SetLapNumber(value.Value);

                if (newLapNumber != null)
                {
                    _lapNumber = newLapNumber;
                    OnPropertyChanged(nameof(LapNumber));
                    NotifyLapNumberChanged(_lapNumber.Value);
                }
            }
        }

        public int? MinLapNumber
        {
            get
            {
                if (Session == null)
                    return null;

                return Session.Laps.Min(l => l.LapNumber);
            }
        }
        public int? MaxLapNumber
        {
            get
            {
                if (Session == null)
                    return null;

                return Session.Laps.Max(l => l.LapNumber);
            }
        }
        public int? MinFrameIdx
        {
            get
            {
                if (Session == null)
                    return null;

                return 0;
            }
        }
        public int? MaxFrameIdx
        {
            get
            {
                if (Session == null)
                    return null;

                return Session.Frames.Count - 1;
            }
        }
        public int? MinLapFrameIdx
        {
            get
            {
                if (Session == null)
                    return null;

                return CurrentLap.FrameIndex;
            }
        }
        public int? MaxLapFrameIdx
        {
            get
            {
                if (Session == null)
                    return null;

                return CurrentLap.FrameIndex + CurrentLap.LapFrames.Count - 1;
            }
        }
        #endregion

        #region ctor
        public DisplayController(Form owner)
        {
            Owner = owner;
        }
        #endregion

        #region public
        public void AddDisplay(ITelemetryDisplay display)
        {
            display.CloseDisplayRequest += Display_CloseDisplayRequest;
            ((Control)display).GotFocus += DisplayController_GotFocus;

            ((Form)display).MdiParent = Owner;
            ((Form)display).Show();

            if (display is ITelemetryFrameDisplay)
            {
                if (Session != null)
                {
                    ((ITelemetryFrameDisplay)display).Frames = CurrentLap.LapFrames;
                    ((ITelemetryFrameDisplay)display).SetFrameIdx(FrameIdx);
                }
                ((ITelemetryFrameDisplay)display).PropertyChanged += DisplayController_PropertyChanged;
            }
            else if (display is ITelemetryLapDisplay)
            {
                if (Session != null)
                {
                    ((ITelemetryLapDisplay)display).Laps = Session.Laps;
                    ((ITelemetryLapDisplay)display).SetLapNumber(LapNumber);
                }
                ((ITelemetryLapDisplay)display).PropertyChanged += DisplayController_PropertyChanged;
            }

            Displays.Add(display);

            OnDisplayAdded(display);

            ActivateDisplay(display);
        }

        public void ActivateDisplay(ITelemetryDisplay display)
        {
            display.BringToFront();
            display.Focus();

            OnActiveDisplayChanged(display);
        }

        public void RemoveDisplay(ITelemetryDisplay display)
        {
            var displayToRemove = (Control)Owner.MdiChildren.OfType<ITelemetryDisplay>().FirstOrDefault(d => d.Id == display.Id);

            if (displayToRemove == null)
            {
                throw new ArgumentException($"Could not find display to remove having Id {display.Id}.");
            }

            display.CloseDisplayRequest -= Display_CloseDisplayRequest;

            if (display is ITelemetryFrameDisplay)
            {
                ((ITelemetryFrameDisplay)display).PropertyChanged -= DisplayController_PropertyChanged;
            }
            else if (display is ITelemetryLapDisplay)
            {
                ((ITelemetryLapDisplay)display).PropertyChanged -= DisplayController_PropertyChanged;
            }

            Owner.Controls.Remove(displayToRemove);

            Displays.Remove((ITelemetryDisplay)displayToRemove);

            OnDisplayRemoved((ITelemetryDisplay)displayToRemove);

            display.Dispose();
        }

        public void RemoveAllDisplays()
        {
            foreach (ITelemetryDisplay display in Owner.MdiChildren.OfType<ITelemetryDisplay>().ToList())
            {
                RemoveDisplay(display);
            }
        }

        public void ClearAllDisplays()
        {
            foreach (ITelemetryDisplay display in Owner.Controls.OfType<ITelemetryDisplay>().ToList())
            {
                display.ClearDisplay();
            }
        }

        public int? NextLap()
        {
            if (Session == null)
                return null;

            LapNumber = SetLapNumber(_lapNumber.Value + 1);

            return LapNumber;
        }
        public int? PreviousLap()
        {
            if (Session == null)
                return null;

            LapNumber = SetLapNumber(_lapNumber.Value - 1);

            return LapNumber;
        }
        public int? FirstLap()
        {
            if (Session == null)
                return null;

            LapNumber = SetLapNumber(MinLapNumber.Value);

            return LapNumber;
        }
        public int? LastLap()
        {
            if (Session == null)
                return null;

            LapNumber = SetLapNumber(MaxLapNumber.Value);

            return LapNumber;
        }

        public int? NextFrame()
        {
            if (Session == null)
                return null;

            FrameIdx = SetFrameIdx(_frameIdx.Value + 1);

            return FrameIdx;
        }
        public int? PreviousFrame()
        {
            if (Session == null)
                return null;

            FrameIdx = SetFrameIdx(_frameIdx.Value - 1);

            return FrameIdx;
        }
        public int? FirstFrame()
        {
            if (Session == null)
                return null;

            FrameIdx = SetFrameIdx(MinFrameIdx.Value);

            return FrameIdx;
        }
        public int? LastFrame()
        {
            if (Session == null)
                return null;

            FrameIdx = SetFrameIdx(MaxFrameIdx.Value);

            return FrameIdx;
        }
        #endregion

        #region protected
        protected virtual int? SetLapNumber(int newLapNumber)
        {
            if (Session == null)
                return null;

            if (newLapNumber < MinLapNumber)
                newLapNumber = MinLapNumber.Value;
            else if (newLapNumber > MaxLapNumber)
                newLapNumber = MaxLapNumber.Value;

            return newLapNumber;
        }
        protected virtual int? SetFrameIdx(int newFrameIdx)
        {
            if (Session == null)
                return null;

            if (newFrameIdx < MinFrameIdx)
                newFrameIdx = MinFrameIdx.Value;
            else if (newFrameIdx > MaxFrameIdx)
                newFrameIdx = MaxFrameIdx.Value;

            return newFrameIdx;
        }

        protected virtual void DisplayController_GotFocus(object sender, EventArgs e)
        {
            LastActiveDisplay = (Control)sender;
        }

        protected virtual void DisplayController_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "FrameIdx":
                    {

                        break;
                    }
                case "LapNumber":
                    {

                        break;
                    }
                default:
                    {

                        break;
                    }
            }
        }

        protected virtual void NotifySessionChanged(ISessionData session)
        {
            foreach (ITelemetryLapDisplay display in Owner.MdiChildren.OfType<ITelemetryLapDisplay>())
            {
                display.Laps = Session?.Laps;

                display.SessionChanged(Session);

                NotifyLapNumberChanged(LapNumber);
            }

            foreach (ITelemetryFrameDisplay display in Owner.MdiChildren.OfType<ITelemetryFrameDisplay>())
            {
                display.Frames = Session?.Frames;

                display.SessionChanged(Session);

                NotifyFrameIdxChanged(FrameIdx);
            }
        }

        protected virtual void NotifyLapNumberChanged(ITelemetryLapDisplay sender, int lapNumber)
        {
            foreach (ITelemetryLapDisplay display in Owner.Controls.OfType<ITelemetryLapDisplay>().Where(d => d.Id != sender.Id))
            {
                display.SetLapNumber(lapNumber);
            }
        }
        protected virtual void NotifyLapNumberChanged(int? lapNumber)
        {
            foreach (LineGraphDisplay display in Owner.MdiChildren.OfType<LineGraphDisplay>())
            {
                ((ITelemetryFrameDisplay)display).Frames = CurrentLap.LapFrames;
            }
        }

        protected virtual void NotifyFrameIdxChanged(ITelemetryFrameDisplay sender, int frameIdx)
        {
            foreach (ITelemetryFrameDisplay display in Owner.MdiChildren.OfType<ITelemetryFrameDisplay>().Where(d => d.Id != sender.Id))
            {
                display.SetFrameIdx(frameIdx);
            }
        }
        protected virtual void NotifyFrameIdxChanged(int? frameIdx)
        {
            foreach (LineGraphDisplay display in Owner.MdiChildren.OfType<LineGraphDisplay>())
            {
                display.SetFrameIdx(frameIdx);
            }
        }

        protected virtual void Display_CloseDisplayRequest(object sender, EventArgs e)
        {
            RemoveDisplay((ITelemetryFrameDisplay)sender);
        }
        #endregion
    }
}
