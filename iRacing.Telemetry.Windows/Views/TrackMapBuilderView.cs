using iRacing.Common;
using iRacing.Common.Models;
using iRacing.Telemetry.Maps.Models;
using iRacing.Telemetry.Maps.Ports;
using iRacing.Telemetry.Windows.Models;
using iRacing.TelemetryFile;
using iRacing.TelemetryFile.Ports;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views
{
    public partial class TrackMapBuilderView : Form
    {
        #region fields
        private int _mapZoom = 18;
        bool _manualLapSelection = false;
        int _lapNumber = 0;
        int _minLap = 0;
        int _maxLap = 0;
        private float _telemetryCenterX = 0;
        private float _telemetryCenterY = 0;
        string _trackName = string.Empty;
        private IImageHelper _imageHelper;
        private ITrackMapService _mapService;
        private IIbtFileParser _telemetryFileParser;
        private iRacingTelemetryOptions _options;
        private ITrackMapRepository _trackMapRepo;
        bool _loading = true;
        private float _imageZoomFactor = 1.0F;
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
        private IServiceProvider _serviceProvider = null;
        protected virtual IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                {
                    var services = new ServiceCollection();

                    services.AddCommon();
                    services.AddTelemetryFile();
                    services.AddTelemetryWindows();

                    _serviceProvider = services.BuildServiceProvider();
                }
                return _serviceProvider;
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
                picMap.Image = _trackMapImage;
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
                lstLaps.DataSource = null;
                _lapViews = value;
                if (_lapViews != null)
                {
                    IList<LapView> filtered = null;
                    if (chkHideInOut.Checked)
                    {
                        filtered = _lapViews.Where(f => f.LapTime >= 0).ToList();
                    }
                    else
                    {
                        filtered = _lapViews.ToList();
                    }
                    lstLaps.DataSource = filtered;
                    lstLaps.DisplayMember = "DisplayTitle";
                    lstLaps.ValueMember = "LapNumber";
                }
            }
        }
        protected virtual IList<ILapInfo> Laps { get; set; }
        protected IList<FramePosition> SessionFramePositions { get; set; } = new List<FramePosition>();
        #endregion

        #region ctor/load
        public TrackMapBuilderView()
        {
            InitializeComponent();
        }

        private async void TrackMapBuilderView_Load(object sender, EventArgs e)
        {
            try
            {
                _trackMapRepo = ServiceProvider.GetRequiredService<ITrackMapRepository>();
                _imageHelper = ServiceProvider.GetRequiredService<IImageHelper>();
                _mapService = ServiceProvider.GetRequiredService<ITrackMapService>();
                _telemetryFileParser = ServiceProvider.GetRequiredService<IIbtFileParser>();
                IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor = ServiceProvider.GetRequiredService<IOptionsMonitor<iRacingTelemetryOptions>>();
                _options = (optionsAccessor == null) ? throw new ArgumentNullException(nameof(optionsAccessor)) : optionsAccessor.CurrentValue;

                await GetTrackMapList();

                _loading = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region common
        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }
        #endregion

        #region track map repo
        private async Task GetTrackMapList()
        {
            var trackMapInfos = await _trackMapRepo.GetTrackMapInfosAsync();

            foreach (TrackMapInfo trackMapInfo in trackMapInfos)
            {
                cboTrackMaps.Items.Add(trackMapInfo);
            }
            cboTrackMaps.SelectedIndex = -1;
        }

        private async void cboTrackMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_loading)
                    return;

                if (cboTrackMaps.SelectedItem == null)
                    return;

                var selected = (TrackMapInfo)cboTrackMaps.SelectedItem;

                TrackMapImage = await _trackMapRepo.GetTrackMapImageAsync(selected.Id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            TrackMapImage = null;
        }
        #endregion

        #region open telemetry file
        private async void btnOpenTelemetryFile_Click(object sender, EventArgs e)
        {
            try
            {
                await OpenTelemetry();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async Task OpenTelemetry()
        {
            try
            {
                var fileName = SelectTelemetrySessionFile();

                if (!String.IsNullOrEmpty(fileName))
                {
                    var parsedFile = await ParseTelemetryFile(fileName);

                    Laps = parsedFile.SessionData.Laps;

                    SessionFramePositions = await ParseTelemetryLaps(Laps);

                    await UpdateTrackMapDisplay(_lapNumber);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private string SelectTelemetrySessionFile()
        {
            var fileName = String.Empty;

            var dialog = new OpenFileDialog()
            {
                InitialDirectory = _options.TelemetryDirectory,
                Filter = "Atlas Files (*.ibt)|*.ibt|All Files (*.*)|*.*",
                FilterIndex = 1
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }

            return fileName;
        }
        private async Task<IbtTelemetryFile> ParseTelemetryFile(string fileName)
        {
            var ibtFile = await _telemetryFileParser.ParseTelemetryFileAsync(fileName, IbtParseOptions.All);
            _trackName = ibtFile.SessionData.SessionInfo.weekendInfo["TrackDisplayShortName"].ToString();
            return ibtFile;
        }
        #endregion

        #region image zoom
        private async void btnZoomMapIn_Click(object sender, EventArgs e)
        {
            _mapZoom += 1;
            await RefreshTrackMapDisplay();
        }
        private async void btnZoomMapOut_Click(object sender, EventArgs e)
        {
            _mapZoom -= 1;
            await RefreshTrackMapDisplay();
        }
        #endregion

        #region lap navigation
        private async void btnPrevLap_Click(object sender, EventArgs e)
        {
            _lapNumber--;
            if (_lapNumber < _minLap)
                _lapNumber = _minLap;

            _manualLapSelection = true;
            lstLaps.SelectedItem = _lapViews.FirstOrDefault(l => l.LapNumber == _lapNumber);
            _manualLapSelection = false;

            await UpdateTrackMapDisplay(_lapNumber);
        }
        private async void btnNextLap_Click(object sender, EventArgs e)
        {
            _lapNumber++;
            if (_lapNumber > _maxLap)
                _lapNumber = _maxLap;

            _manualLapSelection = true;
            lstLaps.SelectedItem = _lapViews.FirstOrDefault(l => l.LapNumber == _lapNumber);
            _manualLapSelection = false;

            await UpdateTrackMapDisplay(_lapNumber);
        }
        private async void btnClearAll_Click(object sender, EventArgs e)
        {
            _manualLapSelection = true;
            while (lstLaps.CheckedIndices.Count > 0)
            {
                lstLaps.SetItemChecked(lstLaps.CheckedIndices[0], false);
            }
            _manualLapSelection = false;

            await DisplaySelectedLaps();
        }

        private async void btnSelectAll_Click(object sender, EventArgs e)
        {
            _manualLapSelection = true;
            for (int i = 0; i < lstLaps.Items.Count; i++)
            {
                lstLaps.SetItemChecked(i, true);
            }
            _manualLapSelection = false;

            await DisplaySelectedLaps();
        }
        private async void btnFastest_Click(object sender, EventArgs e)
        {
            _manualLapSelection = true;
            lstLaps.SelectedItem = _lapViews.FirstOrDefault(l => l.IsFastest);
            _manualLapSelection = false;

            await DisplaySelectedLaps();
        }
        private async void lstLaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_manualLapSelection)
                return;

            if (lstLaps.CheckedItems.Count > 0)
            {
                await DisplaySelectedLaps();
            }
            else if (lstLaps.SelectedItem != null)
            {
                var lapView = (LapView)lstLaps.SelectedItem;
                await DisplaySelectedLap(lapView.LapNumber);
            }
        }
        private async void lstLaps_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_manualLapSelection)
                return;

            await DisplaySelectedLaps();
        }
        private async void btnDisplaySelectedLaps_Click(object sender, EventArgs e)
        {
            await DisplaySelectedLaps();
        }
        private void chkHideInOut_CheckedChanged(object sender, EventArgs e)
        {
            ResetLapViews();
        }

        private async Task DisplaySelectedLaps()
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

            await UpdateTrackMapDisplay(selectedLaps);
        }
        private async Task DisplaySelectedLap(int lapNumber)
        {
            await UpdateTrackMapDisplay(lapNumber);
        }
        private void ResetLapViews()
        {
            LapViews = _lapViews;
        }
        #endregion

        #region parse telemetry laps
        private async Task<IList<FramePosition>> ParseTelemetryLaps(IList<ILapInfo> laps)
        {
            var sessionFramePositions = new List<FramePosition>();

            var lapViews = new List<LapView>();

            if (laps.Count > 0)
            {
                await Task.Run(() =>
                {
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

                        //lapsList.Add(firstlap.Lap.ToString());

                        foreach (IFrame lapFrame in lapFrames.Where(f => f.Lat != 0 || f.Lon != 0))
                        {
                            sessionFramePositions.Add(new FramePosition()
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

                    _minLap = sessionFramePositions.Min(f => f.LapNumber);
                    _maxLap = sessionFramePositions.Max(f => f.LapNumber);
                    // Bristol
                    // https://maps.googleapis.com/maps/api/staticmap?center=36.5157,-82.2570&zoom=17&size=640x640&maptype=satellite&format=png32&key=AIzaSyDXQGes6eNVFioWly0s--o0T9mqfrVtaTw
                    var minLatitude = sessionFramePositions.Min(f => f.Latitude);
                    var maxLatitude = sessionFramePositions.Max(f => f.Latitude);
                    var minLongitude = sessionFramePositions.Min(f => f.Longitude);
                    var maxLongitude = sessionFramePositions.Max(f => f.Longitude);

                    _telemetryCenterY = (float)(minLongitude + ((maxLongitude - minLongitude) / 2));
                    _telemetryCenterX = (float)(minLatitude + ((maxLatitude - minLatitude) / 2));

                    _lapNumber = lapViews.FirstOrDefault().LapNumber;
                });

                LapViews = lapViews;
            }

            return sessionFramePositions;
        }
        #endregion

        #region current lap(s)
        private async Task RefreshTrackMapDisplay()
        {
            await UpdateTrackMapDisplay(_lapNumber);
        }
        private async Task UpdateTrackMapDisplay(int selectedLapNumber)
        {
            await UpdateTrackMapDisplay(new List<int>() { selectedLapNumber });
        }
        private async Task UpdateTrackMapDisplay(IList<int> selectedLapNumbers)
        {
            if (selectedLapNumbers.Count == 0)
            {
                lblLap.Text = "No laps selected";
            }
            else if (selectedLapNumbers.Count == 1)
            {
                lblLap.Text = $"Lap {selectedLapNumbers.FirstOrDefault()} of laps {_minLap} to {_maxLap}";
            }
            else if (selectedLapNumbers.Count < 5)
            {
                var laps = String.Join(", ", selectedLapNumbers.Take(4).Select(l => l.ToString()).ToList());

                lblLap.Text = $"Displaying laps {laps} of laps {_minLap} to {_maxLap}";
            }
            else
            {
                var laps = String.Join(", ", selectedLapNumbers.Take(4).Select(l => l.ToString()).ToList());

                lblLap.Text = $"Displaying laps {laps}....";
            }

            var selectedFramePositions = SessionFramePositions.Where(f => selectedLapNumbers.Contains(f.LapNumber)).ToList();

            await UpdateTrackMapImage(selectedFramePositions.OfType<TrackCoordinate>().ToList());
        }
        #endregion

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
                    TrackMapImage = _imageHelper.GetImageFromByteArray(trackMapByteArray);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async Task<byte[]> UpdateGoogleTrackMap(float latitude, float longitude, int zoom, IList<TrackCoordinate> trackCoordinates)
        {
            return await _mapService.GetMapAsync(latitude, longitude, zoom, trackCoordinates);
        }
        #endregion

        #region save image
        private async Task SaveTrackMap()
        {
            if (String.IsNullOrEmpty(_trackName))
                return;

            try
            {
                var model = await _trackMapRepo.GetTrackMapInfoAsync(_trackName);

                if (model == null)
                {
                    model = new TrackMapInfo()
                    {
                        Latitude = _telemetryCenterX,
                        Longitude = _telemetryCenterY,
                        TrackName = _trackName,
                        Zoom = _mapZoom,
                        Size = new Size(640, 640)
                    };
                    model.Url = _mapService.GetMapUri((float)model.Latitude, (float)model.Longitude, model.Zoom);
                }
                else
                {
                    model.Latitude = _telemetryCenterX;
                    model.Longitude = _telemetryCenterY;
                    model.TrackName = _trackName;
                    model.Zoom = _mapZoom;
                    model.Size = new Size(640, 640);
                    model.Url = _mapService.GetMapUri((float)model.Latitude, (float)model.Longitude, model.Zoom);
                }

                model = await _trackMapRepo.SaveTrackMapInfoAsync(model);

                await _trackMapRepo.SaveChangesAsync();

                var trackImageBytes = await _mapService.GetMapAsync((float)model.Latitude, (float)model.Longitude, model.Zoom);

                var trackImage = _mapService.GetImageFromBytes(trackImageBytes);

                await _trackMapRepo.SaveTrackMapImageAsync(trackImage, model.Id);

                await _trackMapRepo.SaveChangesAsync();

                MessageBox.Show("Track map info saved");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private async void btnSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                await SaveTrackMap();
                //var fileName = SelectSaveImageFile();
                //picMap.Image.Save(fileName);
                MessageBox.Show("Image saved");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private string SelectSaveImageFile(string fileName)
        {
            var dialog = new SaveFileDialog()
            {
                InitialDirectory = _options.TracksDirectory,
                Filter = _imageHelper.FileDialogFilter,
                DefaultExt = ".png",
                FilterIndex = 1
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }

            return fileName;
        }

        #endregion

        private void btnZoomImageIn_Click(object sender, EventArgs e)
        {
          
        }
        private void btnZoomImageOut_Click(object sender, EventArgs e)
        {
            _imageZoomFactor -= .1F;
            picMap.Image = _imageHelper.ZoomImage(TrackMapImage, _imageZoomFactor);
        }
    }
}
