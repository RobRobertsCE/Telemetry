using iRacing.Common;
using iRacing.Common.Models;
using iRacing.Telemetry.Data.Ports;
using log4net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Data.Adapters
{
    internal class FieldDefinitionFileRepository : JsonFileRepository, IFieldDefinitionRepository
    {
        #region properties
        private IList<IFieldDefinition> _telemetryFieldDefinitions = null;
        protected virtual IList<IFieldDefinition> TelemetryFieldDefinitions
        {
            get
            {
                if (_telemetryFieldDefinitions == null)
                {
                    _telemetryFieldDefinitions = LoadFromFile();
                }
                return _telemetryFieldDefinitions;
            }
            set
            {
                _telemetryFieldDefinitions = value;
            }
        }

        public bool HasChanges
        {
            get
            {
                var currentState = Serialize(TelemetryFieldDefinitions);

                return (State != currentState);
            }
        }
        protected string State { get; set; }
        #endregion

        #region ctor
        public FieldDefinitionFileRepository(
            IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor,
            ILog log)
            : base(optionsAccessor, log)
        {
            DataFileName = _options.FieldDefinitionsFileName;
        }
        #endregion

        #region public 
        public async Task<IFieldDefinition> FindFieldDefinitionAsync(string key)
        {
            return await Task.Run(() =>
            {
                return FindFieldDefinition(key);
            });
        }

        public async Task<IFieldDefinition> GetFieldDefinitionAsync(string name)
        {
            return await Task.Run(() =>
            {
                return FindFieldDefinition(name);
            });
        }

        public async Task<IList<IFieldDefinition>> GetFieldDefinitionsAsync()
        {
            return await Task.Run(() =>
            {
                return GetFieldDefinitions();
            });
        }

        public async Task<bool> SaveFieldDefinitionAsync(IFieldDefinition fieldDefinition)
        {
            return await Task.Run(() =>
            {
                return SaveFieldDefinition(fieldDefinition);
            });
        }

        public async Task<bool> SaveFieldDefinitionsAsync(IList<IFieldDefinition> fieldDefinitions)
        {
            return await Task.Run(() =>
            {
                return SaveFieldDefinitions(fieldDefinitions);
            });
        }

        public async Task<bool> DeleteFieldDefinitionAsync(IFieldDefinition fieldDefinition)
        {
            return await Task.Run(() =>
            {
                return DeleteFieldDefinition(fieldDefinition);
            });
        }

        public async Task<bool> DeleteFieldDefinitionAsync(string key)
        {
            return await Task.Run(() =>
            {
                return DeleteFieldDefinition(key);
            });
        }

        public async Task<bool> SaveChanges()
        {
            return await Task.Run(() =>
            {
                var success = false;

                if (FieldDefinitionsListIsValid(TelemetryFieldDefinitions))
                    success = SaveToFile(TelemetryFieldDefinitions);

                return success;
            });
        }

        public async Task<bool> DiscardChanges()
        {
            return await Task.Run(() =>
            {
                _telemetryFieldDefinitions = null;
                State = String.Empty;
                return true;
            });
        }
        #endregion

        #region protected  
        protected virtual IFieldDefinition FindFieldDefinition(string key)
        {
            return ((List<IFieldDefinition>)TelemetryFieldDefinitions).Find(f => f.Name == key);
        }

        protected virtual IFieldDefinition GetFieldDefinition(string name)
        {
            return TelemetryFieldDefinitions.FirstOrDefault(f => f.Name == name);
        }

        protected virtual IList<IFieldDefinition> GetFieldDefinitions()
        {
            return TelemetryFieldDefinitions.ToList();
        }

        protected virtual bool SaveFieldDefinition(IFieldDefinition fieldDefinition)
        {
            var FieldDefinitionsBuffer = TelemetryFieldDefinitions.ToList();

            FieldDefinitionsBuffer.Add(fieldDefinition);

            if (!FieldDefinitionsListIsValid(FieldDefinitionsBuffer))
                return false;

            DeleteFieldDefinition(fieldDefinition);

            TelemetryFieldDefinitions.Add(fieldDefinition);

            return true;
        }

        protected virtual bool SaveFieldDefinitions(IList<IFieldDefinition> fieldDefinitions)
        {
            if (!FieldDefinitionsListIsValid(fieldDefinitions))
                return false;

            if (SaveToFile(fieldDefinitions))
            {
                TelemetryFieldDefinitions = fieldDefinitions;
                State = Serialize(TelemetryFieldDefinitions);

                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual bool DeleteFieldDefinition(IFieldDefinition fieldDefinition)
        {
            return DeleteFieldDefinition(fieldDefinition.Key);
        }

        protected virtual bool DeleteFieldDefinition(string key)
        {
            var existingFieldDefinition = FindFieldDefinition(key);

            if (existingFieldDefinition == null)
            {
                throw new ArgumentException($"FieldDefinition having key {key} not found.");
            }

            return TelemetryFieldDefinitions.Remove(existingFieldDefinition);
        }

        protected virtual bool FieldDefinitionsListIsValid(IList<IFieldDefinition> fieldDefinition)
        {
            //if (fieldDefinition.GroupBy(f => f.Key).Any(g => g.Count() > 1))
            //    throw new ArgumentException("Duplicate key");

            return true;
        }

        protected virtual IList<IFieldDefinition> LoadFromFile()
        {
            IList<IFieldDefinition> FieldDefinitions = new List<IFieldDefinition>();

            var json = ReadFromFile(_options.AppDirectory, DataFileName);

            if (!String.IsNullOrEmpty(json))
            {
                FieldDefinitions = Deserialize(json);
                State = json;
            }

            return FieldDefinitions;
        }
        protected virtual bool SaveToFile(IList<IFieldDefinition> fieldDefinitions)
        {
            var json = Serialize(fieldDefinitions);
            WriteToFile(_options.AppDirectory, DataFileName, json);
            State = json;
            return true;
        }

        protected virtual string Serialize(IList<IFieldDefinition> fieldDefinitions)
        {
            return JsonConvert.SerializeObject(fieldDefinitions, _jsonSerializerSettings);
        }
        protected virtual IList<IFieldDefinition> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<IList<IFieldDefinition>>(json, _jsonSerializerSettings);
        }
        #endregion
    }
}
