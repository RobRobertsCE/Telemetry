using iRacing.Telemetry.Windows.Models;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Windows.Ports
{
    public interface IProjectFactory
    {
        Task<IProject> OpenTelemetryProject(string fileName);
    }
}
