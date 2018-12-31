using iRacing.Common;
using iRacing.TelemetrySessions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRacing.TelemetrySessions.Ports
{
    public interface ITelemetrySessionRepository
    {
        Task<IList<TelemetrySession>> SearchTelemetrySessionsAsync(SearchCriteria searchCriteria);
        Task<TelemetrySession> GetTelemetrySessionAsync(Guid telemetrySessionId);
        Task<TelemetrySession> SaveTelemetrySessionAsync(TelemetrySession telemetrySession);
        Task DeleteTelemetrySession(Guid telemetrySessionId);

        Task<IList<SessionRun>> GetSessionRunsAsync(Guid telemetrySessionId);
        Task<IList<SessionRun>> SearchSessionRunsAsync(SearchCriteria searchCriteria);
        Task<SessionRun> GetSessionRunAsync(Guid sessionRunId);
        Task<SessionRun> SaveSessionRunAsync(Guid telemetrySessionId, SessionRun sessionRun);
        Task DeleteSessionRun(Guid sessionRunId);
    }
}
