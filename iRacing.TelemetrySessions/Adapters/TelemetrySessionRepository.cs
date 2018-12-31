using iRacing.Common;
using iRacing.TelemetrySessions.Models;
using iRacing.TelemetrySessions.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.TelemetrySessions.Adapters
{
    class TelemetrySessionRepository : ITelemetrySessionRepository
    {
        public Task DeleteSessionRun(Guid sessionRunId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTelemetrySession(Guid telemetrySessionId)
        {
            throw new NotImplementedException();
        }

        public Task<SessionRun> GetSessionRunAsync(Guid sessionRunId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<SessionRun>> GetSessionRunsAsync(Guid telemetrySessionId)
        {
            throw new NotImplementedException();
        }

        public Task<TelemetrySession> GetTelemetrySessionAsync(Guid telemetrySessionId)
        {
            throw new NotImplementedException();
        }

        public Task<SessionRun> SaveSessionRunAsync(Guid telemetrySessionId, SessionRun sessionRun)
        {
            throw new NotImplementedException();
        }

        public Task<TelemetrySession> SaveTelemetrySessionAsync(TelemetrySession telemetrySession)
        {
            throw new NotImplementedException();
        }

        public Task<IList<SessionRun>> SearchSessionRunsAsync(SearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TelemetrySession>> SearchTelemetrySessionsAsync(SearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }
    }
}
