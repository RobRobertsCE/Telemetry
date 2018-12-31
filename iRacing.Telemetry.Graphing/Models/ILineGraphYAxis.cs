using System.ComponentModel;
using System.Windows.Forms;

namespace iRacing.Telemetry.Graphing.Models
{
    public interface ILineGraphYAxis : INotifyPropertyChanged
    {
        bool DrawTitleLettersHorizontally { get; set; }
        bool DrawTitleVertically { get; set; }
        YAxisPosition Position { get; set; }
        float RangeEnd { get; set; }
        float RangeStart { get; set; }
        float GetAxisDrawWidth();
        void PaintAxis(PaintEventArgs e, int offset);
        void ResetAxisCoordinates();
    }
}