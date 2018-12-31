using iRacing.Common.Models;
using iRacing.Telemetry.Windows.Models;

namespace iRacing.Telemetry.Windows.Ports
{
    public interface IDisplayInfoService
    {
        IFormDisplayInfo LoadFormDisplayInfo(string fileName);
        bool SaveFormDisplayInfo(IFormDisplayInfo displayInfo, string fileName);
    }
}
