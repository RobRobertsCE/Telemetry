using iRacing.Telemetry.Controls.Displays;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace iRacing.Telemetry.TestApp.Project
{
    public class TelemetryProject
    {
        public string Name { get; set; }

        public IList<DisplayInfo> Displays { get; set; }

        public string SessionName { get; set; }

        [JsonIgnore()]
        internal string State { get; set; }

        public TelemetryProject()
        {
            Displays = new List<DisplayInfo>();
        }

        public void Save(string fileName)
        {
            var json = SerializeProject(this);
            File.WriteAllText(fileName, json);
        }

        public static TelemetryProject Load(string fileName)
        {
            var json = File.ReadAllText(fileName);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var project = JsonConvert.DeserializeObject<TelemetryProject>(json, settings);
            project.State = SerializeProject(project);
            return project;
        }

        internal static string SerializeProject(TelemetryProject project)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            return JsonConvert.SerializeObject(project, settings);
        }
    }
}
