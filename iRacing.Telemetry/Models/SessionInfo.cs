using System.Collections.Generic;

namespace iRacing.Telemetry.Models
{
    public class SessionInfo
    {
        #region properties
        public IList<Session> Sessions { get; set; } = new List<Session>();
        #endregion

        #region ctor
        public SessionInfo()
        {
        }
        #endregion
    }
}


