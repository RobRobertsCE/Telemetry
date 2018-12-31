using iRacing.Common.Models;
using iRacing.Telemetry.Windows.Models;
using iRacing.Telemetry.Windows.Ports;
using Newtonsoft.Json;
using System.IO;

namespace iRacing.Telemetry.Windows.Adapters
{
    internal class DisplayInfoService : IDisplayInfoService
    {
        public IFormDisplayInfo LoadFormDisplayInfo(string fileName)
        {
            var json = File.ReadAllText(fileName);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var displayInfo = JsonConvert.DeserializeObject<FormDisplayInfo>(json, settings);
            displayInfo.Name = Path.GetFileNameWithoutExtension(fileName);

            return displayInfo;
        }

        public bool SaveFormDisplayInfo(IFormDisplayInfo displayInfo, string fileName)
        {
            displayInfo.Name = Path.GetFileNameWithoutExtension(fileName);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var json = JsonConvert.SerializeObject(displayInfo, settings);
            File.WriteAllText(fileName, json);
            return true;
        }
    }
}
