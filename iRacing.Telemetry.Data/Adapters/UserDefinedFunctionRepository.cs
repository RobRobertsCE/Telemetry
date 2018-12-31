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
    internal class UserDefinedFunctionRepository : JsonFileRepository, IUserDefinedFunctionRepository
    {
        #region properties
        private IList<IUserDefinedFunction> _userTelemetryUserFunctions = null;
        protected virtual IList<IUserDefinedFunction> UserTelemetryUserFunctions
        {
            get
            {
                if (_userTelemetryUserFunctions == null)
                {
                    _userTelemetryUserFunctions = LoadFromFile();
                }
                return _userTelemetryUserFunctions;
            }
            set
            {
                _userTelemetryUserFunctions = value;
            }
        }

        public bool HasChanges
        {
            get
            {
                var currentState = Serialize(UserTelemetryUserFunctions);

                return (State != currentState);
            }
        }
        protected string State { get; set; }
        #endregion

        #region ctor
        public UserDefinedFunctionRepository(
            IOptionsMonitor<iRacingTelemetryOptions> optionsAccessor,
            ILog log)
            : base(optionsAccessor, log)
        {
            DataFileName = _options.UserDefinedFunctionsFileName;
        }
        #endregion

        #region public 
        public async Task<IUserDefinedFunction> FindUserFunctionAsync(string key)
        {
            return await Task.Run(() =>
            {
                return FindUserFunction(key);
            });
        }

        public async Task<IUserDefinedFunction> GetUserFunctionAsync(string name)
        {
            return await Task.Run(() =>
            {
                return FindUserFunction(name);
            });
        }

        public async Task<IList<IUserDefinedFunction>> GetUserFunctionsAsync()
        {
            return await Task.Run(() =>
            {
                return GetUserFunctions();
            });
        }

        public async Task<bool> SaveUserFunctionAsync(IUserDefinedFunction UserFunction)
        {
            return await Task.Run(() =>
            {
                return SaveUserFunction(UserFunction);
            });
        }

        public async Task<bool> DeleteUserFunctionAsync(IUserDefinedFunction UserFunction)
        {
            return await Task.Run(() =>
            {
                return DeleteUserFunction(UserFunction);
            });
        }

        public async Task<bool> DeleteUserFunctionAsync(string key)
        {
            return await Task.Run(() =>
            {
                return DeleteUserFunction(key);
            });
        }

        public async Task<bool> SaveChanges()
        {
            return await Task.Run(() =>
            {
                var success = false;

                if (UserFunctionsListIsValid(UserTelemetryUserFunctions))
                    success = SaveToFile(UserTelemetryUserFunctions);

                return success;
            });
        }

        public async Task<bool> DiscardChanges()
        {
            return await Task.Run(() =>
            {
                _userTelemetryUserFunctions = null;
                State = String.Empty;
                return true;
            });
        }
        #endregion

        #region protected  
        protected virtual IUserDefinedFunction FindUserFunction(string key)
        {
            return ((List<IUserDefinedFunction>)UserTelemetryUserFunctions).Find(f => f.Name == key);
        }

        protected virtual IUserDefinedFunction GetUserFunction(string name)
        {
            return UserTelemetryUserFunctions.FirstOrDefault(f => f.Name == name);
        }

        protected virtual IList<IUserDefinedFunction> GetUserFunctions()
        {
            return UserTelemetryUserFunctions.ToList();
        }

        protected virtual bool SaveUserFunction(IUserDefinedFunction UserFunction)
        {
            var UserFunctionsBuffer = UserTelemetryUserFunctions.ToList();

            UserFunctionsBuffer.Add(UserFunction);

            if (!UserFunctionsListIsValid(UserFunctionsBuffer))
                return false;

            DeleteUserFunction(UserFunction);

            UserTelemetryUserFunctions.Add(UserFunction);

            return true;
        }

        protected virtual bool DeleteUserFunction(IUserDefinedFunction UserFunction)
        {
            return DeleteUserFunction(UserFunction.Key);
        }

        protected virtual bool DeleteUserFunction(string key)
        {
            var existingUserFunction = FindUserFunction(key);

            if (existingUserFunction == null)
            {
                throw new ArgumentException($"UserFunction having key {key} not found.");
            }

            return UserTelemetryUserFunctions.Remove(existingUserFunction);
        }

        protected virtual bool UserFunctionsListIsValid(IList<IUserDefinedFunction> UserFunctions)
        {
            if (UserFunctions.GroupBy(f => f.Key).Any(g => g.Count() > 1))
                throw new ArgumentException("Duplicate key");

            return true;
        }

        protected virtual IList<IUserDefinedFunction> LoadFromFile()
        {
            IList<IUserDefinedFunction> UserFunctions = new List<IUserDefinedFunction>();

            var json = ReadFromFile(_options.FunctionsDirectory, DataFileName);

            if (!String.IsNullOrEmpty(json))
            {
                UserFunctions = Deserialize(json);
                State = json;
            }

            return UserFunctions;
        }
        protected virtual bool SaveToFile(IList<IUserDefinedFunction> UserFunctions)
        {
            var json = Serialize(UserFunctions);
            WriteToFile(_options.FunctionsDirectory, DataFileName, json);
            State = json;
            return true;
        }

        protected virtual string Serialize(IList<IUserDefinedFunction> displayInfos)
        {
            return JsonConvert.SerializeObject(displayInfos, _jsonSerializerSettings);
        }
        protected virtual IList<IUserDefinedFunction> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<IList<IUserDefinedFunction>>(json, _jsonSerializerSettings);
        }
        #endregion
    }
}
