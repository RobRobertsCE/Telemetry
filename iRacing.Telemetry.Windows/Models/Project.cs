using iRacing.Common.Models;
using iRacing.Telemetry.Controls.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace iRacing.Telemetry.Windows.Models
{
    public class Project : IProject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal const string DefaultProjectName = "<New Project>";

        private string _name = string.Empty;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _fileName = string.Empty;
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        public string SessionFileName { get; set; }

        private ISession _session = null;
        [JsonIgnore()]
        public ISession Session
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;

                if (_session != null)
                {
                    SessionFileName = Session.SessionFileName;
                }

                OnPropertyChanged(nameof(Session));
            }
        }

        public IList<IFormDisplayInfo> Displays { get; set; }

        [JsonIgnore()]
        internal string State { get; set; }
        [JsonIgnore()]
        public bool HasChanges
        {
            get
            {
                if (Name == DefaultProjectName || string.IsNullOrEmpty(FileName))
                {
                    return true;
                }
                else
                {
                    var currentState = Serialize(this);
                    return (currentState == State);
                }
            }
        }

        public Project()
        {
            Displays = new List<IFormDisplayInfo>();
            Name = DefaultProjectName;
        }

        public void Save()
        {
            SaveAs(FileName);
        }
        public virtual void SaveAs(string fileName)
        {
            FileName = fileName;
            if (Name == DefaultProjectName)
            {
                Name = Path.GetFileNameWithoutExtension(fileName);
            }
            var json = Serialize(this);
            File.WriteAllText(fileName, json);
        }

        internal static string Serialize(Project project)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
            settings.Converters.Add(new ColorConverter());
            var json = JsonConvert.SerializeObject(project, settings);

            return json;
        }
    }
}
