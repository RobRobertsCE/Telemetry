using System.Collections.Generic;

namespace iRacing.Telemetry.Models
{
    public class SplitTimeInfo
    {
        #region properties
        public IList<Sector> Sectors { get; set; } = new List<Sector>();
        #endregion

        #region ctor
        public SplitTimeInfo()
        {
        }
        #endregion
    }
}

