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
    internal class FunctionFileRepository : JsonFileRepository, IFunctionRepository
    {
        #region properties
        private IList<IFunction> _telemetryFunctions = null;
        protected virtual IList<IFunction> TelemetryFunctions
        {
            get
            {
                if (_telemetryFunctions == null)
                {
                    _telemetryFunctions = LoadFromFile();
                }
                return _telemetryFunctions;
            }
            set
            {
                _telemetryFunctions = value;
            }
        }

        public bool HasChanges
        {
            get
            {
                var currentState = Serialize(TelemetryFunctions);

                return (State != currentState);
            }
        }
        protected string State { get; set; }
        #endregion

        #region ctor
        public FunctionFileRepository(
            IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor,
            ILog log)
            : base(optionsAccessor, log)
        {
            DataFileName = _options.TelemetryFunctionsFileName;
        }
        #endregion

        #region public 
        public async Task<IFunction> FindFunctionAsync(string key)
        {
            return await Task.Run(() =>
            {
                return FindFunction(key);
            });
        }

        public async Task<IFunction> GetFunctionAsync(string name)
        {
            return await Task.Run(() =>
            {
                return FindFunction(name);
            });
        }

        public async Task<IList<IFunction>> GetFunctionsAsync()
        {
            return await Task.Run(() =>
            {
                return GetFunctions();
            });
        }

        public async Task<bool> SaveFunctionAsync(IFunction function)
        {
            return await Task.Run(() =>
            {
                return SaveFunction(function);
            });
        }

        public async Task<bool> DeleteFunctionAsync(IFunction function)
        {
            return await Task.Run(() =>
            {
                return DeleteFunction(function);
            });
        }

        public async Task<bool> DeleteFunctionAsync(string key)
        {
            return await Task.Run(() =>
            {
                return DeleteFunction(key);
            });
        }

        public async Task<bool> SaveChanges()
        {
            return await Task.Run(() =>
            {
                var success = false;

                if (FunctionsListIsValid(TelemetryFunctions))
                    success = SaveToFile(TelemetryFunctions);

                return success;
            });
        }

        public async Task<bool> DiscardChanges()
        {
            return await Task.Run(() =>
            {
                _telemetryFunctions = null;
                State = String.Empty;
                return true;
            });
        }
        #endregion

        #region protected  
        protected virtual IFunction FindFunction(string key)
        {
            return ((List<IFunction>)TelemetryFunctions).Find(f => f.Name == key);
        }

        protected virtual IFunction GetFunction(string name)
        {
            return TelemetryFunctions.FirstOrDefault(f => f.Name == name);
        }

        protected virtual IList<IFunction> GetFunctions()
        {
            return TelemetryFunctions.ToList();
        }

        protected virtual bool SaveFunction(IFunction function)
        {
            var functionsBuffer = TelemetryFunctions.ToList();

            functionsBuffer.Add(function);

            if (!FunctionsListIsValid(functionsBuffer))
                return false;

            DeleteFunction(function);

            TelemetryFunctions.Add(function);

            return true;
        }

        protected virtual bool DeleteFunction(IFunction function)
        {
            return DeleteFunction(function.Key);
        }

        protected virtual bool DeleteFunction(string key)
        {
            var existingFunction = FindFunction(key);

            if (existingFunction == null)
            {
                throw new ArgumentException($"Function having key {key} not found.");
            }

            return TelemetryFunctions.Remove(existingFunction);
        }

        protected virtual bool FunctionsListIsValid(IList<IFunction> Functions)
        {
            if (Functions.GroupBy(f => f.Key).Any(g => g.Count() > 1))
                throw new ArgumentException("Duplicate key");

            return true;
        }

        protected virtual IList<IFunction> LoadFromFile()
        {
            IList<IFunction> Functions = new List<IFunction>();

            var json = ReadFromFile(_options.FunctionsDirectory, DataFileName);

            if (!String.IsNullOrEmpty(json))
            {
                Functions = Deserialize(json);
                State = json;
            }

            return Functions;
        }
        protected virtual bool SaveToFile(IList<IFunction> Functions)
        {
            var json = Serialize(Functions);
            WriteToFile(_options.FunctionsDirectory, DataFileName, json);
            State = json;
            return true;
        }

        protected virtual string Serialize(IList<IFunction> displayInfos)
        {
            return JsonConvert.SerializeObject(displayInfos, _jsonSerializerSettings);
        }
        protected virtual IList<IFunction> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<IList<IFunction>>(json, _jsonSerializerSettings);
        }
        #endregion
    }
}
