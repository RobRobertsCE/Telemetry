using System.ComponentModel;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Models
{
    public interface ILineGraphYAxis : ILineGraphAxis
    {
        bool DrawTitleLettersHorizontally { get; set; }
        bool DrawTitleVertically { get; set; }
        YAxisPosition Position { get; set; }
        float GetAxisDrawWidth();
        void ResetAxisCoordinates();
    }
}