using iRacing.Common.Models;
using Newtonsoft.Json;

namespace iRacing.Telemetry.Controls.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class WaveformDisplayInfo : FormDisplayInfo
    {
        public ILineGraphModel Model { get; set; }

        public WaveformDisplayInfo()
            : base()
        {
            Model = new LineGraphModel();
        }
    }
}
