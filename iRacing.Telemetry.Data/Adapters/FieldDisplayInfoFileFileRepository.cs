using iRacing.Common;
using iRacing.Common.Models;
using iRacing.Telemetry.Data.Ports;
using log4net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Data.Adapters
{
    internal class FieldDisplayInfoFileFileRepository : JsonFileRepository, IFieldDisplayInfoRepository
    {
        #region properties
        private IList<IFieldDisplayInfo> _telemetryDisplayFields = null;
        protected virtual IList<IFieldDisplayInfo> TelemetryDisplayFields
        {
            get
            {
                if (_telemetryDisplayFields == null)
                {
                    _telemetryDisplayFields = LoadFromFile();
                }
                return _telemetryDisplayFields;
            }
            set
            {
                _telemetryDisplayFields = value;
            }
        }

        public bool HasChanges
        {
            get
            {
                var currentState = Serialize(TelemetryDisplayFields);

                return (State != currentState);
            }
        }
        protected string State { get; set; }
        #endregion

        #region ctor
        public FieldDisplayInfoFileFileRepository(
            IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor,
            ILog log)
            : base(optionsAccessor, log)
        {
            DataFileName = _options.FieldDisplaysFileName;
        }
        #endregion

        #region public 
        public async Task<IFieldDisplayInfo> FindDisplayFieldAsync(string key)
        {
            return await Task.Run(() =>
            {
                return FindDisplayField(key);
            });
        }

        public async Task<IFieldDisplayInfo> GetDisplayFieldAsync(string name)
        {
            return await Task.Run(() =>
            {
                return FindDisplayField(name);
            });
        }

        public async Task<IList<IFieldDisplayInfo>> GetDisplayFieldsAsync()
        {
            return await Task.Run(() =>
            {
                return GetDisplayFields();
            });
        }

        public async Task<bool> SaveDisplayFieldAsync(IFieldDisplayInfo displayField)
        {
            return await Task.Run(() =>
            {
                return SaveDisplayField(displayField);
            });
        }

        public async Task<bool> SaveDisplayFieldsAsync(IList<IFieldDisplayInfo> displayFields)
        {
            return await Task.Run(() =>
            {
                return SaveDisplayFields(displayFields);
            });
        }

        public async Task<bool> DeleteDisplayFieldAsync(IFieldDisplayInfo displayField)
        {
            return await Task.Run(() =>
            {
                return DeleteDisplayField(displayField);
            });
        }

        public async Task<bool> DeleteDisplayFieldAsync(string key)
        {
            return await Task.Run(() =>
            {
                return DeleteDisplayField(key);
            });
        }

        public async Task<bool> SaveChanges()
        {
            return await Task.Run(() =>
            {
                var success = false;

                if (DisplayFieldsListIsValid(TelemetryDisplayFields))
                    success = SaveToFile(TelemetryDisplayFields);

                return success;
            });
        }

        public async Task<bool> DiscardChanges()
        {
            return await Task.Run(() =>
            {
                _telemetryDisplayFields = null;
                State = String.Empty;
                return true;
            });
        }
        #endregion

        #region protected  
        protected virtual IFieldDisplayInfo FindDisplayField(string key)
        {
            return ((List<IFieldDisplayInfo>)TelemetryDisplayFields).Find(f => f.Name == key);
        }

        protected virtual IFieldDisplayInfo GetDisplayField(string name)
        {
            return TelemetryDisplayFields.FirstOrDefault(f => f.Name == name);
        }

        protected virtual IList<IFieldDisplayInfo> GetDisplayFields()
        {
            return TelemetryDisplayFields.ToList();
        }

        protected virtual bool SaveDisplayField(IFieldDisplayInfo displayField)
        {
            var displayFieldsBuffer = TelemetryDisplayFields.ToList();

            displayFieldsBuffer.Add(displayField);

            if (!DisplayFieldsListIsValid(displayFieldsBuffer))
                return false;

            DeleteDisplayField(displayField);

            TelemetryDisplayFields.Add(displayField);

            return true;
        }
        protected virtual bool SaveDisplayFields(IList<IFieldDisplayInfo> displayFields)
        {
            if (!DisplayFieldsListIsValid(displayFields))
                return false;

            if (SaveToFile(displayFields))
            {
                TelemetryDisplayFields = displayFields;
                State = Serialize(TelemetryDisplayFields);

                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual bool DeleteDisplayField(IFieldDisplayInfo displayField)
        {
            return DeleteDisplayField(displayField.Key);
        }
        protected virtual bool DeleteDisplayField(string key)
        {
            var existingDisplayField = FindDisplayField(key);

            if (existingDisplayField == null)
            {
                throw new ArgumentException($"DisplayField having key {key} not found.");
            }

            return TelemetryDisplayFields.Remove(existingDisplayField);
        }

        protected virtual bool DisplayFieldsListIsValid(IList<IFieldDisplayInfo> displayFields)
        {
            if (displayFields.GroupBy(f => f.Key).Any(g => g.Count() > 1))
                throw new ArgumentException("Duplicate key");

            return true;
        }

        protected virtual IList<IFieldDisplayInfo> LoadFromFile()
        {
            IList<IFieldDisplayInfo> displayFields = new List<IFieldDisplayInfo>();

            var json = ReadFromFile(_options.AppDirectory, DataFileName);

            if (!String.IsNullOrEmpty(json))
            {
                displayFields = Deserialize(json);
                State = json;
            }

            return displayFields;
        }
        protected virtual bool SaveToFile(IList<IFieldDisplayInfo> displayFields)
        {
            var json = Serialize(displayFields);
            WriteToFile(_options.AppDirectory, DataFileName, json);
            State = json;
            return true;
        }

        protected virtual string Serialize(IList<IFieldDisplayInfo> displayInfos)
        {
            return JsonConvert.SerializeObject(displayInfos, _jsonSerializerSettings);
        }
        protected virtual IList<IFieldDisplayInfo> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<IList<IFieldDisplayInfo>>(json, _jsonSerializerSettings);
        }
        #endregion
    }
}
