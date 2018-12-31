using iRacing.Common;
using iRacing.Common.Models;
using iRacing.Telemetry.Maps.Models;
using iRacing.Telemetry.Maps.Ports;
using iRacing.Telemetry.Windows.Models;
using iRacing.TelemetryFile;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views.Displays
{
    public partial class TrackMapDisplay : MdiChildForm, INotifyPropertyChanged
    {
        #region events     
        protected override async void ProtectedPropertyChangedHandlerAsync(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(CurrentLapNumber):
                    {
                        _suppressUpdate = true;
                        SetCurrentLap(CurrentLapNumber);
                        _suppressUpdate = false;
                        break;
                    }
                case nameof(CurrentFrameIndex):
                    {

                        break;
                    }
                case nameof(Laps):
                    {
                        ParseTelemetryLapFrames(Laps);
                        break;
                    }
                case nameof(LapViews):
                    {
                        UpdateActiveLapViews(LapViews);
                        break;
                    }
                case nameof(ActiveLapViews):
                    {
                        DisplayActiveLapViews(ActiveLapViews);
                        break;
                    }
                case (nameof(HideInOutLaps)):
                    {
                        UpdateActiveLapViews(LapViews);
                        break;
                    }
                case (nameof(TrackShortName)):
                    {
                        await GetTrackMap(TrackShortName);
                        break;
                    }
                case (nameof(TrackMapImage)):
                    {
                        picMap.Image = TrackMapImage;
                        break;
                    }
                case (nameof(TrackMapInfo)):
                    {
                        await DisplayTrackMap(TrackMapInfo);
                        break;
                    }
                case ("Session"):
                    {
                        ParseTelemetrySession(Session);
                        break;
                    }
            }
        }
        #endregion

        #region fields
        private int _panelWidth;
        private int _mapZoom = 18;
        bool _manualLapSelection = false;
        int _minLap = 0;
        int _maxLap = 0;
        private float _telemetryCenterX = 0;
        private float _telemetryCenterY = 0;
        string _trackName = string.Empty;
        private IImageHelper _imageHelper;
        private ITrackMapService _mapService;
        private ITrackMapRepository _trackMapRepo;
        bool _loading = true;
        private float _imageZoomFactor = 1.0F;
        private bool _suppressUpdate = false;
        #endregion

        #region protected classes
        protected class FramePosition : TrackCoordinate
        {
            public float X { get; set; }
            public float Y { get; set; }
            public int LapNumber { get; set; }
            public int FrameIdx { get; set; }
        }
        #endregion

        #region properties
        private bool _hideInOutLaps = true;
        protected bool HideInOutLaps
        {
            get
            {
                return _hideInOutLaps;
            }
            set
            {
                _hideInOutLaps = value;
                OnPropertyChanged(nameof(HideInOutLaps));
            }
        }

        private Image _trackMapImage = null;
        protected Image TrackMapImage
        {
            get
            {
                return _trackMapImage;
            }
            set
            {
                _trackMapImage = value;
                OnPropertyChanged(nameof(TrackMapImage));
            }
        }

        private TrackMapInfo _trackMapInfo = null;
        protected TrackMapInfo TrackMapInfo
        {
            get
            {
                return _trackMapInfo;
            }
            set
            {
                _trackMapInfo = value;
                OnPropertyChanged(nameof(TrackMapInfo));
            }
        }

        private string _trackShortName = string.Empty;
        public string TrackShortName
        {
            get
            {
                return _trackShortName;
            }
            set
            {
                _trackShortName = value;
                OnPropertyChanged(nameof(TrackShortName));
            }
        }

        private IList<LapView> _lapViews = new List<LapView>();
        internal IList<LapView> LapViews
        {
            get
            {
                return _lapViews;
            }
            set
            {
                _lapViews = value;
                OnPropertyChanged(nameof(LapViews));
            }
        }

        private IList<LapView> _activeLapViews = new List<LapView>();
        internal IList<LapView> ActiveLapViews
        {
            get
            {
                return _activeLapViews;
            }
            set
            {
                _activeLapViews = value;
                OnPropertyChanged(nameof(ActiveLapViews));
            }
        }

        private IList<FramePosition> _sessionFramePositions { get; set; } = new List<FramePosition>();
        protected IList<FramePosition> SessionFramePositions
        {
            get
            {
                return _sessionFramePositions;
            }
            set
            {
                _sessionFramePositions = value;
                OnPropertyChanged(nameof(SessionFramePositions));
            }
        }
        #endregion

        #region ctor/load
        public TrackMapDisplay()
            : base()
        {
            InitializeComponent();

            FormDisplayInfo.DisplayType = DisplayTypes.TrackMap;
        }

        public TrackMapDisplay(
            IServiceProvider serviceProvider,
            log4net.ILog log,
            iRacingTelemetryOptions options)
          : base(
            serviceProvider,
            log,
            options,
            DisplayTypes.TrackMap)
        {
            InitializeComponent();
        }

        protected override void TelemetryForm_Load(object sender, EventArgs e)
        {
            try
            {
                base.TelemetryForm_Load(sender, e);

                _trackMapRepo = ServiceProvider.GetRequiredService<ITrackMapRepository>();
                _imageHelper = ServiceProvider.GetRequiredService<IImageHelper>();
                _mapService = ServiceProvider.GetRequiredService<ITrackMapService>();

                if (Session != null)
                {
                    ParseTelemetrySession(Session);
                }

                _panelWidth = splitContainer1.Panel1.Width;

                SetLapViewListHiddenState(true);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region parse telemetry data
        private void ParseTelemetrySession(ISession session)
        {
            TrackShortName = String.Empty;
            Laps = new List<ILapInfo>();

            if (session != null)
            {
                TrackShortName = session.TelemetrySessionData.SessionInfo.weekendInfo["TrackDisplayShortName"].ToString();
                Laps = session.TelemetrySessionData.Laps;
            }
        }
        private void ParseTelemetryLapFrames(IList<ILapInfo> laps)
        {
            SessionFramePositions = new List<FramePosition>();

            var lapViews = new List<LapView>();

            _minLap = 0;
            _maxLap = 0;
            _telemetryCenterY = 0F;
            _telemetryCenterX = 0F;

            if (laps == null || laps.Count <= 1)
                return;

            foreach (ILapInfo lap in laps)
            {
                lapViews.Add(new LapView() { Index = lap.LapIndex, LapNumber = lap.LapNumber, LapTime = lap.LapTime });
            }

            var fastestLap = lapViews.Where(l => l.LapTime >= 0).OrderBy(l => l.LapTime).FirstOrDefault();
            if (fastestLap != null)
                fastestLap.IsFastest = true;

            foreach (IList<IFrame> lapFrames in laps.Select(l => l.LapFrames))
            {
                int frameIdx = 0;
                var firstlap = lapFrames.Where(f => f.Lat != 0 || f.Lon != 0).FirstOrDefault();

                foreach (IFrame lapFrame in lapFrames.Where(f => f.Lat != 0 || f.Lon != 0))
                {
                    SessionFramePositions.Add(new FramePosition()
                    {
                        LapNumber = lapFrame.Lap,
                        FrameIdx = frameIdx,
                        Latitude = lapFrame.Lat,
                        Longitude = lapFrame.Lon,
                        Throttle = lapFrame.Throttle,
                        Brake = lapFrame.Brake
                    });

                    frameIdx++;
                }
            }

            _minLap = SessionFramePositions.Min(f => f.LapNumber);
            _maxLap = SessionFramePositions.Max(f => f.LapNumber);

            var minLatitude = SessionFramePositions.Min(f => f.Latitude);
            var maxLatitude = SessionFramePositions.Max(f => f.Latitude);
            var minLongitude = SessionFramePositions.Min(f => f.Longitude);
            var maxLongitude = SessionFramePositions.Max(f => f.Longitude);

            _telemetryCenterY = (float)(minLongitude + ((maxLongitude - minLongitude) / 2));
            _telemetryCenterX = (float)(minLatitude + ((maxLatitude - minLatitude) / 2));

            LapViews = lapViews;
        }
        #endregion

        #region TrackMapInfo
        private async Task GetTrackMap(string trackShortName)
        {
            if (!String.IsNullOrEmpty(trackShortName))
            {
                TrackMapInfo = await _trackMapRepo.GetTrackMapInfoAsync(trackShortName);
            }
        }
        protected async Task DisplayTrackMap(TrackMapInfo trackMapInfo)
        {
            try
            {
                if (_loading)
                    return;

                if (trackMapInfo == null)
                    return;

                TrackMapImage = await _trackMapRepo.GetTrackMapImageAsync(trackMapInfo.Id);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region laps panel
        private void chkHidenOutLaps_CheckedChanged(object sender, EventArgs e)
        {
            HideInOutLaps = !HideInOutLaps;
        }
        private void btnToggleLapViews_Click(object sender, EventArgs e)
        {
            SetLapViewListHiddenState(!splitContainer1.Panel1Collapsed);
        }
        private void SetLapViewListHiddenState(bool hidePanel)
        {
            try
            {
                this.SuspendLayout();

                if (hidePanel)
                {
                    this.Size = new Size(this.Width - _panelWidth, this.Height);
                }
                else
                {
                    this.Size = new Size(this.Width + _panelWidth, this.Height);
                }

                splitContainer1.Panel1Collapsed = hidePanel;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                this.ResumeLayout(true);
            }
        }
        private async void btnClearAll_Click(object sender, EventArgs e)
        {
            _manualLapSelection = true;
            while (lstLaps.CheckedIndices.Count > 0)
            {
                lstLaps.SetItemChecked(lstLaps.CheckedIndices[0], false);
            }
            _manualLapSelection = false;

            await DisplaySelectedLaps(false);
        }
        private async void btnSelectAll_Click(object sender, EventArgs e)
        {
            _manualLapSelection = true;
            for (int i = 0; i < lstLaps.Items.Count; i++)
            {
                lstLaps.SetItemChecked(i, true);
            }
            _manualLapSelection = false;

            await DisplaySelectedLaps(false);
        }
        private async void btnFastestLap_Click(object sender, EventArgs e)
        {
            _manualLapSelection = true;
            lstLaps.SelectedItem = _lapViews.FirstOrDefault(l => l.IsFastest);
            _manualLapSelection = false;

            await DisplaySelectedLaps(false);
        }
        private void SetCurrentLap(int lapNumber)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => { SetCurrentLap(lapNumber); }));
            }
            else
            {
                lstLaps.SelectedItems.Clear();
                lstLaps.SelectedItem = _lapViews.FirstOrDefault(l => l.LapNumber == lapNumber);
            }
        }
        private async void lstLaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressUpdate)
                return;

            if (_manualLapSelection)
                return;

            if (lstLaps.CheckedItems.Count > 0)
            {
                await DisplaySelectedLaps(_suppressUpdate);
            }
            else if (lstLaps.SelectedItem != null)
            {
                var lapView = (LapView)lstLaps.SelectedItem;
                await DisplaySelectedLap(lapView.LapNumber, false);
            }
        }
        private async void lstLaps_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_manualLapSelection)
                return;

            await DisplaySelectedLaps(false);
        }
        private void UpdateActiveLapViews(IList<LapView> lapViews)
        {
            ActiveLapViews = null;
            if (HideInOutLaps)
            {
                ActiveLapViews = lapViews.Where(f => f.LapTime >= 0).ToList();
            }
            else
            {
                ActiveLapViews = lapViews.ToList();
            }
        }
        private void DisplayActiveLapViews(IList<LapView> lapViews)
        {
            lstLaps.DataSource = null;

            if (lapViews != null && lapViews.Count > 0)
            {
                lstLaps.DataSource = lapViews;
                lstLaps.DisplayMember = "DisplayTitle";
                lstLaps.ValueMember = "LapNumber";
            }
        }
        #endregion

        #region update track map image
        private async Task DisplaySelectedLaps(bool suppressUpdate)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(async () => { await DisplaySelectedLaps(suppressUpdate); }));
            }
            else
            {
                IList<int> selectedLaps = new List<int>();
                if (lstLaps.CheckedItems.Count > 0)
                {
                    foreach (var item in lstLaps.CheckedItems)
                    {
                        var lapView = (LapView)item;
                        selectedLaps.Add(lapView.LapNumber);
                    }
                }
                else if (lstLaps.SelectedItems.Count > 0)
                {
                    foreach (var item in lstLaps.SelectedItems)
                    {
                        var lapView = (LapView)item;
                        selectedLaps.Add(lapView.LapNumber);
                    }
                }
                else
                    return;

                await UpdateTrackMapDisplay(selectedLaps, suppressUpdate);
            }
        }
        private async Task DisplaySelectedLap(int lapNumber, bool suppressUpdate)
        {
            await UpdateTrackMapDisplay(lapNumber, suppressUpdate);
        }

        private async Task UpdateTrackMapDisplay()
        {
            await UpdateTrackMapDisplay(false);
        }
        private async Task UpdateTrackMapDisplay(bool suppressUpdate)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(async () => { await UpdateTrackMapDisplay(suppressUpdate); }));
            }
            else
            {
                if (CurrentLapNumber > 0)
                    await UpdateTrackMapDisplay(CurrentLapNumber, suppressUpdate);
            }
        }
        private async Task UpdateTrackMapDisplay(int selectedLapNumber, bool suppressUpdate)
        {
            if (selectedLapNumber > 0)
                await UpdateTrackMapDisplay(new List<int>() { selectedLapNumber }, suppressUpdate);
        }
        private async Task UpdateTrackMapDisplay(IList<int> selectedLapNumbers, bool suppressUpdate)
        {
            if (selectedLapNumbers.Count == 0)
            {
                lblLaps.Text = "No laps selected";
            }
            else if (selectedLapNumbers.Count == 1)
            {
                lblLaps.Text = $"Lap {selectedLapNumbers.FirstOrDefault()} of laps {_minLap} to {_maxLap}";

                if (!suppressUpdate)
                    OnLapNumberChangeRequest(selectedLapNumbers.FirstOrDefault());
            }
            else if (selectedLapNumbers.Count < 5)
            {
                var laps = String.Join(", ", selectedLapNumbers.Take(4).Select(l => l.ToString()).ToList());

                lblLaps.Text = $"Displaying laps {laps} of laps {_minLap} to {_maxLap}";

                if (!suppressUpdate)
                    OnLapNumberChangeRequest(selectedLapNumbers.FirstOrDefault());
            }
            else
            {
                var laps = String.Join(", ", selectedLapNumbers.Take(4).Select(l => l.ToString()).ToList());

                lblLaps.Text = $"Displaying laps {laps}....";

                if (!suppressUpdate)
                    OnLapNumberChangeRequest(selectedLapNumbers.FirstOrDefault());
            }

            var selectedFramePositions = SessionFramePositions.Where(f => selectedLapNumbers.Contains(f.LapNumber)).ToList();

            await UpdateTrackMapImage(selectedFramePositions.OfType<TrackCoordinate>().ToList());
        }

        #region google image service
        private async Task UpdateTrackMapImage(IList<TrackCoordinate> trackMapCoordinates)
        {
            try
            {
                var trackMapByteArray = await UpdateGoogleTrackMap(
                    _telemetryCenterX,
                    _telemetryCenterY,
                    _mapZoom,
                    trackMapCoordinates);

                if (trackMapByteArray != null)
                {
                    Image image = _imageHelper.GetImageFromByteArray(trackMapByteArray);

                    if (_imageZoomFactor != 0)
                    {
                        image = _imageHelper.ZoomImage(image, _imageZoomFactor);
                    }

                    TrackMapImage = image;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async Task<byte[]> UpdateGoogleTrackMap(float latitude, float longitude, int zoom, IList<TrackCoordinate> trackCoordinates)
        {
            var image = await _mapService.GetMapAsync(latitude, longitude, zoom, trackCoordinates);

            return image;
        }
        #endregion
        #endregion

        #region zoom image
        private void btnZoomImageIn_Click(object sender, EventArgs e)
        {
            _imageZoomFactor += .1F;
            picMap.Image = _imageHelper.ZoomImage(TrackMapImage, _imageZoomFactor);
        }
        private void btnResetZoom_Click(object sender, EventArgs e)
        {
            _imageZoomFactor = 1F;
            picMap.Image = TrackMapImage;
        }
        private void btnZoomImageOut_Click(object sender, EventArgs e)
        {
            if (_imageZoomFactor > .1F)
                _imageZoomFactor -= .1F;

            picMap.Image = _imageHelper.ZoomImage(TrackMapImage, _imageZoomFactor);
        }
        #endregion
    }
}
