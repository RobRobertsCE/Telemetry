using System.Collections.Generic;

namespace iRacing.Common.Models
{
    public interface ISessionData
    {
        IList<IFieldDefinition> Fields { get; set; }
        IList<IFrame> Frames { get; set; }
        IList<ILapInfo> Laps { get; set; }
        ISessionDictionaries SessionInfo { get; set; }
        ISetupInfo SetupInfo { get; set; }

        string FieldsToString();
        string ToString();
        string ValuesToString();
    }
}