using iRacing.Common.Models;
using System;

namespace iRacing.Telemetry.Data.Models
{
    public class UserDefinedTelemetryFunction : TelemetryFunction, IUserDefinedFunction
    {
        public string fileName { get; set; }
    }
}
