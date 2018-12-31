using iRacing.Common.Models;
using iRacing.Telemetry.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Ports
{
    public interface ISessionParser
    {
        Task<TelemetrySet> ParseTelemetrySessionAsync(IDictionary<object, object> telemetryValues);
        Task UpdateTelemetrySessionAsync(IDictionary<object, object> telemetryValues, TelemetrySet telemetrySet);
        Task<IList<IFieldDefinition>> BuildFieldDefinitionListAsync(IDictionary<object, object> telemetryValues);
    }
}
