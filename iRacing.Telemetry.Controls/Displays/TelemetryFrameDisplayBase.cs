using iRacing.Common.Models;
using System.Collections.Generic;

namespace iRacing.Telemetry.Controls.Displays
{
    public partial class TelemetryFrameDisplayBase : DisplayBase, ITelemetryFrameDisplay
    {
        #region events
        public event FrameChangedEventHandler FrameChanged;
        protected virtual void OnFrameChanged(int newFrameIdx)
        {
            var handler = this.FrameChanged;

            if (handler != null)
            {
                handler.Invoke(this, new FrameChangedEventArgs(newFrameIdx));
            }
        }
        #endregion

        #region properties
        public LineGraphDisplayInfo DisplayInfo { get; set; }

        private IList<IFrame> _frames;
        public IList<IFrame> Frames
        {
            get
            {
                return _frames;
            }
            set
            {
                _frames = value;
                OnPropertyChanged(nameof(Frames));
                DisplayFrames();
            }
        }

        private IFieldDefinition _field;
        public IFieldDefinition Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;
                OnPropertyChanged(nameof(Field));
            }
        }

        private int? _frameIdx = null;
        public int? FrameIdx
        {
            get
            {
                return _frameIdx;
            }
            protected set
            {
                _frameIdx = value;
                OnPropertyChanged(nameof(FrameIdx));
                DisplaySelectedFrameIdx();
            }
        }
        #endregion

        #region ctor
        public TelemetryFrameDisplayBase(IList<IFrame> frames, IFieldDefinition field)
           : this()
        {
            _frames = frames;
        }

        public TelemetryFrameDisplayBase(IFieldDefinition field)
            : this()
        {
            _field = field;
        }

        public TelemetryFrameDisplayBase()
            : base()
        {
            InitializeComponent();
            DisplayType = DisplayType.LineGraph;
        }
        #endregion

        #region public
        // External call to set the frame index. Do not raise event.
        public void SetFrameIdx(int? frameIdx)
        {
            _frameIdx = frameIdx;
        }
        #endregion

        #region protected
        protected virtual void DisplayFrames()
        {
            ClearFramesDisplay();

            if (Frames == null || Frames.Count == 0)
                return;

            if (Field == null)
                return;


            DisplaySelectedFrameIdx();
        }

        // Display the frame index vertical line
        protected virtual void DisplaySelectedFrameIdx()
        {

        }

        protected virtual void ClearFramesDisplay()
        {

        }
        #endregion
    }
}
