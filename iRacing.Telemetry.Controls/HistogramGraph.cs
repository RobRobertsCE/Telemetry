using iRacing.Telemetry.Controls.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls
{
    public partial class HistogramGraph : UserControl
    {
        #region fields
        int _maxGroupCount = 0;
        #endregion

        #region fields
        public int MaxCount { get; set; }

        public HistogramCorners Corner { get; set; }

        private HistogramModel _model = null;
        public HistogramModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model != null)
                {
                    _model.PropertyChanged -= _model_PropertyChanged;
                }
                _model = value;
                if (_model != null)
                {
                    _model.PropertyChanged += _model_PropertyChanged;
                    lblField.Text = _model.FieldName;
                }
                else
                {
                    lblField.Text = string.Empty;
                }
            }
        }
        #endregion

        #region ctor
        public HistogramGraph()
        {
            InitializeComponent();

            graphPanel.Paint += GraphPanel_Paint;
        }
        #endregion

        #region public
        public void GenerateHistogramMap(int resolution)
        {
            MaxCount = Model.MapValues(resolution);
        }

        public void DisplayMap(int maxGroupCount)
        {
            _maxGroupCount = maxGroupCount;
            graphPanel.Refresh();
        }
        #endregion

        #region private
        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Model == null)
                return;

            if (Model.Map == null)
                return;

            if (Model.Map.Count == 0)
                return;

            int resolution = Model.Map.Count;

            bool printZeroBin = (resolution % 2 == 0) ? false : true;

            int binLabelInterval = 3;

            e.Graphics.Clear(Color.Black);

            float panelSideMargin = 8;
            float panelTopMargin = 30;
            float panelTextTopMargin = 2;
            float panelTextBottomMargin = 2;
            float panelBottomMargin = 30;
            float spanMargin = 4;

            float lowSpeedModeCutoff = 20.0F;

            float panelWidth = graphPanel.Width;
            float printWidth = panelWidth - (panelSideMargin * 2);
            int spanWidth = (int)((printWidth - (spanMargin * resolution)) / resolution);
            float printStartX = panelSideMargin + spanMargin;

            float panelHeight = graphPanel.Height;
            float printHeight = panelHeight - panelTopMargin - panelBottomMargin;
            int printStartY = (int)(panelHeight - panelBottomMargin);
            float maxCount = _maxGroupCount;
            float sumCount = Model.Map.Sum(m => m.Count);

            int fontSize = Model.Map.Count < 20 ? 8 : 6;

            StringFormat labelFormat = new StringFormat() { Alignment = StringAlignment.Center };

            using (Brush labelBrush = new SolidBrush(Color.White))
            {
                using (Font labelFont = new Font(new FontFamily("Tahoma"), fontSize))
                {
                    for (int i = 0; i < Model.Map.Count; i++)
                    {
                        var map = Model.Map[i];

                        int printX = (int)(printStartX + (i * (spanWidth + spanMargin)));
                        float spanRelativeHeight = map.Count / maxCount;
                        float spanRelativePercent = map.Count / sumCount;

                        int spanHeight = (int)(printHeight * spanRelativeHeight);

                        Brush binBrush = ((Math.Abs(map.Max) <= lowSpeedModeCutoff) || (Math.Abs(map.Min) <= lowSpeedModeCutoff)) ? Brushes.LightSteelBlue : Brushes.SteelBlue;

                        e.Graphics.FillRectangle(
                         binBrush,
                         new Rectangle(
                             printX, printStartY - spanHeight, spanWidth, spanHeight));

                        /* percent label at top */
                        string percentLabelText = spanRelativePercent.ToString("P2");
                        SizeF percentLabelSize = e.Graphics.MeasureString(percentLabelText, labelFont);

                        RectangleF percentLabelRectangle = new RectangleF(
                            printX + (spanWidth / 2) - (percentLabelSize.Width / 2),
                            panelTextTopMargin,
                            percentLabelSize.Width,
                            percentLabelSize.Height);

                        e.Graphics.DrawString(
                            percentLabelText,
                            labelFont,
                            labelBrush,
                            percentLabelRectangle,
                            labelFormat);

                        /* span labels at bottom */

                        // zero bin check
                        if (printZeroBin && map.Min < 0 && map.Max > 0)
                        {
                            string spanLabelText = "0";
                            SizeF spanLabelSize = e.Graphics.MeasureString(spanLabelText, labelFont);

                            RectangleF spanLabelRectangle = new RectangleF(
                               printX + (spanWidth / 2) - (spanLabelSize.Width / 2), // printX - (spanLabelSize.Width / 2),
                               panelHeight - panelTextBottomMargin - spanLabelSize.Height,
                               spanLabelSize.Width,
                               spanLabelSize.Height);

                            e.Graphics.DrawString(
                               spanLabelText,
                               labelFont,
                               labelBrush,
                               spanLabelRectangle,
                               labelFormat);

                            e.Graphics.DrawLine(
                                Pens.White,
                                new PointF(
                                    printX + (spanWidth / 2), // printX - (spanMargin / 2), 
                                    panelHeight - panelTextBottomMargin - spanLabelSize.Height),
                                new PointF(
                                    printX + (spanWidth / 2), // printX - (spanMargin / 2), 
                                    panelHeight - panelBottomMargin + 1)
                                );

                        }
                        else
                        {
                            // print every nth one.
                            if ((i != Model.Map.Count - 1) && (i == 0) || (map.BinsToZero % binLabelInterval == 0))
                            {
                                bool printMax = map.Max > 0 ? true : false;

                                string spanLabelText = Math.Round(printMax ? map.Max : map.Min, 3, MidpointRounding.AwayFromZero).ToString();
                                SizeF spanLabelSize = e.Graphics.MeasureString(spanLabelText, labelFont);

                                RectangleF spanLabelRectangle = new RectangleF(
                                   printX + (printMax ? spanWidth - (spanLabelSize.Width / 2) : -(spanLabelSize.Width / 2)),
                                   panelHeight - panelTextBottomMargin - spanLabelSize.Height,
                                   spanLabelSize.Width,
                                   spanLabelSize.Height);

                                e.Graphics.DrawString(
                                   spanLabelText,
                                   labelFont,
                                   labelBrush,
                                   spanLabelRectangle,
                                   labelFormat);

                                e.Graphics.DrawLine(
                                    Pens.White,
                                    new PointF(
                                        printX + (printMax ? spanWidth : -(spanMargin / 2)),
                                        panelHeight - panelTextBottomMargin - spanLabelSize.Height),
                                    new PointF(
                                        printX + (printMax ? spanWidth : -(spanMargin / 2)),
                                        panelHeight - panelBottomMargin + 1)
                                    );
                            }
                        }
                    }

                    var lastMap = Model.Map.LastOrDefault();
                    int lastPrintX = (int)(printStartX + (Model.Map.Count * (spanWidth + spanMargin)));

                    /* last span label */
                    string lastSpanLabelText = Math.Round(lastMap.Max, 3, MidpointRounding.AwayFromZero).ToString();
                    SizeF lastSpanLabelSize = e.Graphics.MeasureString(lastSpanLabelText, labelFont);

                    RectangleF lastSpanLabelRectangle = new RectangleF(
                       lastPrintX - (lastSpanLabelSize.Width / 2),
                       panelHeight - panelTextBottomMargin - lastSpanLabelSize.Height,
                       lastSpanLabelSize.Width,
                       lastSpanLabelSize.Height);

                    e.Graphics.DrawString(
                       lastSpanLabelText,
                       labelFont,
                       labelBrush,
                       lastSpanLabelRectangle,
                       labelFormat);

                    e.Graphics.DrawLine(
                        Pens.White,
                        new PointF(
                            lastPrintX - (spanMargin / 2),
                            panelHeight - panelTextBottomMargin - lastSpanLabelSize.Height),
                        new PointF(
                            lastPrintX - (spanMargin / 2),
                            panelHeight - panelBottomMargin + 1)
                        );
                }
            }
        }

        private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(HistogramModel.Map):
                    {
                        break;
                    }
                case nameof(HistogramModel.FieldName):
                    {
                        lblField.Text = _model.FieldName;
                        break;
                    }
            }
        }
        #endregion
    }
}
