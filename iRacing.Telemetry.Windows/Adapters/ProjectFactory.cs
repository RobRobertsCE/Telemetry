using iRacing.Telemetry.Controls.Converters;
using iRacing.Telemetry.Windows.Models;
using iRacing.Telemetry.Windows.Ports;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Windows.Adapters
{
    internal class ProjectFactory : IProjectFactory
    {
        public async Task<IProject> OpenTelemetryProject(string fileName)
        {
            return await Task.Run(() =>
            {
                var json = File.ReadAllText(fileName);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
                settings.Converters.Add(new ColorConverter());
                var project = JsonConvert.DeserializeObject<Project>(json, settings);
                project.FileName = fileName;

                project.State = Project.Serialize(project);

                if (project.Session != null)
                {
                    ((TelemetrySession)project.Session).State = TelemetrySession.Serialize(project.Session);
                }

                return project;
            });
        }
    }
}
