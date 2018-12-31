using System.Drawing;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Models
{
    public class LineGraphXAxis : LineGraphAxis
    {
        public LineGraphXAxis()
            : base()
        {

        }

        #region properties
        public int Height { get; set; }
        public XAxisPosition Position { get; set; }
        #endregion

        #region public
        public override void PaintAxis(PaintEventArgs e, int offset)
        {
            if (!ShowAxis) return;
        }
        #endregion
    }
}
