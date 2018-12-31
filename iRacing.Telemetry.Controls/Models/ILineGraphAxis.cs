using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Models
{
    public interface ILineGraphAxis
    {
        float AxisBaseLineThickness { get; set; }
        Color Color { get; set; }
        Font Font { get; set; }
        string Format { get; set; }
        int Index { get; set; }
        bool InvertRange { get; set; }
        float TickStep { get; set; }
        Margins Margins { get; set; }
        float Maximum { get; set; }
        float Minimum { get; set; }
        string Name { get; set; }
        int Precision { get; set; }
        float RangeEnd { get; set; }
        float RangeStart { get; set; }
        bool ShowAxis { get; set; }
        bool ShowTickLabels { get; set; }
        bool ShowTicks { get; set; }
        bool ShowTitle { get; set; }
        string Unit { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void PaintAxis(PaintEventArgs e, int offset);
    }
}